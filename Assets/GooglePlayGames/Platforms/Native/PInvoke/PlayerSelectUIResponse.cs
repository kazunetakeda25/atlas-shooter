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
using C = GooglePlayGames.Native.Cwrapper.TurnBasedMultiplayerManager;
using Types = GooglePlayGames.Native.Cwrapper.Types;
using Status = GooglePlayGames.Native.Cwrapper.CommonErrorStatus;
using MultiplayerStatus = GooglePlayGames.Native.Cwrapper.CommonErrorStatus.MultiplayerStatus;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GooglePlayGames.Native.PInvoke {
internal class PlayerSelectUIResponse : BaseReferenceHolder, IEnumerable<string> {
    internal PlayerSelectUIResponse(IntPtr selfPointer) : base(selfPointer) {
    }

    internal Status.UIStatus Status() {
        return C.TurnBasedMultiplayerManager_PlayerSelectUIResponse_GetStatus(SelfPtr());
    }

    private string PlayerIdAtIndex(UIntPtr index) {
        return PInvokeUtilities.OutParamsToString(
            (out_string, size) => C.TurnBasedMultiplayerManager_PlayerSelectUIResponse_GetPlayerIds_GetElement(
                SelfPtr(), index, out_string, size));
    }

    public IEnumerator<string> GetEnumerator() {
        return PInvokeUtilities.ToEnumerator<string>(
            C.TurnBasedMultiplayerManager_PlayerSelectUIResponse_GetPlayerIds_Length(SelfPtr()),
            PlayerIdAtIndex
        );
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    internal uint MinimumAutomatchingPlayers() {
        return C.TurnBasedMultiplayerManager_PlayerSelectUIResponse_GetMinimumAutomatchingPlayers(SelfPtr());
    }

    internal uint MaximumAutomatchingPlayers() {
        return C.TurnBasedMultiplayerManager_PlayerSelectUIResponse_GetMaximumAutomatchingPlayers(SelfPtr());
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.TurnBasedMultiplayerManager_PlayerSelectUIResponse_Dispose(selfPointer);
    }

    internal static PlayerSelectUIResponse FromPointer(IntPtr pointer) {
        if (PInvokeUtilities.IsNull(pointer)) {
            return null;
        }

        return new PlayerSelectUIResponse(pointer);
    }
}
}


#endif
