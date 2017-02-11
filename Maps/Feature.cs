using ApiDefinition;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maps
{
    [Model, Protocol, Register("MGLFeature", false)]
    public class Feature : NSObject, IFeature, IAnnotation, INativeObject, IDisposable
    {
        
        public virtual NSDictionary Attributes
        {
            [Export("attributes", ArgumentSemantic.Copy)]
            get
            {
                throw new ModelNotImplementedException();
            }
        }

        
        public virtual CLLocationCoordinate2D Coordinate
        {
            [Export("coordinate")]
            get
            {
                throw new ModelNotImplementedException();
            }
        }

        
        public virtual NSObject Identifier
        {
            [Export("identifier", ArgumentSemantic.Copy)]
            get
            {
                throw new ModelNotImplementedException();
            }
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
        public Feature() : base(NSObjectFlag.Empty)
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
        protected Feature(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal Feature(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [Export("attributeForKey:")]
        public virtual NSObject GetAttribute(string key)
        {
            throw new You_Should_Not_Call_base_In_This_Method();
        }
    }
}
