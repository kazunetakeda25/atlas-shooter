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

using C = GooglePlayGames.Native.Cwrapper.GameServices;

namespace GooglePlayGames.Native.PInvoke {

class GameServices : BaseReferenceHolder {

    internal GameServices (IntPtr selfPointer) : base(selfPointer) {
    }

    internal bool IsAuthenticated() {
        return C.GameServices_IsAuthorized(SelfPtr());
    }

    internal void SignOut() {
        C.GameServices_SignOut(SelfPtr());
    }

    internal void StartAuthorizationUI() {
        C.GameServices_StartAuthorizationUI(SelfPtr());
    }

    public AchievementManager AchievementManager() {
        return new AchievementManager(this);
    }

    public LeaderboardManager LeaderboardManager() {
        return new LeaderboardManager(this);
    }

    public PlayerManager PlayerManager() {
        return new PlayerManager(this);
    }

    internal HandleRef AsHandle() {
        return SelfPtr();
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.GameServices_Dispose(selfPointer);
    }
}
}


#endif
