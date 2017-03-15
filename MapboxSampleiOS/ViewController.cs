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
            SVGKImageView iv = new SVGKFastTileView(new CGRect(0, 0, 1024, 1024));
            //iv.Frame = new CGRect(0, 0, 256, 256);
            View.AddSubview(iv);

        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();

            // Cleanup anything possible
           // mapView.EmptyMemoryCache ();
        }
    }
}

