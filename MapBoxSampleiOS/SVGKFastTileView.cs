using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using SVGKit;
using CoreGraphics;
using CoreLocation;
using System.IO;
using UIKit;
using CoreAnimation;

namespace MapBoxSampleiOS
{
    public class SVGKFastTileView : SVGKFastImageView
    {
		CLLocation loc;
        GlobalMapTiles gmt;
        SVGKImage svgImage;
        UIRotationGestureRecognizer rotateGesture;
        UIPanGestureRecognizer panGesture;
        CGSize tileSize;

        public SVGKFastTileView(SVGKImage svgImage) : base (svgImage)
        {
            this.svgImage = svgImage;
            tileSize = tileSize = new CGSize(256, 256);
            this.svgImage.Size = tileSize;
            this.SetGestures();

        }

        public SVGKFastTileView(CGRect frame) : base (frame)
        {
			this.SetGestures();
            tileSize = new CGSize(256, 256);
        }

        public override void Draw(CGRect area)
        {
            base.Draw(area);
			const int ZOOM = 7;
			//this.svgImage = SVGKImage.ImageNamed(Path.Combine("tiles/", ZOOM.ToString() + "/" + "BL-NY.svg"));

            //CGRect imageBounds = new CGRect(0, 0, this.svgImage.Size.Width, this.svgImage.Size.Height);
            

            var context = UIGraphics.GetCurrentContext();
           
            //context.ScaleCTM(-10, -10);

            // TODO : replace with coordinate location
            int firstCol = 35;
            int lastCol = 37;
            int firstRow = 46;
            int lastRow = 47;
			int c;
			int r=0;
            //this.Layer.AddSublayer(svgImage.CALayerTree); 
            //this.svgImage.CALayerTree.RenderInContext(context);
            
            for (int row = firstRow; row <= lastRow; row++)
            {
				c = 0;
                for (int col = firstCol; col <= lastCol; col++)
                {
                    context.SaveState();
                    context.TranslateCTM(tileSize.Width * c, tileSize.Height * r);
                    this.svgImage = getTile(ZOOM, col, row);
                    this.svgImage.Size = tileSize;
                    

                    this.svgImage.CALayerTree.RenderInContext(context);
                    context.RestoreState();
                    c++;
                    
                }
                r++;

            }

         

        }

        public SVGKImage getTile(int zoom, int col, int row)
		{
			string path = "tiles/";

			string pngFilename = Path.Combine(path, zoom.ToString() + "/" + col.ToString() + "/" + row.ToString() + "/tile.svg");

			return SVGKImage.ImageNamed(pngFilename);
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

        private void SetGestures()
        {
            nfloat r = 0;
            nfloat dx = 0;
            nfloat dy = 0;
            this.rotateGesture = new UIRotationGestureRecognizer(() =>
            {
                if ((rotateGesture.State == UIGestureRecognizerState.Began || rotateGesture.State == UIGestureRecognizerState.Changed)
                && rotateGesture.NumberOfTouches == 2)
                {
                    this.Transform = CGAffineTransform.MakeRotation(rotateGesture.Rotation + r);
                }
                else if (rotateGesture.State == UIGestureRecognizerState.Ended)
                {
                    r += rotateGesture.Rotation;
                }
            });

            /* this.panGesture = new UIPanGestureRecognizer(() =>
             {
                 if ((panGesture.State == UIGestureRecognizerState.Began || panGesture.State == UIGestureRecognizerState.Changed)
                  && panGesture.NumberOfTouches == 1)
                 {
                     var p0 = panGesture.LocationInView(this);

                     if (dx == 0)
                         dx = p0.X - this.Center.X;

                     if (dy == 0)
                         dy = p0.Y - this.Center.Y;

                     var p1 = new CGPoint(p0.X - dx, p0.Y - dy);
                     this.Center = p1;
                 }
                 else if (panGesture.State == UIGestureRecognizerState.Ended)
                 {
                     dx = 0;
                     dy = 0;
                 }

             });*/

            var panGesture = new UIPanGestureRecognizer(PanImage);

            panGesture.MaximumNumberOfTouches = 2;

            //panGesture.Delegate = new GestureDelegate(this);
            
            this.AddGestureRecognizer(panGesture);
			this.AddGestureRecognizer(rotateGesture);
        }

        void AdjustAnchorPointForGestureRecognizer(UIGestureRecognizer gestureRecognizer)

        {

            if (gestureRecognizer.State == UIGestureRecognizerState.Began)
            {

                var image = gestureRecognizer.View;

                var locationInView = gestureRecognizer.LocationInView(image);

                var locationInSuperview = gestureRecognizer.LocationInView(image.Superview);



                image.Layer.AnchorPoint = new CGPoint(locationInView.X / image.Bounds.Size.Width, locationInView.Y / image.Bounds.Size.Height);

                image.Center = locationInSuperview;

            }

        }
        void PanImage(UIPanGestureRecognizer gestureRecognizer)

        {

            AdjustAnchorPointForGestureRecognizer(gestureRecognizer);

            var image = gestureRecognizer.View;

            if (gestureRecognizer.State == UIGestureRecognizerState.Began || gestureRecognizer.State == UIGestureRecognizerState.Changed)
            {

                var translation = gestureRecognizer.TranslationInView(this);

                image.Center = new CGPoint(image.Center.X + translation.X, image.Center.Y + translation.Y);

                // Reset the gesture recognizer's translation to {0, 0} - the next callback will get a delta from the current position.

                gestureRecognizer.SetTranslation(CGPoint.Empty, image);

            }

        }

    }
}