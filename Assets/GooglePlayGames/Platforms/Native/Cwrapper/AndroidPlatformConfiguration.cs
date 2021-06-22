/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

#if UNITY_ANDROID
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace GooglePlayGames.Native.Cwrapper {
internal static class AndroidPlatformConfiguration {
    internal delegate void IntentHandler(
         /* from(jobject) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void OnLaunchedWithSnapshotCallback(
         /* from(SnapshotMetadata_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void OnLaunchedWithQuestCallback(
         /* from(Quest_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AndroidPlatformConfiguration_SetOnLaunchedWithSnapshot(
        HandleRef self,
         /* from(AndroidPlatformConfiguration_OnLaunchedWithSnapshotCallback_t) */ OnLaunchedWithSnapshotCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(AndroidPlatformConfiguration_t) */ IntPtr AndroidPlatformConfiguration_Construct();

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AndroidPlatformConfiguration_SetOptionalIntentHandlerForUI(
        HandleRef self,
         /* from(AndroidPlatformConfiguration_IntentHandler_t) */ IntentHandler intent_handler,
         /* from(void *) */ IntPtr intent_handler_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AndroidPlatformConfiguration_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern /* from(bool) */ bool AndroidPlatformConfiguration_Valid(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AndroidPlatformConfiguration_SetActivity(
        HandleRef self,
         /* from(jobject) */ IntPtr android_app_activity);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AndroidPlatformConfiguration_SetOnLaunchedWithQuest(
        HandleRef self,
         /* from(AndroidPlatformConfiguration_OnLaunchedWithQuestCallback_t) */ OnLaunchedWithQuestCallback callback,
         /* from(void *) */ IntPtr callback_arg);
}
}
#endif // UNITY_ANDROID
