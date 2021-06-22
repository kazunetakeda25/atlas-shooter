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

using C = GooglePlayGames.Native.Cwrapper.MultiplayerParticipant;
using Types = GooglePlayGames.Native.Cwrapper.Types;
using Status = GooglePlayGames.Native.Cwrapper.CommonErrorStatus;
using GooglePlayGames.BasicApi.Multiplayer;

namespace GooglePlayGames.Native.PInvoke {
internal class MultiplayerParticipant : BaseReferenceHolder {

    private static readonly
        Dictionary<Types.ParticipantStatus, Participant.ParticipantStatus> StatusConversion =
            new Dictionary<Types.ParticipantStatus, Participant.ParticipantStatus> {
        {Types.ParticipantStatus.INVITED, Participant.ParticipantStatus.Invited},
        {Types.ParticipantStatus.JOINED, Participant.ParticipantStatus.Joined},
        {Types.ParticipantStatus.DECLINED, Participant.ParticipantStatus.Declined},
        {Types.ParticipantStatus.LEFT, Participant.ParticipantStatus.Left},
        {Types.ParticipantStatus.NOT_INVITED_YET, Participant.ParticipantStatus.NotInvitedYet},
        {Types.ParticipantStatus.FINISHED, Participant.ParticipantStatus.Finished},
        {Types.ParticipantStatus.UNRESPONSIVE, Participant.ParticipantStatus.Unresponsive},
    };

    internal MultiplayerParticipant(IntPtr selfPointer) : base(selfPointer) {
    }

    internal Types.ParticipantStatus Status() {
        return C.MultiplayerParticipant_Status(SelfPtr());
    }

    internal bool IsConnectedToRoom() {
        return C.MultiplayerParticipant_IsConnectedToRoom(SelfPtr());
    }

    internal string DisplayName() {
        return PInvokeUtilities.OutParamsToString(
            (out_string, size) => C.MultiplayerParticipant_DisplayName(SelfPtr(), out_string, size)
        );
    }

    internal NativePlayer Player() {
        if (!C.MultiplayerParticipant_HasPlayer(SelfPtr())) {
            return null;
        }

        return new NativePlayer(C.MultiplayerParticipant_Player(SelfPtr()));
    }

    internal string Id() {
        return PInvokeUtilities.OutParamsToString(
            (out_string, size) => C.MultiplayerParticipant_Id(SelfPtr(), out_string, size));
    }

    internal bool Valid() {
        return C.MultiplayerParticipant_Valid(SelfPtr());
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.MultiplayerParticipant_Dispose(selfPointer);
    }

    internal Participant AsParticipant() {
        NativePlayer nativePlayer = Player();

        return new Participant(
            DisplayName(),
            Id(),
            StatusConversion[Status()],
            nativePlayer == null ? null : nativePlayer.AsPlayer(),
            IsConnectedToRoom()
        );
    }

    internal static MultiplayerParticipant FromPointer(IntPtr pointer) {
        if (PInvokeUtilities.IsNull(pointer)) {
            return null;
        }

        return new MultiplayerParticipant(pointer);
    }

    internal static MultiplayerParticipant AutomatchingSentinel() {
        return new MultiplayerParticipant(Sentinels.Sentinels_AutomatchingParticipant());
    }
}
}

#endif
