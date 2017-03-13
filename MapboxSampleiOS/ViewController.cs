using System;
using System.IO;
using System.Xml;
using System.Drawing;
using UIKit;
using System.Linq;
using CoreLocation;
using CoreGraphics;
using Foundation;
using ImageIO;
using SVGKit;


namespace MapBoxSampleiOS
{
    public partial class ViewController : UIViewController
    { 
        public ViewController (IntPtr handle) : base (handle)
        {
			
        }
        
        
        UIImageView image;        
        UIRotationGestureRecognizer rotateGesture;
        UIPanGestureRecognizer panGesture;

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            
            nfloat r = 0;            
            nfloat dx = 0;
            nfloat dy = 0;

       
            // Add base map
            using (UIImage foto = UIImage.FromBundle("mapserv.png"))
             {
                image = new UIImageView(foto);
                image.UserInteractionEnabled = true;
                View.AddSubview(image);
                image.Frame = new CGRect(10, 10, image.Image.CGImage.Width, image.Image.CGImage.Height);

             }
		
            SVGKImageView iv = new SVGKFastTileView(View.Bounds);
			//iv.Frame = new CGRect(0, 0, 256, 256);
			View.AddSubview(iv);
         
            
            rotateGesture = new UIRotationGestureRecognizer(() =>
            {
                if ((rotateGesture.State == UIGestureRecognizerState.Began || rotateGesture.State == UIGestureRecognizerState.Changed)
                && rotateGesture.NumberOfTouches == 2)
                {
                    image.Transform = CGAffineTransform.MakeRotation(rotateGesture.Rotation + r);
                }
                else if (rotateGesture.State == UIGestureRecognizerState.Ended)
                {
                    r += rotateGesture.Rotation;
                }
            });

            panGesture = new UIPanGestureRecognizer(() =>
            {
                if ((panGesture.State == UIGestureRecognizerState.Began || panGesture.State == UIGestureRecognizerState.Changed)
                 && panGesture.NumberOfTouches == 1)
                {
                    var p0 = panGesture.LocationInView(View);

                    if (dx == 0)
                        dx = p0.X - image.Center.X;

                    if (dy == 0)
                        dy = p0.Y - image.Center.Y;

                    var p1 = new CGPoint(p0.X - dx, p0.Y - dy);
                    image.Center = p1;
                }
                else if (panGesture.State == UIGestureRecognizerState.Ended)
                {
                    dx = 0;
                    dy = 0;
                }

            });

            image.AddGestureRecognizer(panGesture);
            image.AddGestureRecognizer(rotateGesture);
            

        }


        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();

            // Cleanup anything possible
           // mapView.EmptyMemoryCache ();
        }
    }
}

