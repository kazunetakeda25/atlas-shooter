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

using C = GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfigBuilder;
using Types = GooglePlayGames.Native.Cwrapper.Types;
using Status = GooglePlayGames.Native.Cwrapper.CommonErrorStatus;

namespace GooglePlayGames.Native.PInvoke {
internal class TurnBasedMatchConfigBuilder : BaseReferenceHolder {

    private TurnBasedMatchConfigBuilder(IntPtr selfPointer) : base(selfPointer) {
    }

    internal TurnBasedMatchConfigBuilder PopulateFromUIResponse(PlayerSelectUIResponse response) {
        C.TurnBasedMatchConfig_Builder_PopulateFromPlayerSelectUIResponse(SelfPtr(),
            response.AsPointer());

        return this;
    }

    internal TurnBasedMatchConfigBuilder SetVariant(uint variant) {
        C.TurnBasedMatchConfig_Builder_SetVariant(SelfPtr(), variant);
        return this;
    }

    internal TurnBasedMatchConfigBuilder AddInvitedPlayer(string playerId) {
        C.TurnBasedMatchConfig_Builder_AddPlayerToInvite(SelfPtr(), playerId);
        return this;
    }

    internal TurnBasedMatchConfigBuilder SetExclusiveBitMask(ulong bitmask) {
        C.TurnBasedMatchConfig_Builder_SetExclusiveBitMask(SelfPtr(), bitmask);
        return this;
    }

    internal TurnBasedMatchConfigBuilder SetMinimumAutomatchingPlayers(uint minimum) {
        C.TurnBasedMatchConfig_Builder_SetMinimumAutomatchingPlayers(SelfPtr(), minimum);
        return this;
    }

    internal TurnBasedMatchConfigBuilder SetMaximumAutomatchingPlayers(uint maximum) {
        C.TurnBasedMatchConfig_Builder_SetMaximumAutomatchingPlayers(SelfPtr(), maximum);
        return this;
    }

    internal TurnBasedMatchConfig Build() {
        return new TurnBasedMatchConfig(C.TurnBasedMatchConfig_Builder_Create(SelfPtr()));
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.TurnBasedMatchConfig_Builder_Dispose(selfPointer);
    }

    internal static TurnBasedMatchConfigBuilder Create() {
        return new TurnBasedMatchConfigBuilder(C.TurnBasedMatchConfig_Builder_Construct());
    }
}
}

#endif
