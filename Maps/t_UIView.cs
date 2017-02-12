﻿using ApiDefinition;
using CoreAnimation;
using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using UIKit;

namespace Maps
{
    public class t_UIView : UIView
    {
        public t_UIView (CGRect frame) : base (frame)
        {

        }

        /*
         If your object will be deserialized from an archive produced by the UI 
         designer, you would need to chain to the UIView.UIView(NSCoder) constructor 
         and also flag the constructor as being the one implementing the selector 
         "initWithCoder:", 
         */
         [Export("initiWithCoder:")]
         public t_UIView (NSCoder coder): base (coder)
        {

        }

        public void Draw(RectangleF rect)
        {
            base.Draw(rect);

            var context = UIGraphics.GetCurrentContext();

            context.SetLineWidth(4);
            UIColor.Red.SetFill();
            UIColor.Blue.SetStroke();

            var path = new CGPath();

            path.AddLines(new CGPoint[]{
        new PointF(100,200),
        new PointF(160,100),
        new PointF(220,200)
    });

            path.CloseSubpath();

            context.AddPath(path);
            context.DrawPath(CGPathDrawingMode.FillStroke);
        }
    }
}
