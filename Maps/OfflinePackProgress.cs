using System;

namespace Maps
{
    public struct OfflinePackProgress
    {
        private ulong CountOfResourcesCompleted;

        private ulong CountOfBytesCompleted;

        private ulong CountOfTilesCompleted;

        private ulong CountOfTileBytesCompleted;

        private ulong CountOfResourcesExpected;

        private ulong MaximumResourcesExpected;
    }
}
