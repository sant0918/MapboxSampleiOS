using System;
using System.Collections.Generic;
using System.Text;
using SVGKit;
using CoreLocation;

namespace StateMaps.Models
{
    public class MapTile
    {
        
        public int XTile { get; private set; }
        public int YTile { get; private set; }
        public int ZTile { get; private set; }
        public SVGKImage _svgImage;

        public MapTile(CLLocation location)
        {
            throw new NotImplementedException();
        }
        public MapTile(int x, int y, int z, SVGKImage svgImage)
        {
            XTile = x;
            YTile = y;
            ZTile = z;
            _svgImage = svgImage;
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
