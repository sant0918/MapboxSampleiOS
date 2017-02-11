using CoreGraphics;
using CoreLocation;
using Foundation;
using Maps;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ObjCRuntime
{
    
    internal static class Trampolines
    {
        [UserDelegateType(typeof(CustomStyleLayerCompletionHandler)), UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DCustomStyleLayerCompletionHandler(IntPtr block);

        internal static class SDCustomStyleLayerCompletionHandler
        {
            internal static readonly Trampolines.DCustomStyleLayerCompletionHandler Handler;

            
            private static Trampolines.DCustomStyleLayerCompletionHandler cache;

			[MonoPInvokeCallback(typeof(Trampolines.DCustomStyleLayerCompletionHandler))]
            private unsafe static void Invoke(IntPtr block)
            {
                BlockLiteral* ptr = (BlockLiteral*)((void*)block);
                CustomStyleLayerCompletionHandler customStyleLayerCompletionHandler = (CustomStyleLayerCompletionHandler)ptr->Target;
                if (customStyleLayerCompletionHandler != null)
                {
                    customStyleLayerCompletionHandler();
                }
            }

            static SDCustomStyleLayerCompletionHandler()
            {
                // Note: this type is marked as 'beforefieldinit'.
                if (Trampolines.SDCustomStyleLayerCompletionHandler.cache == null)
				{
                    Trampolines.SDCustomStyleLayerCompletionHandler.cache = new Trampolines.DCustomStyleLayerCompletionHandler(Trampolines.SDCustomStyleLayerCompletionHandler.Invoke);
                }
                Trampolines.SDCustomStyleLayerCompletionHandler.Handler = Trampolines.SDCustomStyleLayerCompletionHandler.cache;
            }
        }

        internal class NIDCustomStyleLayerCompletionHandler
        {
            private IntPtr blockPtr;

            private Trampolines.DCustomStyleLayerCompletionHandler invoker;

            [Preserve(Conditional = true)]
            public unsafe NIDCustomStyleLayerCompletionHandler(BlockLiteral* block)
            {
                this.blockPtr = Trampolines._Block_copy((IntPtr)((void*)block));
                this.invoker = block->GetDelegateForBlock<Trampolines.DCustomStyleLayerCompletionHandler>();
            }

            [Preserve(Conditional = true)]
            ~NIDCustomStyleLayerCompletionHandler()
            {
                Trampolines._Block_release(this.blockPtr);
            }

            [Preserve(Conditional = true)]
            public unsafe static CustomStyleLayerCompletionHandler Create(IntPtr block)
            {
                if (block == IntPtr.Zero)
                {
                    return null;
                }
                if (BlockLiteral.IsManagedBlock(block))
                {
                    CustomStyleLayerCompletionHandler customStyleLayerCompletionHandler = ((BlockLiteral*)((void*)block))->Target as CustomStyleLayerCompletionHandler;
                    if (customStyleLayerCompletionHandler != null)
                    {
                        return customStyleLayerCompletionHandler;
                    }
                }
                return new CustomStyleLayerCompletionHandler(new Trampolines.NIDCustomStyleLayerCompletionHandler((BlockLiteral*)((void*)block)).Invoke);
            }

            [Preserve(Conditional = true)]
            private void Invoke()
            {
                this.invoker(this.blockPtr);
            }
        }

        [UserDelegateType(typeof(CustomStyleLayerDrawingHandler)), UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DCustomStyleLayerDrawingHandler(IntPtr block, CGSize arg0, CLLocationCoordinate2D arg1, double arg2, double arg3, nfloat arg4, nfloat arg5);

        internal static class SDCustomStyleLayerDrawingHandler
        {
            internal static readonly Trampolines.DCustomStyleLayerDrawingHandler Handler;

            
            private static Trampolines.DCustomStyleLayerDrawingHandler cache;

			[MonoPInvokeCallback(typeof(Trampolines.DCustomStyleLayerDrawingHandler))]
            private unsafe static void Invoke(IntPtr block, CGSize arg0, CLLocationCoordinate2D arg1, double arg2, double arg3, nfloat arg4, nfloat arg5)
            {
                BlockLiteral* ptr = (BlockLiteral*)((void*)block);
                CustomStyleLayerDrawingHandler customStyleLayerDrawingHandler = (CustomStyleLayerDrawingHandler)ptr->Target;
                if (customStyleLayerDrawingHandler != null)
                {
                    customStyleLayerDrawingHandler(arg0, arg1, arg2, arg3, arg4, arg5);
                }
            }

            static SDCustomStyleLayerDrawingHandler()
            {
                // Note: this type is marked as 'beforefieldinit'.
                if (Trampolines.SDCustomStyleLayerDrawingHandler.cache == null)
				{
                    Trampolines.SDCustomStyleLayerDrawingHandler.cache = new Trampolines.DCustomStyleLayerDrawingHandler(Trampolines.SDCustomStyleLayerDrawingHandler.Invoke);
                }
                Trampolines.SDCustomStyleLayerDrawingHandler.Handler = Trampolines.SDCustomStyleLayerDrawingHandler.cache;
            }
        }

        internal class NIDCustomStyleLayerDrawingHandler
        {
            private IntPtr blockPtr;

            private Trampolines.DCustomStyleLayerDrawingHandler invoker;

            [Preserve(Conditional = true)]
            public unsafe NIDCustomStyleLayerDrawingHandler(BlockLiteral* block)
            {
                this.blockPtr = Trampolines._Block_copy((IntPtr)((void*)block));
                this.invoker = block->GetDelegateForBlock<Trampolines.DCustomStyleLayerDrawingHandler>();
            }

            [Preserve(Conditional = true)]
            ~NIDCustomStyleLayerDrawingHandler()
            {
                Trampolines._Block_release(this.blockPtr);
            }

            [Preserve(Conditional = true)]
            public unsafe static CustomStyleLayerDrawingHandler Create(IntPtr block)
            {
                if (block == IntPtr.Zero)
                {
                    return null;
                }
                if (BlockLiteral.IsManagedBlock(block))
                {
                    CustomStyleLayerDrawingHandler customStyleLayerDrawingHandler = ((BlockLiteral*)((void*)block))->Target as CustomStyleLayerDrawingHandler;
                    if (customStyleLayerDrawingHandler != null)
                    {
                        return customStyleLayerDrawingHandler;
                    }
                }
                return new CustomStyleLayerDrawingHandler(new Trampolines.NIDCustomStyleLayerDrawingHandler((BlockLiteral*)((void*)block)).Invoke);
            }

            [Preserve(Conditional = true)]
            private void Invoke(CGSize arg0, CLLocationCoordinate2D arg1, double arg2, double arg3, nfloat arg4, nfloat arg5)
            {
                this.invoker(this.blockPtr, arg0, arg1, arg2, arg3, arg4, arg5);
            }
        }

        [UserDelegateType(typeof(CustomStyleLayerPreparationHandler)), UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DCustomStyleLayerPreparationHandler(IntPtr block);

        internal static class SDCustomStyleLayerPreparationHandler
        {
            internal static readonly Trampolines.DCustomStyleLayerPreparationHandler Handler;

            
            private static Trampolines.DCustomStyleLayerPreparationHandler cache;

			[MonoPInvokeCallback(typeof(Trampolines.DCustomStyleLayerPreparationHandler))]
            private unsafe static void Invoke(IntPtr block)
            {
                BlockLiteral* ptr = (BlockLiteral*)((void*)block);
                CustomStyleLayerPreparationHandler customStyleLayerPreparationHandler = (CustomStyleLayerPreparationHandler)ptr->Target;
                if (customStyleLayerPreparationHandler != null)
                {
                    customStyleLayerPreparationHandler();
                }
            }

            static SDCustomStyleLayerPreparationHandler()
            {
                // Note: this type is marked as 'beforefieldinit'.
                if (Trampolines.SDCustomStyleLayerPreparationHandler.cache == null)
				{
                    Trampolines.SDCustomStyleLayerPreparationHandler.cache = new Trampolines.DCustomStyleLayerPreparationHandler(Trampolines.SDCustomStyleLayerPreparationHandler.Invoke);
                }
                Trampolines.SDCustomStyleLayerPreparationHandler.Handler = Trampolines.SDCustomStyleLayerPreparationHandler.cache;
            }
        }

        internal class NIDCustomStyleLayerPreparationHandler
        {
            private IntPtr blockPtr;

            private Trampolines.DCustomStyleLayerPreparationHandler invoker;

            [Preserve(Conditional = true)]
            public unsafe NIDCustomStyleLayerPreparationHandler(BlockLiteral* block)
            {
                this.blockPtr = Trampolines._Block_copy((IntPtr)((void*)block));
                this.invoker = block->GetDelegateForBlock<Trampolines.DCustomStyleLayerPreparationHandler>();
            }

            [Preserve(Conditional = true)]
            ~NIDCustomStyleLayerPreparationHandler()
            {
                Trampolines._Block_release(this.blockPtr);
            }

            [Preserve(Conditional = true)]
            public unsafe static CustomStyleLayerPreparationHandler Create(IntPtr block)
            {
                if (block == IntPtr.Zero)
                {
                    return null;
                }
                if (BlockLiteral.IsManagedBlock(block))
                {
                    CustomStyleLayerPreparationHandler customStyleLayerPreparationHandler = ((BlockLiteral*)((void*)block))->Target as CustomStyleLayerPreparationHandler;
                    if (customStyleLayerPreparationHandler != null)
                    {
                        return customStyleLayerPreparationHandler;
                    }
                }
                return new CustomStyleLayerPreparationHandler(new Trampolines.NIDCustomStyleLayerPreparationHandler((BlockLiteral*)((void*)block)).Invoke);
            }

            [Preserve(Conditional = true)]
            private void Invoke()
            {
                this.invoker(this.blockPtr);
            }
        }

        [UserDelegateType(typeof(OfflinePackAdditionCompletion)), UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DOfflinePackAdditionCompletion(IntPtr block, IntPtr pack, IntPtr error);

        internal static class SDOfflinePackAdditionCompletion
        {
            internal static readonly Trampolines.DOfflinePackAdditionCompletion Handler;

            
            private static Trampolines.DOfflinePackAdditionCompletion cache;

			[MonoPInvokeCallback(typeof(Trampolines.DOfflinePackAdditionCompletion))]
            private unsafe static void Invoke(IntPtr block, IntPtr pack, IntPtr error)
            {
                BlockLiteral* ptr = (BlockLiteral*)((void*)block);
                OfflinePackAdditionCompletion offlinePackAdditionCompletion = (OfflinePackAdditionCompletion)ptr->Target;
                if (offlinePackAdditionCompletion != null)
                {
                    offlinePackAdditionCompletion(Runtime.GetNSObject<OfflinePack>(pack), Runtime.GetNSObject<NSError>(error));
                }
            }

            static SDOfflinePackAdditionCompletion()
            {
                // Note: this type is marked as 'beforefieldinit'.
                if (Trampolines.SDOfflinePackAdditionCompletion.cache == null)
				{
                    Trampolines.SDOfflinePackAdditionCompletion.cache = new Trampolines.DOfflinePackAdditionCompletion(Trampolines.SDOfflinePackAdditionCompletion.Invoke);
                }
                Trampolines.SDOfflinePackAdditionCompletion.Handler = Trampolines.SDOfflinePackAdditionCompletion.cache;
            }
        }

        internal class NIDOfflinePackAdditionCompletion
        {
            private IntPtr blockPtr;

            private Trampolines.DOfflinePackAdditionCompletion invoker;

            [Preserve(Conditional = true)]
            public unsafe NIDOfflinePackAdditionCompletion(BlockLiteral* block)
            {
                this.blockPtr = Trampolines._Block_copy((IntPtr)((void*)block));
                this.invoker = block->GetDelegateForBlock<Trampolines.DOfflinePackAdditionCompletion>();
            }

            [Preserve(Conditional = true)]
            ~NIDOfflinePackAdditionCompletion()
            {
                Trampolines._Block_release(this.blockPtr);
            }

            [Preserve(Conditional = true)]
            public unsafe static OfflinePackAdditionCompletion Create(IntPtr block)
            {
                if (block == IntPtr.Zero)
                {
                    return null;
                }
                if (BlockLiteral.IsManagedBlock(block))
                {
                    OfflinePackAdditionCompletion offlinePackAdditionCompletion = ((BlockLiteral*)((void*)block))->Target as OfflinePackAdditionCompletion;
                    if (offlinePackAdditionCompletion != null)
                    {
                        return offlinePackAdditionCompletion;
                    }
                }
                return new OfflinePackAdditionCompletion(new Trampolines.NIDOfflinePackAdditionCompletion((BlockLiteral*)((void*)block)).Invoke);
            }

            [Preserve(Conditional = true)]
            private void Invoke(OfflinePack pack, NSError error)
            {
                this.invoker(this.blockPtr, (pack != null) ? pack.Handle : IntPtr.Zero, (error != null) ? error.Handle : IntPtr.Zero);
            }
        }

        [UserDelegateType(typeof(OfflinePackRemovalCompletion)), UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DOfflinePackRemovalCompletion(IntPtr block, IntPtr error);

        internal static class SDOfflinePackRemovalCompletion
        {
            internal static readonly Trampolines.DOfflinePackRemovalCompletion Handler;

            
            private static Trampolines.DOfflinePackRemovalCompletion cache;

			[MonoPInvokeCallback(typeof(Trampolines.DOfflinePackRemovalCompletion))]
            private unsafe static void Invoke(IntPtr block, IntPtr error)
            {
                BlockLiteral* ptr = (BlockLiteral*)((void*)block);
                OfflinePackRemovalCompletion offlinePackRemovalCompletion = (OfflinePackRemovalCompletion)ptr->Target;
                if (offlinePackRemovalCompletion != null)
                {
                    offlinePackRemovalCompletion(Runtime.GetNSObject<NSError>(error));
                }
            }

            static SDOfflinePackRemovalCompletion()
            {
                // Note: this type is marked as 'beforefieldinit'.
                if (Trampolines.SDOfflinePackRemovalCompletion.cache == null)
				{
                    Trampolines.SDOfflinePackRemovalCompletion.cache = new Trampolines.DOfflinePackRemovalCompletion(Trampolines.SDOfflinePackRemovalCompletion.Invoke);
                }
                Trampolines.SDOfflinePackRemovalCompletion.Handler = Trampolines.SDOfflinePackRemovalCompletion.cache;
            }
        }

        internal class NIDOfflinePackRemovalCompletion
        {
            private IntPtr blockPtr;

            private Trampolines.DOfflinePackRemovalCompletion invoker;

            [Preserve(Conditional = true)]
            public unsafe NIDOfflinePackRemovalCompletion(BlockLiteral* block)
            {
                this.blockPtr = Trampolines._Block_copy((IntPtr)((void*)block));
                this.invoker = block->GetDelegateForBlock<Trampolines.DOfflinePackRemovalCompletion>();
            }

            [Preserve(Conditional = true)]
            ~NIDOfflinePackRemovalCompletion()
            {
                Trampolines._Block_release(this.blockPtr);
            }

            [Preserve(Conditional = true)]
            public unsafe static OfflinePackRemovalCompletion Create(IntPtr block)
            {
                if (block == IntPtr.Zero)
                {
                    return null;
                }
                if (BlockLiteral.IsManagedBlock(block))
                {
                    OfflinePackRemovalCompletion offlinePackRemovalCompletion = ((BlockLiteral*)((void*)block))->Target as OfflinePackRemovalCompletion;
                    if (offlinePackRemovalCompletion != null)
                    {
                        return offlinePackRemovalCompletion;
                    }
                }
                return new OfflinePackRemovalCompletion(new Trampolines.NIDOfflinePackRemovalCompletion((BlockLiteral*)((void*)block)).Invoke);
            }

            [Preserve(Conditional = true)]
            private void Invoke(NSError error)
            {
                this.invoker(this.blockPtr, (error != null) ? error.Handle : IntPtr.Zero);
            }
        }

        [UserDelegateType(typeof(Action)), UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DAction(IntPtr block);

        internal static class SDAction
        {
            internal static readonly Trampolines.DAction Handler;

            
            private static Trampolines.DAction cache;

			[MonoPInvokeCallback(typeof(Trampolines.DAction))]
            private unsafe static void Invoke(IntPtr block)
            {
                BlockLiteral* ptr = (BlockLiteral*)((void*)block);
                Action action = (Action)ptr->Target;
                if (action != null)
                {
                    action();
                }
            }

            static SDAction()
            {
                // Note: this type is marked as 'beforefieldinit'.
                if (Trampolines.SDAction.cache == null)
				{
                    Trampolines.SDAction.cache = new Trampolines.DAction(Trampolines.SDAction.Invoke);
                }
                Trampolines.SDAction.Handler = Trampolines.SDAction.cache;
            }
        }

        internal class NIDAction
        {
            private IntPtr blockPtr;

            private Trampolines.DAction invoker;

            [Preserve(Conditional = true)]
            public unsafe NIDAction(BlockLiteral* block)
            {
                this.blockPtr = Trampolines._Block_copy((IntPtr)((void*)block));
                this.invoker = block->GetDelegateForBlock<Trampolines.DAction>();
            }

            [Preserve(Conditional = true)]
            ~NIDAction()
            {
                Trampolines._Block_release(this.blockPtr);
            }

            [Preserve(Conditional = true)]
            public unsafe static Action Create(IntPtr block)
            {
                if (block == IntPtr.Zero)
                {
                    return null;
                }
                if (BlockLiteral.IsManagedBlock(block))
                {
                    Action action = ((BlockLiteral*)((void*)block))->Target as Action;
                    if (action != null)
                    {
                        return action;
                    }
                }
                return new Action(new Trampolines.NIDAction((BlockLiteral*)((void*)block)).Invoke);
            }

            [Preserve(Conditional = true)]
            private void Invoke()
            {
                this.invoker(this.blockPtr);
            }
        }

        [DllImport("/usr/lib/libobjc.dylib")]
        private static extern IntPtr _Block_copy(IntPtr ptr);

        [DllImport("/usr/lib/libobjc.dylib")]
        private static extern void _Block_release(IntPtr ptr);
    }
}
