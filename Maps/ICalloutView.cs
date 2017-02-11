using CoreGraphics;
using Foundation;
using ObjCRuntime;
using System;
using System.Runtime.CompilerServices;
using UIKit;

namespace Maps
{
    [Protocol(Name = "MGLCalloutView", WrapperType = typeof(CalloutViewWrapper)), ProtocolMember(IsRequired = true, IsProperty = false, IsStatic = false, Name = "PresentCallout", Selector = "presentCalloutFromRect:inView:constrainedToView:animated:", ParameterType = new Type[]
    {
        typeof(CGRect),
        typeof(UIView),
        typeof(UIView),
        typeof(bool)
    }, ParameterByRef = new bool[]
    {
        false,
        false,
        false,
        false
    }), ProtocolMember(IsRequired = true, IsProperty = false, IsStatic = false, Name = "DismissCallout", Selector = "dismissCalloutAnimated:", ParameterType = new Type[]
    {
        typeof(bool)
    }, ParameterByRef = new bool[]
    {
        false
    }), ProtocolMember(IsRequired = true, IsProperty = true, IsStatic = false, Name = "RepresentedObject", Selector = "representedObject", PropertyType = typeof(IAnnotation), GetterSelector = "representedObject", SetterSelector = "setRepresentedObject:", ArgumentSemantic = ArgumentSemantic.Retain), ProtocolMember(IsRequired = true, IsProperty = true, IsStatic = false, Name = "LeftAccessoryView", Selector = "leftAccessoryView", PropertyType = typeof(UIView), GetterSelector = "leftAccessoryView", SetterSelector = "setLeftAccessoryView:", ArgumentSemantic = ArgumentSemantic.Retain), ProtocolMember(IsRequired = true, IsProperty = true, IsStatic = false, Name = "RightAccessoryView", Selector = "rightAccessoryView", PropertyType = typeof(UIView), GetterSelector = "rightAccessoryView", SetterSelector = "setRightAccessoryView:", ArgumentSemantic = ArgumentSemantic.Retain), ProtocolMember(IsRequired = true, IsProperty = true, IsStatic = false, Name = "Delegate", Selector = "delegate", PropertyType = typeof(ICalloutViewDelegate), GetterSelector = "delegate", SetterSelector = "setDelegate:", ArgumentSemantic = ArgumentSemantic.Weak)]
    public interface ICalloutView : INativeObject, IDisposable
    {
        [Preserve(Conditional = true)]
        IAnnotation RepresentedObject
        {
            [Export("representedObject", ArgumentSemantic.Retain)]
            get;
            [Export("setRepresentedObject:", ArgumentSemantic.Retain)]
            set;
        }

        [Preserve(Conditional = true)]
        UIView LeftAccessoryView
        {
            [Export("leftAccessoryView", ArgumentSemantic.Retain)]
            get;
            [Export("setLeftAccessoryView:", ArgumentSemantic.Retain)]
            set;
        }

        [Preserve(Conditional = true)]
        UIView RightAccessoryView
        {
            [Export("rightAccessoryView", ArgumentSemantic.Retain)]
            get;
            [Export("setRightAccessoryView:", ArgumentSemantic.Retain)]
            set;
        }

        [Preserve(Conditional = true)]
        ICalloutViewDelegate Delegate
        {
            [Export("delegate", ArgumentSemantic.Weak)]
            get;
            [Export("setDelegate:", ArgumentSemantic.Weak)]
            set;
        }

        [Export("presentCalloutFromRect:inView:constrainedToView:animated:"), Preserve(Conditional = true)]
        void PresentCallout(CGRect fromRect, UIView inView, UIView constrainedToView, bool animated);

        [Export("dismissCalloutAnimated:"), Preserve(Conditional = true)]
        void DismissCallout(bool animated);
    }
}
