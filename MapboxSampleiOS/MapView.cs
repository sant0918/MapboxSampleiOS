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
        public int Zoom;

        public MapView(string url, CGRect frame, CLLocation location, int zoom) : base(frame)
        {
            this._area = frame;
            this._map = new MapLinkedList(new MapTile(location));
            this._client = new HttpClient();
            this._url = url;
            this.Zoom = zoom;
            PopulateTiles();


        }

        public MapView(string url, MapTile maptile, CGRect frame, int zoom) : base(frame)
        {
            this._area = frame;
            this._map = new MapLinkedList(maptile);
            this._client = new HttpClient();
            this._url = url;
            this.mapTile = maptile;
            this.Zoom = zoom;
            PopulateTiles();
        }

        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);

            //TODO: Implement dispose.

        }

        public override void Draw(CGRect area)
        {
            base.Draw(area);

            // TODO: Render tiles.
            RenderSVgImages();
            // TODO: Update display as user moves/pans. Use eventArgs/delegate in user gesture.
        }

        public async void PopulateTiles()
        {
            // Get dimensions for view.
            CGRect view = this.Frame;

            // Get tile number for center of screen.
                await GetTile(mapTile);                
        }
        

        // We fetch tile data here.
        private async Task GetTile(MapTile maptile)
        {
            // TODO: IMPLEMENT AZURE AD ACCESS TOKEN.
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, String.Concat(_url,mapTile.XTile,"+",mapTile.YTile,"+",mapTile.ZTile));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            // Get serialized tiles
            // TODO: Implement web api and return row of maptiles.
            //object tile = await _client.SendAsync(request);

            #region Temporary tile fetch implementation

            #endregion
            
            // Tile gets added to linked list.
            // going left
            this._map.AddTile(TEMPgetTile(maptile.ZTile, maptile.XTile, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height) ));
            this._map.AddTile(TEMPgetTile(maptile.ZTile, maptile.XTile - 1, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height) ));
            this._map.AddTile(TEMPgetTile(maptile.ZTile, maptile.XTile - 2, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height) ));
            this._map.AddTile(TEMPgetTile(maptile.ZTile, maptile.XTile - 3, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height) ));
            this._map.AddTile(TEMPgetTile(maptile.ZTile, maptile.XTile - 4, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height) ));

            // going right
            this._map.AddTile(TEMPgetTile(maptile.ZTile, maptile.XTile, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height)));
            this._map.AddTile(TEMPgetTile(maptile.ZTile, maptile.XTile + 1, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height)));
            this._map.AddTile(TEMPgetTile(maptile.ZTile, maptile.XTile + 2, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height)));
            this._map.AddTile(TEMPgetTile(maptile.ZTile, maptile.XTile + 3, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height)));
            this._map.AddTile(TEMPgetTile(maptile.ZTile, maptile.XTile + 4, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height)));
            // get more tiles recursively.
            //await this.GetTile(maptile.NextTile(-1)); // go left
            //Sawait this.GetTile(maptile.NextTile(1)); // go right

        }

        private static LinkedListNode<MapTile> TEMPgetTile(int zoom, int col, int row)
        {
            string path = "tiles/";

            string pngFilename = Path.Combine(path, zoom.ToString() + "/" + col.ToString() + "/" + row.ToString() + "/tile.svg");

            return new LinkedListNode<MapTile>(new MapTile(col,row,zoom, SVGKImage.ImageNamed(pngFilename)) );
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Cleanup anything possible
            // mapView.EmptyMemoryCache ();
        }
        
        private void RenderSVgImages()
        {
            var context = UIGraphics.GetCurrentContext();

            
            //this.Layer.AddSublayer(svgImage.CALayerTree); 
            //this.svgImage.CALayerTree.RenderInContext(context);

            
            foreach(var map in _map.nodes)
            {
                MapTile m = map.GetTile(map);

                context.SaveState();
                context.TranslateCTM(m.tileSize.Width * m.tileNum, m.tileSize.Height);
                m._svgImage.CALayerTree.RenderInContext(context);
                context.RestoreState();
            }

           

        }
    }
}