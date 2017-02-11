using System;
using System.Runtime.CompilerServices;

namespace ObjCRuntime
{
    
    internal static class Libraries
    {
        public static class __Internal
        {
            public static readonly IntPtr Handle = Dlfcn.dlopen(null, 0);
        }
    }
}
