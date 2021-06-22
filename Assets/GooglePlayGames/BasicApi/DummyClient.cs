/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;
using System.Collections.Generic;
using System.Collections;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.BasicApi {
public class DummyClient : IPlayGamesClient {
    public void Authenticate(System.Action<bool> callback, bool silent) {
        LogUsage();
        if (callback != null) {
            callback.Invoke(false);
        }
    }

    public bool IsAuthenticated() {
        LogUsage();
        return false;
    }

    public void SignOut() {
        LogUsage();
    }

    public string GetUserId() {
        LogUsage();
        return "DummyID";
    }

    public string GetUserDisplayName() {
        LogUsage();
        return "Player";
    }

    public string GetUserImageUrl() {
        LogUsage();
        return null;
    }

    public List<Achievement> GetAchievements() {
        LogUsage();
        return new List<Achievement>();
    }

    public Achievement GetAchievement(string achId) {
        LogUsage();
        return null;
    }

    public void UnlockAchievement(string achId, Action<bool> callback) {
        LogUsage();
        if (callback != null) {
            callback.Invoke(false);
        }
    }

    public void RevealAchievement(string achId, Action<bool> callback) {
        LogUsage();
        if (callback != null) {
            callback.Invoke(false);
        }
    }

    public void IncrementAchievement(string achId, int steps, Action<bool> callback) {
        LogUsage();
        if (callback != null) {
            callback.Invoke(false);
        }
    }

    public void ShowAchievementsUI() {
        LogUsage();
    }

    public void ShowLeaderboardUI(string lbId) {
        LogUsage();
    }

    public void SubmitScore(string lbId, long score, Action<bool> callback) {
        LogUsage();
        if (callback != null) {
            callback.Invoke(false);
        }
    }

    public void LoadState(int slot, OnStateLoadedListener listener) {
        LogUsage();
        if (listener != null) {
            listener.OnStateLoaded(false, slot, null);
        }
    }

    public void UpdateState(int slot, byte[] data, OnStateLoadedListener listener) {
        LogUsage();
    }

    public Multiplayer.IRealTimeMultiplayerClient GetRtmpClient() {
        LogUsage();
        return null;
    }

    public Multiplayer.ITurnBasedMultiplayerClient GetTbmpClient() {
        LogUsage();
        return null;
    }

    public SavedGame.ISavedGameClient GetSavedGameClient() {
        LogUsage();
        return null;
    }

    public void RegisterInvitationDelegate(InvitationReceivedDelegate deleg) {
        LogUsage();
    }

    public Invitation GetInvitationFromNotification() {
        LogUsage();
        return null;
    }

    public bool HasInvitationFromNotification() {
        LogUsage();
        return false;
    }

    private static void LogUsage() {
        Logger.d("Received method call on DummyClient - using stub implementation.");
    }
}
}

