using System;
using CoreGraphics;
using System.Linq;
using UIKit;
using Foundation;
using ObjCRuntime;

namespace MapboxSampleiOS
{
    public partial class ViewController : UIViewController

    {

        
        public ViewController(UIWindow window, string nibName, NSBundle bundle) : base(nibName, bundle)

        {

        }



        #region Tearing down

        
        #endregion



        




        // Add gesture recognizers to one of our images

        void AddGestureRecognizersToImage(UIImageView image)

        {

            image.UserInteractionEnabled = true;



            var rotationGesture = new UIRotationGestureRecognizer(RotateImage);

            image.AddGestureRecognizer(rotationGesture);



            var pinchGesture = new UIPinchGestureRecognizer(ScaleImage);

            pinchGesture.Delegate = new GestureDelegate(this);

            image.AddGestureRecognizer(pinchGesture);



            var panGesture = new UIPanGestureRecognizer(PanImage);

            panGesture.MaximumNumberOfTouches = 2;

            panGesture.Delegate = new GestureDelegate(this);

            image.AddGestureRecognizer(panGesture);



            //var longPressGesture = new UILongPressGestureRecognizer(ShowResetMenu);

            //image.AddGestureRecognizer(longPressGesture);

        }

        
        #region Utility methods

        // Scale and rotation transforms are applied relative to the layer's anchor point.

        // This method moves a UIGestureRecognizer's view anchor point between the user's fingers

       



        // Reset image to the default anchor point and transform

        [Export("ResetImage:")]

        void ResetImage(UIMenuController controller)

        {

            var mid = new CGPoint((imageForReset.Bounds.Left + imageForReset.Bounds.Right) / 2, (imageForReset.Bounds.Top + imageForReset.Bounds.Bottom) / 2);

            var locationInSuperview = imageForReset.ConvertPointToView(mid, imageForReset.Superview);

            imageForReset.Layer.AnchorPoint = new CGPoint(0.5f, 0.5f);

            imageForReset.Center = locationInSuperview;



            UIView.BeginAnimations(null, IntPtr.Zero);

            imageForReset.Transform = CoreGraphics.CGAffineTransform.MakeIdentity();

            UIView.CommitAnimations();

        }



        // UIMenuController requires that we can become first responder - otherwise it won't display

        public override bool CanBecomeFirstResponder
        {

            get
            {

                return true;

            }

        }

        #endregion



        #region Touch handling

       


        

        #endregion

    }
}
