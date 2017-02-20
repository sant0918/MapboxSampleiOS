using ObjCRuntime;

[assembly: LinkWith("", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true,
   Frameworks = "SVGKit.framework")]