using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using SVGKit;
using CoreGraphics;
using CoreLocation;
using System.IO;
using CoreAnimation;

namespace StateMaps
{
    public class SVGKFastTileView : SVGKFastImageView
    {
		CLLocation loc;
        GlobalMapTiles gmt;
        SVGKImage svgImage;
        UIRotationGestureRecognizer rotateGesture;
        UIPanGestureRecognizer panGesture;
        CGSize tileSize;
		private int col = 9651;
        public SVGKFastTileView(SVGKImage svgImage) : base (svgImage)
        {
            SetupImages(svgImage);

        }

        public SVGKFastTileView(CGRect frame, int xOffset) : base (frame)
        {
			//this.SetGestures();
            tileSize = new CGSize(256, 256);
			this.col += xOffset;
        }

        public SVGKFastTileView(SVGKImage svgImage, CGRect frame) : base(frame)
        {
            SetupImages(svgImage);
        }

        private void SetupImages(SVGKImage svgImage)
        {
            this.svgImage = svgImage;
            tileSize = tileSize = new CGSize(256, 256);
            this.svgImage.Size = tileSize;
            //this.SetGestures();
        }
        public override void Draw(CGRect area)
        {
            base.Draw(area);
            RenderSVgImages();

        }

        public void RenderSVgImages()
        {
            const int ZOOM = 15;
            //this.svgImage = SVGKImage.ImageNamed(Path.Combine("tiles/", ZOOM.ToString() + "/" + "BL-NY.svg"));

            //CGRect imageBounds = new CGRect(0, 0, this.svgImage.Size.Width, this.svgImage.Size.Height);


            var context = UIGraphics.GetCurrentContext();

            //context.ScaleCTM(-10, -10);

            // TODO : replace with coordinate location
            int minX = 9646;
            int maxX = 9652;
            int minY = 12314;
            int maxY = 12320;
            int c=0;
            int r = 0;
            int col = 9651;
            int row = 12314;
            context.SaveState();
            context.TranslateCTM(tileSize.Width * c, tileSize.Height * r);

            this.svgImage = getTile(ZOOM, col, row);
            this.svgImage.Size = tileSize;

            this.svgImage.CALayerTree.RenderInContext(context);

            //

            context.RestoreState();

            //this.Layer.AddSublayer(svgImage.CALayerTree); 
            //this.svgImage.CALayerTree.RenderInContext(context);

            /*for (int row = minY; row <= maxY; row++)
            {
                c = 0;
                for (int col = minX; col <= maxX; col++)
                {
					context.SaveState();
					context.TranslateCTM(tileSize.Width * c, tileSize.Height * r);

					  this.svgImage = getTile(ZOOM, col, row);
					this.svgImage.Size = tileSize;

					this.svgImage.CALayerTree.RenderInContext(context);

					//

					context.RestoreState();
					

					c++;

                }
                r++;

            }*/



        }
        private  static SVGKImage getTile(int zoom, int col, int row)
        {
            string path = "tiles/";

            string pngFilename = Path.Combine(path, zoom.ToString() + "/" + col.ToString() + "/" + row.ToString() + "/tile.svg");

            return SVGKImage.ImageNamed(pngFilename);
        }

        private void SetGestures()
        {
            nfloat r = 0;
            nfloat dx = 0;
            nfloat dy = 0;
            //this.rotateGesture = new UIRotationGestureRecognizer(() =>
            //{
            //    if ((rotateGesture.State == UIGestureRecognizerState.Began || rotateGesture.State == UIGestureRecognizerState.Changed)
            //    && rotateGesture.NumberOfTouches == 2)
            //    {
            //        this.Transform = CGAffineTransform.MakeRotation(rotateGesture.Rotation + r);
            //    }
            //    else if (rotateGesture.State == UIGestureRecognizerState.Ended)
            //    {
            //        r += rotateGesture.Rotation;
            //    }
            //});

            this.UserInteractionEnabled = true;



            var rotationGesture = new UIRotationGestureRecognizer(RotateImage);

            this.AddGestureRecognizer(rotationGesture);



            var pinchGesture = new UIPinchGestureRecognizer(ScaleImage);

            //pinchGesture.Delegate = new GestureDelegate(this);

            this.AddGestureRecognizer(pinchGesture);

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
        // Scales the image by the current scale

        void ScaleImage(UIPinchGestureRecognizer gestureRecognizer)

        {

            AdjustAnchorPointForGestureRecognizer(gestureRecognizer);

            if (gestureRecognizer.State == UIGestureRecognizerState.Began || gestureRecognizer.State == UIGestureRecognizerState.Changed)
            {

                gestureRecognizer.View.Transform *= CGAffineTransform.MakeScale(gestureRecognizer.Scale, gestureRecognizer.Scale);

                // Reset the gesture recognizer's scale - the next callback will get a delta from the current scale.

                gestureRecognizer.Scale = 1;

            }

        }
        // Rotates the image by the current rotation

        void RotateImage(UIRotationGestureRecognizer gestureRecognizer)

        {

            AdjustAnchorPointForGestureRecognizer(gestureRecognizer);

            if (gestureRecognizer.State == UIGestureRecognizerState.Began || gestureRecognizer.State == UIGestureRecognizerState.Changed)
            {

                gestureRecognizer.View.Transform *= CGAffineTransform.MakeRotation(gestureRecognizer.Rotation);

                // Reset the gesture recognizer's rotation - the next callback will get a delta from the current rotation.

                gestureRecognizer.Rotation = 0;

            }

        }


    }
}