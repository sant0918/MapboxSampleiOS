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

namespace MapBoxSampleiOS
{
    public class SVGKFastTileView : SVGKFastImageView
    {
		CLLocation loc;
        GlobalMapTiles gmt;
        public SVGKFastTileView(SVGKImage svgImage) : base (svgImage)
        {

        }

        public SVGKFastTileView(CGRect frame) : base (frame)
        {

        }

        public override void Draw(CGRect area)
        {
            base.Draw(area);
            const int ZOOM = 16;

            var context = UIGraphics.GetCurrentContext();

            CGSize tileSize = new CGSize(256, 256);

            int firstCol = (int)Math.Floor(area.GetMinX() / tileSize.Width);
            int lastCol = (int)Math.Floor((area.GetMaxX() - 1) / tileSize.Width);
            int firstRow = (int)Math.Floor(area.GetMinY() / tileSize.Height);
            int lastRow = (int)Math.Floor((area.GetMaxY() - 1) / tileSize.Height);

            SVGKImage tileBL = SVGKImage.ImageNamed(Path.Combine("tiles/", ZOOM.ToString() + "/" + "BL-NY.svg"));
            SVGKImage tileBR = SVGKImage.ImageNamed(Path.Combine("tiles/", ZOOM.ToString() + "/" + "BR-NY.svg"));
            SVGKImage tileTL = SVGKImage.ImageNamed(Path.Combine("tiles/", ZOOM.ToString() + "/" + "TL-NY.svg"));
            SVGKImage tileTR = SVGKImage.ImageNamed(Path.Combine("tiles/", ZOOM.ToString() + "/" + "TR-NY.svg"));

            CGRect tileRectBL = new CGRect(tileSize.Width * 0,tileSize.Height * 0,tileSize.Width,tileSize.Height);
            CGRect tileRectBR = new CGRect(tileSize.Width * 0, tileSize.Height * 1, tileSize.Width, tileSize.Height);
            CGRect tileRectTL = new CGRect(tileSize.Width * 1, tileSize.Height * 0, tileSize.Width, tileSize.Height);
            CGRect tileRectTR = new CGRect(tileSize.Width * 1, tileSize.Height * 1, tileSize.Width, tileSize.Height);

            tileRectBL.Intersect(tileRectBL);
            tileRectBR.Intersect(tileRectBR);
            tileRectTL.Intersect(tileRectTL);
            tileRectTR.Intersect(tileRectTR);

            tileBL.DrawAsPatternInRect(tileRectBL);
            tileBR.DrawAsPatternInRect(tileRectBL);
            tileTL.DrawAsPatternInRect(tileRectBL);
            tileTR.DrawAsPatternInRect(tileRectBL);


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