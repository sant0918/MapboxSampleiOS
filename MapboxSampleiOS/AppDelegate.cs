using Foundation;
using UIKit;
using SVGKit;
using System;
using System.IO;
using CoreGraphics;

namespace StateMaps
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register ("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        public static AppDelegate Self { get; private set; }
        public ViewController viewController;

        public override UIWindow Window {
            get;
            set;
        }

        
        public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
        {
            AppDelegate.Self = this;
            //Window = new UIWindow(UIScreen.MainScreen.Bounds);
            //if(UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
            //{
            //    viewController = new ViewController("MainViewController", null);
            //}
            //else
            //{
            //    viewController = new ViewController("MapViewController_ipad", null);
            //}
            //Window.RootViewController = this.viewController;
            // Window.MakeKeyAndVisible();

            return true;
        }

        
        public override void DidEnterBackground(UIApplication application)
        {
            Console.WriteLine("App entering background state.");
        }

        public override void WillEnterForeground(UIApplication application)
        {
            Console.WriteLine("App will enter foreground");
        }

    }
}


