using ApiDefinition;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using System;
using System.Runtime.CompilerServices;

namespace Maps
{
    internal sealed class FeatureWrapper : BaseWrapper, IFeature, INativeObject, IDisposable, IAnnotation
    {
        
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

        public FeatureWrapper(IntPtr handle) : base(handle, false)
        {
        }

        [Preserve(Conditional = true)]
        public FeatureWrapper(IntPtr handle, bool owns) : base(handle, owns)
        {
        }
    }
}
