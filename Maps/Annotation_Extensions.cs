using ApiDefinition;
using Foundation;
using ObjCRuntime;
using System;
using System.Runtime.CompilerServices;

namespace Maps
{
    public static class Annotation_Extensions
    {
        
        public static string GetTitle(this IAnnotation This)
        {
            return NSString.FromHandle(Messaging.IntPtr_objc_msgSend(This.Handle, Selector.GetHandle("title")));
        }

        
        public static string GetSubtitle(this IAnnotation This)
        {
            return NSString.FromHandle(Messaging.IntPtr_objc_msgSend(This.Handle, Selector.GetHandle("subtitle")));
        }
    }
}
