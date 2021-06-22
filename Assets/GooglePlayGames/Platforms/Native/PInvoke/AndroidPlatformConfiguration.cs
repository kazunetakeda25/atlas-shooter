/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

#if (UNITY_ANDROID || UNITY_IPHONE)
using System;
using System.Runtime.InteropServices;
using GooglePlayGames.OurUtils;
using GooglePlayGames.Native.Cwrapper;

#if UNITY_ANDROID
using C = GooglePlayGames.Native.Cwrapper.AndroidPlatformConfiguration;

namespace GooglePlayGames.Native.PInvoke {

sealed class AndroidPlatformConfiguration : PlatformConfiguration {

    private delegate void IntentHandlerInternal(IntPtr intent, IntPtr userData);

    private AndroidPlatformConfiguration (IntPtr selfPointer) : base(selfPointer) {
    }

    internal void SetActivity(System.IntPtr activity) {
        C.AndroidPlatformConfiguration_SetActivity(SelfPtr(), activity);
    }

    internal void SetOptionalIntentHandlerForUI(Action<IntPtr> intentHandler) {
        Misc.CheckNotNull(intentHandler);
        C.AndroidPlatformConfiguration_SetOptionalIntentHandlerForUI(SelfPtr(),
            InternalIntentHandler, Callbacks.ToIntPtr(intentHandler));
    }

    internal void EnableAppState() {
        InternalHooks.InternalHooks_EnableAppState(SelfPtr());
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.AndroidPlatformConfiguration_Dispose(selfPointer);
    }

    [AOT.MonoPInvokeCallback(typeof(IntentHandlerInternal))]
    private static void InternalIntentHandler(IntPtr intent, IntPtr userData) {
        Callbacks.PerformInternalCallback("AndroidPlatformConfiguration#InternalIntentHandler",
            Callbacks.Type.Permanent, intent, userData);
    }

    internal static AndroidPlatformConfiguration Create() {
        return new AndroidPlatformConfiguration(C.AndroidPlatformConfiguration_Construct());
    }
}
}
#endif

#endif
