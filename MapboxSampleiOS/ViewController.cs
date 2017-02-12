using System;
using System.Drawing;
using UIKit;
using Maps;
using System.Linq;
using CoreLocation;
using CoreGraphics;
using Foundation;
using ImageIO;

namespace MapBoxSampleiOS
{
    public partial class ViewController : UIViewController, IMapViewDelegate
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        MapView mapView;
        t_UIView testView;

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            testView = new t_UIView(View.Bounds);
            View.AddSubview(testView);

            testView.Layer.CornerRadius = 4;
            testView.Layer.ShadowColor = new CGColor(1, 0, 0);
            testView.Layer.ShadowOpacity = 1.0f;
            testView.Layer.ShadowOffset = new SizeF(0, 4);
            testView.BackgroundColor = UIColor.White;


            var image = new UIImageView(UIImage.FromBundle("mapserv.png"));
            View.AddSubview(image);
            image.Frame = new CoreGraphics.CGRect(10, 10, image.Image.CGImage.Width, image.Image.CGImage.Height);
           
        }



        // Delegate for an annotation to be selected
        [Export ("mapView:didSelectAnnotation:")]
        public void DidSelectAnnotation (MapView mapView, IAnnotation annotation)
        {
            // Just show the user which one was pressed
            new UIAlertView ("Annotation Tapped", "You tapped on: " + annotation.GetTitle (), null, "OK")
                .Show ();
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();

            // Cleanup anything possible
            mapView.EmptyMemoryCache ();
        }
    }
}

