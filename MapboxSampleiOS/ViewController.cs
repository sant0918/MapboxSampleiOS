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
            
           
            // Add base map
            /*using (UIImage foto = UIImage.FromBundle("mapserv.png"))
             {
                image = new UIImageView(foto);
                image.UserInteractionEnabled = true;
                View.AddSubview(image);
                image.Frame = new CGRect(10, 10, image.Image.CGImage.Width, image.Image.CGImage.Height);

             }*/
		
           
         
            

        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            SVGKImageView iv = new SVGKFastTileView(new CGRect(0, 0, -1024, 2048));
            //iv.Frame = new CGRect(0, 0, 256, 256);
            View.AddSubview(iv);
            UIView v = AppDelegate.Self.Window.RootViewController.View;
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();

            // Cleanup anything possible
           // mapView.EmptyMemoryCache ();
        }
    }
}

