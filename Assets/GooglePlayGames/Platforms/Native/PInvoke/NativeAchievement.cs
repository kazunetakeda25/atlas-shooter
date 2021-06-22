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
using System.Text;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.BasicApi;

using C = GooglePlayGames.Native.Cwrapper.Achievement;
using Types = GooglePlayGames.Native.Cwrapper.Types;

namespace GooglePlayGames.Native {
internal class NativeAchievement : BaseReferenceHolder {

    internal NativeAchievement (IntPtr selfPointer) : base(selfPointer) {
    }

    internal uint CurrentSteps() {
        return C.Achievement_CurrentSteps(SelfPtr());
    }

    internal string Description() {
        return PInvokeUtilities.OutParamsToString((out_string, out_size) =>
                C.Achievement_Description(SelfPtr(), out_string, out_size));
    }

    internal string Id() {
        return PInvokeUtilities.OutParamsToString(
            (out_string, out_size) => C.Achievement_Id(SelfPtr(), out_string, out_size));
    }

    internal string Name() {
        return PInvokeUtilities.OutParamsToString(
            (out_string, out_size) => C.Achievement_Name(SelfPtr(), out_string, out_size));
    }

    internal Types.AchievementState State() {
        return C.Achievement_State(SelfPtr());
    }

    internal uint TotalSteps() {
        return C.Achievement_TotalSteps(SelfPtr());
    }

    internal Types.AchievementType Type() {
        return C.Achievement_Type(SelfPtr());
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.Achievement_Dispose(selfPointer);
    }

    internal Achievement AsAchievement() {
        Achievement achievement = new Achievement();

        achievement.Id = Id();
        achievement.Name = Name();
        achievement.Description = Description();

        if (Type() == Types.AchievementType.INCREMENTAL) {
            achievement.IsIncremental = true;
            achievement.CurrentSteps = (int)CurrentSteps();
            achievement.TotalSteps = (int)TotalSteps();
        }

        achievement.IsRevealed = State() == Types.AchievementState.REVEALED;
        achievement.IsUnlocked = State() == Types.AchievementState.UNLOCKED;

        return achievement;
    }

}
}


#endif
