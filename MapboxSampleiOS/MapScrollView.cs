using System;
using System.Collections.Generic;
using System.Text;
using CoreFoundation;
using CoreGraphics;
using CoreLocation;
using Foundation;
using UIKit;
using StateMaps.Models;
using System.Threading.Tasks;
using System.Threading;

namespace StateMaps
{
	public class MapScrollView : UIScrollView
	{
		volatile NSMutableArray<NSMutableArray<MapTileView>> visibleTiles; // visibleTile Matrix

		UIView MapContainerView;
		CancellationTokenSource cts;

		public string _url { get; private set; } = "http://javier.nyc/cgi-bin/mapserv.exe?map=/ms4w/apps/osm/basemaps/osm-google.map&layers=all&mode=tile&tilemode=gmap&tile=";

		public static LocationManager Manager { get; set; }
		public int zoom = 15; // init zoom level
							  //min
		nfloat minimumVisibleX = 0;
		nfloat minimumVisibleY = 0;
		//max
		nfloat maximumVisibleX = 0;
		nfloat maximumVisibleY = 0;

		public MapScrollView(CGRect frame) : base(frame)
		{
			ContentSize = new CGSize(5000, 5000);//this.Frame.Size.Height * 2);
			visibleTiles = new NSMutableArray<NSMutableArray<MapTileView>>();
			cts = new CancellationTokenSource();
			MapContainerView = new UIView();
			MapContainerView.Frame = new CGRect(0, 0, ContentSize.Width, ContentSize.Height / 2);
			this.AddSubview(MapContainerView);
			MapContainerView.UserInteractionEnabled = false;
			this.UserInteractionEnabled = true;
			// setup gps location
			Manager = new LocationManager();
			Manager.StartLocationUpdates();

			// hide horizontal scroll indicator so our recentering trick is not revealed.
			ShowsHorizontalScrollIndicator = false;
			ShowsVerticalScrollIndicator = false;

		}

		#region Layout

		// recenter content periodically to achieve impression of infinite scrolling
		/*
		Recenters all views in array.
		*/
		public void RecenterIfNecessary()
		{
			CGPoint currentOffset = this.ContentOffset;
			nfloat contentWidth = this.ContentSize.Width;
			nfloat contentHeight = this.ContentSize.Height;

			nfloat centerOffsetX = (contentWidth - this.Bounds.Size.Width) / 2;
			nfloat centerOffsetY = (contentHeight - this.Bounds.Size.Height) / 2;

			nfloat distanceFromCenterX = (nfloat)Math.Abs(currentOffset.X - centerOffsetX);
			nfloat distanceFromCenterY = (nfloat)Math.Abs(currentOffset.Y - centerOffsetY);

			if (distanceFromCenterX > (contentWidth / 4))
			{
				this.ContentOffset = new CGPoint(centerOffsetX, currentOffset.Y);

				// move content by the same amount so it appears to stay still

				foreach (NSMutableArray<MapTileView> YMap in visibleTiles)
				{
					foreach (MapTileView XMap in YMap)
					{
						CGPoint center = this.MapContainerView.ConvertPointToView(XMap.Center, this);
						center.X += (centerOffsetX - currentOffset.X);
						XMap.Center = this.ConvertPointToView(center, this.MapContainerView);
					}
				}
			}

			// recenter vertical scroll
			if (distanceFromCenterY > (contentHeight / 4))
			{
				this.ContentOffset = new CGPoint(this.ContentOffset.X, centerOffsetY);

				// move content by the same amount so it appears to stay still

				foreach (NSMutableArray<MapTileView> XMap in visibleTiles)
				{
					foreach (MapTileView YMap in XMap)
					{
						CGPoint center = this.MapContainerView.ConvertPointToView(YMap.Center, this);
						center.Y += (centerOffsetY - currentOffset.Y);
						YMap.Center = this.ConvertPointToView(center, this.MapContainerView);
					}
				}
			}
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			this.RecenterIfNecessary();

			// tile content in visible bounds.
			// visibleBounds 
			CGRect visibleBounds = this.ConvertRectToView(this.Bounds, this.MapContainerView);
			this.minimumVisibleX = visibleBounds.GetMinX();
			this.minimumVisibleY = visibleBounds.GetMinY();

			this.maximumVisibleX = visibleBounds.GetMaxX();
			this.maximumVisibleY = visibleBounds.GetMaxY();

			//Console.WriteLine("\n------------LayoutSubviews(): tileLabelsFromMinX------------\n");
			//this.tileLabelsFromMinX(minimumVisibleX, maximumVisibleX);
            Console.WriteLine("\n------------LayoutSubviews(): tileMapsFromMinXAsync------------\n");
            
            this.tileMapsFromMinX(minimumVisibleX, maximumVisibleX);
            
            //Console.WriteLine("\n------------LayoutSubviews(): tileLabelsFromMinY------------\n");
			//this.tileLabelsFromMinY(this.minimumVisibleY, this.maximumVisibleY);

		}
		#endregion

		#region MapTiling
		// inserts item into suview and returns item.
		MapTileView InsertMap(MapTile maptile = null, int newXTile = 0)
		{
			MapTileView map;
			if (this.visibleTiles.Count == 0)
			{
				map = new MapTileView("tempurl", new CGRect(0, 0, 256, 256), Manager.LocMgr.Location, 15);
			}
			else
			{
				map = new MapTileView("tempurl", new CGRect(0, 0, 256, 256), maptile, 15);
			}

			this.AddSubview(map);
			return map;
		}

		async Task<MapTileView> InsertMapAsync(CancellationToken ct, MapTile maptile = null, int newXTile = 0)
		{
			MapTileView map = null;
			// TODO: perform cancellation token logic
			await Task.Run(() =>
			{
				map = InsertMap(maptile, newXTile);
			});

			return map;
			
		}

		// Adds new item into subview, adds to the end of the array and put's it in view
		// by adjusting the frame size of item in array.
		private nfloat PlaceNewMapOnRight(nfloat rightEdge)
		{
			NSMutableArray<MapTileView> map;
			NSMutableArray<MapTileView> lastTiles;
			if (this.visibleTiles.Count == 0)
			{
				map = new NSMutableArray<MapTileView>();
				map.Add(this.InsertMap());

			}
			else
			{
				// we pass the XTile value and increment during insertion of new map.
				lastTiles = this.visibleTiles[this.visibleTiles.Count - 1];
				map = new NSMutableArray<MapTileView>();
				// We need to make sure we keep the same map order in array.
				for (nuint i = 0; i <= (lastTiles.Count - 1); i++)
				{
					Console.WriteLine("PlaceNewMapOnRight:lastTiles[" + i + "] = " + lastTiles[i].mapTile.XTile);
					//lastTiles[i].mapTile.NextXTile(1); // move right.
					map.Add(this.InsertMap(new MapTile(lastTiles[i].mapTile).NextXTile(1)));
				}

			}

			this.visibleTiles.AddObjects(map);

			CGRect frame = new CGRect();
			foreach (MapTileView m in map)
			{
				frame = m.Frame;
				frame.X = rightEdge;
				frame.Y = this.MapContainerView.Bounds.Size.Height - frame.Size.Height;
				m.Frame = frame;

#if DEBUG
				UILabel label = new UILabel();
				label.Frame = frame;
				label.Text = "Right:X:" + m.mapTile.XTile + " Y:" + m.mapTile.YTile;
				this.AddSubview(label);
#endif
			}
			return frame.GetMaxX();
		}
		 async Task<nfloat> PlaceNewMapOnRightAsync(nfloat rightEdge, CancellationToken ct)
		{
			NSMutableArray<MapTileView> map;
			NSMutableArray<MapTileView> lastTiles;
			if (this.visibleTiles.Count == 0)
			{
				map = new NSMutableArray<MapTileView>();

				map.Add(await InsertMapAsync(ct));
			}
			else
			{
				// we pass the XTile value and increment during insertion of new map.
				lastTiles = this.visibleTiles[this.visibleTiles.Count - 1];
				map = new NSMutableArray<MapTileView>();
				// We need to make sure we keep the same map order in array.
				for (nuint i = 0; i <= (lastTiles.Count - 1); i++)
				{
					Console.WriteLine("PlaceNewMapOnRightAsync:lastTiles[" + i + "] = " + lastTiles[i].mapTile.XTile);
					//lastTiles[i].mapTile.NextXTile(1); // move right.
					map.Add(await this.InsertMapAsync(ct, new MapTile(lastTiles[i].mapTile).NextXTile(1)));
				}

			}

            this.BeginInvokeOnMainThread(() => {
                this.visibleTiles.AddObjects(map);
            });
			

			CGRect frame = new CGRect();
			foreach (MapTileView m in map)
			{
				frame = m.Frame;
				frame.X = rightEdge;
				frame.Y = this.MapContainerView.Bounds.Size.Height - frame.Size.Height;
				m.Frame = frame;

#if DEBUG
				UILabel label = new UILabel();
				label.Frame = frame;
				label.Text = "Right:X:" + m.mapTile.XTile + " Y:" + m.mapTile.YTile;
				this.AddSubview(label);
#endif
			}
			return frame.GetMaxX();
		}

		private nfloat PlaceNewMapOnBottom(nfloat bottomEdge)
		{
			NSMutableArray<MapTileView> map;

			CGRect frame = new CGRect();
			foreach (NSMutableArray<MapTileView> bottomTiles in this.visibleTiles)
			{
				MapTile _maptile = new MapTile(bottomTiles[bottomTiles.Count - 1].mapTile);

				frame = bottomTiles[bottomTiles.Count - 1].Frame;

				Console.WriteLine(
					"PlaceNewMapOnBottom:bottomTles[" +
					(bottomTiles.Count - 1) +
					"] = " + bottomTiles[bottomTiles.Count - 1].mapTile.YTile);

				bottomTiles.AddObjects(this.InsertMap(_maptile.NextYTile(1))); // move down.

				frame.Y = bottomEdge;
				bottomTiles[bottomTiles.Count - 1].Frame = frame;

#if DEBUG
				UILabel label = new UILabel();

				frame.Y += 10;
				label.Frame = frame;

				label.Text = "Bottom:X:" + _maptile.XTile + " Y:" + _maptile.YTile;
				this.AddSubview(label);
				frame.Y -= 10;
#endif
			}
			return frame.GetMaxY();
		}

		async Task<nfloat> PlaceNewMapOnBottomAsync(nfloat bottomEdge, CancellationToken ct)
		{
			NSMutableArray<MapTileView> map;

			CGRect frame = new CGRect();
			foreach (NSMutableArray<MapTileView> bottomTiles in this.visibleTiles)
			{
				MapTile _maptile = new MapTile(bottomTiles[bottomTiles.Count - 1].mapTile);

				frame = bottomTiles[bottomTiles.Count - 1].Frame;

				Console.WriteLine(
					"PlaceNewMapOnBottom:bottomTles[" +
					(bottomTiles.Count - 1) +
					"] = " + bottomTiles[bottomTiles.Count - 1].mapTile.YTile);

				bottomTiles.AddObjects(await this.InsertMapAsync(ct,_maptile.NextYTile(1))); // move down.

				frame.Y = bottomEdge;
				bottomTiles[bottomTiles.Count - 1].Frame = frame;

#if DEBUG
				UILabel label = new UILabel();

				frame.Y += 10;
				label.Frame = frame;

				label.Text = "Bottom:X:" + _maptile.XTile + " Y:" + _maptile.YTile;
				this.AddSubview(label);
				frame.Y -= 10;
#endif
			}
			return frame.GetMaxY();
		}
		// Adds new item into subview, adds to the beginning of the array and put's it in view
		// by adjusting the frame size of item in array.
		private nfloat PlaceNewMapOnLeft(nfloat leftEdge)
		{

			NSMutableArray<MapTileView> firstTiles = this.visibleTiles[0];
			// Insert object requires an array so map array looks weird.
			NSMutableArray<MapTileView>[] map = new NSMutableArray<MapTileView>[1];

			// We have to copy the left most column and update the xtile
			for (nuint i = 0; i <= (firstTiles.Count - 1); i++)
			{
				if (map[0] == null)
				{
					// move left
					map[0] = new NSMutableArray<MapTileView>(firstTiles.Count){

						this.InsertMap(new MapTile(firstTiles[i].mapTile).NextXTile(-1))
					};
				}
				else
				{
					Console.WriteLine("PlaceNewMapOnLeft:firstTiles[" + i + "] = " + firstTiles[i].mapTile.XTile);
					// move left
					map[0].Add(this.InsertMap(new MapTile(firstTiles[i].mapTile).NextXTile(-1)));

				}
			}

			this.visibleTiles.InsertObjects(map, new NSIndexSet(0)); // TODO: figure out this weird array parameter.

			CGRect frame = new CGRect();
			foreach (MapTileView m in map[0])
			{
				frame = m.Frame;
				frame.X = leftEdge - frame.Size.Width;
				frame.Y = this.MapContainerView.Bounds.Size.Height - frame.Size.Height;

				m.Frame = frame;

#if DEBUG
				UILabel label = new UILabel();
				frame.Y += 20;
				label.Frame = frame;
				label.Text = "Left:X:" + m.mapTile.XTile + " Y:" + m.mapTile.YTile;
				this.AddSubview(label);
				frame.Y -= 20;
#endif
			}
			return frame.GetMinX();
		}

        async Task<nfloat> PlaceNewMapOnLeftAsync(nfloat leftEdge, CancellationToken ct)
        {
            NSMutableArray<MapTileView> firstTiles = this.visibleTiles[0];
            // Insert object requires an array so map array looks weird.
            NSMutableArray<MapTileView>[] map = new NSMutableArray<MapTileView>[1];

            // We have to copy the left most column and update the xtile
            for (nuint i = 0; i <= (firstTiles.Count - 1); i++)
            {
                if (map[0] == null)
                {
                    // move left
                    map[0] = new NSMutableArray<MapTileView>(firstTiles.Count){

                        await this.InsertMapAsync(ct, new MapTile(firstTiles[i].mapTile).NextXTile(-1))
                    };
                }
                else
                {
                    Console.WriteLine("PlaceNewMapOnLeft:firstTiles[" + i + "] = " + firstTiles[i].mapTile.XTile);
                    // move left
                    map[0].Add(await this.InsertMapAsync(ct, new MapTile(firstTiles[i].mapTile).NextXTile(-1)));

                }
            }

            this.visibleTiles.InsertObjects(map, new NSIndexSet(0)); // TODO: figure out this weird array parameter.

            CGRect frame = new CGRect();
            foreach (MapTileView m in map[0])
            {
                frame = m.Frame;
                frame.X = leftEdge - frame.Size.Width;
                frame.Y = this.MapContainerView.Bounds.Size.Height - frame.Size.Height;

                m.Frame = frame;

#if DEBUG
                UILabel label = new UILabel();
                frame.Y += 20;
                label.Frame = frame;
                label.Text = "Left:X:" + m.mapTile.XTile + " Y:" + m.mapTile.YTile;
                this.AddSubview(label);
                frame.Y -= 20;
#endif
            }
            return frame.GetMinX();
        }

        private nfloat PlaceNewMapOntop(nfloat topEdge)
		{
			nuint TOP = 0;
			// Insert object requires an array so map array looks weird.
			NSMutableArray<MapTileView>[] map = new NSMutableArray<MapTileView>[1];
			// we have to get the first tile in every vertical array.
			map[0] = new NSMutableArray<MapTileView>();
			CGRect frame = new CGRect();
			foreach (NSMutableArray<MapTileView> topTiles in this.visibleTiles)
			{
				Console.WriteLine("PlaceNewMapOntop:topTiles[0] = " + topTiles[TOP].mapTile.YTile);
				MapTile _maptile = new MapTile(topTiles[TOP].mapTile);

				frame = topTiles[TOP].Frame;
				frame.Y = topEdge - frame.Size.Height;

				topTiles.InsertObjects(new MapTileView[1] {
					this.InsertMap(_maptile.NextYTile(-1))
				}, new NSIndexSet(0));



				topTiles[TOP].Frame = frame;
#if DEBUG
				UILabel label = new UILabel();
				frame.Y += 30;
				label.Frame = frame;
				label.Text = "Top:X:" + _maptile.XTile + " Y:" + _maptile.YTile;
				this.AddSubview(label);
				frame.Y -= 30;
#endif
			}

			//this.visibleTiles.InsertObjects(map, new NSIndexSet(0));
			return frame.GetMinY();
		}

        async Task<nfloat> PlaceNewMapOntopAsync(nfloat topEdge, CancellationToken ct)
        {
            nuint TOP = 0;
            // Insert object requires an array so map array looks weird.
            NSMutableArray<MapTileView>[] map = new NSMutableArray<MapTileView>[1];
            // we have to get the first tile in every vertical array.
            map[0] = new NSMutableArray<MapTileView>();
            CGRect frame = new CGRect();
            foreach (NSMutableArray<MapTileView> topTiles in this.visibleTiles)
            {
                Console.WriteLine("PlaceNewMapOntop:topTiles[0] = " + topTiles[TOP].mapTile.YTile);
                MapTile _maptile = new MapTile(topTiles[TOP].mapTile);

                frame = topTiles[TOP].Frame;
                frame.Y = topEdge - frame.Size.Height;

                topTiles.InsertObjects(new MapTileView[1] {
                    await this.InsertMapAsync(ct, _maptile.NextYTile(-1))
                }, new NSIndexSet(0));



                topTiles[TOP].Frame = frame;
#if DEBUG
                UILabel label = new UILabel();
                frame.Y += 30;
                label.Frame = frame;
                label.Text = "Top:X:" + _maptile.XTile + " Y:" + _maptile.YTile;
                this.AddSubview(label);
                frame.Y -= 30;
#endif
            }

            //this.visibleTiles.InsertObjects(map, new NSIndexSet(0));
            return frame.GetMinY();
        }

        private void tileLabelsFromMinX(nfloat minimumVisibleX, nfloat maximumVisibleX)
		{
			// the upcoming tiling logic depends on there already being at least one tile in the visibleTiles array, so
			// to kick off the tiliong we need to make sure there's at least one tile.
			if (this.visibleTiles.Count == 0)
			{
				this.PlaceNewMapOnRight(minimumVisibleX);
			}

			// add tiles that are missing on right side.
			NSMutableArray<MapTileView> lastMap = this.visibleTiles[this.visibleTiles.Count - 1]; // last object

			// All frame will always be th.e same size.
			nfloat rightEdge = lastMap[0].Frame.GetMaxX();
			while (rightEdge < maximumVisibleX)
			{
				rightEdge = this.PlaceNewMapOnRight(rightEdge);
			}

			// add tiles that are missing on left side
			NSMutableArray<MapTileView> firstMap = this.visibleTiles[0];
			nfloat leftEdge = firstMap[0].Frame.GetMinX();
			while (leftEdge > minimumVisibleX)
			{
				leftEdge = this.PlaceNewMapOnLeft(leftEdge);
			}

			// remove tiles that have fallen off right edge.
			lastMap = this.visibleTiles[this.visibleTiles.Count - 1];
			while (lastMap[0].Frame.X > maximumVisibleX)
			{
				foreach (MapTileView m in lastMap)
				{
					m.RemoveFromSuperview();
#if DEBUG
					Console.WriteLine("Removing from right edge\nX:"
									  + m.mapTile.XTile + "\nY:" + m.mapTile.YTile);
#endif
				}
				this.visibleTiles.RemoveLastObject();
				lastMap = this.visibleTiles[this.visibleTiles.Count - 1];
			}

			// remove tiles that have fallen off left edge
			firstMap = this.visibleTiles[0];
			while (firstMap[0].Frame.GetMaxX() < minimumVisibleX)
			{
				foreach (MapTileView m in firstMap)
				{
					m.RemoveFromSuperview();
					Console.WriteLine("Removing from left edge\nX:"
									  + m.mapTile.XTile + "\nY:" + m.mapTile.YTile);
				}
				this.visibleTiles.RemoveObjectsAtIndexes(new NSIndexSet(0));
				firstMap = this.visibleTiles[0];
			}
		}

        void tileMapsFromMinX(nfloat minimumVisibleX,
		                                 nfloat maximumVisibleX)
        {
            // the upcoming tiling logic depends on there already being at least one tile in the visibleTiles array, so
            // to kick off the tiliong we need to make sure there's at least one tile.
            if (this.visibleTiles.Count == 0)
            {
                this.PlaceNewMapOnRight(minimumVisibleX);
            }

            // add tiles that are missing on right side.
            NSMutableArray<MapTileView> lastMap = this.visibleTiles[this.visibleTiles.Count - 1]; // last object

            // All frame will always be th.e same size.
            nfloat rightEdge = lastMap[0].Frame.GetMaxX();
            while (rightEdge < maximumVisibleX)
            {
                rightEdge = Task.Run<nfloat>(() => {
                    return this.PlaceNewMapOnRightAsync(rightEdge, cts.Token);
                }).Result;
                
            }

            // add tiles that are missing on left side
            NSMutableArray<MapTileView> firstMap = this.visibleTiles[0];
            nfloat leftEdge = firstMap[0].Frame.GetMinX();
            while (leftEdge > minimumVisibleX)
            {
                leftEdge = Task.Run<nfloat>(() => {
                    return this.PlaceNewMapOnLeftAsync(leftEdge, cts.Token);
                }).Result;
                
            }

            // remove tiles that have fallen off right edge.
            lastMap = this.visibleTiles[this.visibleTiles.Count - 1];
            while (lastMap[0].Frame.X > maximumVisibleX)
            {
                foreach (MapTileView m in lastMap)
                {
                    m.RemoveFromSuperview();
#if DEBUG
                    Console.WriteLine("Removing from right edge\nX:"
                                      + m.mapTile.XTile + "\nY:" + m.mapTile.YTile);
#endif
                }
                this.visibleTiles.RemoveLastObject();
                lastMap = this.visibleTiles[this.visibleTiles.Count - 1];
            }

            // remove tiles that have fallen off left edge
            firstMap = this.visibleTiles[0];
            while (firstMap[0].Frame.GetMaxX() < minimumVisibleX)
            {
                foreach (MapTileView m in firstMap)
                {
                    m.RemoveFromSuperview();
                    Console.WriteLine("Removing from left edge\nX:"
                                      + m.mapTile.XTile + "\nY:" + m.mapTile.YTile);
                }
                this.visibleTiles.RemoveObjectsAtIndexes(new NSIndexSet(0));
                firstMap = this.visibleTiles[0];
            }
        }
		private void tileLabelsFromMinY(nfloat minimumVisibleY, nfloat maximumVisibleY)
		{
			if (this.visibleTiles.Count == 0)
			{
				this.PlaceNewMapOnRight(minimumVisibleX);
			}
			// add tiles that are missing on the bottom.
			NSMutableArray<MapTileView> lastMap = this.visibleTiles[this.visibleTiles.Count - 1]; // last object
			nfloat bottomEdge = lastMap[lastMap.Count - 1].Frame.GetMaxY();

			while (bottomEdge < maximumVisibleY)
			{
				bottomEdge = this.PlaceNewMapOnBottom(bottomEdge);
			}

			// add tiles that are missing on top.
			NSMutableArray<MapTileView> firstMap = this.visibleTiles[0];
			nfloat topEdge = firstMap[0].Frame.GetMinY();

			while (topEdge > minimumVisibleY)
			{
				topEdge = this.PlaceNewMapOntop(topEdge);
			}

			// remove tiles that fallen off bottom edge.

			while (lastMap[lastMap.Count - 1].Frame.Y > maximumVisibleY)
			{
#if DEBUG
				Console.WriteLine("lastMap[lastMap.Count - 1].Frame.Y" +
								 lastMap[lastMap.Count - 1].Frame.Y +
								  "maximumVisibleY" + maximumVisibleY);
#endif
				foreach (NSMutableArray<MapTileView> tiles in this.visibleTiles)
				{
					tiles[tiles.Count - 1].RemoveFromSuperview();
#if DEBUG
					Console.WriteLine("Removing from bottom edge\nX:"
									  + tiles[tiles.Count - 1].mapTile.XTile + "\nY:"
									  + tiles[tiles.Count - 1].mapTile.YTile);
#endif
					tiles.RemoveLastObject();
				}
				lastMap = this.visibleTiles[this.visibleTiles.Count - 1];
			}

			// remove tiles that have fallen off top edge
			firstMap = this.visibleTiles[0];
			while (firstMap[0].Frame.GetMaxY() < minimumVisibleY)
			{
#if DEBUG
				Console.WriteLine("firstMap[0].Frame.GetMaxY() = " + firstMap[0].Frame.GetMaxY()
								  + "<" + "minimumVisibleY = " +  minimumVisibleY);
#endif

				foreach (NSMutableArray<MapTileView> tiles in this.visibleTiles)
				{
					tiles[0].RemoveFromSuperview();
#if DEBUG
					Console.WriteLine("Removing from top edge\nX:"
									  + tiles[tiles.Count - 1].mapTile.XTile + "\nY:"
									  + tiles[tiles.Count - 1].mapTile.YTile);
#endif
					tiles.RemoveObjectsAtIndexes(new NSIndexSet(0));
				}
				firstMap = this.visibleTiles[0];
			}
			
		}



		#endregion
	}
}
