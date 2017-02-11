using Foundation;
using ObjCRuntime;
using System;

namespace Maps
{
    [Protocol(Name = "MGLFeature", WrapperType = typeof(FeatureWrapper)), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "GetAttribute", Selector = "attributeForKey:", ReturnType = typeof(NSObject), ParameterType = new Type[]
    {
        typeof(string)
    }, ParameterByRef = new bool[]
    {
        false
    }), ProtocolMember(IsRequired = false, IsProperty = true, IsStatic = false, Name = "Identifier", Selector = "identifier", PropertyType = typeof(NSObject), GetterSelector = "identifier", ArgumentSemantic = ArgumentSemantic.Copy), ProtocolMember(IsRequired = false, IsProperty = true, IsStatic = false, Name = "Attributes", Selector = "attributes", PropertyType = typeof(NSDictionary), GetterSelector = "attributes", ArgumentSemantic = ArgumentSemantic.Copy)]
    public interface IFeature : INativeObject, IDisposable, IAnnotation
    {
    }
}
