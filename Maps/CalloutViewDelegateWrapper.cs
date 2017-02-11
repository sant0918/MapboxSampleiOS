using Foundation;
using ObjCRuntime;
using System;

namespace Maps
{
    internal sealed class CalloutViewDelegateWrapper : BaseWrapper, ICalloutViewDelegate, INativeObject, IDisposable
    {
        public CalloutViewDelegateWrapper(IntPtr handle) : base(handle, false)
        {
        }

        [Preserve(Conditional = true)]
        public CalloutViewDelegateWrapper(IntPtr handle, bool owns) : base(handle, owns)
        {
        }
    }
}
