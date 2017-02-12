using ApiDefinition;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maps
{
    [Protocol, Register("MGLPolygon", true)]
    public class Polygon : MultiPoint, IOverlay, INativeObject, IDisposable, IAnnotation
    {
        
        private static readonly IntPtr class_ptr = Class.GetHandle("MGLPolygon");

        public override IntPtr ClassHandle
        {
            get
            {
                return Polygon.class_ptr;
            }
        }

        
        public virtual Polygon[] InteriorPolygons
        {
            [Export("interiorPolygons")]
            get
            {
                Polygon[] result;
                if (base.IsDirectBinding)
                {
                    result = NSArray.ArrayFromHandle<Polygon>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("interiorPolygons")));
                }
                else
                {
                    result = NSArray.ArrayFromHandle<Polygon>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("interiorPolygons")));
                }
                return result;
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
        public Polygon() : base(NSObjectFlag.Empty)
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
        protected Polygon(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal Polygon(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        public static Polygon WithCoordinates(CLLocationCoordinate2D[] coords, nuint count)
        {
            return Polygon.WithCoordinates(Polygon.GetPointer(coords), count);
        }

        internal unsafe static IntPtr GetPointer(CLLocationCoordinate2D[] coordinates)
        {
            
            fixed (void* coord = &coordinates[0] )
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

        [Export("polygonWithCoordinates:count:")]
        public static Polygon WithCoordinates(IntPtr coords, nuint count)
        {
            return Runtime.GetNSObject<Polygon>(Messaging.IntPtr_objc_msgSend_IntPtr_nuint(Polygon.class_ptr, Selector.GetHandle("polygonWithCoordinates:count:"), coords, count));
        }

        [Export("polygonWithCoordinates:count:interiorPolygons:")]
        public static Polygon WithCoordinates(IntPtr coords, nuint count, Polygon[] interiorPolygons)
        {
            NSArray nSArray = (interiorPolygons != null) ? NSArray.FromNSObjects(interiorPolygons) : null;
            Polygon nSObject = Runtime.GetNSObject<Polygon>(Messaging.IntPtr_objc_msgSend_IntPtr_nuint_IntPtr(Polygon.class_ptr, Selector.GetHandle("polygonWithCoordinates:count:interiorPolygons:"), coords, count, (nSArray != null) ? nSArray.Handle : IntPtr.Zero));
            if (nSArray != null)
            {
                nSArray.Dispose();
            }
            return nSObject;
        }
    }
}
