using ObjCRuntime;
using System;

namespace Maps
{
    [Native]
    public enum UserTrackingMode : ulong
    {
        None,
        Follow,
        FollowWithHeading,
        FollowWithCourse
    }
}
