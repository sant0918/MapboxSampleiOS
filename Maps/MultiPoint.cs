using ApiDefinition;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maps
{
    [Register("MGLMultiPoint", true)]
    public class MultiPoint : Shape
    {
        
        private static readonly IntPtr class_ptr = Class.GetHandle("MGLMultiPoint");

        public override IntPtr ClassHandle
        {
            get
            {
                return MultiPoint.class_ptr;
            }
        }

        
        public virtual IntPtr Coordinates
        {
            [Export("coordinates")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("coordinates"));
                }
                return Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("coordinates"));
            }
        }

        
        public virtual nuint PointCount
        {
            [Export("pointCount")]
            get
            {
                if (base.IsDirectBinding)
                {
                    return Messaging.nuint_objc_msgSend(base.Handle, Selector.GetHandle("pointCount"));
                }
                return Messaging.nuint_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("pointCount"));
            }
        }

        [Export("init"), EditorBrowsable(EditorBrowsableState.Advanced)]
        public MultiPoint() : base(NSObjectFlag.Empty)
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
        protected MultiPoint(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal MultiPoint(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [Export("getCoordinates:range:")]
        public virtual void GetCoordinates(IntPtr coordsStructArrayPointer, NSRange range)
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend_IntPtr_NSRange(base.Handle, Selector.GetHandle("getCoordinates:range:"), coordsStructArrayPointer, range);
            }
            else
            {
                Messaging.void_objc_msgSendSuper_IntPtr_NSRange(base.SuperHandle, Selector.GetHandle("getCoordinates:range:"), coordsStructArrayPointer, range);
            }
        }
    }
}
