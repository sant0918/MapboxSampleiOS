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
using SVGKit;
using StateMaps.Models;

namespace StateMaps
{
    public class MapView : UIScrollView
    {
        private CGRect _area;
        private MapLinkedList _map;
        private HttpClient _client;
        private string _url;
        private MapTile mapTile; // used to get starting map tile location.
        public string AccessToken { get; set; }
        public int Zoom;
        public CGSize contentSize;

        public MapView(string url, CGRect frame, CLLocation location, int zoom) : base (frame)
        {
            this._area = frame;
			this.mapTile = new MapTile(location, zoom);
            this._map = new MapLinkedList(this.mapTile);
            this._client = new HttpClient();
            this._url = url;
            this.Zoom = zoom;
            PopulateTiles();


        }

        public MapView(string url, MapTile maptile, CGRect frame, int zoom) : base (frame)
        {
            this._area = frame;
            this._map = new MapLinkedList(maptile);
            this._client = new HttpClient();
            this._url = url;
            this.mapTile = maptile;
            this.Zoom = zoom;
            PopulateTiles();
        }

        public MapView(MapScrollView mapScrollView, CLLocation location, int zoom) : base(mapScrollView.Frame)
        {
            this._area = mapScrollView.Frame;
            this.contentSize = mapScrollView.ContentSize;
            this.Zoom = zoom;

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

        public void PopulateTiles()
        {
            // Get dimensions for view.
            CGRect view = this.Frame;
            
            // Get tile number for center of screen.
                GetTile(mapTile);                
        }
        

        // We fetch tile data here.
        private void GetTile(MapTile maptile)
        {
			// TODO: IMPLEMENT AZURE AD ACCESS TOKEN.
			//            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, String.Concat(_url,mapTile.XTile,"+",mapTile.YTile,"+",mapTile.ZTile));
			//          request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

			// Get serialized tiles
			// TODO: Implement web api and return row of maptiles.
			//object tile = await _client.SendAsync(request);

			#region Temporary tile fetch implementation

			#endregion

			// Tile gets added to linked list.
			int Yoffset = (int)(this._area.Top / maptile.tileSize.Height);
            this._map.AddTile(TEMPgetTile(maptile,  0, Yoffset));
            // going left
			this._map.AddTile(TEMPgetTile(maptile, -1, Yoffset ));
            this._map.AddTile(TEMPgetTile(maptile, -2, Yoffset ));
            //this._map.AddTile(TEMPgetTile(maptile, -3, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height) ));
            //this._map.AddTile(TEMPgetTile(maptile, -4, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height) ));

            // going right
            
            this._map.AddTile(TEMPgetTile(maptile, 1, Yoffset));
            //this._map.AddTile(TEMPgetTile(maptile, 2, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height)));
            //this._map.AddTile(TEMPgetTile(maptile, 3, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height)));
            //this._map.AddTile(TEMPgetTile(maptile, 4, maptile.YTile + (int)(this._area.Top / maptile.tileSize.Height)));
            // get more tiles recursively.
            //await this.GetTile(maptile.NextTile(-1)); // go left
            //Sawait this.GetTile(maptile.NextTile(1)); // go right

        }

        private static LinkedListNode<MapTile> TEMPgetTile(MapTile maptile, int Xoffset, int Yoffset)
        {
            string path = "tiles/";

            string pngFilename = Path.Combine(path, maptile.ZTile.ToString() + "/" + (maptile.XTile + Xoffset) + "/" + (maptile.YTile + Yoffset) + "/tile.svg");

			maptile._svgImage = SVGKImage.ImageNamed(pngFilename);
            return new LinkedListNode<MapTile>(new Models.MapTile(maptile));
        }

       
        
        private void RenderSVgImages()
        {
            var context = UIGraphics.GetCurrentContext();

            
            //this.Layer.AddSublayer(svgImage.CALayerTree); 
            //this.svgImage.CALayerTree.RenderInContext(context);

            
            foreach(var map in _map)
            {
                context.SaveState();
                context.TranslateCTM(map.Value.tileSize.Width * map.Value.tileOffset.Item1, map.Value.tileSize.Height * map.Value.tileOffset.Item2);
                map.Value._svgImage.CALayerTree.RenderInContext(context);
                context.RestoreState();
            }          

        }
    }
}