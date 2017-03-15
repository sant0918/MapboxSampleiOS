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

            RenderSVgImages();



            return true;
        }
        public void RenderSVgImages()
        {
            const int ZOOM = 9;
            //this.svgImage = SVGKImage.ImageNamed(Path.Combine("tiles/", ZOOM.ToString() + "/" + "BL-NY.svg"));

            //CGRect imageBounds = new CGRect(0, 0, this.svgImage.Size.Width, this.svgImage.Size.Height);


            var context = UIGraphics.GetCurrentContext();

            //context.ScaleCTM(-10, -10);

            // TODO : replace with coordinate location
            int firstCol = 148;
            int lastCol = 148;
            int firstRow = 189;
            int lastRow = 189;
            int c;
            int r = 0;
            //this.Layer.AddSublayer(svgImage.CALayerTree); 
            //this.svgImage.CALayerTree.RenderInContext(context);

            for (int row = firstRow; row <= lastRow; row++)
            {
                c = 0;
                for (int col = firstCol; col <= lastCol; col++)
                {
                    context.SaveState();
                    context.TranslateCTM(tileSize.Width * c, tileSize.Height * r);

                    this.svgImage = getTile(ZOOM, col, row);
                    this.svgImage.Size = tileSize;

                    this.svgImage.CALayerTree.RenderInContext(context);

                    context.RestoreState();
                    c++;

                }
                r++;

            }
        }
        public static SVGKImage getTile(int zoom, int col, int row)
        {
            string path = "tiles/";

            string pngFilename = Path.Combine(path, zoom.ToString() + "/" + col.ToString() + "/" + row.ToString() + "/tile.svg");

            return SVGKImage.ImageNamed(pngFilename);
        }

    }
}


