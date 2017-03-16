using CoreAnimation;
using CoreGraphics;
using CoreLocation;
using Foundation;
using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using UIKit;
using GLKit;

namespace StateMaps
{
    public class ImageTileView : UIView
    {

        CLLocation loc;
        GlobalMapTiles gmt;
        public ImageTileView(CGRect frame) : base (frame)
        {
            
        }

        /*
         If your object will be deserialized from an archive produced by the UI 
         designer, you would need to chain to the UIView.UIView(NSCoder) constructor 
         and also flag the constructor as being the one implementing the selector 
         "initWithCoder:", 
         */
        [Export("initiWithCoder:")]
        public ImageTileView(NSCoder coder): base (coder)
        {
             loc = new CLLocation();
             gmt = new GlobalMapTiles();
        }

        public override void Draw(CGRect area)
        {
            base.Draw(area);
            const int ZOOM = 4;

            var context = UIGraphics.GetCurrentContext();

            CGSize tileSize = new CGSize(256, 256);

            int firstCol = (int)Math.Floor(area.GetMinX() / tileSize.Width);
            int lastCol = (int)Math.Floor((area.GetMaxX() - 1) / tileSize.Width);
            int firstRow = (int)Math.Floor(area.GetMinY() / tileSize.Height);
            int lastRow = (int)Math.Floor((area.GetMaxY() - 1) / tileSize.Height);

            UIImage que = getTile(16);
            for (int row = firstRow; row <= lastRow; row++) { 
                for (int col = firstCol; col <= lastCol; col++)
                {
                    UIImage tile = getTile(ZOOM,col, row);
                    
                    CGRect tileRect = new CGRect(tileSize.Width * col,
                                                tileSize.Height * row,
                                                tileSize.Width,
                                                tileSize.Height);
                    tileRect.Intersect(tileRect);

                    tile.DrawAsPatternInRect(tileRect);
                    
                }

            }
        } // end DrawRect

        public void SaveTiles(CGSize size, UIImage image, NSString directoryPath, NSString prefix)
        {
            NSData imageData;
            nfloat cols = image.Size.Width / size.Width;
            nfloat rows = image.Size.Height / size.Height;

            int fullColumns = (int)Math.Floor(cols);
            int fullRows = (int)Math.Floor(rows);

            nfloat remainderWidth = image.Size.Width - (fullColumns * size.Width);
            nfloat remainderHeight = image.Size.Height - (fullRows * size.Height);

            if (cols > fullColumns)
                fullColumns++;

            if (rows > fullRows)
                fullRows++;

            CGImage fullImage = image.CGImage;

            for (int y =0; y < fullRows; ++y)
            {
                for (int x = 0; x < fullColumns; ++x)
                {
                    CGSize tileSize = size;
                    if(x + 1 == fullColumns && remainderWidth > 0)
                    {
                        // Last column
                        tileSize.Width = remainderWidth;
                    }
                    if ( y+ 1 == fullRows && remainderHeight > 0)
                    {
                        // Last row
                        tileSize.Height = remainderHeight;
                    }

                    using (CGImage tileImage = fullImage.WithImageInRect((
                        new CGRect(
                            new CGPoint(x * size.Width, y * size.Height), tileSize))))
                    {
                        imageData = new UIImage(tileImage).AsPNG();
                    }

                    var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                    string pngFilename = System.IO.Path.Combine(path, x.ToString() + y.ToString());
                    imageData.Save(pngFilename, false);
                    
                }
            }
        }

        public UIImage getTile(int zoom, int col, int row)
        {
            string path = "tiles/";
            
            string pngFilename = Path.Combine(path, zoom.ToString() + "/" + col.ToString() + "/" + row.ToString() + ".png");

            return UIImage.FromFile(pngFilename);
        }
        
        
        
        public UIImage getTile(int zoom)
        {
            Tuple<double, double> metersXY = gmt.LatLonToMeters(loc.Coordinate.Latitude, loc.Coordinate.Longitude);
            Tuple<int, int> tilesMinXY = gmt.MetersToTile(metersXY.Item1, metersXY.Item2, zoom);
            Tuple<int, int> tilesMaxXY = tilesMinXY;

            for (int ty = tilesMinXY.Item2; ty <= tilesMaxXY.Item2; ty++)
            {
                for (int tx = tilesMinXY.Item1; tx <= tilesMaxXY.Item1; tx++)
                {
                    Tuple<int, int> googleTiles = gmt.GoogleTile(tx, ty, zoom);

                    // TODO: fetch tiles from mapserver.
                }
            }

            string path = "tiles/";

            string pngFilename = Path.Combine(path, zoom.ToString());

            return UIImage.FromFile(pngFilename);
        }

    } // end of class
}
