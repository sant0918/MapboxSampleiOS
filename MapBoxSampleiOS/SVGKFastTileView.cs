using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using SVGKit;
using CoreGraphics;
using CoreLocation;
using System.IO;
using UIKit;
using CoreAnimation;

namespace MapBoxSampleiOS
{
    public class SVGKFastTileView : SVGKFastImageView
    {
		CLLocation loc;
        GlobalMapTiles gmt;
        SVGKImage svgImage;
        UIRotationGestureRecognizer rotateGesture;
        UIPanGestureRecognizer panGesture;

        public SVGKFastTileView(SVGKImage svgImage) : base (svgImage)
        {
            this.svgImage = svgImage;
        }

        public SVGKFastTileView(CGRect frame) : base (frame)
        {

        }

        public override void Draw(CGRect area)
        {
            base.Draw(area);
			const int ZOOM = 16;
			this.svgImage = SVGKImage.ImageNamed(Path.Combine("tiles/", ZOOM.ToString() + "/" + "BL-NY.svg"));

            CGRect imageBounds = new CGRect(0, 0, this.svgImage.Size.Width, this.svgImage.Size.Height);
            

            var context = UIGraphics.GetCurrentContext();
            context.SaveState();
            
            CGSize tileSize = new CGSize(256, 256);
			this.svgImage.Size = tileSize;
            context.TranslateCTM(0, 0);
			//context.ScaleCTM(-10, -10);

            
            int firstCol = (int)Math.Floor(area.GetMinX() / tileSize.Width);
            int lastCol = (int)Math.Floor((area.GetMaxX() - 1) / tileSize.Width);
            int firstRow = (int)Math.Floor(area.GetMinY() / tileSize.Height);
            int lastRow = (int)Math.Floor((area.GetMaxY() - 1) / tileSize.Height);

            
            //this.Layer.AddSublayer(svgImage.CALayerTree); 
            this.svgImage.CALayerTree.RenderInContext(context);

			context.RestoreState();

            this.svgImage = SVGKImage.ImageNamed(Path.Combine("tiles/", ZOOM.ToString() + "/" + "BR-NY.svg"));

            
            context = UIGraphics.GetCurrentContext();
            context.SaveState();

            
            this.svgImage.Size = tileSize;
            context.TranslateCTM(256, 0);
            //context.ScaleCTM(-10, -10);

            this.svgImage.CALayerTree.RenderInContext(context);

            context.RestoreState();
            SetGestures();
        }

        public SVGKImage getTile(int zoom, int col, int row)
		{
			string path = "tiles/";

			string pngFilename = Path.Combine(path, zoom.ToString() + "/" + col.ToString() + "/" + row.ToString() + ".svg");

			return SVGKImage.ImageNamed(pngFilename);
		}

        public SVGKImage getTile(int zoom)
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

            return SVGKImage.ImageNamed(pngFilename);
        }

        private void SetGestures()
        {
            nfloat r = 0;
            nfloat dx = 0;
            nfloat dy = 0;
            this.rotateGesture = new UIRotationGestureRecognizer(() =>
            {
                if ((rotateGesture.State == UIGestureRecognizerState.Began || rotateGesture.State == UIGestureRecognizerState.Changed)
                && rotateGesture.NumberOfTouches == 2)
                {
                    this.Transform = CGAffineTransform.MakeRotation(rotateGesture.Rotation + r);
                }
                else if (rotateGesture.State == UIGestureRecognizerState.Ended)
                {
                    r += rotateGesture.Rotation;
                }
            });

            this.panGesture = new UIPanGestureRecognizer(() =>
            {
                if ((panGesture.State == UIGestureRecognizerState.Began || panGesture.State == UIGestureRecognizerState.Changed)
                 && panGesture.NumberOfTouches == 1)
                {
                    var p0 = panGesture.LocationInView(View);

                    if (dx == 0)
                        dx = p0.X - this.Center.X;

                    if (dy == 0)
                        dy = p0.Y - this.Center.Y;

                    var p1 = new CGPoint(p0.X - dx, p0.Y - dy);
                    this.Center = p1;
                }
                else if (panGesture.State == UIGestureRecognizerState.Ended)
                {
                    dx = 0;
                    dy = 0;
                }

            });
        }

    }
}