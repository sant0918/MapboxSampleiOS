using ApiDefinition;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UIKit;

namespace Maps
{
    [Protocol, Register("MGLAnnotationView", true)]
    public class AnnotationView : UIView
    {
        public class AnnotationViewAppearance : UIView.UIViewAppearance
        {
            protected internal AnnotationViewAppearance(IntPtr handle) : base(handle)
            {
            }
        }

        
        private static readonly IntPtr class_ptr = Class.GetHandle("MGLAnnotationView");

        public override IntPtr ClassHandle
        {
            get
            {
                return AnnotationView.class_ptr;
            }
        }

        
        public virtual Annotation Annotation
        {
            [Export("annotation")]
            get
            {
                Annotation nSObject;
                if (base.IsDirectBinding)
                {
                    nSObject = Runtime.GetNSObject<Annotation>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("annotation")));
                }
                else
                {
                    nSObject = Runtime.GetNSObject<Annotation>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("annotation")));
                }
                return nSObject;
            }
        }

        
        public virtual CGVector CenterOffset
        {
            [Export("centerOffset", ArgumentSemantic.Assign)]
            get
            {
                CGVector result;
                if (base.IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            result = Messaging.CGVector_objc_msgSend(base.Handle, Selector.GetHandle("centerOffset"));
                        }
                        else
                        {
                            Messaging.CGVector_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("centerOffset"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        result = Messaging.CGVector_objc_msgSend(base.Handle, Selector.GetHandle("centerOffset"));
                    }
                    else
                    {
                        result = Messaging.CGVector_objc_msgSend(base.Handle, Selector.GetHandle("centerOffset"));
                    }
                }
                else if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.CGVector_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("centerOffset"));
                    }
                    else
                    {
                        Messaging.CGVector_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("centerOffset"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    result = Messaging.CGVector_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("centerOffset"));
                }
                else
                {
                    result = Messaging.CGVector_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("centerOffset"));
                }
                return result;
            }
            [Export("setCenterOffset:", ArgumentSemantic.Assign)]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_CGVector(base.Handle, Selector.GetHandle("setCenterOffset:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_CGVector(base.SuperHandle, Selector.GetHandle("setCenterOffset:"), value);
                }
            }
        }

        
        public virtual bool Draggable
        {
            [Export("isDraggable")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("isDraggable"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("isDraggable"));
            }
            [Export("setDraggable:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setDraggable:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setDraggable:"), value);
                }
            }
        }

        
        public virtual AnnotationViewDragState DragState
        {
            [Export("dragState")]
            get
            {
                AnnotationViewDragState result;
                if (base.IsDirectBinding)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = (AnnotationViewDragState)Messaging.UInt64_objc_msgSend(base.Handle, Selector.GetHandle("dragState"));
                    }
                    else
                    {
                        result = (AnnotationViewDragState)Messaging.UInt32_objc_msgSend(base.Handle, Selector.GetHandle("dragState"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    result = (AnnotationViewDragState)Messaging.UInt64_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("dragState"));
                }
                else
                {
                    result = (AnnotationViewDragState)Messaging.UInt32_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("dragState"));
                }
                return result;
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

        
        public virtual bool ScalesWithViewingDistance
        {
            [Export("scalesWithViewingDistance")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("scalesWithViewingDistance"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("scalesWithViewingDistance"));
            }
            [Export("setScalesWithViewingDistance:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setScalesWithViewingDistance:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setScalesWithViewingDistance:"), value);
                }
            }
        }

        
        public virtual bool Selected
        {
            [Export("isSelected")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.bool_objc_msgSend(base.Handle, Selector.GetHandle("isSelected"));
                }
                return Messaging.bool_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("isSelected"));
            }
            [Export("setSelected:")]
            set
            {
                if (base.IsDirectBinding)
                {
                    Messaging.void_objc_msgSend_bool(base.Handle, Selector.GetHandle("setSelected:"), value);
                }
                else
                {
                    Messaging.void_objc_msgSendSuper_bool(base.SuperHandle, Selector.GetHandle("setSelected:"), value);
                }
            }
        }

        public new static AnnotationView.AnnotationViewAppearance Appearance
        {
            get
            {
                return new AnnotationView.AnnotationViewAppearance(Messaging.IntPtr_objc_msgSend(AnnotationView.class_ptr, Selector.GetHandle("appearance")));
            }
        }

        [Export("init"), EditorBrowsable(EditorBrowsableState.Advanced)]
        public AnnotationView() : base(NSObjectFlag.Empty)
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
        public AnnotationView(NSCoder coder) : base(NSObjectFlag.Empty)
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
        protected AnnotationView(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal AnnotationView(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [Export("initWithReuseIdentifier:")]
        public AnnotationView(string reuseIdentifier) : base(NSObjectFlag.Empty)
        {
            IntPtr intPtr = NSString.CreateNative(reuseIdentifier);
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
            if (base.IsDirectBinding)
            {
                base.InitializeHandle(Messaging.IntPtr_objc_msgSend_IntPtr(base.Handle, Selector.GetHandle("initWithReuseIdentifier:"), intPtr), "initWithReuseIdentifier:");
            }
            else
            {
                base.InitializeHandle(Messaging.IntPtr_objc_msgSendSuper_IntPtr(base.SuperHandle, Selector.GetHandle("initWithReuseIdentifier:"), intPtr), "initWithReuseIdentifier:");
            }
            NSString.ReleaseNative(intPtr);
        }

        [Export("prepareForReuse")]
        public virtual void PrepareForReuse()
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend(base.Handle, Selector.GetHandle("prepareForReuse"));
            }
            else
            {
                Messaging.void_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("prepareForReuse"));
            }
        }

        [Export("setDragState:animated:")]
        public virtual void SetDragState(AnnotationViewDragState dragState, bool animated)
        {
            if (base.IsDirectBinding)
            {
                if (IntPtr.Size == 8)
                {
                    Messaging.void_objc_msgSend_UInt64_bool(base.Handle, Selector.GetHandle("setDragState:animated:"), (ulong)dragState, animated);
                }
                else
                {
                    Messaging.void_objc_msgSend_UInt32_bool(base.Handle, Selector.GetHandle("setDragState:animated:"), (uint)dragState, animated);
                }
            }
            else if (IntPtr.Size == 8)
            {
                Messaging.void_objc_msgSendSuper_UInt64_bool(base.SuperHandle, Selector.GetHandle("setDragState:animated:"), (ulong)dragState, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_UInt32_bool(base.SuperHandle, Selector.GetHandle("setDragState:animated:"), (uint)dragState, animated);
            }
        }

        [Export("setSelected:animated:")]
        public virtual void SetSelected(bool selected, bool animated)
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_bool_bool(base.Handle, Selector.GetHandle("setSelected:animated:"), selected, animated);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_bool_bool(base.SuperHandle, Selector.GetHandle("setSelected:animated:"), selected, animated);
            }
        }

        public new static AnnotationView.AnnotationViewAppearance GetAppearance<T>() where T : AnnotationView
        {
            return new AnnotationView.AnnotationViewAppearance(Messaging.IntPtr_objc_msgSend(Class.GetHandle(typeof(T)), Selector.GetHandle("appearance")));
        }

        public new static AnnotationView.AnnotationViewAppearance AppearanceWhenContainedIn(params Type[] containers)
        {
            return new AnnotationView.AnnotationViewAppearance(UIAppearance.GetAppearance(AnnotationView.class_ptr, containers));
        }

        public new static AnnotationView.AnnotationViewAppearance GetAppearance(UITraitCollection traits)
        {
            return new AnnotationView.AnnotationViewAppearance(UIAppearance.GetAppearance(AnnotationView.class_ptr, traits));
        }

        public new static AnnotationView.AnnotationViewAppearance GetAppearance(UITraitCollection traits, params Type[] containers)
        {
            return new AnnotationView.AnnotationViewAppearance(UIAppearance.GetAppearance(AnnotationView.class_ptr, traits, containers));
        }

        public new static AnnotationView.AnnotationViewAppearance GetAppearance<T>(UITraitCollection traits) where T : AnnotationView
        {
            return new AnnotationView.AnnotationViewAppearance(UIAppearance.GetAppearance(Class.GetHandle(typeof(T)), traits));
        }

        public new static AnnotationView.AnnotationViewAppearance GetAppearance<T>(UITraitCollection traits, params Type[] containers) where T : AnnotationView
        {
            return new AnnotationView.AnnotationViewAppearance(UIAppearance.GetAppearance(Class.GetHandle(typeof(T)), containers));
        }
    }
}
