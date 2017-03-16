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
using StateMaps.Models;

namespace StateMaps
{
    public partial class ViewController : UIViewController
    {

        UIImageView image;
        public const string _url = "http://javier.nyc/cgi-bin/mapserv.exe?map=/ms4w/apps/osm/basemaps/osm-google.map&layers=all&mode=tile&tilemode=gmap&tile=";
        public CLLocationCoordinate2D location;

        MapView top;
        MapView center;
        MapView bottom;
        public ViewController (IntPtr handle) : base (handle)
        {
		    top = new MapView(_url, new CGRect(-1280, -2560, 2560, 2560), location = new CLLocationCoordinate2D()); // 
            center = new MapView(_url, new CGRect(-1280, 0, 2560, 2560), location = new CLLocationCoordinate2D());
            bottom = new MapView(_url, new CGRect(-1280, 2560, 2560, 2560), location = new CLLocationCoordinate2D());
        }
        
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
            SVGKImageView iv = new SVGKFastTileView(new CGRect(-1000,0,3048,2048));
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

