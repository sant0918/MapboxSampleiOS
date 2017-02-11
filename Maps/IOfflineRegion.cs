using Foundation;
using ObjCRuntime;
using System;

namespace Maps
{
    [Protocol(Name = "MGLOfflineRegion", WrapperType = typeof(OfflineRegionWrapper))]
    public interface IOfflineRegion : INativeObject, IDisposable
    {
    }
}
