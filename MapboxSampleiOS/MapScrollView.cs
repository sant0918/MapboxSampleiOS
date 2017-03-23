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
        NSMutableArray<UILabel> visibleTiles;
        UIView MapContainerView;
        public string _url { get; private set; } = "http://javier.nyc/cgi-bin/mapserv.exe?map=/ms4w/apps/osm/basemaps/osm-google.map&layers=all&mode=tile&tilemode=gmap&tile=";

        public CLLocation location;
        public int zoom = 15; // init zoom level
        nfloat minimumVisibleX = 0;
        nfloat maximumVisibleX = 0;

        public MapScrollView(NSCoder coder) : base(coder)
        {
            ContentSize = new CGSize(5000, this.Frame.Size.Height);
            visibleTiles = new NSMutableArray<UILabel>();
            MapContainerView = new UIView();
            MapContainerView.Frame = new CGRect(0, 0, ContentSize.Width, ContentSize.Height / 2);
            this.AddSubview(MapContainerView);
            MapContainerView.UserInteractionEnabled = false;

            // hide horizontal scroll indicator so our recentering trick is not revealed.
            ShowsHorizontalScrollIndicator = false;
        }
        public MapScrollView(CGRect frame) : base(frame)
        {
			ContentSize = new CGSize(5000, this.Frame.Size.Height);
			visibleTiles = new NSMutableArray<UILabel>();
			MapContainerView = new UIView();
			MapContainerView.Frame = new CGRect(0, 0, ContentSize.Width, ContentSize.Height / 2);
			this.AddSubview(MapContainerView);
			MapContainerView.UserInteractionEnabled = false;

			// hide horizontal scroll indicator so our recentering trick is not revealed.
			ShowsHorizontalScrollIndicator = false;
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
            nfloat centerOffsetX = (contentWidth - this.Bounds.Size.Width) / 2;
            nfloat distanceFromCenter = (nfloat)Math.Abs(currentOffset.X - centerOffsetX);

            if(distanceFromCenter > (contentWidth / 4))
            {
                this.ContentOffset = new CGPoint(centerOffsetX, currentOffset.Y);

                // move content by the same amount so it appears to stay still
                
                foreach(UILabel label in visibleTiles)
                {
                    CGPoint center = this.MapContainerView.ConvertPointToView(label.Center, this);
                    center.X += (centerOffsetX - currentOffset.X);
                    label.Center = this.ConvertPointToView(center, this.MapContainerView);
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
            this.maximumVisibleX = visibleBounds.GetMaxX();
			nfloat diff = maximumVisibleX - minimumVisibleX;
            this.tileLabelsFromMinX(minimumVisibleX, maximumVisibleX);
        }
        #endregion

        #region MapTiling
		// inserts item into suview and returns item.
        UILabel InsertMap(int xOffset = 0)
        {
			UILabel map = new UILabel(new CGRect(0,0,500,80));
            CGRect bounds = this.ConvertRectToView(this.Bounds, map);
            UILabel label1 = new UILabel(new CGRect(0, 0, 200, 80));
            UILabel label2 = new UILabel(new CGRect(0, 0, 200, 80));
			map.Text = this.minimumVisibleX.ToString();
            label2.Text = "lo que";
			this.AddSubview(map);
			return map;
        }

		// Adds new item into subview, adds to the end of the array and put's it in view
		// by adjusting the frame size of item in array.
        private nfloat PlaceNewMapOnRight(nfloat rightEdge)
        {
            UILabel map = this.InsertMap();
            this.visibleTiles.AddObjects(map);

            CGRect frame = map.Frame;
            frame.X = rightEdge;
            frame.Y = this.MapContainerView.Bounds.Size.Height - frame.Size.Height;

            map.Frame = frame;

            return frame.GetMaxX();
        }

		// Adds new item into subview, adds to the beginning of the array and put's it in view
		// by adjusting the frame size of item in array.
        private nfloat PlaceNewMapOnLeft(nfloat leftEdge)
        {
            
            UILabel[] map = new UILabel[1] { this.InsertMap() };            
            this.visibleTiles.InsertObjects(map, new NSIndexSet(0));

            CGRect frame = map[0].Frame;
            frame.X = leftEdge - frame.Size.Width;
            frame.Y = this.MapContainerView.Bounds.Size.Height - frame.Size.Height;

            map[0].Frame = frame;

            return frame.GetMinX();
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
            UILabel lastMap = this.visibleTiles[this.visibleTiles.Count - 1]; // last object
            nfloat rightEdge = lastMap.Frame.GetMaxX();

            while (rightEdge < maximumVisibleX)
            {
                rightEdge = this.PlaceNewMapOnRight(rightEdge);
            }

            // add tiles that are missing on left side
            UILabel firstMap = this.visibleTiles[0];
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

        #endregion
    }
}
