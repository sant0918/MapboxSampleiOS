using CoreGraphics;
using CoreLocation;
using Foundation;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using UIKit;


namespace ApiDefinition
{
    internal class Messaging
    {
        internal static Assembly this_assembly = typeof(Messaging).Assembly;

        private const string LIBOBJC_DYLIB = "/usr/lib/libobjc.dylib";

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend(IntPtr receiever, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper(IntPtr receiever, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_IntPtr(IntPtr receiever, IntPtr selector, IntPtr arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_IntPtr(IntPtr receiever, IntPtr selector, IntPtr arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern bool bool_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern bool bool_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern CLLocationCoordinate2D CLLocationCoordinate2D_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern CLLocationCoordinate2D CLLocationCoordinate2D_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern void CLLocationCoordinate2D_objc_msgSend_stret(out CLLocationCoordinate2D retval, IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper_stret")]
        public static extern void CLLocationCoordinate2D_objc_msgSendSuper_stret(out CLLocationCoordinate2D retval, IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern CoordinateSpan CoordinateSpan_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern CoordinateSpan CoordinateSpan_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern void CoordinateSpan_objc_msgSend_stret(out CoordinateSpan retval, IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper_stret")]
        public static extern void CoordinateSpan_objc_msgSendSuper_stret(out CoordinateSpan retval, IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern CoordinateBounds CoordinateBounds_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern CoordinateBounds CoordinateBounds_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern void CoordinateBounds_objc_msgSend_stret(out CoordinateBounds retval, IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper_stret")]
        public static extern void CoordinateBounds_objc_msgSendSuper_stret(out CoordinateBounds retval, IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern OfflinePackProgress OfflinePackProgress_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern OfflinePackProgress OfflinePackProgress_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern void OfflinePackProgress_objc_msgSend_stret(out OfflinePackProgress retval, IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper_stret")]
        public static extern void OfflinePackProgress_objc_msgSendSuper_stret(out OfflinePackProgress retval, IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_CLLocationCoordinate2D(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_CLLocationCoordinate2D(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_CoordinateSpan(IntPtr receiver, IntPtr selector, CoordinateSpan arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_CoordinateSpan(IntPtr receiver, IntPtr selector, CoordinateSpan arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_CoordinateBounds(IntPtr receiver, IntPtr selector, CoordinateBounds arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_CoordinateBounds(IntPtr receiver, IntPtr selector, CoordinateBounds arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_OfflinePackProgress(IntPtr receiver, IntPtr selector, OfflinePackProgress arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_OfflinePackProgress(IntPtr receiver, IntPtr selector, OfflinePackProgress arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_bool(IntPtr receiver, IntPtr selector, bool arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_bool(IntPtr receiver, IntPtr selector, bool arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern CGVector CGVector_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern CGVector CGVector_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern void CGVector_objc_msgSend_stret(out CGVector retval, IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper_stret")]
        public static extern void CGVector_objc_msgSendSuper_stret(out CGVector retval, IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_CGVector(IntPtr receiver, IntPtr selector, CGVector arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_CGVector(IntPtr receiver, IntPtr selector, CGVector arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern uint UInt32_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern uint UInt32_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern ulong UInt64_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern ulong UInt64_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_bool_bool(IntPtr receiver, IntPtr selector, bool arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_bool_bool(IntPtr receiver, IntPtr selector, bool arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_UInt32_bool(IntPtr receiver, IntPtr selector, uint arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_UInt32_bool(IntPtr receiver, IntPtr selector, uint arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_UInt64_bool(IntPtr receiver, IntPtr selector, ulong arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_UInt64_bool(IntPtr receiver, IntPtr selector, ulong arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_CGRect_IntPtr_IntPtr_bool(IntPtr receiver, IntPtr selector, CGRect arg1, IntPtr arg2, IntPtr arg3, bool arg4);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_CGRect_IntPtr_IntPtr_bool(IntPtr receiver, IntPtr selector, CGRect arg1, IntPtr arg2, IntPtr arg3, bool arg4);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern bool bool_objc_msgSend_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern bool bool_objc_msgSendSuper_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern int int_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern int int_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern long Int64_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern long Int64_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_int(IntPtr receiver, IntPtr selector, int arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_int(IntPtr receiver, IntPtr selector, int arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_Int64(IntPtr receiver, IntPtr selector, long arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_Int64(IntPtr receiver, IntPtr selector, long arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_Double(IntPtr receiver, IntPtr selector, double arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_Double(IntPtr receiver, IntPtr selector, double arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern bool bool_objc_msgSend_ref_IntPtr_IntPtr_ref_IntPtr(IntPtr receiver, IntPtr selector, ref IntPtr arg1, IntPtr arg2, ref IntPtr arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern bool bool_objc_msgSendSuper_ref_IntPtr_IntPtr_ref_IntPtr(IntPtr receiver, IntPtr selector, ref IntPtr arg1, IntPtr arg2, ref IntPtr arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_CLLocationCoordinate2D(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_CLLocationCoordinate2D(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern double Double_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern double Double_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_Double(IntPtr receiver, IntPtr selector, double arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_Double(IntPtr receiver, IntPtr selector, double arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern nfloat nfloat_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern nfloat nfloat_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_nfloat(IntPtr receiver, IntPtr selector, nfloat arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_nfloat(IntPtr receiver, IntPtr selector, nfloat arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_CLLocationCoordinate2D_CLLocationCoordinate2D_Double(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, CLLocationCoordinate2D arg2, double arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_CLLocationCoordinate2D_CLLocationCoordinate2D_Double(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, CLLocationCoordinate2D arg2, double arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_CLLocationCoordinate2D_Double_nfloat_Double(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, double arg2, nfloat arg3, double arg4);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_CLLocationCoordinate2D_Double_nfloat_Double(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, double arg2, nfloat arg3, double arg4);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_UInt32(IntPtr receiver, IntPtr selector, uint arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_UInt32(IntPtr receiver, IntPtr selector, uint arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_UInt64(IntPtr receiver, IntPtr selector, ulong arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_UInt64(IntPtr receiver, IntPtr selector, ulong arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_CoordinateBounds(IntPtr receiver, IntPtr selector, CoordinateBounds arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_CoordinateBounds(IntPtr receiver, IntPtr selector, CoordinateBounds arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern UIEdgeInsets UIEdgeInsets_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern UIEdgeInsets UIEdgeInsets_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern void UIEdgeInsets_objc_msgSend_stret(out UIEdgeInsets retval, IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper_stret")]
        public static extern void UIEdgeInsets_objc_msgSendSuper_stret(out UIEdgeInsets retval, IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_UIEdgeInsets(IntPtr receiver, IntPtr selector, UIEdgeInsets arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_UIEdgeInsets(IntPtr receiver, IntPtr selector, UIEdgeInsets arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_CGRect(IntPtr receiver, IntPtr selector, CGRect arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_CGRect(IntPtr receiver, IntPtr selector, CGRect arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_CGRect_IntPtr(IntPtr receiver, IntPtr selector, CGRect arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_CGRect_IntPtr(IntPtr receiver, IntPtr selector, CGRect arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_CLLocationCoordinate2D_bool(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_CLLocationCoordinate2D_bool(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_CLLocationCoordinate2D_Double_bool(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, double arg2, bool arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_CLLocationCoordinate2D_Double_bool(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, double arg2, bool arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_CLLocationCoordinate2D_Double_Double_bool(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, double arg2, double arg3, bool arg4);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_CLLocationCoordinate2D_Double_Double_bool(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, double arg2, double arg3, bool arg4);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_CLLocationCoordinate2D_Double_Double_bool_IntPtr(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, double arg2, double arg3, bool arg4, IntPtr arg5);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_CLLocationCoordinate2D_Double_Double_bool_IntPtr(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, double arg2, double arg3, bool arg4, IntPtr arg5);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_Double_bool(IntPtr receiver, IntPtr selector, double arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_Double_bool(IntPtr receiver, IntPtr selector, double arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_CoordinateBounds_bool(IntPtr receiver, IntPtr selector, CoordinateBounds arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_CoordinateBounds_bool(IntPtr receiver, IntPtr selector, CoordinateBounds arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_CoordinateBounds_UIEdgeInsets_bool(IntPtr receiver, IntPtr selector, CoordinateBounds arg1, UIEdgeInsets arg2, bool arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_CoordinateBounds_UIEdgeInsets_bool(IntPtr receiver, IntPtr selector, CoordinateBounds arg1, UIEdgeInsets arg2, bool arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr_nuint_UIEdgeInsets_bool(IntPtr receiver, IntPtr selector, IntPtr arg1, nuint arg2, UIEdgeInsets arg3, bool arg4);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr_nuint_UIEdgeInsets_bool(IntPtr receiver, IntPtr selector, IntPtr arg1, nuint arg2, UIEdgeInsets arg3, bool arg4);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr_nuint_UIEdgeInsets_Double_Double_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, nuint arg2, UIEdgeInsets arg3, double arg4, double arg5, IntPtr arg6, IntPtr arg7);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr_nuint_UIEdgeInsets_Double_Double_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, nuint arg2, UIEdgeInsets arg3, double arg4, double arg5, IntPtr arg6, IntPtr arg7);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr_bool(IntPtr receiver, IntPtr selector, IntPtr arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr_bool(IntPtr receiver, IntPtr selector, IntPtr arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr_UIEdgeInsets_bool(IntPtr receiver, IntPtr selector, IntPtr arg1, UIEdgeInsets arg2, bool arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr_UIEdgeInsets_bool(IntPtr receiver, IntPtr selector, IntPtr arg1, UIEdgeInsets arg2, bool arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr_Double_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, double arg2, IntPtr arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr_Double_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, double arg2, IntPtr arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr_Double_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, double arg2, IntPtr arg3, IntPtr arg4);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr_Double_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, double arg2, IntPtr arg3, IntPtr arg4);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr_Double_Double_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, double arg2, double arg3, IntPtr arg4);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr_Double_Double_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, double arg2, double arg3, IntPtr arg4);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_CoordinateBounds_UIEdgeInsets(IntPtr receiver, IntPtr selector, CoordinateBounds arg1, UIEdgeInsets arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_CoordinateBounds_UIEdgeInsets(IntPtr receiver, IntPtr selector, CoordinateBounds arg1, UIEdgeInsets arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern CGPoint CGPoint_objc_msgSend_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern CGPoint CGPoint_objc_msgSendSuper_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern void CGPoint_objc_msgSend_stret_IntPtr(out CGPoint retval, IntPtr receiver, IntPtr selector, IntPtr arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper_stret")]
        public static extern void CGPoint_objc_msgSendSuper_stret_IntPtr(out CGPoint retval, IntPtr receiver, IntPtr selector, IntPtr arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_UIEdgeInsets_bool(IntPtr receiver, IntPtr selector, UIEdgeInsets arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_UIEdgeInsets_bool(IntPtr receiver, IntPtr selector, UIEdgeInsets arg1, bool arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern CLLocationCoordinate2D CLLocationCoordinate2D_objc_msgSend_CGPoint_IntPtr(IntPtr receiver, IntPtr selector, CGPoint arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern CLLocationCoordinate2D CLLocationCoordinate2D_objc_msgSendSuper_CGPoint_IntPtr(IntPtr receiver, IntPtr selector, CGPoint arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern void CLLocationCoordinate2D_objc_msgSend_stret_CGPoint_IntPtr(out CLLocationCoordinate2D retval, IntPtr receiver, IntPtr selector, CGPoint arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper_stret")]
        public static extern void CLLocationCoordinate2D_objc_msgSendSuper_stret_CGPoint_IntPtr(out CLLocationCoordinate2D retval, IntPtr receiver, IntPtr selector, CGPoint arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern CGPoint CGPoint_objc_msgSend_CLLocationCoordinate2D_IntPtr(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern CGPoint CGPoint_objc_msgSendSuper_CLLocationCoordinate2D_IntPtr(IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern void CGPoint_objc_msgSend_stret_CLLocationCoordinate2D_IntPtr(out CGPoint retval, IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper_stret")]
        public static extern void CGPoint_objc_msgSendSuper_stret_CLLocationCoordinate2D_IntPtr(out CGPoint retval, IntPtr receiver, IntPtr selector, CLLocationCoordinate2D arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern CoordinateBounds CoordinateBounds_objc_msgSend_CGRect_IntPtr(IntPtr receiver, IntPtr selector, CGRect arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern CoordinateBounds CoordinateBounds_objc_msgSendSuper_CGRect_IntPtr(IntPtr receiver, IntPtr selector, CGRect arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern void CoordinateBounds_objc_msgSend_stret_CGRect_IntPtr(out CoordinateBounds retval, IntPtr receiver, IntPtr selector, CGRect arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper_stret")]
        public static extern void CoordinateBounds_objc_msgSendSuper_stret_CGRect_IntPtr(out CoordinateBounds retval, IntPtr receiver, IntPtr selector, CGRect arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern CGRect CGRect_objc_msgSend_CoordinateBounds_IntPtr(IntPtr receiver, IntPtr selector, CoordinateBounds arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern CGRect CGRect_objc_msgSendSuper_CoordinateBounds_IntPtr(IntPtr receiver, IntPtr selector, CoordinateBounds arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend_stret")]
        public static extern void CGRect_objc_msgSend_stret_CoordinateBounds_IntPtr(out CGRect retval, IntPtr receiver, IntPtr selector, CoordinateBounds arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper_stret")]
        public static extern void CGRect_objc_msgSendSuper_stret_CoordinateBounds_IntPtr(out CGRect retval, IntPtr receiver, IntPtr selector, CoordinateBounds arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern double Double_objc_msgSend_Double(IntPtr receiver, IntPtr selector, double arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern double Double_objc_msgSendSuper_Double(IntPtr receiver, IntPtr selector, double arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_CGPoint(IntPtr receiver, IntPtr selector, CGPoint arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_CGPoint(IntPtr receiver, IntPtr selector, CGPoint arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_CGPoint_IntPtr(IntPtr receiver, IntPtr selector, CGPoint arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_CGPoint_IntPtr(IntPtr receiver, IntPtr selector, CGPoint arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr_UInt32_bool(IntPtr receiver, IntPtr selector, IntPtr arg1, uint arg2, bool arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr_UInt32_bool(IntPtr receiver, IntPtr selector, IntPtr arg1, uint arg2, bool arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr_UInt64_bool(IntPtr receiver, IntPtr selector, IntPtr arg1, ulong arg2, bool arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr_UInt64_bool(IntPtr receiver, IntPtr selector, IntPtr arg1, ulong arg2, bool arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern nfloat nfloat_objc_msgSend_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern nfloat nfloat_objc_msgSendSuper_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern bool bool_objc_msgSend_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern bool bool_objc_msgSendSuper_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2, IntPtr arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern nuint nuint_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern nuint nuint_objc_msgSendSuper(IntPtr receiver, IntPtr selector);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern void void_objc_msgSend_IntPtr_NSRange(IntPtr receiver, IntPtr selector, IntPtr arg1, NSRange arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern void void_objc_msgSendSuper_IntPtr_NSRange(IntPtr receiver, IntPtr selector, IntPtr arg1, NSRange arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern bool bool_objc_msgSend_CoordinateBounds(IntPtr receiver, IntPtr selector, CoordinateBounds arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern bool bool_objc_msgSendSuper_CoordinateBounds(IntPtr receiver, IntPtr selector, CoordinateBounds arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_IntPtr_nuint(IntPtr receiver, IntPtr selector, IntPtr arg1, nuint arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_IntPtr_nuint(IntPtr receiver, IntPtr selector, IntPtr arg1, nuint arg2);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_IntPtr_nuint_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, nuint arg2, IntPtr arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_IntPtr_nuint_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, nuint arg2, IntPtr arg3);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_nint(IntPtr receiver, IntPtr selector, nint arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_nint(IntPtr receiver, IntPtr selector, nint arg1);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
        public static extern IntPtr IntPtr_objc_msgSend_IntPtr_CoordinateBounds_Double_Double(IntPtr receiver, IntPtr selector, IntPtr arg1, CoordinateBounds arg2, double arg3, double arg4);

        [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSendSuper")]
        public static extern IntPtr IntPtr_objc_msgSendSuper_IntPtr_CoordinateBounds_Double_Double(IntPtr receiver, IntPtr selector, IntPtr arg1, CoordinateBounds arg2, double arg3, double arg4);
    }
}
