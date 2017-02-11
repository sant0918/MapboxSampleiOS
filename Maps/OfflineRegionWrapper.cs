using Foundation;
using ObjCRuntime;
using System;

namespace Maps
{
    internal sealed class OfflineRegionWrapper : BaseWrapper, IOfflineRegion, INativeObject, IDisposable
    {
        public OfflineRegionWrapper(IntPtr handle) : base(handle, false)
        {
        }

        [Preserve(Conditional = true)]
        public OfflineRegionWrapper(IntPtr handle, bool owns) : base(handle, owns)
        {
        }
    }
}
