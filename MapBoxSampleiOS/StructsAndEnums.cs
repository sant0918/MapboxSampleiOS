using System.Runtime.InteropServices;
using CoreGraphics;

public enum DOMNodeType : uint
{
	ElementNode = 1,
	AttributeNode = 2,
	TextNode = 3,
	CdataSectionNode = 4,
	EntityReferenceNode = 5,
	EntityNode = 6,
	ProcessingInstructionNode = 7,
	CommentNode = 8,
	DocumentNode = 9,
	DocumentTypeNode = 10,
	DocumentFragmentNode = 11,
	NotationNode = 12
}

public enum CSSUnitType : uint
{
	Inherit = 0,
	PrimitiveValue = 1,
	ValueList = 2,
	Custom = 3
}

public enum CSSRuleType : uint
{
	UnknownRule = 0,
	StyleRule = 1,
	CharsetRule = 2,
	ImportRule = 3,
	MediaRule = 4,
	FontFaceRule = 5,
	PageRule = 6
}

public enum SvgLengthType : uint
{
	Unknown = 0,
	Number = 1,
	Percentage = 2,
	Ems = 3,
	Exs = 4,
	Px = 5,
	Cm = 6,
	Mm = 7,
	In = 8,
	Pt = 9,
	Pc = 10
}

[StructLayout (LayoutKind.Sequential)]
public struct SVGColor
{
	public byte r;

	public byte g;

	public byte b;

	public byte a;
}

[StructLayout (LayoutKind.Sequential)]
public struct SVGRect
{
	public float x;

	public float y;

	public float width;

	public float height;
}

public enum SvgPreserveaspectratio : uint
{
	Unknown = 0,
	None = 1,
	Xminymin = 2,
	Xmidymin = 3,
	Xmaxymin = 4,
	Xminymid = 5,
	Xmidymid = 6,
	Xmaxymid = 7,
	Xminymax = 8,
	Xmidymax = 9,
	Xmaxymax = 10
}

public enum SvgMeetorslice : uint
{
	Unknown = 0,
	Meet = 1,
	Slice = 2
}

public enum SVGKAngleType : uint
{
	Unknown = 0,
	Unspecified = 1,
	Deg = 2,
	Rad = 3,
	Grad = 4
}

[StructLayout (LayoutKind.Sequential)]
public struct SVGNumber
{
	public float value;
}

public enum SVGKTransformType : uint
{
	Unknown = 0,
	Matrix = 1,
	Translate = 2,
	Scale = 3,
	Rotate = 4,
	Skewx = 5,
	Skewy = 6
}

public enum SvgUnitType : uint
{
	Unknown = 0,
	Userspaceonuse = 1,
	Objectboundingbox = 2
}

public enum SVGLengthAdjust : uint
{
	Unknown = 0,
	Spacing = 1,
	SpacingAndGlyphs = 2
}

public enum CSSPrimitiveType : uint
{
	Unknown = 0,
	Number = 1,
	Percentage = 2,
	Ems = 3,
	Exs = 4,
	Px = 5,
	Cm = 6,
	Mm = 7,
	In = 8,
	Pt = 9,
	Pc = 10,
	Deg = 11,
	Rad = 12,
	Grad = 13,
	Ms = 14,
	S = 15,
	Hz = 16,
	Khz = 17,
	Dimension = 18,
	String = 19,
	Uri = 20,
	Ident = 21,
	Attr = 22,
	Counter = 23,
	Rect = 24,
	Rgbcolor = 25
}

[StructLayout (LayoutKind.Sequential)]
public struct SVGCurve
{
	public CGPoint c1;

	public CGPoint c2;

	public CGPoint p;
}
