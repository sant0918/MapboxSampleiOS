using System;
using System.Collections.Generic;
using System.Text;


namespace StateMaps
{
    //http://www.maptiler.org/google-maps-coordinates-tile-bounds-projection/
    public class GlobalMapTiles
    {

        private const int tileSize = 256;
        private double initialResolution;
        private double originShift;
     
        public GlobalMapTiles()
        {   
            // 156543.03392804062 for tileSize 256 pixels
            this.initialResolution = 2 * Math.PI * 6378137 / tileSize;
            // 20037508.342789244
            this.originShift = 2 * Math.PI * 6378137 / 2.0;
        }

        //Converts given lat/lon in WGS84 Datum to XY in Spherical Mercator EPSG:900913
        public Tuple<double,double> LatLonToMeters(double lat, double lon)
        {
            double mx =  lon * this.originShift / 180.0;
            double my = Math.Log(Math.Tan((90 + lat) * Math.PI / 360.0)) / (Math.PI / 180.0);

            my = my * this.originShift / 180.0;

            return new Tuple<double, double>(mx, my);
        }

        //"Converts XY point from Spherical Mercator EPSG:900913 to lat/lon in WGS84 Datum"
        public Tuple<double,double> MetersToLatLon(double metersX, double metersY)
        {
            double lon = (metersX / this.originShift) * 180.0;
            double lat = (metersY / this.originShift) * 180.0;

            lat = 180 / Math.PI * (2 * Math.Atan(Math.Exp(lat * Math.PI / 180.0)) - Math.PI / 2.0);

            return new Tuple<double, double>(lat, lon);
        }

        //"Converts pixel coordinates in given zoom level of pyramid to EPSG:900913"
        public Tuple<double,double> PixelstoMeters(double pixelsX, double pixelsY, int zoom)
        {
            double res = this.Resolution(zoom);
            double metersX = pixelsX * res - this.originShift;
            double metersY = pixelsY * res - this.originShift;
            return new Tuple<double, double>(metersX, metersY);
        }

        // "Converts EPSG:900913 to pyramid pixel coordinates in given zoom level"
        public Tuple<double,double> MetersToPixels(double metersX, double metersY, int zoom)
        {
            double res = this.Resolution(zoom);
            double pixelsX = (metersX + this.originShift) / res;
            double pixelsY = (metersY + this.originShift) / res;
            return new Tuple<double, double>(pixelsX, pixelsY);
        }

        // "Returns a tile covering region in given pixel coordinates"
        public Tuple<int,int> PixelsToTiles(double pixelsX, double pixelsY)
        {
            int tilesX = (int)(Math.Ceiling(pixelsX / (float)(tileSize)) - 1);
            int tilesY = (int)(Math.Ceiling(pixelsY / (float)(tileSize)) - 1);
            return new Tuple<int, int>(tilesX, tilesY);
        }

        //Move the origin of pixel coordinates to top-left corner
        public Tuple<double,double> PixelsToRaster(double pixelsX, double pixelsY, int zoom)
        {
            double mapSize = tileSize << zoom;
            
            return new Tuple<double, double>(pixelsX, mapSize - pixelsY);
        }

        //"Returns tile for given mercator coordinates"
        public Tuple<int,int> MetersToTile(double metersX, double metersY, int zoom)
        {
            Tuple<double,double> pixels = MetersToPixels(metersX, metersY, zoom);
            return PixelsToTiles(pixels.Item1, pixels.Item2);
        }

        //"Returns bounds of the given tile in EPSG:900913 coordinates"
        public Tuple<Tuple<double, double>, Tuple<double, double>> TileBounds(int tilesX, int tilesY, int zoom)
        {
            Tuple<double,double> minMeters = PixelstoMeters(tilesX * tileSize, tilesY * tileSize, zoom);
            Tuple<double, double> maxMeters = PixelstoMeters((tilesX + 1) * tileSize, (tilesY + 1) * tileSize, zoom);

            return new Tuple<Tuple<double, double>, Tuple<double, double>>(minMeters, maxMeters);
        }

        //"Returns bounds of the given tile in latutude/longitude using WGS84 datum"
        public Tuple<Tuple<double, double>, Tuple<double, double>> TileLatLonBounds(int tilesX, int tilesY, int zoom)
        {
            Tuple < 
                Tuple<double, double>, 
                    Tuple < double, double>> tiles = this.TileBounds(tilesX, tilesY, zoom);

            Tuple<double,double> minLatLon = this.MetersToLatLon(tiles.Item1.Item1,tiles.Item1.Item2);

            Tuple<double, double> maxLatLon =  this.MetersToLatLon(tiles.Item2.Item1,tiles.Item2.Item2);

            return new Tuple<Tuple<double, double>, Tuple<double, double>>(minLatLon, maxLatLon);
        }
        
        //"Resolution (meters/pixel) for given zoom level (measured at Equator)"
        private double Resolution(int zoom)
        {
            return this.initialResolution / (2 * zoom);
        }

        //"Maximal scaledown zoom of the pyramid closest to the pixelSize."
        public int ZoomForPixelSize(double pixelSize)
        {
            for (int i = 0; i < 30; i++)
            {
                if (pixelSize > this.Resolution(i))
                    return i != 0 ? i - 1 : 0;
            }

            return 0;
        }

        public Tuple<int,int> GoogleTile(int tilesX, int tilesY, int zoom)
        {
            return new Tuple<int, int>(tilesX, (2 * zoom - 1) - tilesY);
        }

        
    }
}
