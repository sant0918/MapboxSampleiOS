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

       
        ImageTileView image;
        SVGKFastTileView svgImage;
        UIImageView imagen;        
        UIRotationGestureRecognizer rotateGesture;
        UIPanGestureRecognizer panGesture;

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            
            nfloat r = 0;            
            nfloat dx = 0;
            nfloat dy = 0;

            //testView = new t_UIView(View.Bounds);
            //View.AddSubview(testView);

            //testView.Layer.CornerRadius = 4;
            //testView.Layer.ShadowColor = new CGColor(1, 0, 0);
            //testView.Layer.ShadowOpacity = 1.0f;
            //testView.Layer.ShadowOffset = new SizeF(0, 4);
            //testView.BackgroundColor = UIColor.Black;
			/*
            UIImage pictura;
            using (UIImage foto = UIImage.FromBundle("mapserv.png"))
             {
                imagen = new UIImageView(foto);
                imagen.UserInteractionEnabled = true;
                View.AddSubview(imagen);
                imagen.Frame = new CGRect(10, 10, imagen.Image.CGImage.Width, imagen.Image.CGImage.Height);

             }*/
			SVGKImage im = SVGKImage.ImageNamed("newyork.svg");
            im.Size = new CGSize(View.Bounds.GetMaxX(), View.Bounds.GetMaxY());
			double half = 1.0 / 2.0;
			SVGKImageView iv = new SVGKFastImageView(im);
			View.AddSubview(iv);


            svgImage = new SVGKFastTileView(View.Bounds);
            svgImage.UserInteractionEnabled = true;
            View.AddSubview(svgImage);

            rotateGesture = new UIRotationGestureRecognizer(() =>
            {
                if ((rotateGesture.State == UIGestureRecognizerState.Began || rotateGesture.State == UIGestureRecognizerState.Changed)
                && rotateGesture.NumberOfTouches == 2)
                {
                    svgImage.Transform = CGAffineTransform.MakeRotation(rotateGesture.Rotation + r);
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
                        dx = p0.X - svgImage.Center.X;

                    if (dy == 0)
                        dy = p0.Y - svgImage.Center.Y;

                    var p1 = new CGPoint(p0.X - dx, p0.Y - dy);
                    svgImage.Center = p1;
                }
                else if (panGesture.State == UIGestureRecognizerState.Ended)
                {
                    dx = 0;
                    dy = 0;
                }

            });

            svgImage.AddGestureRecognizer(panGesture);
            svgImage.AddGestureRecognizer(rotateGesture);
            /*
            // adds maps to view
            image = new ImageTileView(View.Bounds);
            image.UserInteractionEnabled = true;
            View.AddSubview(image);
            

            rotateGesture = new UIRotationGestureRecognizer(() =>
            {
                if((rotateGesture.State == UIGestureRecognizerState.Began || rotateGesture.State == UIGestureRecognizerState.Changed) 
                && rotateGesture.NumberOfTouches == 2)
                {
                    image.Transform = CGAffineTransform.MakeRotation(rotateGesture.Rotation + r);
                } else if ( rotateGesture.State == UIGestureRecognizerState.Ended){
                    r += rotateGesture.Rotation;
                }
            });

            panGesture = new UIPanGestureRecognizer(() =>
            {
                if((panGesture.State == UIGestureRecognizerState.Began || panGesture.State == UIGestureRecognizerState.Changed) 
                 && panGesture.NumberOfTouches == 1)
                {
                    var p0 = panGesture.LocationInView(View);

                    if (dx == 0)
                        dx = p0.X - image.Center.X;

                    if (dy == 0)
                        dy = p0.Y - image.Center.Y;
                    
                    var p1 = new CGPoint(p0.X- dx, p0.Y - dy);
                    image.Center = p1;
                } else if (panGesture.State == UIGestureRecognizerState.Ended)
                {
                    dx = 0;
                    dy = 0;
                }

            });
            
            image.AddGestureRecognizer(panGesture);
            image.AddGestureRecognizer(rotateGesture);*/

        }


        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();

            // Cleanup anything possible
           // mapView.EmptyMemoryCache ();
        }
    }
}

