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
    public class SVGKTileView : SVGKFastImageView
    {
        GlobalMapTiles gmt;
        SVGKTileView(SVGKImage svgImage) : base (svgImage)
        {

        }

        public override void Draw(CGRect area)
        {
            base.Draw(area);
            const int ZOOM = 4;

            var context = UIGraphics.GetCurrentContext();

            CGSize tileSize = new CGSize(256, 256);

            int firstCol = (int)Math.Floor(area.GetMinX() / tileSize.Width);
            int lastCol = (int)Math.Floor((area.GetMaxX() - 1) / tileSize.Width);
            int firstRow = (int)Math.Floor(area.GetMinY() / tileSize.Height);
            int lastRow = (int)Math.Floor((area.GetMaxY() - 1) / tileSize.Height);

            for (int row = firstRow; row <= lastRow; row++)
            {
                for (int col = firstCol; col <= lastCol; col++)
                {
                    SVGKImage tile = getTile(ZOOM, col, row);

                    CGRect tileRect = new CGRect(tileSize.Width * col,
                                                tileSize.Height * row,
                                                tileSize.Width,
                                                tileSize.Height);
                    tileRect.Intersect(tileRect);

                    tile.DrawAsPatternInRect(tileRect);

                }

            }
        }

		public SVGKImage getTile(int zoom, int col, int row)
		{
			string path = "tiles/";

			string pngFilename = Path.Combine(path, zoom.ToString() + "/" + col.ToString() + "/" + row.ToString() + ".png");

			return SVGKImage.FromFile(pngFilename);
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

            return SVGKImage.FromFile(pngFilename);
        }

    }
}