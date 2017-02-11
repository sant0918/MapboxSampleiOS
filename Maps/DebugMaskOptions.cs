using ObjCRuntime;
using System;

namespace Maps
{
    [Native]
    public enum DebugMaskOptions : ulong
    {
        TileBoundariesMask = 2uL,
        TileInfoMask = 4uL,
        TimestampsMask = 8uL,
        CollisionBoxesMask = 16uL,
        OverdrawVisualizationMask = 32uL
    }
}
