using ObjCRuntime;

[assembly: LinkWith("/usr/lib/libxml2.dylib",
					LinkTarget.Arm64 | LinkTarget.ArmV7 | LinkTarget.ArmV7s,
                    ForceLoad = true)]