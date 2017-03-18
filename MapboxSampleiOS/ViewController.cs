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
        public int zoom = 15; // init zoom level


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
            Manager = new LocationManager();
			Manager.StartLocationUpdates();
			location = Manager.LocMgr.Location;

           

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



			// As soon as the app is done launching, begin generating location updates in the location manager

        }

        //Gps location is reiteved here.
        public void HandleLocationChanged(object sender, LocationUpdatedEventArgs e)
        {
            // Handle foreground updates
            this.location = e.Location;

			if (this.location != null)
			{
				if (center == null )
				{
					top = new MapView(_url, new CGRect(-1280, -256, 2560, 256), this.location, zoom); // 
					center = new MapView(_url, new CGRect(-1280, 0, 2560, 256), this.location, zoom);
					bottom = new MapView(_url, new CGRect(-1280, 256, 2560, 256), this.location, zoom);
					SetGestures();
					View.AddSubviews(top, center, bottom);
					View.SetNeedsDisplay();
				}

			}
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
			//SVGKImageView iv = new SVGKFastTileView(new CGRect(-1000,0,3048,2048));
			//iv.Frame = new CGRect(0, 0, 256, 256);
			//View.AddSubview(iv);
			if (this.location != null)
			{
				if (center != null)
				{
					
					// TODO: Add Mapviews as subview.
					//        UIView v = AppDelegate.Self.Window.RootViewController.View;
				}
			}
		}

        

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();

            // TODO: Cleanup anything possible
           // mapView.EmptyMemoryCache ();
        }

        private void SetGestures()
        {
           
            View.UserInteractionEnabled = true;



            var rotationGesture = new UIRotationGestureRecognizer(RotateImage);

            View.AddGestureRecognizer(rotationGesture);



            var pinchGesture = new UIPinchGestureRecognizer(ScaleImage);

            pinchGesture.Delegate = new GestureDelegate(this);

            View.AddGestureRecognizer(pinchGesture);

            var panGesture = new UIPanGestureRecognizer(PanImage);

            panGesture.MaximumNumberOfTouches = 2;

            panGesture.Delegate = new GestureDelegate(this);           

            View.AddGestureRecognizer(panGesture);
            View.AddGestureRecognizer(rotationGesture);
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
        // Shift the image's center by the pan amount

        void PanImage(UIPanGestureRecognizer gestureRecognizer)

        {

            AdjustAnchorPointForGestureRecognizer(gestureRecognizer);

            var image = gestureRecognizer.View;

            if (gestureRecognizer.State == UIGestureRecognizerState.Began || gestureRecognizer.State == UIGestureRecognizerState.Changed)
            {
                // TODO: Load additional tiles if pan reaches edge of image.
                var translation = gestureRecognizer.TranslationInView(View);

                image.Center = new CGPoint(image.Center.X + translation.X, image.Center.Y + translation.Y);

                // Reset the gesture recognizer's translation to {0, 0} - the next callback will get a delta from the current position.

                gestureRecognizer.SetTranslation(CGPoint.Empty, image);

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



        // Scales the image by the current scale

        void ScaleImage(UIPinchGestureRecognizer gestureRecognizer)

        {

            AdjustAnchorPointForGestureRecognizer(gestureRecognizer);

            if (gestureRecognizer.State == UIGestureRecognizerState.Began || gestureRecognizer.State == UIGestureRecognizerState.Changed)
            {
                
                ScaleToZoom(gestureRecognizer.Scale);
                gestureRecognizer.View.Transform *= CGAffineTransform.MakeScale(gestureRecognizer.Scale, gestureRecognizer.Scale);

                
                // Reset the gesture recognizer's scale - the next callback will get a delta from the current scale.

                gestureRecognizer.Scale = 1;

            }

        }

        // TODO: Properly convert scale to zoom.
        private void ScaleToZoom(nfloat scale)
        {
            // TODO: If zoom changes, reload new tiles at new zoom level.
            this.zoom += (int)Math.Floor(scale);
        }


        class GestureDelegate : UIGestureRecognizerDelegate
        {

            ViewController controller;



            public GestureDelegate(ViewController controller)

            {

                this.controller = controller;

            }



            public override bool ShouldReceiveTouch(UIGestureRecognizer aRecogniser, UITouch aTouch)

            {

                return true;

            }



            // Ensure that the pinch, pan and rotate gestures are all recognized simultaneously

            public override bool ShouldRecognizeSimultaneously(UIGestureRecognizer gestureRecognizer, UIGestureRecognizer otherGestureRecognizer)

            {

                // if the gesture recognizers's view isn't one of our images don't recognize

                /*   if (gestureRecognizer.View != controller.firstImage &&

                       gestureRecognizer.View != controller.secondImage &&

                       gestureRecognizer.View != controller.thirdImage)

                       return false;
                       */


                // if the gesture recognizers views differ, don't recognize

                if (gestureRecognizer.View != otherGestureRecognizer.View)

                    return false;



                // if either of the gesture recognizers is a long press, don't recognize

                if (gestureRecognizer is UILongPressGestureRecognizer || otherGestureRecognizer is UILongPressGestureRecognizer)

                    return false;



                return true;

            }

        }
    }
}

