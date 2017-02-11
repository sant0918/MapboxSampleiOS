using ApiDefinition;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using System;
using System.Runtime.CompilerServices;

namespace Maps
{
    internal sealed class OverlayWrapper : BaseWrapper, IOverlay, INativeObject, IDisposable, IAnnotation
    {
        
        public CoordinateBounds OverlayBounds
        {
            [Export("overlayBounds")]
            get
            {
                CoordinateBounds result;
                if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.CoordinateBounds_objc_msgSend(base.Handle, Selector.GetHandle("overlayBounds"));
                    }
                    else
                    {
                        Messaging.CoordinateBounds_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("overlayBounds"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    Messaging.CoordinateBounds_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("overlayBounds"));
                }
                else
                {
                    Messaging.CoordinateBounds_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("overlayBounds"));
                }
                return result;
            }
        }

        
        public CLLocationCoordinate2D Coordinate
        {
            [Export("coordinate")]
            get
            {
                CLLocationCoordinate2D result;
                if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.CLLocationCoordinate2D_objc_msgSend(base.Handle, Selector.GetHandle("coordinate"));
                    }
                    else
                    {
                        Messaging.CLLocationCoordinate2D_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("coordinate"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    result = Messaging.CLLocationCoordinate2D_objc_msgSend(base.Handle, Selector.GetHandle("coordinate"));
                }
                else
                {
                    Messaging.CLLocationCoordinate2D_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("coordinate"));
                }
                return result;
            }
        }

        public OverlayWrapper(IntPtr handle) : base(handle, false)
        {
        }

        [Preserve(Conditional = true)]
        public OverlayWrapper(IntPtr handle, bool owns) : base(handle, owns)
        {
        }

        [Export("intersectsOverlayBounds:")]
        public bool IntersectsOverlayBounds(CoordinateBounds overlayBounds)
        {
            return Messaging.bool_objc_msgSend_CoordinateBounds(base.Handle, Selector.GetHandle("intersectsOverlayBounds:"), overlayBounds);
        }
    }
}
