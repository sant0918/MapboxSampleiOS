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
     //   public static AppDelegate Self { get; private set; }
        
        public override UIWindow Window {
            get;
            set;
        }

        
        public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
        {
       //     AppDelegate.Self = this;
            return true;
        }

       // public override void DidEnterBackground(UIApplication application)
       // {
          //  Console.WriteLine("App entering background state.");
       // }

       // public override void WillEnterForeground(UIApplication application)
       // {
           // Console.WriteLine("App will enter foreground");
       // }

    }
}


