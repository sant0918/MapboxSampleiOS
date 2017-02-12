using ApiDefinition;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maps
{
    [Protocol, Register("MGLMapCamera", true)]
    public class MapCamera : NSObject, INSCoding, INSCopying, INSSecureCoding, INativeObject, IDisposable
    {
       
        private static readonly IntPtr class_ptr = Class.GetHandle("MGLMapCamera");

        public override IntPtr ClassHandle
        {
            get
            {
                return MapCamera.class_ptr;
            }
        }

       
        public virtual double Altitude
        {
            [Export("altitude")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.Double_objc_msgSend(base.Handle, Selector.GetHandle("altitude"));
                }
                return Messaging.Double_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("altitude"));
            }
            [Export("setAltitude:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_Double(base.Handle, Selector.GetHandle("setAltitude:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_Double(base.SuperHandle, Selector.GetHandle("setAltitude:"), value);
                }
            }
        }

       
        public virtual CLLocationCoordinate2D CenterCoordinate
        {
            [Export("centerCoordinate", ArgumentSemantic.Assign)]
            get
            {
                CLLocationCoordinate2D result;
                if (base.IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            result = Messaging.CLLocationCoordinate2D_objc_msgSend(base.Handle, Selector.GetHandle("centerCoordinate"));
                        }
                        else
                        {
                            Messaging.CLLocationCoordinate2D_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("centerCoordinate"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        result = Messaging.CLLocationCoordinate2D_objc_msgSend(base.Handle, Selector.GetHandle("centerCoordinate"));
                    }
                    else
                    {
                        Messaging.CLLocationCoordinate2D_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("centerCoordinate"));
                    }
                }
                else if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.CLLocationCoordinate2D_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("centerCoordinate"));
                    }
                    else
                    {
                        Messaging.CLLocationCoordinate2D_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("centerCoordinate"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    result = Messaging.CLLocationCoordinate2D_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("centerCoordinate"));
                }
                else
                {
                    Messaging.CLLocationCoordinate2D_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("centerCoordinate"));
                }
                return result;
            }
            [Export("setCenterCoordinate:", ArgumentSemantic.Assign)]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_CLLocationCoordinate2D(base.Handle, Selector.GetHandle("setCenterCoordinate:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_CLLocationCoordinate2D(base.SuperHandle, Selector.GetHandle("setCenterCoordinate:"), value);
                }
            }
        }

       
        public virtual double Heading
        {
            [Export("heading")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.Double_objc_msgSend(base.Handle, Selector.GetHandle("heading"));
                }
                return Messaging.Double_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("heading"));
            }
            [Export("setHeading:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_Double(base.Handle, Selector.GetHandle("setHeading:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_Double(base.SuperHandle, Selector.GetHandle("setHeading:"), value);
                }
            }
        }

       
        public virtual nfloat Pitch
        {
            [Export("pitch")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.nfloat_objc_msgSend(base.Handle, Selector.GetHandle("pitch"));
                }
                return Messaging.nfloat_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("pitch"));
            }
            [Export("setPitch:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_nfloat(base.Handle, Selector.GetHandle("setPitch:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_nfloat(base.SuperHandle, Selector.GetHandle("setPitch:"), value);
                }
            }
        }

        [Export("init"), EditorBrowsable(EditorBrowsableState.Advanced)]
        public MapCamera() : base(NSObjectFlag.Empty)
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

        [Export("initWithCoder:"), DesignatedInitializer, EditorBrowsable(EditorBrowsableState.Advanced)]
        public MapCamera(NSCoder coder) : base(NSObjectFlag.Empty)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
            if (base.IsDirectBinding)
            {
                base.InitializeHandle(Messaging.IntPtr_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("initWithCoder:"), coder.Handle), "initWithCoder:");
            }
            else
            {
                base.InitializeHandle(Messaging.IntPtr_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("initWithCoder:"), coder.Handle), "initWithCoder:");
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected MapCamera(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal MapCamera(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [Export("camera")]
        public static MapCamera Camera()
        {
            return Runtime.GetNSObject<MapCamera>(Messaging.IntPtr_objc_msgSend(MapCamera.class_ptr, Selector.GetHandle("camera")));
        }

        [Export("cameraLookingAtCenterCoordinate:fromEyeCoordinate:eyeAltitude:")]
        public static MapCamera CameraLookingAtCenterCoordinate(CLLocationCoordinate2D centerCoordinate, CLLocationCoordinate2D eyeCoordinate, double eyeAltitude)
        {
            return Runtime.GetNSObject<MapCamera>(Messaging.IntPtr_objc_msgSend_CLLocationCoordinate2D_CLLocationCoordinate2D_Double(MapCamera.class_ptr, Selector.GetHandle("cameraLookingAtCenterCoordinate:fromEyeCoordinate:eyeAltitude:"), centerCoordinate, eyeCoordinate, eyeAltitude));
        }

        [Export("cameraLookingAtCenterCoordinate:fromDistance:pitch:heading:")]
        public static MapCamera CameraLookingAtCenterCoordinate(CLLocationCoordinate2D centerCoordinate, double distance, nfloat pitch, double heading)
        {
            return Runtime.GetNSObject<MapCamera>(Messaging.IntPtr_objc_msgSend_CLLocationCoordinate2D_Double_nfloat_Double(MapCamera.class_ptr, Selector.GetHandle("cameraLookingAtCenterCoordinate:fromDistance:pitch:heading:"), centerCoordinate, distance, pitch, heading));
        }

        [Export("copyWithZone:"), Preserve(Conditional = true)]
        public virtual NSObject Copy(NSZone zone)
        {
            if (zone == null)
            {
                throw new ArgumentNullException("zone");
            }
            if (base.IsDirectBinding)
            {
                return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("copyWithZone:"), zone.Handle));
            }
            return Runtime.GetNSObject(Messaging.IntPtr_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("copyWithZone:"), zone.Handle));
        }

        [Export("encodeWithCoder:"), Preserve(Conditional = true)]
        public virtual void EncodeTo(NSCoder encoder)
        {
            if (encoder == null)
            {
                throw new ArgumentNullException("encoder");
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("encodeWithCoder:"), encoder.Handle);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("encodeWithCoder:"), encoder.Handle);
            }
        }
    }
}
