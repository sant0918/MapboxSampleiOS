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
    public class MapTileView : SVGKFastImageView
    {
        public MapTile mapTile;
        private int Zoom = 1;

        public MapTileView(string url, CGRect frame, CLLocation location, int zoom) : base (frame)
        {
            this.mapTile = new MapTile(location, zoom);
            this.Zoom = zoom;
        }

        public MapTileView(string url, CGRect frame, MapTile maptile, int zoom) : base (frame)
        {
            
            maptile.NextTile(1);
            this.mapTile = maptile;
            this.Zoom = zoom;
            this.mapTile = getTile(this.mapTile);
        }

        public override void Draw(CGRect area)
        {
            base.Draw(area);
            // TODO: Render tiles.
            RenderSVgImages();
            // TODO: Update display as user moves/pans. Use eventArgs/delegate in user gesture.
        }

        private static MapTile getTile(MapTile maptile)
        {
            string path = "tiles/NYC/";

            string pngFilename = Path.Combine(path, maptile.ZTile.ToString() + "/" + maptile.XTile + "/" + maptile.YTile + "/tile.svg");
            maptile._svgImage = SVGKImage.ImageNamed(pngFilename);
            return new MapTile(maptile);
        }

        private void RenderSVgImages()
        {
            using (var context = UIGraphics.GetCurrentContext())
            {
                context.SaveState();
                //context.TranslateCTM(this.mapTile.tileSize.Width * map.Value.tileOffset.Item1, map.Value.tileSize.Height * map.Value.tileOffset.Item2);
                this.mapTile._svgImage.CALayerTree.RenderInContext(context);
                context.RestoreState();
            }

        }

    }
}
