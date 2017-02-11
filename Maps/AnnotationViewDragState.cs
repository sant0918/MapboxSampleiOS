using ObjCRuntime;
using System;

namespace Maps
{
    [Native]
    public enum AnnotationViewDragState : ulong
    {
        None,
        Starting,
        Dragging,
        Canceling,
        Ending
    }
}
