using ApiDefinition;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using System;
using System.Runtime.CompilerServices;
using UIKit;

namespace Maps
{
    internal sealed class CalloutViewWrapper : BaseWrapper, ICalloutView, INativeObject, IDisposable
    {
        
        public IAnnotation RepresentedObject
        {
            [Export("representedObject", ArgumentSemantic.Retain)]
            get
            {
                return Runtime.GetINativeObject<IAnnotation>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("representedObject")), false);
            }
            [Export("setRepresentedObject:", ArgumentSemantic.Retain)]
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("setRepresentedObject:"), value.Handle);
            }
        }

        
        public UIView LeftAccessoryView
        {
            [Export("leftAccessoryView", ArgumentSemantic.Retain)]
            get
            {
                return Runtime.GetNSObject<UIView>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("leftAccessoryView")));
            }
            [Export("setLeftAccessoryView:", ArgumentSemantic.Retain)]
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("setLeftAccessoryView:"), value.Handle);
            }
        }

        
        public UIView RightAccessoryView
        {
            [Export("rightAccessoryView", ArgumentSemantic.Retain)]
            get
            {
                return Runtime.GetNSObject<UIView>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("rightAccessoryView")));
            }
            [Export("setRightAccessoryView:", ArgumentSemantic.Retain)]
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("setRightAccessoryView:"), value.Handle);
            }
        }

        
        public ICalloutViewDelegate Delegate
        {
            [Export("delegate", ArgumentSemantic.Weak)]
            get
            {
                return Runtime.GetINativeObject<ICalloutViewDelegate>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("delegate")), false);
            }
            [Export("setDelegate:", ArgumentSemantic.Weak)]
            set
            {
                Messaging.void_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("setDelegate:"), (value != null) ? value.Handle : IntPtr.Zero);
            }
        }

        public CalloutViewWrapper(IntPtr handle) : base(handle, false)
        {
        }

        [Preserve(Conditional = true)]
        public CalloutViewWrapper(IntPtr handle, bool owns) : base(handle, owns)
        {
        }

        [Export("presentCalloutFromRect:inView:constrainedToView:animated:")]
        public void PresentCallout(CGRect fromRect, UIView inView, UIView constrainedToView, bool animated)
        {
            if (inView == null)
            {
                throw new ArgumentNullException("inView");
            }
            if (constrainedToView == null)
            {
                throw new ArgumentNullException("constrainedToView");
            }
            Messaging.void_objc_msgSend_CGRect_IntPtr_IntPtr_bool(base.Handle, Selector.GetHandle("presentCalloutFromRect:inView:constrainedToView:animated:"), fromRect, inView.Handle, constrainedToView.Handle, animated);
        }

        [Export("dismissCalloutAnimated:")]
        public void DismissCallout(bool animated)
        {
            Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("dismissCalloutAnimated:"), animated);
        }
    }
}
