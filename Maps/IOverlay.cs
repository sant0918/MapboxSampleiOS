using Foundation;
using ObjCRuntime;
using System;
using System.Runtime.CompilerServices;

namespace Maps
{
    [Protocol(Name = "MGLOverlay", WrapperType = typeof(OverlayWrapper)), ProtocolMember(IsRequired = true, IsProperty = false, IsStatic = false, Name = "IntersectsOverlayBounds", Selector = "intersectsOverlayBounds:", ReturnType = typeof(bool), ParameterType = new Type[]
    {
        typeof(CoordinateBounds)
    }, ParameterByRef = new bool[]
    {
        false
    }), ProtocolMember(IsRequired = true, IsProperty = true, IsStatic = false, Name = "OverlayBounds", Selector = "overlayBounds", PropertyType = typeof(CoordinateBounds), GetterSelector = "overlayBounds", ArgumentSemantic = ArgumentSemantic.None)]
    public interface IOverlay : INativeObject, IDisposable, IAnnotation
    {
        [Preserve(Conditional = true)]
        CoordinateBounds OverlayBounds
        {
            [Export("overlayBounds")]
            get;
        }

        [Export("intersectsOverlayBounds:"), Preserve(Conditional = true)]
        bool IntersectsOverlayBounds(CoordinateBounds overlayBounds);
    }
}
