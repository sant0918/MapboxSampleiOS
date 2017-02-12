using ApiDefinition;
using Foundation;
using ObjCRuntime;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maps
{
    [Protocol, Register("MGLAccountManager", true)]
    public class AccountManager : NSObject
    {
        
        private static readonly IntPtr class_ptr = Class.GetHandle("MGLAccountManager");

        public override IntPtr ClassHandle
        {
            get
            {
                return AccountManager.class_ptr;
            }
        }

        
        public static string AccessToken
        {
            [Export("accessToken")]
            get
            {
                return NSString.FromHandle(Messaging.IntPtr_objc_msgSend(AccountManager.class_ptr, Selector.GetHandle("accessToken")));
            }
            [Export("setAccessToken:")]
            set
            {
                IntPtr intPtr = NSString.CreateNative(value);
                Messaging.void_objc_msgSend_IntPtr(AccountManager.class_ptr, Selector.GetHandle("setAccessToken:"), intPtr);
                NSString.ReleaseNative(intPtr);
            }
        }

        
        public static bool MetricsEnabledSettingShownInApp
        {
            [Export("mapboxMetricsEnabledSettingShownInApp")]
            get
            {
                return Messaging.bool_objc_msgSend(AccountManager.class_ptr, Selector.GetHandle("mapboxMetricsEnabledSettingShownInApp"));
            }
        }

        [Export("init"), EditorBrowsable(EditorBrowsableState.Advanced)]
        public AccountManager() : base(NSObjectFlag.Empty)
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
        protected AccountManager(NSObjectFlag t) : base(t)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal AccountManager(IntPtr handle) : base(handle)
        {
            base.IsDirectBinding = (base.GetType().Assembly == Messaging.this_assembly);
        }
    }
}
