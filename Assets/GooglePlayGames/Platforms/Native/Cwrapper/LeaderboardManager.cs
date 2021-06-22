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
internal static class LeaderboardManager {
    internal delegate void FetchCallback(
         /* from(LeaderboardManager_FetchResponse_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void FetchAllCallback(
         /* from(LeaderboardManager_FetchAllResponse_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void FetchScorePageCallback(
         /* from(LeaderboardManager_FetchScorePageResponse_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void FetchScoreSummaryCallback(
         /* from(LeaderboardManager_FetchScoreSummaryResponse_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void FetchAllScoreSummariesCallback(
         /* from(LeaderboardManager_FetchAllScoreSummariesResponse_t) */ IntPtr arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void ShowAllUICallback(
         /* from(UIStatus_t) */ CommonErrorStatus.UIStatus arg0,
         /* from(void *) */ IntPtr arg1);

    internal delegate void ShowUICallback(
         /* from(UIStatus_t) */ CommonErrorStatus.UIStatus arg0,
         /* from(void *) */ IntPtr arg1);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void LeaderboardManager_FetchAll(
        HandleRef self,
         /* from(DataSource_t) */ Types.DataSource data_source,
         /* from(LeaderboardManager_FetchAllCallback_t) */ FetchAllCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void LeaderboardManager_FetchScoreSummary(
        HandleRef self,
         /* from(DataSource_t) */ Types.DataSource data_source,
         /* from(char const *) */ string leaderboard_id,
         /* from(LeaderboardTimeSpan_t) */ Types.LeaderboardTimeSpan time_span,
         /* from(LeaderboardCollection_t) */ Types.LeaderboardCollection collection,
         /* from(LeaderboardManager_FetchScoreSummaryCallback_t) */ FetchScoreSummaryCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ScorePage_ScorePageToken_t) */ IntPtr LeaderboardManager_ScorePageToken(
        HandleRef self,
         /* from(char const *) */ string leaderboard_id,
         /* from(LeaderboardStart_t) */ Types.LeaderboardStart start,
         /* from(LeaderboardTimeSpan_t) */ Types.LeaderboardTimeSpan time_span,
         /* from(LeaderboardCollection_t) */ Types.LeaderboardCollection collection);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void LeaderboardManager_ShowAllUI(
        HandleRef self,
         /* from(LeaderboardManager_ShowAllUICallback_t) */ ShowAllUICallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void LeaderboardManager_FetchScorePage(
        HandleRef self,
         /* from(DataSource_t) */ Types.DataSource data_source,
         /* from(ScorePage_ScorePageToken_t) */ IntPtr token,
         /* from(uint32_t) */ uint max_results,
         /* from(LeaderboardManager_FetchScorePageCallback_t) */ FetchScorePageCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void LeaderboardManager_FetchAllScoreSummaries(
        HandleRef self,
         /* from(DataSource_t) */ Types.DataSource data_source,
         /* from(char const *) */ string leaderboard_id,
         /* from(LeaderboardManager_FetchAllScoreSummariesCallback_t) */ FetchAllScoreSummariesCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void LeaderboardManager_ShowUI(
        HandleRef self,
         /* from(char const *) */ string leaderboard_id,
         /* from(LeaderboardManager_ShowUICallback_t) */ ShowUICallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void LeaderboardManager_Fetch(
        HandleRef self,
         /* from(DataSource_t) */ Types.DataSource data_source,
         /* from(char const *) */ string leaderboard_id,
         /* from(LeaderboardManager_FetchCallback_t) */ FetchCallback callback,
         /* from(void *) */ IntPtr callback_arg);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void LeaderboardManager_SubmitScore(
        HandleRef self,
         /* from(char const *) */ string leaderboard_id,
         /* from(uint64_t) */ ulong score,
         /* from(char const *) */ string metadata);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void LeaderboardManager_FetchResponse_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ResponseStatus_t) */ CommonErrorStatus.ResponseStatus LeaderboardManager_FetchResponse_GetStatus(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(Leaderboard_t) */ IntPtr LeaderboardManager_FetchResponse_GetData(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void LeaderboardManager_FetchAllResponse_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ResponseStatus_t) */ CommonErrorStatus.ResponseStatus LeaderboardManager_FetchAllResponse_GetStatus(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(size_t) */ UIntPtr LeaderboardManager_FetchAllResponse_GetData_Length(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(Leaderboard_t) */ IntPtr LeaderboardManager_FetchAllResponse_GetData_GetElement(
        HandleRef self,
         /* from(size_t) */ UIntPtr index);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void LeaderboardManager_FetchScorePageResponse_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ResponseStatus_t) */ CommonErrorStatus.ResponseStatus LeaderboardManager_FetchScorePageResponse_GetStatus(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ScorePage_t) */ IntPtr LeaderboardManager_FetchScorePageResponse_GetData(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void LeaderboardManager_FetchScoreSummaryResponse_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ResponseStatus_t) */ CommonErrorStatus.ResponseStatus LeaderboardManager_FetchScoreSummaryResponse_GetStatus(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ScoreSummary_t) */ IntPtr LeaderboardManager_FetchScoreSummaryResponse_GetData(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern void LeaderboardManager_FetchAllScoreSummariesResponse_Dispose(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ResponseStatus_t) */ CommonErrorStatus.ResponseStatus LeaderboardManager_FetchAllScoreSummariesResponse_GetStatus(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(size_t) */ UIntPtr LeaderboardManager_FetchAllScoreSummariesResponse_GetData_Length(
        HandleRef self);

    [DllImport(SymbolLocation.NativeSymbolLocation)]
    internal static extern /* from(ScoreSummary_t) */ IntPtr LeaderboardManager_FetchAllScoreSummariesResponse_GetData_GetElement(
        HandleRef self,
         /* from(size_t) */ UIntPtr index);
}
}
#endif // (UNITY_ANDROID || UNITY_IPHONE)
