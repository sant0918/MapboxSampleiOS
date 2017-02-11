using Foundation;
using ObjCRuntime;
using System;

namespace Maps
{
    internal sealed class MapViewDelegateWrapper : BaseWrapper, IMapViewDelegate, INativeObject, IDisposable
    {
        public MapViewDelegateWrapper(IntPtr handle) : base(handle, false)
        {
        }

        [Preserve(Conditional = true)]
        public MapViewDelegateWrapper(IntPtr handle, bool owns) : base(handle, owns)
        {
        }
    }
}
