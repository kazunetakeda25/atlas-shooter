/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;

namespace GooglePlayGames.BasicApi.Multiplayer {
/// <summary>
/// Represents an invitation to a multiplayer game. The invitation may be for
/// a turn-based or real-time game.
/// </summary>
public class Invitation {
    public enum InvType { RealTime, TurnBased, Unknown};

    private InvType mInvitationType;
    private string mInvitationId;
    private Participant mInviter;
    private int mVariant;

    internal Invitation(InvType invType, string invId, Participant inviter, int variant) {
        mInvitationType = invType;
        mInvitationId = invId;
        mInviter = inviter;
        mVariant = variant;
    }

    /// <summary>
    /// Gets the type of the invitation.
    /// </summary>
    /// <value>The type of the invitation (real-time or turn-based).</value>
    public InvType InvitationType {
        get {
            return mInvitationType;
        }
    }

    /// <summary>
    /// Gets the invitation id.
    /// </summary>
    /// <value>The invitation id.</value>
    public string InvitationId {
        get {
            return mInvitationId;
        }
    }

    /// <summary>
    /// Gets the participant who issued the invitation.
    /// </summary>
    /// <value>The participant who issued the invitation.</value>
    public Participant Inviter {
        get {
            return mInviter;
        }
    }

    /// <summary>
    /// Gets the match variant. The meaning of this parameter is defined by the game.
    /// It usually indicates a particular game type or mode (for example "capture the flag",
    // "first to 10 points", etc).
    /// </summary>
    /// <value>The match variant. 0 means default (unset).</value>
    public int Variant {
        get {
            return mVariant;
        }
    }

    public override string ToString() {
        return string.Format("[Invitation: InvitationType={0}, InvitationId={1}, Inviter={2}, " +
        "Variant={3}]", InvitationType, InvitationId, Inviter, Variant);
    }
}
}

