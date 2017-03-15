using Foundation;
using UIKit;
using SVGKit;
using System.IO;
using CoreGraphics;

namespace MapBoxSampleiOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register ("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window {
            get;
            set;
        }

        SVGKImage svgImage;
        CGSize tileSize;

        public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
        {
            
            return true;
        }
       
    }
}


