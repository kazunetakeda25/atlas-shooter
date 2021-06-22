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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace GooglePlayGames.Native.Cwrapper {
internal static class Builder {
    internal delegate void OnLogCallback(
         /* from(LogLevel_t) */ Types.LogLevel arg0,
         /* from(char const *) */ string arg1,
         /* from(void *) */ IntPtr arg2);

    internal delegate void OnAuthActionStartedCallback(
         /* from(AuthOperation_t) */ Types.AuthOperation arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void OnAuthActionFinishedCallback(
         /* from(AuthOperation_t) */ Types.AuthOperation arg0,
         /* from(AuthStatus_t) */ CommonErrorStatus.AuthStatus arg1,
         /* from(void *) */ IntPtr arg2);

    internal delegate void OnMultiplayerInvitationEventCallback(
         /* from(MultiplayerEvent_t) */ Types.MultiplayerEvent arg0,
         /* from(char const *) */ string arg1,
         /* from(MultiplayerInvitation_t) */ IntPtr arg2,
         /* from(void *) */ IntPtr arg3);

    internal delegate void OnTurnBasedMatchEventCallback(
         /* from(MultiplayerEvent_t) */ Types.MultiplayerEvent arg0,
         /* from(char const *) */ string arg1,
         /* from(TurnBasedMatch_t) */ IntPtr arg2,
         /* from(void *) */ IntPtr arg3);

    internal delegate void OnQuestCompletedCallback(
         /* from(Quest_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void GameServices_Builder_SetOnAuthActionStarted(
        HandleRef self,
         /* from(GameServices_Builder_OnAuthActionStartedCallback_t) */ OnAuthActionStartedCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void GameServices_Builder_AddOauthScope(
        HandleRef self,
         /* from(char const *) */ string scope);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void GameServices_Builder_SetLogging(
        HandleRef self,
         /* from(GameServices_Builder_OnLogCallback_t) */ OnLogCallback callback,
         /* from(void *) */ IntPtr callback_arg,
         /* from(LogLevel_t) */ Types.LogLevel min_level);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(GameServices_Builder_t) */ IntPtr GameServices_Builder_Construct();

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void GameServices_Builder_EnableSnapshots(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void GameServices_Builder_SetOnLog(
        HandleRef self,
         /* from(GameServices_Builder_OnLogCallback_t) */ OnLogCallback callback,
         /* from(void *) */ IntPtr callback_arg,
         /* from(LogLevel_t) */ Types.LogLevel min_level);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void GameServices_Builder_SetDefaultOnLog(
        HandleRef self,
         /* from(LogLevel_t) */ Types.LogLevel min_level);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void GameServices_Builder_SetOnAuthActionFinished(
        HandleRef self,
         /* from(GameServices_Builder_OnAuthActionFinishedCallback_t) */ OnAuthActionFinishedCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void GameServices_Builder_SetOnTurnBasedMatchEvent(
        HandleRef self,
         /* from(GameServices_Builder_OnTurnBasedMatchEventCallback_t) */ OnTurnBasedMatchEventCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void GameServices_Builder_SetOnQuestCompleted(
        HandleRef self,
         /* from(GameServices_Builder_OnQuestCompletedCallback_t) */ OnQuestCompletedCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void GameServices_Builder_SetOnMultiplayerInvitationEvent(
        HandleRef self,
         /* from(GameServices_Builder_OnMultiplayerInvitationEventCallback_t) */ OnMultiplayerInvitationEventCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(GameServices_t) */ IntPtr GameServices_Builder_Create(
        HandleRef self,
         /* from(PlatformConfiguration_t) */ IntPtr platform);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void GameServices_Builder_Dispose(
        HandleRef self);
}
}
#endif // (UNITY_ANDROID || UNITY_IPHONE)
