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

using C = GooglePlayGames.Native.Cwrapper.RealTimeRoomConfigBuilder;
using Types = GooglePlayGames.Native.Cwrapper.Types;
using Status = GooglePlayGames.Native.Cwrapper.CommonErrorStatus;

namespace GooglePlayGames.Native.PInvoke {
internal class RealtimeRoomConfigBuilder : BaseReferenceHolder {

    internal RealtimeRoomConfigBuilder(IntPtr selfPointer) : base(selfPointer) {
    }

    internal RealtimeRoomConfigBuilder PopulateFromUIResponse(PlayerSelectUIResponse response) {
        C.RealTimeRoomConfig_Builder_PopulateFromPlayerSelectUIResponse(SelfPtr(),
            response.AsPointer());

        return this;
    }

    internal RealtimeRoomConfigBuilder SetVariant(uint variant) {
        C.RealTimeRoomConfig_Builder_SetVariant(SelfPtr(), variant);
        return this;
    }

    internal RealtimeRoomConfigBuilder AddInvitedPlayer(string playerId) {
        C.RealTimeRoomConfig_Builder_AddPlayerToInvite(SelfPtr(), playerId);
        return this;
    }

    internal RealtimeRoomConfigBuilder SetExclusiveBitMask(ulong bitmask) {
        C.RealTimeRoomConfig_Builder_SetExclusiveBitMask(SelfPtr(), bitmask);
        return this;
    }

    internal RealtimeRoomConfigBuilder SetMinimumAutomatchingPlayers(uint minimum) {
        C.RealTimeRoomConfig_Builder_SetMinimumAutomatchingPlayers(SelfPtr(), minimum);
        return this;
    }

    internal RealtimeRoomConfigBuilder SetMaximumAutomatchingPlayers(uint maximum) {
        C.RealTimeRoomConfig_Builder_SetMaximumAutomatchingPlayers(SelfPtr(), maximum);
        return this;
    }

    internal RealtimeRoomConfig Build() {
        return new RealtimeRoomConfig(C.RealTimeRoomConfig_Builder_Create(SelfPtr()));
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.RealTimeRoomConfig_Builder_Dispose(selfPointer);
    }

    internal static RealtimeRoomConfigBuilder Create() {
        return new RealtimeRoomConfigBuilder(C.RealTimeRoomConfig_Builder_Construct());
    }
}
}

#endif
