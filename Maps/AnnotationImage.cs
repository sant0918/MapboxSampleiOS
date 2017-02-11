using ApiDefinition;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UIKit;

namespace Maps
{
    [Register("MGLAnnotationImage", true)]
    public class AnnotationImage : NSObject
    {
        
        private static readonly IntPtr class_ptr = Class.GetHandle("MGLAnnotationImage");

        public override IntPtr ClassHandle
        {
            get
            {
                return AnnotationImage.class_ptr;
            }
        }

        
        public virtual bool Enabled
        {
            [Export("isEnabled")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("isEnabled"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("isEnabled"));
            }
            [Export("setEnabled:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setEnabled:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setEnabled:"), value);
                }
            }
        }

        
        public virtual UIImage Image
        {
            [Export("image")]
            get
            {
                UIImage nSObject;
                if (base.IsDirectBinding)
                {
                    nSObject = Runtime.GetNSObject<UIImage>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("image")));
                }
                else
                {
                    nSObject = Runtime.GetNSObject<UIImage>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("image")));
                }
                return nSObject;
            }
        }

        
        public virtual string ReuseIdentifier
        {
            [Export("reuseIdentifier")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return NSString.FromHandle(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("reuseIdentifier")));
                }
                return NSString.FromHandle(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("reuseIdentifier")));
            }
        }

        [Export("init"), EditorBrowsable(EditorBrowsableState.Advanced)]
        public AnnotationImage() : base(NSObjectFlag.Empty)
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
        protected AnnotationImage(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal AnnotationImage(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [Export("annotationImageWithImage:reuseIdentifier:")]
        public static AnnotationImage Create(UIImage image, string reuseIdentifier)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
            if (reuseIdentifier == null)
            {
                throw new ArgumentNullException("reuseIdentifier");
            }
            IntPtr intPtr = NSString.CreateNative(reuseIdentifier);
            AnnotationImage nSObject = Runtime.GetNSObject<AnnotationImage>(Messaging.IntPtr_objc_msgSend_IntPtr_IntPtr(AnnotationImage.class_ptr, Selector.GetHandle("annotationImageWithImage:reuseIdentifier:"), image.Handle, intPtr));
            NSString.ReleaseNative(intPtr);
            return nSObject;
        }
    }
}
