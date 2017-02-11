using ObjCRuntime;
using System;

namespace Maps
{
    [Native]
    public enum OfflinePackState : ulong
    {
        Unknown,
        Inactive,
        Active,
        Complete,
        Invalid
    }
}
