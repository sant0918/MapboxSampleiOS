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
        volatile Queue<MapTileView> subViewQueue;
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
            subViewQueue = new Queue<MapTileView>();
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


            // add items from subview queue
            while (subViewQueue.Count > 0)
            {
                MapTileView m = subViewQueue.Dequeue();
                AddSubview(m);
            }
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
            //Console.WriteLine("\n------------LayoutSubviews(): tileMapsFromMinXAsync------------\n");

            //this.tileMapsFromMinX(minimumVisibleX, maximumVisibleX);
            //this.SetNeedsDisplay();
            this.tileMapsFromMinY(minimumVisibleY, maximumVisibleY);
            this.SetNeedsDisplay();
            //Console.WriteLine("\n------------LayoutSubviews(): tileLabelsFromMinY------------\n");
            //this.tileLabelsFromMinY(this.minimumVisibleY, this.maximumVisibleY);

        }
        #endregion

        #region MapTiling
        // inserts item into suview and returns item.
        MapTileView InsertMap(MapScrollView view, MapTile maptile = null, int newXTile = 0)
        {
            MapTileView map;
            if (view.visibleTiles.Count == 0)
            {
                return new MapTileView("tempurl", new CGRect(0, 0, 256, 256), Manager.LocMgr.Location, 15);
            }
            else
            {
                return new MapTileView("tempurl", new CGRect(0, 0, 256, 256), maptile, 15);
            }

        }

        async Task<MapTileView> InsertMapAsync(MapTile maptile, int newXTile = 0)
        {

            MapTileView map = new MapTileView("tempurl", new CGRect(0, 0, 256, 256), 15);
            map.mapTile = await map.getTileAsync(maptile);
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
                var m = this.InsertMap(this);
                AddSubview(m);
                map.Add(m);
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
                    map.Add(this.InsertMap(this, new MapTile(lastTiles[i].mapTile).NextXTile(1)));
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


            NSMutableArray<MapTileView> map = new NSMutableArray<MapTileView>();



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

                bottomTiles.AddObjects(this.InsertMap(this, _maptile.NextYTile(1))); // move down.

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

                bottomTiles.AddObjects(await this.InsertMapAsync(_maptile.NextYTile(1))); // move down.

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

                        this.InsertMap(this,new MapTile(firstTiles[i].mapTile).NextXTile(-1))
                    };
                }
                else
                {
                    Console.WriteLine("PlaceNewMapOnLeft:firstTiles[" + i + "] = " + firstTiles[i].mapTile.XTile);
                    // move left
                    map[0].Add(this.InsertMap(this, new MapTile(firstTiles[i].mapTile).NextXTile(-1)));

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
                    this.InsertMap(this,_maptile.NextYTile(-1))
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
                    await this.InsertMapAsync(_maptile.NextYTile(-1))
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

            if (rightEdge < maximumVisibleX)
            {
                nuint count = (nuint)Math.Floor(maximumVisibleX / rightEdge);
                nuint x;
                // Start test
                NSMutableArray<MapTileView>[] map = new NSMutableArray<MapTileView>[count];
                NSMutableArray<MapTileView> lastTiles = this.visibleTiles[this.visibleTiles.Count - 1];
                // we pass the XTile value and increment during insertion of new map.
                // We need to make sure we keep the same map order in array.

                for (x = 0; x <= count; x++)
                {
                    var r = Task.Factory.StartNew(async () =>
                    {
                        NSMutableArray<MapTileView> m = new NSMutableArray<MapTileView>();
                        for (nuint i = 0; i <= (lastTiles.Count - 1); i++)
                        {
                            Console.WriteLine("PlaceNewMapOnRightAsync:lastTiles[" + i + "] = " + lastTiles[i].mapTile.XTile);
                            //lastTiles[i].mapTile.NextXTile(1); // move right.
                            MapTile mt = new MapTile(lastTiles[i].mapTile);
                            mt = mt.NextXTile(1);
                            MapTileView mtv = await this.InsertMapAsync(mt);
                            //InvokeOnMainThread(() => { AddSubview(mtv); });
                            m.Add(mtv);
                        }
                        return m;
                    }); // end thread dispatch

#if DEBUG
                    Console.WriteLine("Thread {0} launched.", r.Id);
#endif
                    Task.WaitAll(r);

                    CGRect frame = new CGRect();
                    foreach (MapTileView m in r.Result.Result)
                    {
                        this.subViewQueue.Enqueue(m);
                        frame = m.Frame;
                        frame.X = rightEdge;
                        frame.Y = this.MapContainerView.Bounds.Size.Height - frame.Size.Height;
                        m.Frame = frame;
                    }

                    this.visibleTiles.AddObjects(r.Result.Result);

                    if (r.IsCompleted)
                    {
#if DEBUG
                        Console.WriteLine("Disposing");
#endif
                        r.Dispose();
                    }
                }// end for loop

                // End test
            }// end if statement

            // add tiles that are missing on left side
            NSMutableArray<MapTileView> firstMap = this.visibleTiles[0];
            nfloat leftEdge = firstMap[0].Frame.GetMinX();

            if (leftEdge > minimumVisibleX)
            {

                nuint count = (nuint)Math.Floor(leftEdge / minimumVisibleX);
                nuint x;
                // Start test
                NSMutableArray<MapTileView>[] map = new NSMutableArray<MapTileView>[count];
                NSMutableArray<MapTileView> firstTiles = this.visibleTiles[0];
                // Insert object requires an array so map array looks weird.


                // we pass the XTile value and increment during insertion of new map.
                // We need to make sure we keep the same map order in array.

                for (x = 0; x <= count; x++)
                {

                    var l = Task.Factory.StartNew(async () =>
                   {
                       NSMutableArray<MapTileView> m = new NSMutableArray<MapTileView>();
                       for (nuint i = 0; i <= (firstTiles.Count - 1); i++)
                       {
                           Console.WriteLine("PlaceNewMapOnLeft:firstTiles[" + i + "] = " + firstTiles[i].mapTile.XTile);
                           //lastTiles[i].mapTile.NextXTile(1); // move right.
                           MapTile mt = new MapTile(firstTiles[i].mapTile).NextXTile(-1);
                           MapTileView mtv = await this.InsertMapAsync(mt);
                           /*
                          InvokeOnMainThread(() =>
                          {
                              AddSubview(mtv);
                          });*/
                           m.Add(mtv);
                       }
                       return m;
                   });
#if DEBUG
                    Console.WriteLine("Thread {0} launched.", l.Id);
#endif
                    Task.WaitAll(l);

                    CGRect frame = new CGRect();
                    foreach (MapTileView m in l.Result.Result)
                    {
                        this.subViewQueue.Enqueue(m);
                        frame = m.Frame;
                        frame.X = leftEdge - frame.Size.Width;
                        frame.Y = this.MapContainerView.Bounds.Size.Height - frame.Size.Height;

                        m.Frame = frame;
                    }
                    this.visibleTiles.InsertObjects(
                         new NSMutableArray<MapTileView>[1] {
                            l.Result.Result
                     }, new NSIndexSet(0)); // TODO: figure out this weird array parameter.

                    if (l.IsCompleted)
                    {
#if DEBUG
                        Console.WriteLine("Disposing");
#endif
                        l.Dispose();
                    }
                }
                // End test

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
                                  + "<" + "minimumVisibleY = " + minimumVisibleY);
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

        private void tileMapsFromMinY(nfloat minimumVisibleY, nfloat maximumVisibleY)
        {
            if (this.visibleTiles.Count == 0)
            {
                this.PlaceNewMapOnRight(minimumVisibleX);
            }

            // add tiles that are missing on the bottom.
            NSMutableArray<MapTileView> lastMap = this.visibleTiles[this.visibleTiles.Count - 1]; // last object
            nfloat bottomEdge = lastMap[lastMap.Count - 1].Frame.GetMaxY();

            if (bottomEdge < maximumVisibleY)
            {
                nuint count = (nuint)Math.Floor(maximumVisibleY / bottomEdge);
                nuint y;
                // Start test
                NSMutableArray<MapTileView>[] map = new NSMutableArray<MapTileView>[count];

                foreach (NSMutableArray<MapTileView> Tiles in this.visibleTiles)
                {
                    var b = Task.Factory.StartNew(async () =>
                    {

                        NSMutableArray<MapTileView> m = new NSMutableArray<MapTileView>();
                        for (nuint i = 0; i <= count; i++)
                        {
                            Console.WriteLine("PlaceNewMapOnBottomAsync:lastTiles[" + i + "] = " + Tiles[Tiles.Count - 1].mapTile.YTile);
                            // Get bottom tile
                            var bottomTile = Tiles[Tiles.Count - 1];
                            MapTile mt = new MapTile(bottomTile.mapTile);
                            mt = mt.NextYTile(1); // move down
                            MapTileView mtv = await this.InsertMapAsync(mt);
                            m.Add(mtv);
                        }
                        return m;
                    }); // end thread dispatch

#if DEBUG
                    Console.WriteLine("Thread {0} launched.", b.Id);
#endif
                    Task.WaitAll(b);

                    CGRect frame = new CGRect();
                    foreach (MapTileView m in b.Result.Result)
                    {
                        this.subViewQueue.Enqueue(m);
                        frame = m.Frame;
                        frame.Y = bottomEdge;
                        m.Frame = frame;
                    }

                    Tiles.AddObjects(b.Result.Result);

                    if (b.IsCompleted)
                    {
#if DEBUG
                        Console.WriteLine("Disposing");
#endif
                        b.Dispose();
                    }
                }


                #endregion
            }
            // add tiles that are missing on top.
            NSMutableArray<MapTileView> firstMap = this.visibleTiles[0];
            nfloat topEdge = firstMap[0].Frame.GetMinY();

            if (topEdge > minimumVisibleY)
            {
                nuint count = (nuint)Math.Floor(topEdge / minimumVisibleY);
                nuint y;
                // Start test
                NSMutableArray<MapTileView>[] map = new NSMutableArray<MapTileView>[count];

                foreach (NSMutableArray<MapTileView> Tiles in this.visibleTiles)
                {
                    var t = Task.Factory.StartNew(async () =>
                    {
                        NSMutableArray<MapTileView> m = new NSMutableArray<MapTileView>();
                        for (nuint i = 0; i <= count; i++)
                        {
                            Console.WriteLine("PlaceNewMapOnTopAsync:topTiles[" + i + "] = " + Tiles[0].mapTile.YTile);
                            // Get top tile
                            var topTile = Tiles[0];
                            MapTile mt = new MapTile(topTile.mapTile);
                            mt = mt.NextYTile(-1); // move up
                            MapTileView[] mtv = new MapTileView[1];
                            mtv[0] = await this.InsertMapAsync(mt);
                            
                            m.Add(mtv[0]);
                        }
                        return m;
                    }); // end thread dispatch

#if DEBUG
                    Console.WriteLine("Thread {0} launched.", t.Id);
#endif
                    Task.WaitAll(t);

                    CGRect frame = new CGRect();
                    foreach (MapTileView m in t.Result.Result)
                    {
                        this.subViewQueue.Enqueue(m);
                        frame = m.Frame;
                        frame.Y = topEdge - frame.Size.Height;
                        m.Frame = frame;
                    }
                    Tiles.InsertObjects(new NSMutableArray<MapTileView>[1] {
                            t.Result.Result
                     }, new NSIndexSet(0));

                    if (t.IsCompleted)
                    {
#if DEBUG
                        Console.WriteLine("Disposing");
#endif
                        t.Dispose();
                    }
                }

            }
        }
    }
}
