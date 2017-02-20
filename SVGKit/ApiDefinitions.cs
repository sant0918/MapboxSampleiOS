using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using SVGKit;

// @interface  (Node)
[Category]
[BaseType (typeof(Node))]
interface Node_
{
	// @property (readwrite, nonatomic, strong) NSString * nodeName;
	[Export ("nodeName", ArgumentSemantic.Strong)]
	string NodeName { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * nodeValue;
	[Export ("nodeValue", ArgumentSemantic.Strong)]
	string NodeValue { get; set; }

	// @property (readwrite, nonatomic) DOMNodeType nodeType;
	[Export ("nodeType", ArgumentSemantic.Assign)]
	DOMNodeType NodeType { get; set; }

	// @property (readwrite, nonatomic, weak) Node * parentNode;
	[Export ("parentNode", ArgumentSemantic.Weak)]
	Node ParentNode { get; set; }

	// @property (readwrite, nonatomic, strong) NodeList * childNodes;
	[Export ("childNodes", ArgumentSemantic.Strong)]
	NodeList ChildNodes { get; set; }

	// @property (readwrite, nonatomic, strong) NamedNodeMap * attributes;
	[Export ("attributes", ArgumentSemantic.Strong)]
	NamedNodeMap Attributes { get; set; }

	// @property (readwrite, nonatomic, weak) Document * ownerDocument;
	[Export ("ownerDocument", ArgumentSemantic.Weak)]
	Document OwnerDocument { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * namespaceURI;
	[Export ("namespaceURI", ArgumentSemantic.Strong)]
	string NamespaceURI { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * prefix;
	[Export ("prefix", ArgumentSemantic.Strong)]
	string Prefix { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * localName;
	[Export ("localName", ArgumentSemantic.Strong)]
	string LocalName { get; set; }
}

// @interface  (BaseClassForAllSVGBasicShapes)
[Category]
[BaseType (typeof(BaseClassForAllSVGBasicShapes))]
interface BaseClassForAllSVGBasicShapes_
{
	// @property (readwrite, nonatomic) CGPathRef pathForShapeInRelativeCoords;
	[Export ("pathForShapeInRelativeCoords", ArgumentSemantic.Assign)]
	unsafe CGPathRef* PathForShapeInRelativeCoords { get; set; }
}

// @interface  (SVGElement)
[Category]
[BaseType (typeof(SVGElement))]
interface SVGElement_
{
	// +(BOOL)shouldStoreContent;
	[Static]
	[Export ("shouldStoreContent")]
	[Verify (MethodToProperty)]
	bool ShouldStoreContent { get; }

	// -(void)loadDefaults;
	[Export ("loadDefaults")]
	void LoadDefaults ();

	// -(void)postProcessAttributesAddingErrorsTo:(SVGKParseResult *)parseResult;
	[Export ("postProcessAttributesAddingErrorsTo:")]
	void PostProcessAttributesAddingErrorsTo (SVGKParseResult parseResult);
}

// typedef void (^SVGKImageAsynchronousLoadingDelegate)(SVGKImage *, SVGKParseResult *);
delegate void SVGKImageAsynchronousLoadingDelegate (SVGKImage arg0, SVGKParseResult arg1);

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern double SVGKitFramework_VersionNumber;
	[Field ("SVGKitFramework_VersionNumber", "__Internal")]
	double SVGKitFramework_VersionNumber { get; }

	// extern const unsigned char [] SVGKitFramework_VersionString;
	[Field ("SVGKitFramework_VersionString", "__Internal")]
	byte[] SVGKitFramework_VersionString { get; }
}

// @interface  (CSSRuleList)
[Category]
[BaseType (typeof(CSSRuleList))]
interface CSSRuleList_
{
	// @property (nonatomic, strong) NSMutableArray * internalArray;
	[Export ("internalArray", ArgumentSemantic.Strong)]
	NSMutableArray InternalArray { get; set; }
}

// @interface  (CSSPrimitiveValue)
[Category]
[BaseType (typeof(CSSPrimitiveValue))]
interface CSSPrimitiveValue_
{
	// @property (nonatomic) float pixelsPerInch;
	[Export ("pixelsPerInch")]
	float PixelsPerInch { get; set; }
}

// @interface  (CSSValue)
[Category]
[BaseType (typeof(CSSValue))]
interface CSSValue_
{
	// -(id)initWithUnitType:(CSSUnitType)t;
	[Export ("initWithUnitType:")]
	IntPtr Constructor (CSSUnitType t);
}

// @interface  (Document)
[Category]
[BaseType (typeof(Document))]
interface Document_
{
	// @property (readwrite, nonatomic, strong) Element * documentElement;
	[Export ("documentElement", ArgumentSemantic.Strong)]
	Element DocumentElement { get; set; }
}

// @interface  (StyleSheetList)
[Category]
[BaseType (typeof(StyleSheetList))]
interface StyleSheetList_
{
	// @property (nonatomic, strong) NSMutableArray * internalArray;
	[Export ("internalArray", ArgumentSemantic.Strong)]
	NSMutableArray InternalArray { get; set; }
}

// @interface  (NamedNodeMap)
[Category]
[BaseType (typeof(NamedNodeMap))]
interface NamedNodeMap_
{
	// -(NSArray *)allNodesUnsortedDOM1;
	[Export ("allNodesUnsortedDOM1")]
	[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
	NSObject[] AllNodesUnsortedDOM1 { get; }

	// -(NSDictionary *)allNodesUnsortedDOM2;
	[Export ("allNodesUnsortedDOM2")]
	[Verify (MethodToProperty)]
	NSDictionary AllNodesUnsortedDOM2 { get; }
}

// @interface  (NodeList)
[Category]
[BaseType (typeof(NodeList))]
interface NodeList_
{
	// @property (nonatomic, strong) NSMutableArray * internalArray;
	[Export ("internalArray", ArgumentSemantic.Strong)]
	NSMutableArray InternalArray { get; set; }
}

// @interface  (SVGDocument)
[Category]
[BaseType (typeof(SVGDocument))]
interface SVGDocument_
{
	// @property (readwrite, nonatomic, strong) NSString * title;
	[Export ("title", ArgumentSemantic.Strong)]
	string Title { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * referrer;
	[Export ("referrer", ArgumentSemantic.Strong)]
	string Referrer { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * domain;
	[Export ("domain", ArgumentSemantic.Strong)]
	string Domain { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * URL;
	[Export ("URL", ArgumentSemantic.Strong)]
	string URL { get; set; }

	// @property (readwrite, nonatomic, strong) SVGSVGElement * rootElement;
	[Export ("rootElement", ArgumentSemantic.Strong)]
	SVGSVGElement RootElement { get; set; }
}

// @interface  (SVGElementInstance)
[Category]
[BaseType (typeof(SVGElementInstance))]
interface SVGElementInstance_
{
	// @property (readwrite, nonatomic, weak) SVGElement * correspondingElement;
	[Export ("correspondingElement", ArgumentSemantic.Weak)]
	SVGElement CorrespondingElement { get; set; }

	// @property (readwrite, nonatomic, weak) SVGUseElement * correspondingUseElement;
	[Export ("correspondingUseElement", ArgumentSemantic.Weak)]
	SVGUseElement CorrespondingUseElement { get; set; }

	// @property (readwrite, nonatomic, strong) SVGElementInstance * parentNode;
	[Export ("parentNode", ArgumentSemantic.Strong)]
	SVGElementInstance ParentNode { get; set; }

	// @property (readwrite, nonatomic, strong) SVGElementInstanceList * childNodes;
	[Export ("childNodes", ArgumentSemantic.Strong)]
	SVGElementInstanceList ChildNodes { get; set; }
}

// @interface  (SVGElementInstanceList)
[Category]
[BaseType (typeof(SVGElementInstanceList))]
interface SVGElementInstanceList_
{
	// @property (nonatomic, strong) NSMutableArray * internalArray;
	[Export ("internalArray", ArgumentSemantic.Strong)]
	NSMutableArray InternalArray { get; set; }
}

// @interface  (SVGSVGElement)
[Category]
[BaseType (typeof(SVGSVGElement))]
interface SVGSVGElement_
{
	// @property (readwrite, nonatomic, strong) SVGLength * x;
	[Export ("x", ArgumentSemantic.Strong)]
	SVGLength X { get; set; }

	// @property (readwrite, nonatomic, strong) SVGLength * y;
	[Export ("y", ArgumentSemantic.Strong)]
	SVGLength Y { get; set; }

	// @property (readwrite, nonatomic, strong) SVGLength * width;
	[Export ("width", ArgumentSemantic.Strong)]
	SVGLength Width { get; set; }

	// @property (readwrite, nonatomic, strong) SVGLength * height;
	[Export ("height", ArgumentSemantic.Strong)]
	SVGLength Height { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * contentScriptType;
	[Export ("contentScriptType", ArgumentSemantic.Strong)]
	string ContentScriptType { get; set; }

	// @property (readwrite, nonatomic, strong) NSString * contentStyleType;
	[Export ("contentStyleType", ArgumentSemantic.Strong)]
	string ContentStyleType { get; set; }

	// @property (readwrite, nonatomic) SVGRect viewport;
	[Export ("viewport", ArgumentSemantic.Assign)]
	SVGRect Viewport { get; set; }

	// @property (readwrite, nonatomic) float pixelUnitToMillimeterX;
	[Export ("pixelUnitToMillimeterX")]
	float PixelUnitToMillimeterX { get; set; }

	// @property (readwrite, nonatomic) float pixelUnitToMillimeterY;
	[Export ("pixelUnitToMillimeterY")]
	float PixelUnitToMillimeterY { get; set; }

	// @property (readwrite, nonatomic) float screenPixelToMillimeterX;
	[Export ("screenPixelToMillimeterX")]
	float ScreenPixelToMillimeterX { get; set; }

	// @property (readwrite, nonatomic) float screenPixelToMillimeterY;
	[Export ("screenPixelToMillimeterY")]
	float ScreenPixelToMillimeterY { get; set; }

	// @property (readwrite, nonatomic) BOOL useCurrentView;
	[Export ("useCurrentView")]
	bool UseCurrentView { get; set; }

	// @property (readwrite, nonatomic, strong) SVGViewSpec * currentView;
	[Export ("currentView", ArgumentSemantic.Strong)]
	SVGViewSpec CurrentView { get; set; }

	// @property (readwrite, nonatomic) float currentScale;
	[Export ("currentScale")]
	float CurrentScale { get; set; }

	// @property (readwrite, nonatomic, strong) SVGPoint * currentTranslate;
	[Export ("currentTranslate", ArgumentSemantic.Strong)]
	SVGPoint CurrentTranslate { get; set; }
}

// @interface  (SVGUseElement)
[Category]
[BaseType (typeof(SVGUseElement))]
interface SVGUseElement_
{
	// @property (readwrite, nonatomic, strong) SVGLength * x;
	[Export ("x", ArgumentSemantic.Strong)]
	SVGLength X { get; set; }

	// @property (readwrite, nonatomic, strong) SVGLength * y;
	[Export ("y", ArgumentSemantic.Strong)]
	SVGLength Y { get; set; }

	// @property (readwrite, nonatomic, strong) SVGLength * width;
	[Export ("width", ArgumentSemantic.Strong)]
	SVGLength Width { get; set; }

	// @property (readwrite, nonatomic, strong) SVGLength * height;
	[Export ("height", ArgumentSemantic.Strong)]
	SVGLength Height { get; set; }

	// @property (readwrite, nonatomic, strong) SVGElementInstance * instanceRoot;
	[Export ("instanceRoot", ArgumentSemantic.Strong)]
	SVGElementInstance InstanceRoot { get; set; }

	// @property (readwrite, nonatomic, strong) SVGElementInstance * animatedInstanceRoot;
	[Export ("animatedInstanceRoot", ArgumentSemantic.Strong)]
	SVGElementInstance AnimatedInstanceRoot { get; set; }
}

// @interface  (SVGTextPositioningElement)
[Category]
[BaseType (typeof(SVGTextPositioningElement))]
interface SVGTextPositioningElement_
{
	// @property (readwrite, nonatomic, strong) SVGLength * x;
	[Export ("x", ArgumentSemantic.Strong)]
	SVGLength X { get; set; }

	// @property (readwrite, nonatomic, strong) SVGLength * y;
	[Export ("y", ArgumentSemantic.Strong)]
	SVGLength Y { get; set; }

	// @property (readwrite, nonatomic, strong) SVGLength * dx;
	[Export ("dx", ArgumentSemantic.Strong)]
	SVGLength Dx { get; set; }

	// @property (readwrite, nonatomic, strong) SVGLength * dy;
	[Export ("dy", ArgumentSemantic.Strong)]
	SVGLength Dy { get; set; }

	// @property (readwrite, nonatomic, strong) SVGLength * rotate;
	[Export ("rotate", ArgumentSemantic.Strong)]
	SVGLength Rotate { get; set; }
}
