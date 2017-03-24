using System;
using System.Collections.Generic;
using System.Text;
using CoreFoundation;
using CoreGraphics;
using CoreLocation;
using Foundation;
using UIKit;
using StateMaps.Models;

namespace StateMaps
{
    public class MapScrollView : UIScrollView
    {
        NSMutableArray<NSMutableArray<MapTileView>> visibleTiles; // visibleTile Matrix
        
        UIView MapContainerView;
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
			ContentSize = new CGSize(5000, this.Frame.Size.Height * 2);
			visibleTiles = new NSMutableArray<NSMutableArray<MapTileView>>();
            
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
            ShowsVerticalScrollIndicator = true;
            
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

            if(distanceFromCenterX > (contentWidth / 4))
            {
                this.ContentOffset = new CGPoint(centerOffsetX, currentOffset.Y);

                // move content by the same amount so it appears to stay still
                
                foreach(NSMutableArray<MapTileView> YMap in visibleTiles)
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
				this.ContentOffset = new CGPoint(centerOffsetX, currentOffset.Y);

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

			this.tileLabelsFromMinX(minimumVisibleX, maximumVisibleX);
            this.tileLabelsFromMinY(minimumVisibleY, maximumVisibleY);

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
                for (nuint i = 0; i < (lastTiles.Count - 1); i++)
                {
                    lastTiles[i].mapTile.NextXTile(1); // move right.
                    map.Add(this.InsertMap(lastTiles[i].mapTile));
                }
                
            }
            
            this.visibleTiles.AddObjects(map);

            CGRect frame = new CGRect();

            foreach(MapTileView m in map)
            {
                frame = m.Frame;
                frame.X = rightEdge;
                frame.Y = this.MapContainerView.Bounds.Size.Height - frame.Size.Height;
                m.Frame = frame;
            }
            

            return frame.GetMaxX();
        }

        private nfloat PlaceNewMapOnBottom(nfloat bottomEdge)
        {
            NSMutableArray<MapTileView> map;

            CGRect frame = new CGRect();
            foreach (NSMutableArray<MapTileView> bottomTiles in this.visibleTiles)
            {
                bottomTiles[bottomTiles.Count - 1].mapTile.NextYTile(1); // move down.
                bottomTiles.AddObjects( this.InsertMap(bottomTiles[bottomTiles.Count - 1].mapTile));
                
                frame = bottomTiles[bottomTiles.Count - 1].Frame;
                frame.Y = bottomEdge;
                frame.X = this.MapContainerView.Bounds.Size.Width - frame.Size.Width;
                bottomTiles[bottomTiles.Count - 1].Frame = frame;
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
            for (nuint i = 0; i < (firstTiles.Count - 1); i++)
            {
                firstTiles[i].mapTile.NextXTile(-1); // move left
                map[0][i] = this.InsertMap(firstTiles[i].mapTile);
            }
            this.visibleTiles.InsertObjects(map, new NSIndexSet(0)); // TODO: figure out this weird array parameter.

            CGRect frame = new CGRect();
            foreach(MapTileView m in map[0])
            {
                frame = m.Frame;
                frame.X = leftEdge - frame.Size.Width;
                frame.Y = this.MapContainerView.Bounds.Size.Height - frame.Size.Height;

                m.Frame = frame;
            }
            return frame.GetMinX();
        }

        private nfloat PlaceNewMapOntop(nfloat topEdge)
        {
            nuint TOP = 0;
            // Insert object requires an array so map array looks weird.
            NSMutableArray<MapTileView>[] map = new NSMutableArray<MapTileView>[1];
            // we have to get the first tile in every vertical array.

            CGRect frame = new CGRect();
            foreach (NSMutableArray<MapTileView> topTiles in this.visibleTiles)
            {
                topTiles[TOP].mapTile.NextYTile(-1); // move up
                topTiles.InsertObjects( new MapTileView[1] { this.InsertMap(topTiles[TOP].mapTile) }, new NSIndexSet(0));

                frame = topTiles[TOP].Frame;
                frame.Y = topEdge - frame.Size.Height;
                frame.X = this.MapContainerView.Bounds.Size.Width - frame.Size.Width;

                topTiles[TOP].Frame = frame;
            }
            return frame.GetMinY();
        }
        private void tileLabelsFromMinX(nfloat minimumVisibleX, nfloat maximumVisibleX)
        {
            // the upcoming tiling logic depends on there already being at least one tile in the visibleTiles array, so
            // to kick off the tiliong we need to make sure there's at least one tile.
            if(this.visibleTiles.Count == 0)
            {
                this.PlaceNewMapOnRight(minimumVisibleX);
            }

            // add tiles that are missing on right side.
            NSMutableArray<MapTileView> lastMap = this.visibleTiles[this.visibleTiles.Count - 1]; // last object

            nfloat rightEdge = lastMap.Frame.GetMaxX();

            while (rightEdge < maximumVisibleX)
            {
                rightEdge = this.PlaceNewMapOnRight(rightEdge);
            }

            // add tiles that are missing on left side
            MapTileView firstMap = this.visibleTiles[0];
            nfloat leftEdge = firstMap.Frame.GetMinX();

            while (leftEdge > minimumVisibleX)
            {
                leftEdge = this.PlaceNewMapOnLeft(leftEdge);
            }

            // remove tiles that have fallen off right edge.
            lastMap = this.visibleTiles[this.visibleTiles.Count - 1];
            while(lastMap.Frame.X > maximumVisibleX)
            {
                lastMap.RemoveFromSuperview();
                this.visibleTiles.RemoveLastObject();
                lastMap = this.visibleTiles[this.visibleTiles.Count - 1];
            }

            // remove tiles that have fallen off left edge
            firstMap = this.visibleTiles[0];
            while(firstMap.Frame.GetMaxX() < minimumVisibleX)
            {
                firstMap.RemoveFromSuperview();
                this.visibleTiles.RemoveObjectsAtIndexes(new NSIndexSet(0));
                firstMap = this.visibleTiles[0];
            }
        }

        private void tileLabelsFromMinY(nfloat minimumVisibleY, nfloat maximumVisibleY)
        {
            if(this.visiblesVerticalTiles.Count == 0)
            {
                this.PlaceNewMapOnBottom(minimumVisibleY);
            }
            // add tiles that are missing on the bottom.
            MapTileView lastMap = this.visiblesVerticalTiles[this.visiblesVerticalTiles.Count - 1]; // last object
            nfloat bottomEdge = lastMap.Frame.GetMaxY();

            while (bottomEdge < maximumVisibleY)
            {
                bottomEdge = this.PlaceNewMapOnBottom(bottomEdge);
            }

            // add tiles that are missing on top.
            MapTileView firstMap = this.visiblesVerticalTiles[0];
            nfloat topEdge = firstMap.Frame.GetMinY();

            while(topEdge > minimumVisibleY)
            {
                topEdge = this.PlaceNewMapOntop(topEdge);
            }

            // remove tiles that fallen off bottom edge.
            lastMap = this.visiblesVerticalTiles[this.visiblesVerticalTiles.Count - 1];
            while(lastMap.Frame.Y > maximumVisibleY)
            {
                lastMap.RemoveFromSuperView();
                this.visiblesVerticalTiles.RemoveLastObject();
                lastMap = this.visiblesVerticalTiles[this.visiblesVerticalTiles.Count - 1];
            }

            // remove tiles that have fallen off top edge
            firstMap = this.visiblesVerticalTiles[0];
            while(firstMap.Frame.GetMaxY() < minimumVisibleY)
            {
                firstMap.RemoveFromSuperview();
                this.visiblesVerticalTiles.RemoveObjectsAtIndexes(new NSIndexSet(0));
                firstMap = this.visiblesVerticalTiles[0];
            }
            
        }

        #endregion
    }
}
