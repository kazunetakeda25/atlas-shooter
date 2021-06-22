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

using C = GooglePlayGames.Native.Cwrapper.MultiplayerInvitation;
using Types = GooglePlayGames.Native.Cwrapper.Types;
using Status = GooglePlayGames.Native.Cwrapper.CommonErrorStatus;
using GooglePlayGames.BasicApi.Multiplayer;

namespace GooglePlayGames.Native.PInvoke {
internal class MultiplayerInvitation : BaseReferenceHolder {
    internal MultiplayerInvitation(IntPtr selfPointer) : base(selfPointer) {
    }

    internal MultiplayerParticipant Inviter() {
        MultiplayerParticipant participant =
            new MultiplayerParticipant(C.MultiplayerInvitation_InvitingParticipant(SelfPtr()));

        if (!participant.Valid()) {
            participant.Dispose();
            return null;
        }

        return participant;
    }

    internal uint Variant() {
        return C.MultiplayerInvitation_Variant(SelfPtr());
    }

    internal Types.MultiplayerInvitationType Type() {
        return C.MultiplayerInvitation_Type(SelfPtr());
    }

    internal string Id() {
        return PInvokeUtilities.OutParamsToString(
            (out_string, size) => C.MultiplayerInvitation_Id(SelfPtr(), out_string, size)
        );
    }

    protected override void CallDispose(HandleRef selfPointer) {
        C.MultiplayerInvitation_Dispose(selfPointer);
    }

    private static Invitation.InvType ToInvType(Types.MultiplayerInvitationType invitationType) {
        switch (invitationType) {
            case Types.MultiplayerInvitationType.REAL_TIME:
                return Invitation.InvType.RealTime;
            case Types.MultiplayerInvitationType.TURN_BASED:
                return Invitation.InvType.TurnBased;
            default:
                Logger.d("Found unknown invitation type: " + invitationType);
                return Invitation.InvType.Unknown;
        }
    }

    internal Invitation AsInvitation() {
        var type = ToInvType(Type());
        var invitationId = Id();
        int variant = (int)Variant();
        Participant inviter;

        using (var nativeInviter = Inviter()) {
            inviter = nativeInviter == null ? null : nativeInviter.AsParticipant();
        }

        return new Invitation(type, invitationId, inviter, variant);
    }

    internal static MultiplayerInvitation FromPointer(IntPtr selfPointer) {
        if (PInvokeUtilities.IsNull(selfPointer)) {
            return null;
        }

        return new MultiplayerInvitation(selfPointer);
    }
}
}

#endif
