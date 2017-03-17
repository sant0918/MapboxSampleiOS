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
        // location is updated from HandleLocationChanged event then passed to mapviews.
        public CLLocation location; 

        MapView top;
        MapView center;
        MapView bottom;

        #region ComputedProperties
        public static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public static LocationManager Manager { get; set; }
        #endregion

        #region Constructors
        public ViewController (IntPtr handle) : base (handle)
        {
            // As soon as the app is done launching, begin generating location updates in the location manager
            Manager = new LocationManager();
            Manager.StartLocationUpdates();

            top = new MapView(_url, new CGRect(-1280, -256, 2560, 256), location ); // 
            center = new MapView(_url, new CGRect(-1280, 0, 2560, 256), location );
            bottom = new MapView(_url, new CGRect(-1280, 256, 2560, 256), location );

        }

        #endregion

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            // It is better to handle this with notifications, so that the UI updates
            // resume when the application re-enters the foreground!
            Manager.LocationUpdated += HandleLocationChanged;

            // Add base map
            /*using (UIImage foto = UIImage.FromBundle("mapserv.png"))
             {
                image = new UIImageView(foto);
                image.UserInteractionEnabled = true;
                View.AddSubview(image);
                image.Frame = new CGRect(10, 10, image.Image.CGImage.Width, image.Image.CGImage.Height);

             }*/
        }

        //Gps location is reiteved here.
        public void HandleLocationChanged(object sender, LocationUpdatedEventArgs e)
        {
            // Handle foreground updates
            this.location = e.Location;
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

