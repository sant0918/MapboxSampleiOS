using ApiDefinition;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maps
{
    [Register("MGLOfflinePack", true)]
    public class OfflinePack : NSObject
    {
        
        private static readonly IntPtr class_ptr = Class.GetHandle("MGLOfflinePack");

        public override IntPtr ClassHandle
        {
            get
            {
                return OfflinePack.class_ptr;
            }
        }

        
        public virtual NSData Context
        {
            [Export("context")]
            get
            {
                NSData nSObject;
                if (base.IsDirectBinding)
                {
                    nSObject = Runtime.GetNSObject<NSData>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("context")));
                }
                else
                {
                    nSObject = Runtime.GetNSObject<NSData>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("context")));
                }
                return nSObject;
            }
        }

        
        public virtual OfflinePackProgress Progress
        {
            [Export("progress")]
            get
            {
                OfflinePackProgress result;
                if (base.IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            result = Messaging.OfflinePackProgress_objc_msgSend(base.Handle, Selector.GetHandle("progress"));
                        }
                        else
                        {
                            Messaging.OfflinePackProgress_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("progress"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        Messaging.OfflinePackProgress_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("progress"));
                    }
                    else
                    {
                        Messaging.OfflinePackProgress_objc_msgSend_stret(out result, base.Handle, Selector.GetHandle("progress"));
                    }
                }
                else if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = Messaging.OfflinePackProgress_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("progress"));
                    }
                    else
                    {
                        Messaging.OfflinePackProgress_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("progress"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    Messaging.OfflinePackProgress_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("progress"));
                }
                else
                {
                    Messaging.OfflinePackProgress_objc_msgSendSuper_stret(out result, base.SuperHandle, Selector.GetHandle("progress"));
                }
                return result;
            }
        }

        
        public virtual IOfflineRegion Region
        {
            [Export("region")]
            get
            {
                IOfflineRegion iNativeObject;
                if (base.IsDirectBinding)
                {
                    iNativeObject = Runtime.GetINativeObject<IOfflineRegion>(Messaging.IntPtr_objc_msgSend(base.Handle, Selector.GetHandle("region")), false);
                }
                else
                {
                    iNativeObject = Runtime.GetINativeObject<IOfflineRegion>(Messaging.IntPtr_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("region")), false);
                }
                return iNativeObject;
            }
        }

        
        public virtual OfflinePackState State
        {
            [Export("state")]
            get
            {
                OfflinePackState result;
                if (base.IsDirectBinding)
                {
                    if (IntPtr.Size == 8)
                    {
                        result = (OfflinePackState)Messaging.UInt64_objc_msgSend(base.Handle, Selector.GetHandle("state"));
                    }
                    else
                    {
                        result = (OfflinePackState)Messaging.UInt32_objc_msgSend(base.Handle, Selector.GetHandle("state"));
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    result = (OfflinePackState)Messaging.UInt64_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("state"));
                }
                else
                {
                    result = (OfflinePackState)Messaging.UInt32_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("state"));
                }
                return result;
            }
        }

        [Export("init"), EditorBrowsable(EditorBrowsableState.Advanced)]
        public OfflinePack() : base(NSObjectFlag.Empty)
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
        protected OfflinePack(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal OfflinePack(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [Export("requestProgress")]
        public virtual void RequestProgress()
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend(base.Handle, Selector.GetHandle("requestProgress"));
            }
            else
            {
                Messaging.void_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("requestProgress"));
            }
        }

        [Export("resume")]
        public virtual void Resume()
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend(base.Handle, Selector.GetHandle("resume"));
            }
            else
            {
                Messaging.void_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("resume"));
            }
        }

        [Export("suspend")]
        public virtual void Suspend()
        {
            if (base.IsDirectBinding)
            {
                Messaging.void_objc_msgSend(base.Handle, Selector.GetHandle("suspend"));
            }
            else
            {
                Messaging.void_objc_msgSendSuper(base.SuperHandle, Selector.GetHandle("suspend"));
            }
        }
    }
}
