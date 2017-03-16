using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using System.Net.Http;
using System.Net.Http.Headers;
using UIKit;
using StateMaps.Models;
using CoreGraphics;
using CoreLocation;
using System.IO;

namespace StateMaps
{
    public class MapView : UIView
    {
        private CGRect _area;
        private MapLinkedList _map;
        private HttpClient _client;
        private string _url;
        private MapTile mapTile; // used to get starting map tile location.
        public string AccessToken { get; set; }

        public MapView(string url, CGRect frame, CLLocationCoordinate2D location) : base(frame)
        {
            this._area = frame;
            this._map = new MapLinkedList();
            this._client = new HttpClient();
            this._url = url;
            this.mapTile = new MapTile(location);
        }

        public MapView(string url, MapTile maptile, CGRect frame) : base(frame)
        {
            this._area = frame;
            this._map = new MapLinkedList();
            this._client = new HttpClient();
            this._url = url;
            this.mapTile = maptile;
        }
        public override void Draw(CGRect area)
        {
            base.Draw(area);
        }

        public async void PopulateTiles()
        {
            // Get dimensions for view.

            // Get tile number for center of screen.
                await GetTile(mapTile);
                
        }
        private async Task GetTile(MapTile maptile)
        {
            // TODO: IMPLEMENT AZURE AD ACCESS TOKEN.
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, String.Concat(_url,mapTile.XTile,"+",mapTile.YTile,"+",mapTile.ZTile));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            object tile = await _client.SendAsync(request);

            this._map.AddTile(tile);
            // get more tiles recursively.

            await this.GetTile(maptile.NextTile(-1)); // go left
            await this.GetTile(maptile.NextTile(1)); // go right

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Cleanup anything possible
            // mapView.EmptyMemoryCache ();
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