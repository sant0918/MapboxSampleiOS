using ApiDefinition;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maps
{
    [Protocol, Register("MGLShape", true)]
    public class Shape : NSObject, IAnnotation, INativeObject, IDisposable
    {
        
        private static readonly IntPtr class_ptr = Class.GetHandle("MGLShape");

        public override IntPtr ClassHandle
        {
            get
            {
                return Shape.class_ptr;
            }
        }

        
        public virtual CLLocationCoordinate2D Coordinate
        {
            [Export("coordinate")]
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
        }

        
        public virtual string Subtitle
        {
            [Export("subtitle")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return NSString.FromHandle(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("subtitle")));
                }
                return NSString.FromHandle(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("subtitle")));
            }
            [Export("setSubtitle:")]
            set
            {
                IntPtr intPtr = NSString.CreateNative(value);
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("setSubtitle:"), intPtr);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("setSubtitle:"), intPtr);
                }
                NSString.ReleaseNative(intPtr);
            }
        }

        
        public virtual string Title
        {
            [Export("title")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return NSString.FromHandle(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("title")));
                }
                return NSString.FromHandle(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("title")));
            }
            [Export("setTitle:")]
            set
            {
                IntPtr intPtr = NSString.CreateNative(value);
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("setTitle:"), intPtr);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("setTitle:"), intPtr);
                }
                NSString.ReleaseNative(intPtr);
            }
        }

        [Export("init"), EditorBrowsable(EditorBrowsableState.Advanced)]
        public Shape() : base(NSObjectFlag.Empty)
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
        protected Shape(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal Shape(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }
    }
}
