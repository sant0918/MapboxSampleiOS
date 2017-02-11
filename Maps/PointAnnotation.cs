using ApiDefinition;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maps
{
    [Register("MGLPointAnnotation", true)]
    public class PointAnnotation : Shape
    {
        
        private static readonly IntPtr class_ptr = Class.GetHandle("MGLPointAnnotation");

        public override IntPtr ClassHandle
        {
            get
            {
                return PointAnnotation.class_ptr;
            }
        }

        
        public new virtual CLLocationCoordinate2D Coordinate
        {
            [Export("coordinate", ArgumentSemantic.Assign)]
            get
            {
                CLLocationCoordinate2D result;
                if (base.IsDirectBinding)
                {
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
                }
                else if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.CLLocationCoordinate2D_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("coordinate"));
                    }
                    else
                    {
                        Messaging.CLLocationCoordinate2D_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("coordinate"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    result = Messaging.CLLocationCoordinate2D_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("coordinate"));
                }
                else
                {
                    Messaging.CLLocationCoordinate2D_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("coordinate"));
                }
                return result;
            }
            [Export("setCoordinate:", ArgumentSemantic.Assign)]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_CLLocationCoordinate2D(base.Handle, Selector.GetHandle("setCoordinate:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_CLLocationCoordinate2D(base.SuperHandle, Selector.GetHandle("setCoordinate:"), value);
                }
            }
        }

        [Export("init"), EditorBrowsable(EditorBrowsableState.Advanced)]
        public PointAnnotation() : base(NSObjectFlag.Empty)
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
        protected PointAnnotation(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal PointAnnotation(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }
    }
}
