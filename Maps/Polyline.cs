using ApiDefinition;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maps
{
    [Protocol, Register("MGLPolyline", true)]
    public class Polyline : MultiPoint, IOverlay, INativeObject, IDisposable, IAnnotation
    {
       
        private static readonly IntPtr class_ptr = Class.GetHandle("MGLPolyline");

        public override IntPtr ClassHandle
        {
            get
            {
                return Polyline.class_ptr;
            }
        }

       
        public virtual CoordinateBounds OverlayBounds
        {
            [Export("overlayBounds")]
            get
            {
                CoordinateBounds result;
                if (base.IsDirectBinding)
                {
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
                }
                else if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.CoordinateBounds_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("overlayBounds"));
                    }
                    else
                    {
                        Messaging.CoordinateBounds_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("overlayBounds"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    Messaging.CoordinateBounds_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("overlayBounds"));
                }
                else
                {
                    Messaging.CoordinateBounds_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("overlayBounds"));
                }
                return result;
            }
        }

        [Export("init"), EditorBrowsable(EditorBrowsableState.Advanced)]
        public Polyline() : base(NSObjectFlag.Empty)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
            if (base.IsDirectBinding)
            {
                base.InitializeHandle(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("init")), "init");
            }
            else
            {
                base.InitializeHandle(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("init")), "init");
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected Polyline(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal Polyline(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        public static Polyline WithCoordinates(CLLocationCoordinate2D[] coords, nuint count)
        {
            return Polyline.WithCoordinates(Polyline.GetPointer(coords), count);
        }

        internal unsafe static IntPtr GetPointer(CLLocationCoordinate2D[] coordinates)
        {
            fixed (void* coord = &coordinates[0])
            {
                return (IntPtr)coord;
            }
            //return (IntPtr)((void*)(&coordinates[0]));
        }

        [Export("intersectsOverlayBounds:")]
        public virtual bool IntersectsOverlayBounds(CoordinateBounds overlayBounds)
        {
            if (base.IsDirectBinding)
            {
                return Messaging.bool_objc_msgSend_CoordinateBounds(base.Handle, Selector.GetHandle("intersectsOverlayBounds:"), overlayBounds);
            }
            return Messaging.bool_objc_msgSendSuper_CoordinateBounds(base.SuperHandle, Selector.GetHandle("intersectsOverlayBounds:"), overlayBounds);
        }

        [Export("polylineWithCoordinates:count:")]
        public static Polyline WithCoordinates(IntPtr coords, nuint count)
        {
            return Runtime.GetNSObject<Polyline>(Messaging.IntPtr_objc_msgSend_IntPtr_nuint(Polyline.class_ptr, Selector.GetHandle("polylineWithCoordinates:count:"), coords, count));
        }
    }
}
