using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using SVGKit;
using CoreGraphics;
using CoreLocation;
using System.IO;
using UIKit;
using CoreAnimation;

namespace MapBoxSampleiOS
{
    public class SVGKFastTileView : SVGKFastImageView
    {
		CLLocation loc;
        GlobalMapTiles gmt;
        SVGKImage svgImage;
        public SVGKFastTileView(SVGKImage svgImage) : base (svgImage)
        {
            this.svgImage = svgImage;
        }

        public SVGKFastTileView(CGRect frame) : base (frame)
        {

        }

        public override void DrawRect(CGRect area, UIViewPrintFormatter formatter)
        {
            base.DrawRect(area, formatter);

            CGRect imageBounds = new CGRect(0, 0, this.svgImage.Size.Width, this.svgImage.Size.Height);
            const int ZOOM = 16;

            var context = UIGraphics.GetCurrentContext();
            context.SaveState();
            
            CGSize tileSize = new CGSize(256, 256);

            context.TranslateCTM(tileSize.Width, tileSize.Height);
            context.ScaleCTM(svgImage.Size.Width, svgImage.Size.Height);
            
            

            int firstCol = (int)Math.Floor(area.GetMinX() / tileSize.Width);
            int lastCol = (int)Math.Floor((area.GetMaxX() - 1) / tileSize.Width);
            int firstRow = (int)Math.Floor(area.GetMinY() / tileSize.Height);
            int lastRow = (int)Math.Floor((area.GetMaxY() - 1) / tileSize.Height);

            this.Layer.AddSublayer(SVGKImage.ImageNamed(Path.Combine("tiles/", ZOOM.ToString() + "/" + "BL-NY.svg")).CALayerTree); 
            


        }

        public SVGKImage getTile(int zoom, int col, int row)
		{
			string path = "tiles/";

			string pngFilename = Path.Combine(path, zoom.ToString() + "/" + col.ToString() + "/" + row.ToString() + ".svg");

			return SVGKImage.ImageNamed(pngFilename);
		}

        public SVGKImage getTile(int zoom)
        {
            Tuple<double, double> metersXY = gmt.LatLonToMeters(loc.Coordinate.Latitude, loc.Coordinate.Longitude);
            Tuple<int, int> tilesMinXY = gmt.MetersToTile(metersXY.Item1, metersXY.Item2, zoom);
            Tuple<int, int> tilesMaxXY = tilesMinXY;

            for (int ty = tilesMinXY.Item2; ty <= tilesMaxXY.Item2; ty++)
            {
                for (int tx = tilesMinXY.Item1; tx <= tilesMaxXY.Item1; tx++)
                {
                    Tuple<int, int> googleTiles = gmt.GoogleTile(tx, ty, zoom);

                    // TODO: fetch tiles from mapserver.
                }
            }

            string path = "tiles/";

            string pngFilename = Path.Combine(path, zoom.ToString());

            return SVGKImage.ImageNamed(pngFilename);
        }

    }
}