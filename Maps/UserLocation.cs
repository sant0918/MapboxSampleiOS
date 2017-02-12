using ApiDefinition;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maps
{
    [Protocol, Register("MGLUserLocation", true)]
    public class UserLocation : NSObject, IAnnotation, INativeObject, IDisposable
    {
        
        private static readonly IntPtr class_ptr = Class.GetHandle("MGLUserLocation");

        public override IntPtr ClassHandle
        {
            get
            {
                return UserLocation.class_ptr;
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

        
        public virtual CLHeading Heading
        {
            [Export("heading")]
            get
            {
                CLHeading nSObject;
                if (base.IsDirectBinding)
                {
                    nSObject = Runtime.GetNSObject<CLHeading>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("heading")));
                }
                else
                {
                    nSObject = Runtime.GetNSObject<CLHeading>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("heading")));
                }
                return nSObject;
            }
        }

        
        public virtual CLLocation Location
        {
            [Export("location")]
            get
            {
                CLLocation nSObject;
                if (base.IsDirectBinding)
                {
                    nSObject = Runtime.GetNSObject<CLLocation>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("location")));
                }
                else
                {
                    nSObject = Runtime.GetNSObject<CLLocation>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("location")));
                }
                return nSObject;
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
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
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

        
        public virtual bool Updating
        {
            [Export("isUpdating")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("isUpdating"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("isUpdating"));
            }
        }

        [Export("init"), EditorBrowsable(EditorBrowsableState.Advanced)]
        public UserLocation() : base(NSObjectFlag.Empty)
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
        protected UserLocation(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal UserLocation(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }
    }
}
