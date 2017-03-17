﻿using System;
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

        public MapTile(CLLocation loc)
        {
            // Convert location to gmap tiles.
            GlobalMapTiles gmt = new GlobalMapTiles();
            Tuple<double, double> metersXY = gmt.LatLonToMeters(loc.Coordinate.Latitude, loc.Coordinate.Longitude);
            Tuple<int, int> tilesMinXY = gmt.MetersToTile(metersXY.Item1, metersXY.Item2, ZTile);
            this.XTile = tilesMinXY.Item1;
            this.YTile = tilesMinXY.Item2;
            
            
            
        }

        public MapTile(int x, int y, int z, SVGKImage svgImage)
        {
            XTile = x;
            YTile = y;
            ZTile = z;
            _svgImage = svgImage;
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
