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
using GooglePlayGames.Native.PInvoke;
using System.Runtime.InteropServices;
using GooglePlayGames.OurUtils;

using C = GooglePlayGames.Native.Cwrapper.LeaderboardManager;

using Types = GooglePlayGames.Native.Cwrapper.Types;
using Status = GooglePlayGames.Native.Cwrapper.CommonErrorStatus;

namespace GooglePlayGames.Native {
internal class LeaderboardManager {

    private readonly GameServices mServices;

    internal LeaderboardManager (GameServices services) {
        mServices = Misc.CheckNotNull(services);
    }

    internal void SubmitScore(string leaderboardId, long score) {
        Misc.CheckNotNull(leaderboardId);
        Logger.d("Native Submitting score: " + score + " for lb " + leaderboardId);
        // Note, we pass empty-string as the metadata - this is ignored by the native SDK.
        C.LeaderboardManager_SubmitScore(mServices.AsHandle(), leaderboardId, (ulong) score, "");
    }

    internal void ShowAllUI(Action<Status.UIStatus> callback) {
        Misc.CheckNotNull(callback);

        C.LeaderboardManager_ShowAllUI(mServices.AsHandle(), Callbacks.InternalShowUICallback,
            Callbacks.ToIntPtr(callback));
    }

    internal void ShowUI(string leaderboardId, Action<Status.UIStatus> callback) {
        Misc.CheckNotNull(callback);

        C.LeaderboardManager_ShowUI(mServices.AsHandle(), leaderboardId,
            Callbacks.InternalShowUICallback, Callbacks.ToIntPtr(callback));
    }
}
}


#endif
