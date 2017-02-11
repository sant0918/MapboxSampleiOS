using Foundation;
using ObjCRuntime;
using System;
using UIKit;

namespace Maps
{
    [Protocol(Name = "MGLMapViewDelegate", WrapperType = typeof(MapViewDelegateWrapper)), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "RegionWillChange", Selector = "mapView:regionWillChangeAnimated:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(bool)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "RegionIsChanging", Selector = "mapViewRegionIsChanging:", ParameterType = new Type[]
    {
        typeof(MapView)
    }, ParameterByRef = new bool[]
    {
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "RegionDidChange", Selector = "mapView:regionDidChangeAnimated:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(bool)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "WillStartLoadingMap", Selector = "mapViewWillStartLoadingMap:", ParameterType = new Type[]
    {
        typeof(MapView)
    }, ParameterByRef = new bool[]
    {
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidFinishLoadingMap", Selector = "mapViewDidFinishLoadingMap:", ParameterType = new Type[]
    {
        typeof(MapView)
    }, ParameterByRef = new bool[]
    {
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidFailLoadingMap", Selector = "mapViewDidFailLoadingMap:withError:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(NSError)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "WillStartRenderingMap", Selector = "mapViewWillStartRenderingMap:", ParameterType = new Type[]
    {
        typeof(MapView)
    }, ParameterByRef = new bool[]
    {
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidFinishRenderingMap", Selector = "mapViewDidFinishRenderingMap:fullyRendered:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(bool)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "WillStartRenderingFrame", Selector = "mapViewWillStartRenderingFrame:", ParameterType = new Type[]
    {
        typeof(MapView)
    }, ParameterByRef = new bool[]
    {
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidFinishRenderingFrame", Selector = "mapViewDidFinishRenderingFrame:fullyRendered:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(bool)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "WillStartLocatingUser", Selector = "mapViewWillStartLocatingUser:", ParameterType = new Type[]
    {
        typeof(MapView)
    }, ParameterByRef = new bool[]
    {
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidStopLocatingUser", Selector = "mapViewDidStopLocatingUser:", ParameterType = new Type[]
    {
        typeof(MapView)
    }, ParameterByRef = new bool[]
    {
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidUpdateUserLocation", Selector = "mapView:didUpdateUserLocation:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(UserLocation)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidFailToLocateUser", Selector = "mapView:didFailToLocateUserWithError:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(NSError)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidChangeUserTrackingMode", Selector = "mapView:didChangeUserTrackingMode:animated:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(UserTrackingMode),
        typeof(bool)
    }, ParameterByRef = new bool[]
    {
        false,
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "GetImage", Selector = "mapView:imageForAnnotation:", ReturnType = typeof(AnnotationImage), ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(IAnnotation)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "GetAlpha", Selector = "mapView:alphaForShapeAnnotation:", ReturnType = typeof(nfloat), ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(Shape)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "GetStrokeColor", Selector = "mapView:strokeColorForShapeAnnotation:", ReturnType = typeof(UIColor), ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(Shape)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "GetFillColor", Selector = "mapView:fillColorForPolygonAnnotation:", ReturnType = typeof(UIColor), ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(Polygon)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "GetLineWidth", Selector = "mapView:lineWidthForPolylineAnnotation:", ReturnType = typeof(nfloat), ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(Polyline)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "GetAnnotationView", Selector = "mapView:viewForAnnotation:", ReturnType = typeof(AnnotationView), ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(IAnnotation)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidAddAnnotationViews", Selector = "mapView:didAddAnnotationViews:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(AnnotationView[])
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidSelectAnnotation", Selector = "mapView:didSelectAnnotation:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(IAnnotation)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidDeselectAnnotation", Selector = "mapView:didDeselectAnnotation:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(IAnnotation)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidSelectAnnotationView", Selector = "mapView:didSelectAnnotationView:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(AnnotationView)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidDeselectAnnotationView", Selector = "mapView:didDeselectAnnotationView:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(AnnotationView)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "CanShowCallout", Selector = "mapView:annotationCanShowCallout:", ReturnType = typeof(bool), ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(IAnnotation)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "GetCalloutView", Selector = "mapView:calloutViewForAnnotation:", ReturnType = typeof(ICalloutView), ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(IAnnotation)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "LeftCalloutAccessoryView", Selector = "mapView:leftCalloutAccessoryViewForAnnotation:", ReturnType = typeof(UIView), ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(IAnnotation)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "RightCalloutAccessoryView", Selector = "mapView:rightCalloutAccessoryViewForAnnotation:", ReturnType = typeof(UIView), ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(IAnnotation)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "CalloutAccessoryControlTapped", Selector = "mapView:annotation:calloutAccessoryControlTapped:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(IAnnotation),
        typeof(UIControl)
    }, ParameterByRef = new bool[]
    {
        false,
        false,
        false
    }), ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "TapOnCallout", Selector = "mapView:tapOnCalloutForAnnotation:", ParameterType = new Type[]
    {
        typeof(MapView),
        typeof(IAnnotation)
    }, ParameterByRef = new bool[]
    {
        false,
        false
    })]
    public interface IMapViewDelegate : INativeObject, IDisposable
    {
    }
}
