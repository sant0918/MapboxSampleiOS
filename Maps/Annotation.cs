using ApiDefinition;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maps
{
    [Model, Protocol, Register("MGLAnnotation", false)]
    public abstract class Annotation : NSObject, IAnnotation, INativeObject, IDisposable
    {
        
        public abstract CLLocationCoordinate2D Coordinate
        {
            [Export("coordinate")]
            get;
        }

        
        public virtual string Subtitle
        {
            [Export("subtitle")]
            get
            {
                throw new ModelNotImplementedException();
            }
        }

        
        public virtual string Title
        {
            [Export("title")]
            get
            {
                throw new ModelNotImplementedException();
            }
        }

        [Export("init"), EditorBrowsable(EditorBrowsableState.Advanced)]
        protected Annotation() : base(NSObjectFlag.Empty)
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
        protected Annotation(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal Annotation(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }
    }
}
