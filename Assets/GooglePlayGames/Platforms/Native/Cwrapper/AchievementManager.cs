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
internal static class AchievementManager {
    internal delegate void FetchAllCallback(
         /* from(AchievementManager_FetchAllResponse_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void FetchCallback(
         /* from(AchievementManager_FetchResponse_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void ShowAllUICallback(
         /* from(UIStatus_t) */ CommonErrorStatus.UIStatus arg0,
         /* from(void *) */ IntPtr arg1);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AchievementManager_FetchAll(
        HandleRef self,
         /* from(DataSource_t) */ Types.DataSource data_source,
         /* from(AchievementManager_FetchAllCallback_t) */ FetchAllCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AchievementManager_Reveal(
        HandleRef self,
         /* from(char const *) */ string achievement_id);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AchievementManager_Unlock(
        HandleRef self,
         /* from(char const *) */ string achievement_id);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AchievementManager_ShowAllUI(
        HandleRef self,
         /* from(AchievementManager_ShowAllUICallback_t) */ ShowAllUICallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AchievementManager_SetStepsAtLeast(
        HandleRef self,
         /* from(char const *) */ string achievement_id,
         /* from(uint32_t) */ uint steps);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AchievementManager_Increment(
        HandleRef self,
         /* from(char const *) */ string achievement_id,
         /* from(uint32_t) */ uint steps);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AchievementManager_Fetch(
        HandleRef self,
         /* from(DataSource_t) */ Types.DataSource data_source,
         /* from(char const *) */ string achievement_id,
         /* from(AchievementManager_FetchCallback_t) */ FetchCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AchievementManager_FetchAllResponse_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ResponseStatus_t) */ CommonErrorStatus.ResponseStatus AchievementManager_FetchAllResponse_GetStatus(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(size_t) */ UIntPtr AchievementManager_FetchAllResponse_GetData_Length(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(Achievement_t) */ IntPtr AchievementManager_FetchAllResponse_GetData_GetElement(
        HandleRef self,
         /* from(size_t) */ UIntPtr index);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void AchievementManager_FetchResponse_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ResponseStatus_t) */ CommonErrorStatus.ResponseStatus AchievementManager_FetchResponse_GetStatus(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(Achievement_t) */ IntPtr AchievementManager_FetchResponse_GetData(
        HandleRef self);
}
}
#endif // (UNITY_ANDROID || UNITY_IPHONE)
