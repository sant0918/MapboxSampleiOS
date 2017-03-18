using System;
using System.Collections.Generic;
using System.Text;
using SVGKit;
using CoreGraphics;
using CoreLocation;

namespace StateMaps.Models
{
    public class MapTile
    {
        public int tileNum { get; private set; }
        public int XTile { get; private set; }
        public int YTile { get; private set; }
        public int ZTile { get; private set; }
        public CGSize tileSize;
        public SVGKImage _svgImage;

        public MapTile(CLLocation loc, int zoom)
        {
            // Convert location to gmap tiles.
            GlobalMapTiles gmt = new GlobalMapTiles();
            Tuple<double, double> metersXY = gmt.LatLonToMeters(loc.Coordinate.Latitude, loc.Coordinate.Longitude);
            Tuple<int, int> tilesMinXY = gmt.MetersToTile(metersXY.Item1, metersXY.Item2, zoom);
			Tuple<int, int> gtilesXY = gmt.GoogleTile(tilesMinXY.Item1, tilesMinXY.Item2, zoom);
            
			this.XTile = gtilesXY.Item1;
            this.YTile = gtilesXY.Item2;
			this.ZTile = zoom;
            tileSize = new CGSize(256, 256);
            
            
        }

      
         public MapTile NextTile(int direction)
        {
            XTile += direction;

            return this;
        }
        public MapTile Deserialize(string mapTile)
        {
            throw new NotImplementedException();
        }

        public string Serialize(MapTile mapTile)
        {
            throw new NotImplementedException();
        }

    }
}
