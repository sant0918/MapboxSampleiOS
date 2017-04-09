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

		public MapTileView(string url, CGRect frame, CLLocation location, int zoom) : base(frame)
		{
			this.mapTile = getTile(new MapTile(location, zoom));
			this.Zoom = zoom;

		}
		public MapTileView(string url, CGRect frame, int zoom) : base(frame)
		{
			this.Zoom = zoom;

		}
		public MapTileView(string url, CGRect frame, MapTile maptile, int zoom) : base(frame)
		{
			this.Zoom = zoom;
			this.mapTile = getTile(maptile);
		}


		public override void Draw(CGRect area)
		{
			base.Draw(area);
			// TODO: Render tiles.
#if DEBUG
			Console.WriteLine("Rendering image: X: " + this.mapTile.XTile + " Y: " + this.mapTile.YTile);
#endif
			RenderSVgImages();
            // TODO: Update display as user moves/pans. Use eventArgs/delegate in user gesture.
        }

        private static MapTile getTile(MapTile maptile)
        {
            string path = "tiles/NYC/";
            string pngFilename = Path.Combine(path, maptile.ZTile.ToString() + "/" + maptile.XTile + "/" + maptile.YTile + "/tile.svg");
			File.OpenRead(pngFilename);
			Console.WriteLine("X:" + maptile.XTile + "\nY:" + maptile.YTile + "\nPath:" + pngFilename);
			try
			{
				maptile._svgImage = SVGKImage.ImageNamed(pngFilename);
			}
			catch(System.Exception e)
			{
				return null;
			}
            return new MapTile(maptile);
        }

		public async Task<MapTile> getTileAsync(MapTile maptile)
		{
			
			string path = "tiles/NYC/";
			string pngFilename = Path.Combine(path, maptile.ZTile.ToString() + "/" + maptile.XTile + "/" + maptile.YTile + "/tile.svg");
			File.OpenRead(pngFilename);
			Console.WriteLine("async: X:" + maptile.XTile + "\nY:" + maptile.YTile + "\nPath:" + pngFilename);
			try
			{
				maptile._svgImage = await Task.Factory.StartNew(() => { return SVGKImage.ImageNamed(pngFilename);});
			}
			catch (System.Exception e)
			{
				return null;
			}
			return new MapTile(maptile);
		}

		private static void loadingDelegateCall(SVGKImage image, SVGKParseResult parse)
		{
			// do stuffs
		}
				                                                                    
		
		private void RenderSVgImages()
        {
			using (var context = UIGraphics.GetCurrentContext())
			{
			//BeginInvokeOnMainThread(() =>
			//{
				

					context.SaveState();
					//context.TranslateCTM(this.mapTile.tileSize.Width * map.Value.tileOffset.Item1, map.Value.tileSize.Height * map.Value.tileOffset.Item2);
					this.mapTile._svgImage.CALayerTree.RenderInContext(context);
					context.RestoreState();

				

			//});

				}

        }

    }
}
