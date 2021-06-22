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
using System.Collections.Generic;
using GooglePlayGames.Native.Cwrapper;

using C = GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfig;
using Types = GooglePlayGames.Native.Cwrapper.Types;
using Status = GooglePlayGames.Native.Cwrapper.CommonErrorStatus;

namespace GooglePlayGames.Native.PInvoke {
internal class TurnBasedMatchConfig : BaseReferenceHolder {

    internal TurnBasedMatchConfig(IntPtr selfPointer) : base(selfPointer) {
    }

    private string PlayerIdAtIndex(UIntPtr index) {
        return PInvokeUtilities.OutParamsToString(
            (out_string, size) => C.TurnBasedMatchConfig_PlayerIdsToInvite_GetElement(
                SelfPtr(), index, out_string, size));
    }

    internal IEnumerator<string> PlayerIdsToInvite() {
        return PInvokeUtilities.ToEnumerator<string>(
            C.TurnBasedMatchConfig_PlayerIdsToInvite_Length(SelfPtr()),
            PlayerIdAtIndex
        );
    }

    internal uint Variant() {
        return C.TurnBasedMatchConfig_Variant(SelfPtr());
    }

    internal long ExclusiveBitMask() {
        return C.TurnBasedMatchConfig_ExclusiveBitMask(SelfPtr());
    }

    internal uint MinimumAutomatchingPlayers() {
        return C.TurnBasedMatchConfig_MinimumAutomatchingPlayers(SelfPtr());
    }

    internal uint MaximumAutomatchingPlayers() {
        return C.TurnBasedMatchConfig_MaximumAutomatchingPlayers(SelfPtr());
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.TurnBasedMatchConfig_Dispose(selfPointer);
    }
}
}

#endif
