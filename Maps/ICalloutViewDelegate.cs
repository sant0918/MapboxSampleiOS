using Foundation;
using ObjCRuntime;
using System;

namespace Maps
{
    [Protocol(Name = "MGLCalloutViewDelegate", WrapperType = typeof(CalloutViewDelegateWrapper)), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "ShouldHighlight", Selector = "calloutViewShouldHighlight:", ReturnType = typeof(bool), ParameterType = new Type[]
    {
        typeof(ICalloutView)
    }, ParameterByRef = new bool[]
    {
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "Tapped", Selector = "calloutViewTapped:", ParameterType = new Type[]
    {
        typeof(ICalloutView)
    }, ParameterByRef = new bool[]
    {
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "WillAppear", Selector = "calloutViewWillAppear:", ParameterType = new Type[]
    {
        typeof(ICalloutView)
    }, ParameterByRef = new bool[]
    {
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidAppear", Selector = "calloutViewDidAppear:", ParameterType = new Type[]
    {
        typeof(ICalloutView)
    }, ParameterByRef = new bool[]
    {
        false
    })]
    public interface ICalloutViewDelegate : INativeObject, IDisposable
    {
    }
}
