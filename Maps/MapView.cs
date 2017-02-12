using ApiDefinition;
using CoreAnimation;
using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using ObjCR;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UIKit;

namespace Maps
{
    [Protocol, Register("MGLMapView", true)]
    public class MapView : UIView
    {
        public class MapViewAppearance : UIView.UIViewAppearance
        {
            protected internal MapViewAppearance(IntPtr handle) : base(handle)
            {
            }
        }

        private const string frameworkPath = "Frameworks/Mapbox.framework/Mapbox";

        public static readonly nfloat DecelerationRateNormal = UIScrollView.DecelerationRateNormal;

        public static readonly nfloat DecelerationRateFast = UIScrollView.DecelerationRateFast;

        public static readonly nfloat DecelerationRateImmediate = 0f;

        
        private static readonly IntPtr class_ptr = Class.GetHandle("MGLMapView");

        
        private object __mt_Delegate_var;

        
        private object __mt_StyleURL_var;

        public override IntPtr ClassHandle
        {
            get
            {
                return MapView.class_ptr;
            }
        }

        
        public virtual bool AllowsRotating
        {
            [Export("allowsRotating")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("allowsRotating"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("allowsRotating"));
            }
            [Export("setAllowsRotating:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setAllowsRotating:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setAllowsRotating:"), value);
                }
            }
        }

        
        public virtual bool AllowsScrolling
        {
            [Export("allowsScrolling")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("allowsScrolling"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("allowsScrolling"));
            }
            [Export("setAllowsScrolling:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setAllowsScrolling:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setAllowsScrolling:"), value);
                }
            }
        }

        
        public virtual bool AllowsTilting
        {
            [Export("allowsTilting")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("allowsTilting"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("allowsTilting"));
            }
            [Export("setAllowsTilting:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setAllowsTilting:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setAllowsTilting:"), value);
                }
            }
        }

        
        public virtual bool AllowsZooming
        {
            [Export("allowsZooming")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("allowsZooming"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("allowsZooming"));
            }
            [Export("setAllowsZooming:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setAllowsZooming:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setAllowsZooming:"), value);
                }
            }
        }

        
        public virtual IAnnotation[] Annotations
        {
            [Export("annotations")]
            get
            {
                IAnnotation[] result;
                if (base.IsDirectBinding)
                {
                    result = NSArray.ArrayFromHandle<IAnnotation>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("annotations")));
                }
                else
                {
                    result = NSArray.ArrayFromHandle<IAnnotation>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("annotations")));
                }
                return result;
            }
        }

        
        public virtual UIButton AttributionButton
        {
            [Export("attributionButton")]
            get
            {
                UIButton nSObject;
                if (base.IsDirectBinding)
                {
                    nSObject = Runtime.GetNSObject<UIButton>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("attributionButton")));
                }
                else
                {
                    nSObject = Runtime.GetNSObject<UIButton>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("attributionButton")));
                }
                return nSObject;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Obsolete("Call the relevant class method of Style for the URL of a particular default style.", false)]
        public virtual NSUrl[] BundledStyleURLs
        {
            [Export("bundledStyleURLs")]
            get
            {
                NSUrl[] result;
                if (base.IsDirectBinding)
                {
                    result = NSArray.ArrayFromHandle<NSUrl>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("bundledStyleURLs")));
                }
                else
                {
                    result = NSArray.ArrayFromHandle<NSUrl>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("bundledStyleURLs")));
                }
                return result;
            }
        }

        
        public virtual MapCamera Camera
        {
            [Export("camera", ArgumentSemantic.Copy)]
            get
            {
                MapCamera nSObject;
                if (base.IsDirectBinding)
                {
                    nSObject = Runtime.GetNSObject<MapCamera>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("camera")));
                }
                else
                {
                    nSObject = Runtime.GetNSObject<MapCamera>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("camera")));
                }
                return nSObject;
            }
            [Export("setCamera:", ArgumentSemantic.Copy)]
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("setCamera:"), value.Handle);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("setCamera:"), value.Handle);
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

        
        public virtual UIImageView CompassView
        {
            [Export("compassView")]
            get
            {
                UIImageView nSObject;
                if (base.IsDirectBinding)
                {
                    nSObject = Runtime.GetNSObject<UIImageView>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("compassView")));
                }
                else
                {
                    nSObject = Runtime.GetNSObject<UIImageView>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("compassView")));
                }
                return nSObject;
            }
        }

        
        public virtual UIEdgeInsets ContentInset
        {
            [Export("contentInset", ArgumentSemantic.Assign)]
            get
            {
                UIEdgeInsets result;
                if (base.IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            result = Messaging.UIEdgeInsets_objc_msgSend(base.Handle, Selector.GetHandle("contentInset"));
                        }
                        else
                        {
                            Messaging.UIEdgeInsets_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("contentInset"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        Messaging.UIEdgeInsets_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("contentInset"));
                    }
                    else
                    {
                        Messaging.UIEdgeInsets_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("contentInset"));
                    }
                }
                else if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.UIEdgeInsets_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("contentInset"));
                    }
                    else
                    {
                        Messaging.UIEdgeInsets_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("contentInset"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    Messaging.UIEdgeInsets_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("contentInset"));
                }
                else
                {
                    Messaging.UIEdgeInsets_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("contentInset"));
                }
                return result;
            }
            [Export("setContentInset:", ArgumentSemantic.Assign)]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_UIEdgeInsets(base.Handle, Selector.GetHandle("setContentInset:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_UIEdgeInsets(base.SuperHandle, Selector.GetHandle("setContentInset:"), value);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Obsolete("Use DebugMask instead", false)]
        public virtual bool DebugActive
        {
            [Export("isDebugActive")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("isDebugActive"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("isDebugActive"));
            }
            [Export("setDebugActive:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setDebugActive:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setDebugActive:"), value);
                }
            }
        }

        
        public virtual DebugMaskOptions DebugMask
        {
            [Export("debugMask", ArgumentSemantic.Assign)]
            get
            {
                DebugMaskOptions result;
                if (base.IsDirectBinding)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = (DebugMaskOptions)Messaging.UInt64_objc_msgSend(base.Handle, Selector.GetHandle("debugMask"));
                    }
                    else
                    {
                        result = (DebugMaskOptions)Messaging.UInt32_objc_msgSend(base.Handle, Selector.GetHandle("debugMask"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    result = (DebugMaskOptions)Messaging.UInt64_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("debugMask"));
                }
                else
                {
                    result = (DebugMaskOptions)Messaging.UInt32_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("debugMask"));
                }
                return result;
            }
            [Export("setDebugMask:", ArgumentSemantic.Assign)]
            set
            {
                if (base.IsDirectBinding)
                {
                    if (IntPtr.Size == 8)
                    {
                        Messaging.void_objc_msgSend_UInt64(base.Handle, Selector.GetHandle("setDebugMask:"), (ulong)value);
                    }
                    else
                    {
                        Messaging.void_objc_msgSend_UInt32(base.Handle, Selector.GetHandle("setDebugMask:"), (uint)value);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    Messaging.void_objc_msgSendSuper_UInt64(base.SuperHandle, Selector.GetHandle("setDebugMask:"), (ulong)value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_UInt32(base.SuperHandle, Selector.GetHandle("setDebugMask:"), (uint)value);
                }
            }
        }

        
        public virtual nfloat DecelerationRate
        {
            [Export("decelerationRate")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.nfloat_objc_msgSend(base.Handle, Selector.GetHandle("decelerationRate"));
                }
                return Messaging.nfloat_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("decelerationRate"));
            }
            [Export("setDecelerationRate:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_nfloat(base.Handle, Selector.GetHandle("setDecelerationRate:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_nfloat(base.SuperHandle, Selector.GetHandle("setDecelerationRate:"), value);
                }
            }
        }

        
        public virtual IMapViewDelegate Delegate
        {
            [Export("delegate", ArgumentSemantic.Weak)]
            get
            {
                IMapViewDelegate iNativeObject;
                if (base.IsDirectBinding)
                {
                    iNativeObject = Runtime.GetINativeObject<IMapViewDelegate>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("delegate")), false);
                }
                else
                {
                    iNativeObject = Runtime.GetINativeObject<IMapViewDelegate>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("delegate")), false);
                }
                base.MarkDirty();
                this.__mt_Delegate_var = iNativeObject;
                return iNativeObject;
            }
            [Export("setDelegate:", ArgumentSemantic.Weak)]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("setDelegate:"), (value != null) ? value.Handle : IntPtr.Zero);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("setDelegate:"), (value != null) ? value.Handle : IntPtr.Zero);
                }
                base.MarkDirty();
                this.__mt_Delegate_var = value;
            }
        }

        
        public virtual double Direction
        {
            [Export("direction")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.Double_objc_msgSend(base.Handle, Selector.GetHandle("direction"));
                }
                return Messaging.Double_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("direction"));
            }
            [Export("setDirection:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_Double(base.Handle, Selector.GetHandle("setDirection:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_Double(base.SuperHandle, Selector.GetHandle("setDirection:"), value);
                }
            }
        }

        
        public virtual bool DisplayHeadingCalibration
        {
            [Export("displayHeadingCalibration")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("displayHeadingCalibration"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("displayHeadingCalibration"));
            }
            [Export("setDisplayHeadingCalibration:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setDisplayHeadingCalibration:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setDisplayHeadingCalibration:"), value);
                }
            }
        }

        
        public virtual double Latitude
        {
            [Export("latitude")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.Double_objc_msgSend(base.Handle, Selector.GetHandle("latitude"));
                }
                return Messaging.Double_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("latitude"));
            }
            [Export("setLatitude:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_Double(base.Handle, Selector.GetHandle("setLatitude:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_Double(base.SuperHandle, Selector.GetHandle("setLatitude:"), value);
                }
            }
        }

        
        public virtual UIImageView LogoView
        {
            [Export("logoView")]
            get
            {
                UIImageView nSObject;
                if (base.IsDirectBinding)
                {
                    nSObject = Runtime.GetNSObject<UIImageView>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("logoView")));
                }
                else
                {
                    nSObject = Runtime.GetNSObject<UIImageView>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("logoView")));
                }
                return nSObject;
            }
        }

        
        public virtual double Longitude
        {
            [Export("longitude")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.Double_objc_msgSend(base.Handle, Selector.GetHandle("longitude"));
                }
                return Messaging.Double_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("longitude"));
            }
            [Export("setLongitude:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_Double(base.Handle, Selector.GetHandle("setLongitude:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_Double(base.SuperHandle, Selector.GetHandle("setLongitude:"), value);
                }
            }
        }

        
        public virtual double MaximumZoomLevel
        {
            [Export("maximumZoomLevel")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.Double_objc_msgSend(base.Handle, Selector.GetHandle("maximumZoomLevel"));
                }
                return Messaging.Double_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("maximumZoomLevel"));
            }
            [Export("setMaximumZoomLevel:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_Double(base.Handle, Selector.GetHandle("setMaximumZoomLevel:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_Double(base.SuperHandle, Selector.GetHandle("setMaximumZoomLevel:"), value);
                }
            }
        }

        
        public virtual double MinimumZoomLevel
        {
            [Export("minimumZoomLevel")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.Double_objc_msgSend(base.Handle, Selector.GetHandle("minimumZoomLevel"));
                }
                return Messaging.Double_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("minimumZoomLevel"));
            }
            [Export("setMinimumZoomLevel:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_Double(base.Handle, Selector.GetHandle("setMinimumZoomLevel:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_Double(base.SuperHandle, Selector.GetHandle("setMinimumZoomLevel:"), value);
                }
            }
        }

        
        public virtual bool PitchEnabled
        {
            [Export("isPitchEnabled")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("isPitchEnabled"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("isPitchEnabled"));
            }
            [Export("setPitchEnabled:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setPitchEnabled:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setPitchEnabled:"), value);
                }
            }
        }

        
        public virtual bool RotateEnabled
        {
            [Export("isRotateEnabled")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("isRotateEnabled"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("isRotateEnabled"));
            }
            [Export("setRotateEnabled:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setRotateEnabled:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setRotateEnabled:"), value);
                }
            }
        }

        
        public virtual bool ScrollEnabled
        {
            [Export("isScrollEnabled")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("isScrollEnabled"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("isScrollEnabled"));
            }
            [Export("setScrollEnabled:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setScrollEnabled:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setScrollEnabled:"), value);
                }
            }
        }

        
        public virtual IAnnotation[] SelectedAnnotations
        {
            [Export("selectedAnnotations", ArgumentSemantic.Copy)]
            get
            {
                IAnnotation[] result;
                if (base.IsDirectBinding)
                {
                    result = NSArray.ArrayFromHandle<IAnnotation>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("selectedAnnotations")));
                }
                else
                {
                    result = NSArray.ArrayFromHandle<IAnnotation>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("selectedAnnotations")));
                }
                return result;
            }
            [Export("setSelectedAnnotations:", ArgumentSemantic.Copy)]
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                NSArray nSArray = NSArray.FromNSObjects(value);
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("setSelectedAnnotations:"), nSArray.Handle);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("setSelectedAnnotations:"), nSArray.Handle);
                }
                nSArray.Dispose();
            }
        }

        
        public virtual bool ShowsUserLocation
        {
            [Export("showsUserLocation")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("showsUserLocation"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("showsUserLocation"));
            }
            [Export("setShowsUserLocation:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setShowsUserLocation:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setShowsUserLocation:"), value);
                }
            }
        }

        
        public virtual string[] StyleClasses
        {
            [Export("styleClasses", ArgumentSemantic.Assign)]
            get
            {
                if (base.IsDirectBinding)
                {
                    return NSArray.StringArrayFromHandle(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("styleClasses")));
                }
                return NSArray.StringArrayFromHandle(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("styleClasses")));
            }
            [Export("setStyleClasses:", ArgumentSemantic.Assign)]
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                NSArray nSArray = NSArray.FromStrings(value);
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("setStyleClasses:"), nSArray.Handle);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("setStyleClasses:"), nSArray.Handle);
                }
                nSArray.Dispose();
            }
        }

        
        public virtual NSUrl StyleURL
        {
            [Export("styleURL", ArgumentSemantic.Assign)]
            get
            {
                NSUrl nSObject;
                if (base.IsDirectBinding)
                {
                    nSObject = Runtime.GetNSObject<NSUrl>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("styleURL")));
                }
                else
                {
                    nSObject = Runtime.GetNSObject<NSUrl>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("styleURL")));
                }
                base.MarkDirty();
                this.__mt_StyleURL_var = nSObject;
                return nSObject;
            }
            [Export("setStyleURL:", ArgumentSemantic.Assign)]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("setStyleURL:"), (!(value == null)) ? value.Handle : IntPtr.Zero);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("setStyleURL:"), (!(value == null)) ? value.Handle : IntPtr.Zero);
                }
                base.MarkDirty();
                this.__mt_StyleURL_var = value;
            }
        }

        
        public virtual CLLocationCoordinate2D TargetCoordinate
        {
            [Export("targetCoordinate", ArgumentSemantic.Assign)]
            get
            {
                CLLocationCoordinate2D result;
                if (base.IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            result = Messaging.CLLocationCoordinate2D_objc_msgSend(base.Handle, Selector.GetHandle("targetCoordinate"));
                        }
                        else
                        {
                            Messaging.CLLocationCoordinate2D_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("targetCoordinate"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        result = Messaging.CLLocationCoordinate2D_objc_msgSend(base.Handle, Selector.GetHandle("targetCoordinate"));
                    }
                    else
                    {
                        Messaging.CLLocationCoordinate2D_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("targetCoordinate"));
                    }
                }
                else if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.CLLocationCoordinate2D_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("targetCoordinate"));
                    }
                    else
                    {
                        Messaging.CLLocationCoordinate2D_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("targetCoordinate"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    result = Messaging.CLLocationCoordinate2D_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("targetCoordinate"));
                }
                else
                {
                    Messaging.CLLocationCoordinate2D_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("targetCoordinate"));
                }
                return result;
            }
            [Export("setTargetCoordinate:", ArgumentSemantic.Assign)]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_CLLocationCoordinate2D(base.Handle, Selector.GetHandle("setTargetCoordinate:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_CLLocationCoordinate2D(base.SuperHandle, Selector.GetHandle("setTargetCoordinate:"), value);
                }
            }
        }

        
        public virtual UserLocation UserLocation
        {
            [Export("userLocation")]
            get
            {
                UserLocation nSObject;
                if (base.IsDirectBinding)
                {
                    nSObject = Runtime.GetNSObject<UserLocation>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("userLocation")));
                }
                else
                {
                    nSObject = Runtime.GetNSObject<UserLocation>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("userLocation")));
                }
                return nSObject;
            }
        }

        
        public virtual AnnotationVerticalAlignment UserLocationVerticalAlignment
        {
            [Export("userLocationVerticalAlignment", ArgumentSemantic.Assign)]
            get
            {
                AnnotationVerticalAlignment result;
                if (base.IsDirectBinding)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = (AnnotationVerticalAlignment)Messaging.UInt64_objc_msgSend(base.Handle, Selector.GetHandle("userLocationVerticalAlignment"));
                    }
                    else
                    {
                        result = (AnnotationVerticalAlignment)Messaging.UInt32_objc_msgSend(base.Handle, Selector.GetHandle("userLocationVerticalAlignment"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    result = (AnnotationVerticalAlignment)Messaging.UInt64_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("userLocationVerticalAlignment"));
                }
                else
                {
                    result = (AnnotationVerticalAlignment)Messaging.UInt32_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("userLocationVerticalAlignment"));
                }
                return result;
            }
            [Export("setUserLocationVerticalAlignment:", ArgumentSemantic.Assign)]
            set
            {
                if (base.IsDirectBinding)
                {
                    if (IntPtr.Size == 8)
                    {
                        Messaging.void_objc_msgSend_UInt64(base.Handle, Selector.GetHandle("setUserLocationVerticalAlignment:"), (ulong)value);
                    }
                    else
                    {
                        Messaging.void_objc_msgSend_UInt32(base.Handle, Selector.GetHandle("setUserLocationVerticalAlignment:"), (uint)value);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    Messaging.void_objc_msgSendSuper_UInt64(base.SuperHandle, Selector.GetHandle("setUserLocationVerticalAlignment:"), (ulong)value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_UInt32(base.SuperHandle, Selector.GetHandle("setUserLocationVerticalAlignment:"), (uint)value);
                }
            }
        }

        
        public virtual bool UserLocationVisible
        {
            [Export("isUserLocationVisible")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("isUserLocationVisible"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("isUserLocationVisible"));
            }
        }

        
        public virtual UserTrackingMode UserTrackingMode
        {
            [Export("userTrackingMode", ArgumentSemantic.Assign)]
            get
            {
                UserTrackingMode result;
                if (base.IsDirectBinding)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = (UserTrackingMode)Messaging.UInt64_objc_msgSend(base.Handle, Selector.GetHandle("userTrackingMode"));
                    }
                    else
                    {
                        result = (UserTrackingMode)Messaging.UInt32_objc_msgSend(base.Handle, Selector.GetHandle("userTrackingMode"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    result = (UserTrackingMode)Messaging.UInt64_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("userTrackingMode"));
                }
                else
                {
                    result = (UserTrackingMode)Messaging.UInt32_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("userTrackingMode"));
                }
                return result;
            }
            [Export("setUserTrackingMode:", ArgumentSemantic.Assign)]
            set
            {
                if (base.IsDirectBinding)
                {
                    if (IntPtr.Size == 8)
                    {
                        Messaging.void_objc_msgSend_UInt64(base.Handle, Selector.GetHandle("setUserTrackingMode:"), (ulong)value);
                    }
                    else
                    {
                        Messaging.void_objc_msgSend_UInt32(base.Handle, Selector.GetHandle("setUserTrackingMode:"), (uint)value);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    Messaging.void_objc_msgSendSuper_UInt64(base.SuperHandle, Selector.GetHandle("setUserTrackingMode:"), (ulong)value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_UInt32(base.SuperHandle, Selector.GetHandle("setUserTrackingMode:"), (uint)value);
                }
            }
        }

        
        public virtual CoordinateBounds VisibleCoordinateBounds
        {
            [Export("visibleCoordinateBounds", ArgumentSemantic.Assign)]
            get
            {
                CoordinateBounds result;
                if (base.IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            result = Messaging.CoordinateBounds_objc_msgSend(base.Handle, Selector.GetHandle("visibleCoordinateBounds"));
                        }
                        else
                        {
                            Messaging.CoordinateBounds_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("visibleCoordinateBounds"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        Messaging.CoordinateBounds_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("visibleCoordinateBounds"));
                    }
                    else
                    {
                        Messaging.CoordinateBounds_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("visibleCoordinateBounds"));
                    }
                }
                else if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.CoordinateBounds_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("visibleCoordinateBounds"));
                    }
                    else
                    {
                        Messaging.CoordinateBounds_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("visibleCoordinateBounds"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    Messaging.CoordinateBounds_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("visibleCoordinateBounds"));
                }
                else
                {
                    Messaging.CoordinateBounds_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("visibleCoordinateBounds"));
                }
                return result;
            }
            [Export("setVisibleCoordinateBounds:", ArgumentSemantic.Assign)]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_CoordinateBounds(base.Handle, Selector.GetHandle("setVisibleCoordinateBounds:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_CoordinateBounds(base.SuperHandle, Selector.GetHandle("setVisibleCoordinateBounds:"), value);
                }
            }
        }

        
        public virtual bool ZoomEnabled
        {
            [Export("isZoomEnabled")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("isZoomEnabled"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("isZoomEnabled"));
            }
            [Export("setZoomEnabled:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setZoomEnabled:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setZoomEnabled:"), value);
                }
            }
        }

        
        public virtual double ZoomLevel
        {
            [Export("zoomLevel")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.Double_objc_msgSend(base.Handle, Selector.GetHandle("zoomLevel"));
                }
                return Messaging.Double_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("zoomLevel"));
            }
            [Export("setZoomLevel:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_Double(base.Handle, Selector.GetHandle("setZoomLevel:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_Double(base.SuperHandle, Selector.GetHandle("setZoomLevel:"), value);
                }
            }
        }

        public new static MapView.MapViewAppearance Appearance
        {
            get
            {
                return new MapView.MapViewAppearance(Messaging.IntPtr_objc_msgSend(MapView.class_ptr, Selector.GetHandle("appearance")));
            }
        }

        [Export("init"), EditorBrowsable(EditorBrowsableState.Advanced)]
        public MapView() : base(NSObjectFlag.Empty)
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
        public MapView(NSCoder coder) : base(NSObjectFlag.Empty)
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
        protected MapView(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal MapView(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [Export("initWithFrame:")]
        public MapView(CGRect frame) : base(NSObjectFlag.Empty)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
            if (base.IsDirectBinding)
            {
                base.InitializeHandle(Messaging.IntPtr_objc_msgSend_CGRect(base.Handle, Selector.GetHandle("initWithFrame:"), frame), "initWithFrame:");
            }
            else
            {
                base.InitializeHandle(Messaging.IntPtr_objc_msgSendSuper_CGRect(base.SuperHandle, Selector.GetHandle("initWithFrame:"), frame), "initWithFrame:");
            }
        }

        [Export("initWithFrame:styleURL:")]
        public MapView(CGRect frame, NSUrl styleURL) : base(NSObjectFlag.Empty)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
            if (base.IsDirectBinding)
            {
                base.InitializeHandle(Messaging.IntPtr_objc_msgSend_CGRect_IntPtr(base.Handle, Selector.GetHandle("initWithFrame:styleURL:"), frame, (!(styleURL == null)) ? styleURL.Handle : IntPtr.Zero), "initWithFrame:styleURL:");
            }
            else
            {
                base.InitializeHandle(Messaging.IntPtr_objc_msgSendSuper_CGRect_IntPtr(base.SuperHandle, Selector.GetHandle("initWithFrame:styleURL:"), frame, (!(styleURL == null)) ? styleURL.Handle : IntPtr.Zero), "initWithFrame:styleURL:");
            }
        }

        public void SetVisibleCoordinates(CLLocationCoordinate2D[] coordinates, nuint count, UIEdgeInsets insets, bool animated)
        {
            this.SetVisibleCoordinates(MapView.GetPointer(coordinates), count, insets, animated);
        }

        internal unsafe static IntPtr GetPointer(CLLocationCoordinate2D[] coordinates)
        {

            fixed (void* coord = &coordinates[0])
            {
                return (IntPtr)coord;
            }
            //return (IntPtr)((void*)(&coordinates[0]));
        }

        [Export("addAnnotation:")]
        public virtual void AddAnnotation(IAnnotation annotation)
        {
            if (annotation == null)
            {
                throw new ArgumentNullException("annotation");
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("addAnnotation:"), annotation.Handle);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("addAnnotation:"), annotation.Handle);
            }
        }

        [Export("addAnnotations:")]
        public virtual void AddAnnotations(IAnnotation[] annotations)
        {
            if (annotations == null)
            {
                throw new ArgumentNullException("annotations");
            }
            NSArray nSArray = NSArray.FromNSObjects(annotations);
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("addAnnotations:"), nSArray.Handle);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("addAnnotations:"), nSArray.Handle);
            }
            nSArray.Dispose();
        }

        [Export("addOverlay:")]
        public virtual void AddOverlay(IOverlay overlay)
        {
            if (overlay == null)
            {
                throw new ArgumentNullException("overlay");
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("addOverlay:"), overlay.Handle);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("addOverlay:"), overlay.Handle);
            }
        }

        [Export("addOverlays:")]
        public virtual void AddOverlays(IOverlay[] overlays)
        {
            if (overlays == null)
            {
                throw new ArgumentNullException("overlays");
            }
            NSArray nSArray = NSArray.FromNSObjects(overlays);
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("addOverlays:"), nSArray.Handle);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("addOverlays:"), nSArray.Handle);
            }
            nSArray.Dispose();
        }

        [Export("addStyleClass:")]
        public virtual void AddStyleClass(string styleClass)
        {
            if (styleClass == null)
            {
                throw new ArgumentNullException("styleClass");
            }
            IntPtr intPtr = NSString.CreateNative(styleClass);
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("addStyleClass:"), intPtr);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("addStyleClass:"), intPtr);
            }
            NSString.ReleaseNative(intPtr);
        }

        [Export("convertCoordinate:toPointToView:")]
        public virtual CGPoint ConvertCoordinate(CLLocationCoordinate2D coordinate, UIView view)
        {
            CGPoint result;
            if (base.IsDirectBinding)
            {
                if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.CGPoint_objc_msgSend_CLLocationCoordinate2D_IntPtr(base.Handle, Selector.GetHandle("convertCoordinate:toPointToView:"), coordinate, (view != null) ? view.Handle : IntPtr.Zero);
                    }
                    else
                    {
                        Messaging.CGPoint_objc_msgSend_stret_CLLocationCoordinate2D_IntPtr(out result, base.Handle, Selector.GetHandle("convertCoordinate:toPointToView:"), coordinate, (view != null) ? view.Handle : IntPtr.Zero);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    result = Messaging.CGPoint_objc_msgSend_CLLocationCoordinate2D_IntPtr(base.Handle, Selector.GetHandle("convertCoordinate:toPointToView:"), coordinate, (view != null) ? view.Handle : IntPtr.Zero);
                }
                else
                {
                    result = Messaging.CGPoint_objc_msgSend_CLLocationCoordinate2D_IntPtr(base.Handle, Selector.GetHandle("convertCoordinate:toPointToView:"), coordinate, (view != null) ? view.Handle : IntPtr.Zero);
                }
            }
            else if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    result = Messaging.CGPoint_objc_msgSendSuper_CLLocationCoordinate2D_IntPtr(base.SuperHandle, Selector.GetHandle("convertCoordinate:toPointToView:"), coordinate, (view != null) ? view.Handle : IntPtr.Zero);
                }
                else
                {
                    Messaging.CGPoint_objc_msgSendSuper_stret_CLLocationCoordinate2D_IntPtr(out result, base.SuperHandle, Selector.GetHandle("convertCoordinate:toPointToView:"), coordinate, (view != null) ? view.Handle : IntPtr.Zero);
                }
            }
            else if (IntPtr.Size == 8)
            {
                result = Messaging.CGPoint_objc_msgSendSuper_CLLocationCoordinate2D_IntPtr(base.SuperHandle, Selector.GetHandle("convertCoordinate:toPointToView:"), coordinate, (view != null) ? view.Handle : IntPtr.Zero);
            }
            else
            {
                result = Messaging.CGPoint_objc_msgSendSuper_CLLocationCoordinate2D_IntPtr(base.SuperHandle, Selector.GetHandle("convertCoordinate:toPointToView:"), coordinate, (view != null) ? view.Handle : IntPtr.Zero);
            }
            return result;
        }

        [Export("convertCoordinateBounds:toRectToView:")]
        public virtual CGRect ConvertCoordinateBoundsToRect(CoordinateBounds bounds, UIView view)
        {
            CGRect result;
            if (base.IsDirectBinding)
            {
                if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.CGRect_objc_msgSend_CoordinateBounds_IntPtr(base.Handle, Selector.GetHandle("convertCoordinateBounds:toRectToView:"), bounds, (view != null) ? view.Handle : IntPtr.Zero);
                    }
                    else
                    {
                        Messaging.CGRect_objc_msgSend_stret_CoordinateBounds_IntPtr(out result, base.Handle, Selector.GetHandle("convertCoordinateBounds:toRectToView:"), bounds, (view != null) ? view.Handle : IntPtr.Zero);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    Messaging.CGRect_objc_msgSend_stret_CoordinateBounds_IntPtr(out result, base.Handle, Selector.GetHandle("convertCoordinateBounds:toRectToView:"), bounds, (view != null) ? view.Handle : IntPtr.Zero);
                }
                else
                {
                    Messaging.CGRect_objc_msgSend_stret_CoordinateBounds_IntPtr(out result, base.Handle, Selector.GetHandle("convertCoordinateBounds:toRectToView:"), bounds, (view != null) ? view.Handle : IntPtr.Zero);
                }
            }
            else if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    result = Messaging.CGRect_objc_msgSendSuper_CoordinateBounds_IntPtr(base.SuperHandle, Selector.GetHandle("convertCoordinateBounds:toRectToView:"), bounds, (view != null) ? view.Handle : IntPtr.Zero);
                }
                else
                {
                    Messaging.CGRect_objc_msgSendSuper_stret_CoordinateBounds_IntPtr(out result, base.SuperHandle, Selector.GetHandle("convertCoordinateBounds:toRectToView:"), bounds, (view != null) ? view.Handle : IntPtr.Zero);
                }
            }
            else if (IntPtr.Size == 8)
            {
                Messaging.CGRect_objc_msgSendSuper_stret_CoordinateBounds_IntPtr(out result, base.SuperHandle, Selector.GetHandle("convertCoordinateBounds:toRectToView:"), bounds, (view != null) ? view.Handle : IntPtr.Zero);
            }
            else
            {
                Messaging.CGRect_objc_msgSendSuper_stret_CoordinateBounds_IntPtr(out result, base.SuperHandle, Selector.GetHandle("convertCoordinateBounds:toRectToView:"), bounds, (view != null) ? view.Handle : IntPtr.Zero);
            }
            return result;
        }

        [Export("convertPoint:toCoordinateFromView:")]
        public virtual CLLocationCoordinate2D ConvertPoint(CGPoint point, UIView view)
        {
            CLLocationCoordinate2D result;
            if (base.IsDirectBinding)
            {
                if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.CLLocationCoordinate2D_objc_msgSend_CGPoint_IntPtr(base.Handle, Selector.GetHandle("convertPoint:toCoordinateFromView:"), point, (view != null) ? view.Handle : IntPtr.Zero);
                    }
                    else
                    {
                        Messaging.CLLocationCoordinate2D_objc_msgSend_stret_CGPoint_IntPtr(out result, base.Handle, Selector.GetHandle("convertPoint:toCoordinateFromView:"), point, (view != null) ? view.Handle : IntPtr.Zero);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    result = Messaging.CLLocationCoordinate2D_objc_msgSend_CGPoint_IntPtr(base.Handle, Selector.GetHandle("convertPoint:toCoordinateFromView:"), point, (view != null) ? view.Handle : IntPtr.Zero);
                }
                else
                {
                    Messaging.CLLocationCoordinate2D_objc_msgSend_stret_CGPoint_IntPtr(out result, base.Handle, Selector.GetHandle("convertPoint:toCoordinateFromView:"), point, (view != null) ? view.Handle : IntPtr.Zero);
                }
            }
            else if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    result = Messaging.CLLocationCoordinate2D_objc_msgSendSuper_CGPoint_IntPtr(base.SuperHandle, Selector.GetHandle("convertPoint:toCoordinateFromView:"), point, (view != null) ? view.Handle : IntPtr.Zero);
                }
                else
                {
                    Messaging.CLLocationCoordinate2D_objc_msgSendSuper_stret_CGPoint_IntPtr(out result, base.SuperHandle, Selector.GetHandle("convertPoint:toCoordinateFromView:"), point, (view != null) ? view.Handle : IntPtr.Zero);
                }
            }
            else if (IntPtr.Size == 8)
            {
                result = Messaging.CLLocationCoordinate2D_objc_msgSendSuper_CGPoint_IntPtr(base.SuperHandle, Selector.GetHandle("convertPoint:toCoordinateFromView:"), point, (view != null) ? view.Handle : IntPtr.Zero);
            }
            else
            {
                Messaging.CLLocationCoordinate2D_objc_msgSendSuper_stret_CGPoint_IntPtr(out result, base.SuperHandle, Selector.GetHandle("convertPoint:toCoordinateFromView:"), point, (view != null) ? view.Handle : IntPtr.Zero);
            }
            return result;
        }

        [Export("convertRect:toCoordinateBoundsFromView:")]
        public virtual CoordinateBounds ConvertRectToCoordinateBounds(CGRect rect, UIView view)
        {
            CoordinateBounds result;
            if (base.IsDirectBinding)
            {
                if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.CoordinateBounds_objc_msgSend_CGRect_IntPtr(base.Handle, Selector.GetHandle("convertRect:toCoordinateBoundsFromView:"), rect, (view != null) ? view.Handle : IntPtr.Zero);
                    }
                    else
                    {
                        Messaging.CoordinateBounds_objc_msgSend_stret_CGRect_IntPtr(out result, base.Handle, Selector.GetHandle("convertRect:toCoordinateBoundsFromView:"), rect, (view != null) ? view.Handle : IntPtr.Zero);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    Messaging.CoordinateBounds_objc_msgSend_stret_CGRect_IntPtr(out result, base.Handle, Selector.GetHandle("convertRect:toCoordinateBoundsFromView:"), rect, (view != null) ? view.Handle : IntPtr.Zero);
                }
                else
                {
                    Messaging.CoordinateBounds_objc_msgSend_stret_CGRect_IntPtr(out result, base.Handle, Selector.GetHandle("convertRect:toCoordinateBoundsFromView:"), rect, (view != null) ? view.Handle : IntPtr.Zero);
                }
            }
            else if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    result = Messaging.CoordinateBounds_objc_msgSendSuper_CGRect_IntPtr(base.SuperHandle, Selector.GetHandle("convertRect:toCoordinateBoundsFromView:"), rect, (view != null) ? view.Handle : IntPtr.Zero);
                }
                else
                {
                    Messaging.CoordinateBounds_objc_msgSendSuper_stret_CGRect_IntPtr(out result, base.SuperHandle, Selector.GetHandle("convertRect:toCoordinateBoundsFromView:"), rect, (view != null) ? view.Handle : IntPtr.Zero);
                }
            }
            else if (IntPtr.Size == 8)
            {
                Messaging.CoordinateBounds_objc_msgSendSuper_stret_CGRect_IntPtr(out result, base.SuperHandle, Selector.GetHandle("convertRect:toCoordinateBoundsFromView:"), rect, (view != null) ? view.Handle : IntPtr.Zero);
            }
            else
            {
                Messaging.CoordinateBounds_objc_msgSendSuper_stret_CGRect_IntPtr(out result, base.SuperHandle, Selector.GetHandle("convertRect:toCoordinateBoundsFromView:"), rect, (view != null) ? view.Handle : IntPtr.Zero);
            }
            return result;
        }

        [Export("dequeueReusableAnnotationImageWithIdentifier:")]
        public virtual AnnotationImage DequeueReusableAnnotationImage(string identifier)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException("identifier");
            }
            IntPtr intPtr = NSString.CreateNative(identifier);
            AnnotationImage nSObject;
            if (base.IsDirectBinding)
            {
                nSObject = Runtime.GetNSObject<AnnotationImage>(Messaging.IntPtr_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("dequeueReusableAnnotationImageWithIdentifier:"), intPtr));
            }
            else
            {
                nSObject = Runtime.GetNSObject<AnnotationImage>(Messaging.IntPtr_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("dequeueReusableAnnotationImageWithIdentifier:"), intPtr));
            }
            NSString.ReleaseNative(intPtr);
            return nSObject;
        }

        [Export("dequeueReusableAnnotationViewWithIdentifier:")]
        public virtual AnnotationView DequeueReusableAnnotationView(string identifier)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException("identifier");
            }
            IntPtr intPtr = NSString.CreateNative(identifier);
            AnnotationView nSObject;
            if (base.IsDirectBinding)
            {
                nSObject = Runtime.GetNSObject<AnnotationView>(Messaging.IntPtr_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("dequeueReusableAnnotationViewWithIdentifier:"), intPtr));
            }
            else
            {
                nSObject = Runtime.GetNSObject<AnnotationView>(Messaging.IntPtr_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("dequeueReusableAnnotationViewWithIdentifier:"), intPtr));
            }
            NSString.ReleaseNative(intPtr);
            return nSObject;
        }

        [Export("deselectAnnotation:animated:")]
        public virtual void DeselectAnnotation(IAnnotation annotation, bool animated)
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr_bool(base.Handle, Selector.GetHandle("deselectAnnotation:animated:"), (annotation != null) ? annotation.Handle : IntPtr.Zero, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr_bool(base.SuperHandle, Selector.GetHandle("deselectAnnotation:animated:"), (annotation != null) ? annotation.Handle : IntPtr.Zero, animated);
            }
        }

        [Export("emptyMemoryCache")]
        public virtual void EmptyMemoryCache()
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend(base.Handle, Selector.GetHandle("emptyMemoryCache"));
            }
            else
            {
                Messaging.void_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("emptyMemoryCache"));
            }
        }

        [Export("flyToCamera:completionHandler:")]
        public unsafe virtual void FlyToCamera(MapCamera camera, [BlockProxy(typeof(Trampolines.NIDAction))] Action completion)
        {
            if (camera == null)
            {
                throw new ArgumentNullException("camera");
            }
            BlockLiteral* ptr;
            if (completion == null)
            {
                ptr = null;
            }
            else
            {
                BlockLiteral blockLiteral = default(BlockLiteral);
                ptr = &blockLiteral;
                blockLiteral.SetupBlock(Trampolines.SDAction.Handler, completion);
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr_IntPtr(base.Handle, Selector.GetHandle("flyToCamera:completionHandler:"), camera.Handle, (IntPtr)((void*)ptr));
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr_IntPtr(base.SuperHandle, Selector.GetHandle("flyToCamera:completionHandler:"), camera.Handle, (IntPtr)((void*)ptr));
            }
            if (ptr != null)
            {
                ptr->CleanupBlock();
            }
        }

        [Export("flyToCamera:withDuration:completionHandler:")]
        public unsafe virtual void FlyToCamera(MapCamera camera, double duration, [BlockProxy(typeof(Trampolines.NIDAction))] Action completion)
        {
            if (camera == null)
            {
                throw new ArgumentNullException("camera");
            }
            BlockLiteral* ptr;
            if (completion == null)
            {
                ptr = null;
            }
            else
            {
                BlockLiteral blockLiteral = default(BlockLiteral);
                ptr = &blockLiteral;
                blockLiteral.SetupBlock(Trampolines.SDAction.Handler, completion);
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr_Double_IntPtr(base.Handle, Selector.GetHandle("flyToCamera:withDuration:completionHandler:"), camera.Handle, duration, (IntPtr)((void*)ptr));
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr_Double_IntPtr(base.SuperHandle, Selector.GetHandle("flyToCamera:withDuration:completionHandler:"), camera.Handle, duration, (IntPtr)((void*)ptr));
            }
            if (ptr != null)
            {
                ptr->CleanupBlock();
            }
        }

        [Export("flyToCamera:withDuration:peakAltitude:completionHandler:")]
        public unsafe virtual void FlyToCamera(MapCamera camera, double duration, double peakAltitude, [BlockProxy(typeof(Trampolines.NIDAction))] Action completion)
        {
            if (camera == null)
            {
                throw new ArgumentNullException("camera");
            }
            BlockLiteral* ptr;
            if (completion == null)
            {
                ptr = null;
            }
            else
            {
                BlockLiteral blockLiteral = default(BlockLiteral);
                ptr = &blockLiteral;
                blockLiteral.SetupBlock(Trampolines.SDAction.Handler, completion);
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr_Double_Double_IntPtr(base.Handle, Selector.GetHandle("flyToCamera:withDuration:peakAltitude:completionHandler:"), camera.Handle, duration, peakAltitude, (IntPtr)((void*)ptr));
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr_Double_Double_IntPtr(base.SuperHandle, Selector.GetHandle("flyToCamera:withDuration:peakAltitude:completionHandler:"), camera.Handle, duration, peakAltitude, (IntPtr)((void*)ptr));
            }
            if (ptr != null)
            {
                ptr->CleanupBlock();
            }
        }

        [Export("anchorPointForGesture:")]
        public virtual CGPoint GetAnchorPoint(UIGestureRecognizer gesture)
        {
            if (gesture == null)
            {
                throw new ArgumentNullException("gesture");
            }
            CGPoint result;
            if (base.IsDirectBinding)
            {
                if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.CGPoint_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("anchorPointForGesture:"), gesture.Handle);
                    }
                    else
                    {
                        Messaging.CGPoint_objc_msgSend_stret_IntPtr(out result, base.Handle, Selector.GetHandle("anchorPointForGesture:"), gesture.Handle);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    result = Messaging.CGPoint_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("anchorPointForGesture:"), gesture.Handle);
                }
                else
                {
                    result = Messaging.CGPoint_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("anchorPointForGesture:"), gesture.Handle);
                }
            }
            else if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    result = Messaging.CGPoint_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("anchorPointForGesture:"), gesture.Handle);
                }
                else
                {
                    Messaging.CGPoint_objc_msgSendSuper_stret_IntPtr(out result, base.SuperHandle, Selector.GetHandle("anchorPointForGesture:"), gesture.Handle);
                }
            }
            else if (IntPtr.Size == 8)
            {
                result = Messaging.CGPoint_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("anchorPointForGesture:"), gesture.Handle);
            }
            else
            {
                result = Messaging.CGPoint_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("anchorPointForGesture:"), gesture.Handle);
            }
            return result;
        }

        [Export("cameraThatFitsCoordinateBounds:")]
        public virtual MapCamera GetCameraThatFits(CoordinateBounds bounds)
        {
            if (base.IsDirectBinding)
            {
                return Runtime.GetNSObject<MapCamera>(Messaging.IntPtr_objc_msgSend_CoordinateBounds(base.Handle, Selector.GetHandle("cameraThatFitsCoordinateBounds:"), bounds));
            }
            return Runtime.GetNSObject<MapCamera>(Messaging.IntPtr_objc_msgSendSuper_CoordinateBounds(base.SuperHandle, Selector.GetHandle("cameraThatFitsCoordinateBounds:"), bounds));
        }

        [Export("cameraThatFitsCoordinateBounds:edgePadding:")]
        public virtual MapCamera GetCameraThatFits(CoordinateBounds bounds, UIEdgeInsets insets)
        {
            if (base.IsDirectBinding)
            {
                return Runtime.GetNSObject<MapCamera>(Messaging.IntPtr_objc_msgSend_CoordinateBounds_UIEdgeInsets(base.Handle, Selector.GetHandle("cameraThatFitsCoordinateBounds:edgePadding:"), bounds, insets));
            }
            return Runtime.GetNSObject<MapCamera>(Messaging.IntPtr_objc_msgSendSuper_CoordinateBounds_UIEdgeInsets(base.SuperHandle, Selector.GetHandle("cameraThatFitsCoordinateBounds:edgePadding:"), bounds, insets));
        }

        [Export("visibleFeaturesAtPoint:")]
        public virtual Feature[] GetVisibleFeaturesAtPoint(CGPoint point)
        {
            if (base.IsDirectBinding)
            {
                return NSArray.ArrayFromHandle<Feature>(Messaging.IntPtr_objc_msgSend_CGPoint(base.Handle, Selector.GetHandle("visibleFeaturesAtPoint:"), point));
            }
            return NSArray.ArrayFromHandle<Feature>(Messaging.IntPtr_objc_msgSendSuper_CGPoint(base.SuperHandle, Selector.GetHandle("visibleFeaturesAtPoint:"), point));
        }

        [Export("visibleFeaturesAtPoint:inStyleLayersWithIdentifiers:")]
        public virtual Feature[] GetVisibleFeaturesAtPoint(CGPoint point, string[] styleLayerIdentifiers)
        {
            NSArray nSArray = (styleLayerIdentifiers != null) ? NSArray.FromStrings(styleLayerIdentifiers) : null;
            Feature[] result;
            if (base.IsDirectBinding)
            {
                result = NSArray.ArrayFromHandle<Feature>(Messaging.IntPtr_objc_msgSend_CGPoint_IntPtr(base.Handle, Selector.GetHandle("visibleFeaturesAtPoint:inStyleLayersWithIdentifiers:"), point, (nSArray != null) ? nSArray.Handle : IntPtr.Zero));
            }
            else
            {
                result = NSArray.ArrayFromHandle<Feature>(Messaging.IntPtr_objc_msgSendSuper_CGPoint_IntPtr(base.SuperHandle, Selector.GetHandle("visibleFeaturesAtPoint:inStyleLayersWithIdentifiers:"), point, (nSArray != null) ? nSArray.Handle : IntPtr.Zero));
            }
            if (nSArray != null)
            {
                nSArray.Dispose();
            }
            return result;
        }

        [Export("visibleFeaturesInRect:")]
        public virtual Feature[] GetVisibleFeaturesInRect(CGRect rect)
        {
            if (base.IsDirectBinding)
            {
                return NSArray.ArrayFromHandle<Feature>(Messaging.IntPtr_objc_msgSend_CGRect(base.Handle, Selector.GetHandle("visibleFeaturesInRect:"), rect));
            }
            return NSArray.ArrayFromHandle<Feature>(Messaging.IntPtr_objc_msgSendSuper_CGRect(base.SuperHandle, Selector.GetHandle("visibleFeaturesInRect:"), rect));
        }

        [Export("visibleFeaturesInRect:inStyleLayersWithIdentifiers:")]
        public virtual Feature[] GetVisibleFeaturesInRect(CGRect rect, string[] styleLayerIdentifiers)
        {
            NSArray nSArray = (styleLayerIdentifiers != null) ? NSArray.FromStrings(styleLayerIdentifiers) : null;
            Feature[] result;
            if (base.IsDirectBinding)
            {
                result = NSArray.ArrayFromHandle<Feature>(Messaging.IntPtr_objc_msgSend_CGRect_IntPtr(base.Handle, Selector.GetHandle("visibleFeaturesInRect:inStyleLayersWithIdentifiers:"), rect, (nSArray != null) ? nSArray.Handle : IntPtr.Zero));
            }
            else
            {
                result = NSArray.ArrayFromHandle<Feature>(Messaging.IntPtr_objc_msgSendSuper_CGRect_IntPtr(base.SuperHandle, Selector.GetHandle("visibleFeaturesInRect:inStyleLayersWithIdentifiers:"), rect, (nSArray != null) ? nSArray.Handle : IntPtr.Zero));
            }
            if (nSArray != null)
            {
                nSArray.Dispose();
            }
            return result;
        }

        [Export("hasStyleClass:")]
        public virtual bool HasStyleClass(string styleClass)
        {
            if (styleClass == null)
            {
                throw new ArgumentNullException("styleClass");
            }
            IntPtr intPtr = NSString.CreateNative(styleClass);
            bool result;
            if (base.IsDirectBinding)
            {
                result = Messaging.bool_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("hasStyleClass:"), intPtr);
            }
            else
            {
                result = Messaging.bool_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("hasStyleClass:"), intPtr);
            }
            NSString.ReleaseNative(intPtr);
            return result;
        }

        [Export("metersPerPixelAtLatitude:"), EditorBrowsable(EditorBrowsableState.Never), Obsolete("Use MetersPerPointAtLatitude instead", false)]
        public virtual double MetersPerPixelAtLatitude(double latitude)
        {
            if (base.IsDirectBinding)
            {
                return Messaging.Double_objc_msgSend_Double(base.Handle, Selector.GetHandle("metersPerPixelAtLatitude:"), latitude);
            }
            return Messaging.Double_objc_msgSendSuper_Double(base.SuperHandle, Selector.GetHandle("metersPerPixelAtLatitude:"), latitude);
        }

        [Export("metersPerPointAtLatitude:")]
        public virtual double MetersPerPointAtLatitude(double latitude)
        {
            if (base.IsDirectBinding)
            {
                return Messaging.Double_objc_msgSend_Double(base.Handle, Selector.GetHandle("metersPerPointAtLatitude:"), latitude);
            }
            return Messaging.Double_objc_msgSendSuper_Double(base.SuperHandle, Selector.GetHandle("metersPerPointAtLatitude:"), latitude);
        }

        [Export("reloadStyle:")]
        public virtual void ReloadStyle(NSObject sender)
        {
            if (sender == null)
            {
                throw new ArgumentNullException("sender");
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("reloadStyle:"), sender.Handle);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("reloadStyle:"), sender.Handle);
            }
        }

        [Export("removeAnnotation:")]
        public virtual void RemoveAnnotation(IAnnotation annotation)
        {
            if (annotation == null)
            {
                throw new ArgumentNullException("annotation");
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("removeAnnotation:"), annotation.Handle);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("removeAnnotation:"), annotation.Handle);
            }
        }

        [Export("removeAnnotations:")]
        public virtual void RemoveAnnotations(IAnnotation[] annotations)
        {
            if (annotations == null)
            {
                throw new ArgumentNullException("annotations");
            }
            NSArray nSArray = NSArray.FromNSObjects(annotations);
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("removeAnnotations:"), nSArray.Handle);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("removeAnnotations:"), nSArray.Handle);
            }
            nSArray.Dispose();
        }

        [Export("removeOverlay:")]
        public virtual void RemoveOverlay(IOverlay overlay)
        {
            if (overlay == null)
            {
                throw new ArgumentNullException("overlay");
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("removeOverlay:"), overlay.Handle);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("removeOverlay:"), overlay.Handle);
            }
        }

        [Export("removeOverlays:")]
        public virtual void RemoveOverlays(IOverlay[] overlays)
        {
            if (overlays == null)
            {
                throw new ArgumentNullException("overlays");
            }
            NSArray nSArray = NSArray.FromNSObjects(overlays);
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("removeOverlays:"), nSArray.Handle);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("removeOverlays:"), nSArray.Handle);
            }
            nSArray.Dispose();
        }

        [Export("removeStyleClass:")]
        public virtual void RemoveStyleClass(string styleClass)
        {
            if (styleClass == null)
            {
                throw new ArgumentNullException("styleClass");
            }
            IntPtr intPtr = NSString.CreateNative(styleClass);
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("removeStyleClass:"), intPtr);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("removeStyleClass:"), intPtr);
            }
            NSString.ReleaseNative(intPtr);
        }

        [Export("resetNorth")]
        public virtual void ResetNorth()
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend(base.Handle, Selector.GetHandle("resetNorth"));
            }
            else
            {
                Messaging.void_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("resetNorth"));
            }
        }

        [Export("resetPosition")]
        public virtual void ResetPosition()
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend(base.Handle, Selector.GetHandle("resetPosition"));
            }
            else
            {
                Messaging.void_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("resetPosition"));
            }
        }

        [Export("selectAnnotation:animated:")]
        public virtual void SelectAnnotation(IAnnotation annotation, bool animated)
        {
            if (annotation == null)
            {
                throw new ArgumentNullException("annotation");
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr_bool(base.Handle, Selector.GetHandle("selectAnnotation:animated:"), annotation.Handle, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr_bool(base.SuperHandle, Selector.GetHandle("selectAnnotation:animated:"), annotation.Handle, animated);
            }
        }

        [Export("setCamera:animated:")]
        public virtual void SetCamera(MapCamera camera, bool animated)
        {
            if (camera == null)
            {
                throw new ArgumentNullException("camera");
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr_bool(base.Handle, Selector.GetHandle("setCamera:animated:"), camera.Handle, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr_bool(base.SuperHandle, Selector.GetHandle("setCamera:animated:"), camera.Handle, animated);
            }
        }

        [Export("setCamera:withDuration:animationTimingFunction:")]
        public virtual void SetCamera(MapCamera camera, double duration, CAMediaTimingFunction function)
        {
            if (camera == null)
            {
                throw new ArgumentNullException("camera");
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr_Double_IntPtr(base.Handle, Selector.GetHandle("setCamera:withDuration:animationTimingFunction:"), camera.Handle, duration, (function != null) ? function.Handle : IntPtr.Zero);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr_Double_IntPtr(base.SuperHandle, Selector.GetHandle("setCamera:withDuration:animationTimingFunction:"), camera.Handle, duration, (function != null) ? function.Handle : IntPtr.Zero);
            }
        }

        [Export("setCamera:withDuration:animationTimingFunction:completionHandler:")]
        public unsafe virtual void SetCamera(MapCamera camera, double duration, CAMediaTimingFunction function, [BlockProxy(typeof(Trampolines.NIDAction))] Action completion)
        {
            if (camera == null)
            {
                throw new ArgumentNullException("camera");
            }
            BlockLiteral* ptr;
            if (completion == null)
            {
                ptr = null;
            }
            else
            {
                BlockLiteral blockLiteral = default(BlockLiteral);
                ptr = &blockLiteral;
                blockLiteral.SetupBlock(Trampolines.SDAction.Handler, completion);
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr_Double_IntPtr_IntPtr(base.Handle, Selector.GetHandle("setCamera:withDuration:animationTimingFunction:completionHandler:"), camera.Handle, duration, (function != null) ? function.Handle : IntPtr.Zero, (IntPtr)((void*)ptr));
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr_Double_IntPtr_IntPtr(base.SuperHandle, Selector.GetHandle("setCamera:withDuration:animationTimingFunction:completionHandler:"), camera.Handle, duration, (function != null) ? function.Handle : IntPtr.Zero, (IntPtr)((void*)ptr));
            }
            if (ptr != null)
            {
                ptr->CleanupBlock();
            }
        }

        [Export("setCenterCoordinate:animated:")]
        public virtual void SetCenterCoordinate(CLLocationCoordinate2D coordinate, bool animated)
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_CLLocationCoordinate2D_bool(base.Handle, Selector.GetHandle("setCenterCoordinate:animated:"), coordinate, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_CLLocationCoordinate2D_bool(base.SuperHandle, Selector.GetHandle("setCenterCoordinate:animated:"), coordinate, animated);
            }
        }

        [Export("setCenterCoordinate:zoomLevel:animated:")]
        public virtual void SetCenterCoordinate(CLLocationCoordinate2D centerCoordinate, double zoomLevel, bool animated)
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_CLLocationCoordinate2D_Double_bool(base.Handle, Selector.GetHandle("setCenterCoordinate:zoomLevel:animated:"), centerCoordinate, zoomLevel, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_CLLocationCoordinate2D_Double_bool(base.SuperHandle, Selector.GetHandle("setCenterCoordinate:zoomLevel:animated:"), centerCoordinate, zoomLevel, animated);
            }
        }

        [Export("setCenterCoordinate:zoomLevel:direction:animated:")]
        public virtual void SetCenterCoordinate(CLLocationCoordinate2D centerCoordinate, double zoomLevel, double direction, bool animated)
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_CLLocationCoordinate2D_Double_Double_bool(base.Handle, Selector.GetHandle("setCenterCoordinate:zoomLevel:direction:animated:"), centerCoordinate, zoomLevel, direction, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_CLLocationCoordinate2D_Double_Double_bool(base.SuperHandle, Selector.GetHandle("setCenterCoordinate:zoomLevel:direction:animated:"), centerCoordinate, zoomLevel, direction, animated);
            }
        }

        [Export("setCenterCoordinate:zoomLevel:direction:animated:completionHandler:")]
        public unsafe virtual void SetCenterCoordinate(CLLocationCoordinate2D centerCoordinate, double zoomLevel, double direction, bool animated, [BlockProxy(typeof(Trampolines.NIDAction))] Action completion)
        {
            BlockLiteral* ptr;
            if (completion == null)
            {
                ptr = null;
            }
            else
            {
                BlockLiteral blockLiteral = default(BlockLiteral);
                ptr = &blockLiteral;
                blockLiteral.SetupBlock(Trampolines.SDAction.Handler, completion);
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_CLLocationCoordinate2D_Double_Double_bool_IntPtr(base.Handle, Selector.GetHandle("setCenterCoordinate:zoomLevel:direction:animated:completionHandler:"), centerCoordinate, zoomLevel, direction, animated, (IntPtr)((void*)ptr));
            }
            else
            {
                Messaging.void_objc_msgSendSuper_CLLocationCoordinate2D_Double_Double_bool_IntPtr(base.SuperHandle, Selector.GetHandle("setCenterCoordinate:zoomLevel:direction:animated:completionHandler:"), centerCoordinate, zoomLevel, direction, animated, (IntPtr)((void*)ptr));
            }
            if (ptr != null)
            {
                ptr->CleanupBlock();
            }
        }

        [Export("setContentInset:animated:")]
        public virtual void SetContentInset(UIEdgeInsets contentInset, bool animated)
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_UIEdgeInsets_bool(base.Handle, Selector.GetHandle("setContentInset:animated:"), contentInset, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_UIEdgeInsets_bool(base.SuperHandle, Selector.GetHandle("setContentInset:animated:"), contentInset, animated);
            }
        }

        [Export("setDirection:animated:")]
        public virtual void SetDirection(double direction, bool animated)
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_Double_bool(base.Handle, Selector.GetHandle("setDirection:animated:"), direction, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_Double_bool(base.SuperHandle, Selector.GetHandle("setDirection:animated:"), direction, animated);
            }
        }

        [Export("setTargetCoordinate:animated:")]
        public virtual void SetTargetCoordinate(CLLocationCoordinate2D targetCoordinate, bool animated)
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_CLLocationCoordinate2D_bool(base.Handle, Selector.GetHandle("setTargetCoordinate:animated:"), targetCoordinate, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_CLLocationCoordinate2D_bool(base.SuperHandle, Selector.GetHandle("setTargetCoordinate:animated:"), targetCoordinate, animated);
            }
        }

        [Export("setUserLocationVerticalAlignment:animated:")]
        public virtual void SetUserLocationVerticalAlignment(AnnotationVerticalAlignment alignment, bool animated)
        {
            if (base.IsDirectBinding)
            {
                if (IntPtr.Size == 8)
                {
                    Messaging.void_objc_msgSend_UInt64_bool(base.Handle, Selector.GetHandle("setUserLocationVerticalAlignment:animated:"), (ulong)alignment, animated);
                }
                else
                {
                    Messaging.void_objc_msgSend_UInt32_bool(base.Handle, Selector.GetHandle("setUserLocationVerticalAlignment:animated:"), (uint)alignment, animated);
                }
            }
            else if (IntPtr.Size == 8)
            {
                Messaging.void_objc_msgSendSuper_UInt64_bool(base.SuperHandle, Selector.GetHandle("setUserLocationVerticalAlignment:animated:"), (ulong)alignment, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_UInt32_bool(base.SuperHandle, Selector.GetHandle("setUserLocationVerticalAlignment:animated:"), (uint)alignment, animated);
            }
        }

        [Export("setUserTrackingMode:animated:")]
        public virtual void SetUserTrackingMode(UserTrackingMode mode, bool animated)
        {
            if (base.IsDirectBinding)
            {
                if (IntPtr.Size == 8)
                {
                    Messaging.void_objc_msgSend_UInt64_bool(base.Handle, Selector.GetHandle("setUserTrackingMode:animated:"), (ulong)mode, animated);
                }
                else
                {
                    Messaging.void_objc_msgSend_UInt32_bool(base.Handle, Selector.GetHandle("setUserTrackingMode:animated:"), (uint)mode, animated);
                }
            }
            else if (IntPtr.Size == 8)
            {
                Messaging.void_objc_msgSendSuper_UInt64_bool(base.SuperHandle, Selector.GetHandle("setUserTrackingMode:animated:"), (ulong)mode, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_UInt32_bool(base.SuperHandle, Selector.GetHandle("setUserTrackingMode:animated:"), (uint)mode, animated);
            }
        }

        [Export("setVisibleCoordinateBounds:animated:")]
        public virtual void SetVisibleCoordinateBounds(CoordinateBounds bounds, bool animated)
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_CoordinateBounds_bool(base.Handle, Selector.GetHandle("setVisibleCoordinateBounds:animated:"), bounds, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_CoordinateBounds_bool(base.SuperHandle, Selector.GetHandle("setVisibleCoordinateBounds:animated:"), bounds, animated);
            }
        }

        [Export("setVisibleCoordinateBounds:edgePadding:animated:")]
        public virtual void SetVisibleCoordinateBounds(CoordinateBounds bounds, UIEdgeInsets insets, bool animated)
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_CoordinateBounds_UIEdgeInsets_bool(base.Handle, Selector.GetHandle("setVisibleCoordinateBounds:edgePadding:animated:"), bounds, insets, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_CoordinateBounds_UIEdgeInsets_bool(base.SuperHandle, Selector.GetHandle("setVisibleCoordinateBounds:edgePadding:animated:"), bounds, insets, animated);
            }
        }

        [Export("setVisibleCoordinates:count:edgePadding:animated:")]
        public virtual void SetVisibleCoordinates(IntPtr coordinates, nuint count, UIEdgeInsets insets, bool animated)
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr_nuint_UIEdgeInsets_bool(base.Handle, Selector.GetHandle("setVisibleCoordinates:count:edgePadding:animated:"), coordinates, count, insets, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr_nuint_UIEdgeInsets_bool(base.SuperHandle, Selector.GetHandle("setVisibleCoordinates:count:edgePadding:animated:"), coordinates, count, insets, animated);
            }
        }

        [Export("setVisibleCoordinates:count:edgePadding:direction:duration:animationTimingFunction:completionHandler:")]
        public unsafe virtual void SetVisibleCoordinates(IntPtr coordinates, nuint count, UIEdgeInsets insets, double direction, double duration, CAMediaTimingFunction function, [BlockProxy(typeof(Trampolines.NIDAction))] Action completion)
        {
            BlockLiteral* ptr;
            if (completion == null)
            {
                ptr = null;
            }
            else
            {
                BlockLiteral blockLiteral = default(BlockLiteral);
                ptr = &blockLiteral;
                blockLiteral.SetupBlock(Trampolines.SDAction.Handler, completion);
            }
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr_nuint_UIEdgeInsets_Double_Double_IntPtr_IntPtr(base.Handle, Selector.GetHandle("setVisibleCoordinates:count:edgePadding:direction:duration:animationTimingFunction:completionHandler:"), coordinates, count, insets, direction, duration, (function != null) ? function.Handle : IntPtr.Zero, (IntPtr)((void*)ptr));
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr_nuint_UIEdgeInsets_Double_Double_IntPtr_IntPtr(base.SuperHandle, Selector.GetHandle("setVisibleCoordinates:count:edgePadding:direction:duration:animationTimingFunction:completionHandler:"), coordinates, count, insets, direction, duration, (function != null) ? function.Handle : IntPtr.Zero, (IntPtr)((void*)ptr));
            }
            if (ptr != null)
            {
                ptr->CleanupBlock();
            }
        }

        [Export("setZoomLevel:animated:")]
        public virtual void SetZoomLevel(double zoomLevel, bool animated)
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_Double_bool(base.Handle, Selector.GetHandle("setZoomLevel:animated:"), zoomLevel, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_Double_bool(base.SuperHandle, Selector.GetHandle("setZoomLevel:animated:"), zoomLevel, animated);
            }
        }

        [Export("showAnnotations:animated:")]
        public virtual void ShowAnnotations(IAnnotation[] annotations, bool animated)
        {
            if (annotations == null)
            {
                throw new ArgumentNullException("annotations");
            }
            NSArray nSArray = NSArray.FromNSObjects(annotations);
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr_bool(base.Handle, Selector.GetHandle("showAnnotations:animated:"), nSArray.Handle, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr_bool(base.SuperHandle, Selector.GetHandle("showAnnotations:animated:"), nSArray.Handle, animated);
            }
            nSArray.Dispose();
        }

        [Export("showAnnotations:edgePadding:animated:")]
        public virtual void ShowAnnotations(IAnnotation[] annotations, UIEdgeInsets insets, bool animated)
        {
            if (annotations == null)
            {
                throw new ArgumentNullException("annotations");
            }
            NSArray nSArray = NSArray.FromNSObjects(annotations);
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr_UIEdgeInsets_bool(base.Handle, Selector.GetHandle("showAnnotations:edgePadding:animated:"), nSArray.Handle, insets, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr_UIEdgeInsets_bool(base.SuperHandle, Selector.GetHandle("showAnnotations:edgePadding:animated:"), nSArray.Handle, insets, animated);
            }
            nSArray.Dispose();
        }

        [Export("toggleDebug"), EditorBrowsable(EditorBrowsableState.Never), Obsolete("Use DebugMask instead", false)]
        public virtual void ToggleDebug()
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend(base.Handle, Selector.GetHandle("toggleDebug"));
            }
            else
            {
                Messaging.void_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("toggleDebug"));
            }
        }

        [Export("viewForAnnotation:")]
        public virtual AnnotationView ViewForAnnotation(IAnnotation annotation)
        {
            if (annotation == null)
            {
                throw new ArgumentNullException("annotation");
            }
            if (base.IsDirectBinding)
            {
                return Runtime.GetNSObject<AnnotationView>(Messaging.IntPtr_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("viewForAnnotation:"), annotation.Handle));
            }
            return Runtime.GetNSObject<AnnotationView>(Messaging.IntPtr_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("viewForAnnotation:"), annotation.Handle));
        }

        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (base.Handle == IntPtr.Zero)
            {
                this.__mt_Delegate_var = null;
                this.__mt_StyleURL_var = null;
            }
        }

        public new static MapView.MapViewAppearance GetAppearance<T>() where T : MapView
        {
            return new MapView.MapViewAppearance(Messaging.IntPtr_objc_msgSend(Class.GetHandle(typeof(T)), Selector.GetHandle("appearance")));
        }

        public new static MapView.MapViewAppearance AppearanceWhenContainedIn(params Type[] containers)
        {
            return new MapView.MapViewAppearance(UIAppearance.GetAppearance(MapView.class_ptr, containers));
        }

        public new static MapView.MapViewAppearance GetAppearance(UITraitCollection traits)
        {
            return new MapView.MapViewAppearance(UIAppearance.GetAppearance(MapView.class_ptr, traits));
        }

        public new static MapView.MapViewAppearance GetAppearance(UITraitCollection traits, params Type[] containers)
        {
            return new MapView.MapViewAppearance(UIAppearance.GetAppearance(MapView.class_ptr, traits, containers));
        }

        public new static MapView.MapViewAppearance GetAppearance<T>(UITraitCollection traits) where T : MapView
        {
            return new MapView.MapViewAppearance(UIAppearance.GetAppearance(Class.GetHandle(typeof(T)), traits));
        }

        public new static MapView.MapViewAppearance GetAppearance<T>(UITraitCollection traits, params Type[] containers) where T : MapView
        {
            return new MapView.MapViewAppearance(UIAppearance.GetAppearance(Class.GetHandle(typeof(T)), containers));
        }
    }
}
