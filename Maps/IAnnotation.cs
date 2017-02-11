using CoreLocation;
using Foundation;
using ObjCRuntime;
using System;

namespace Maps
{
    [Protocol(Name = "MGLAnnotation", WrapperType = typeof(AnnotationWrapper)), ProtocolMember(IsRequired = true, IsProperty = true, IsStatic = false, Name = "Coordinate", Selector = "coordinate", PropertyType = typeof(CLLocationCoordinate2D), GetterSelector = "coordinate", ArgumentSemantic = ArgumentSemantic.None), ProtocolMember(IsRequired = false, IsProperty = true, IsStatic = false, Name = "Title", Selector = "title", PropertyType = typeof(string), GetterSelector = "title", ArgumentSemantic = ArgumentSemantic.None), ProtocolMember(IsRequired = false, IsProperty = true, IsStatic = false, Name = "Subtitle", Selector = "subtitle", PropertyType = typeof(string), GetterSelector = "subtitle", ArgumentSemantic = ArgumentSemantic.None)]
    public interface IAnnotation : INativeObject, IDisposable
    {
        [Preserve(Conditional = true)]
        CLLocationCoordinate2D Coordinate
        {
            [Export("coordinate")]
            get;
        }
    }
}
