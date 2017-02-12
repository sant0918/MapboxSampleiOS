using System;
using System.Runtime.CompilerServices;
using ObjCRuntime;

namespace ObjCR
{
    
    internal static class Libraries
    {
        public static class __Internal
        {
            public static readonly IntPtr Handle = Dlfcn.dlopen(null, 0);
        }
    }
}
