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
/// Represents a participant in a real-time or turn-based match. Note the difference
/// between a Player and a Participant! A Player is a real-world person with a name
/// and a Google ID. A Participant is an entity that participates in a real-time
/// or turn-based match; it may be tied to a Player or not. Particularly, Participant
/// without Players represent the anonymous participants in an automatch game.
/// </summary>
public class Participant : IComparable<Participant> {
    public enum ParticipantStatus {
        NotInvitedYet, Invited, Joined, Declined, Left, Finished, Unresponsive, Unknown
    };

    private string mDisplayName = "";
    private string mParticipantId = "";
    private ParticipantStatus mStatus = ParticipantStatus.Unknown;
    private Player mPlayer = null;
    private bool mIsConnectedToRoom = false;

    /// Gets the participant's display name.
    public string DisplayName {
        get {
            return mDisplayName;
        }
    }

    /// <summary>
    /// Gets the participant identifier. Important: everyone in a particular match
    /// agrees on what is the participant ID for each participant; however, participant
    /// IDs are not meaningful outside of the particular match where they are used.
    /// If the same user plays two subsequent matches, their Participant Id will likely
    /// be different in the two matches.
    /// </summary>
    /// <value>The participant identifier.</value>
    public string ParticipantId {
        get {
            return mParticipantId;
        }
    }

    /// Gets the participant's status (invited, joined, declined, left, finished, ...)
    public ParticipantStatus Status {
        get {
            return mStatus;
        }
    }

    /// <summary>
    /// Gets the player that corresponds to this participant. If this is an anonymous
    /// participant, this will be null.
    /// </summary>
    /// <value>The player, or null if this is an anonymous participant.</value>
    public Player Player {
        get {
            return mPlayer;
        }
    }

    /// <summary>
    /// Returns whether the participant is connected to the real time room. This has no
    /// meaning in turn-based matches.
    /// </summary>
    public bool IsConnectedToRoom {
        get {
            return mIsConnectedToRoom;
        }
    }

    /// Returns whether or not this is an automatch participant.
    public bool IsAutomatch {
        get {
            return mPlayer == null;
        }
    }

    internal Participant(string displayName, string participantId,
                             ParticipantStatus status, Player player, bool connectedToRoom) {
        mDisplayName = displayName;
        mParticipantId = participantId;
        mStatus = status;
        mPlayer = player;
        mIsConnectedToRoom = connectedToRoom;
    }

    public override string ToString() {
        return string.Format("[Participant: '{0}' (id {1}), status={2}, " +
        "player={3}, connected={4}]", mDisplayName, mParticipantId, mStatus.ToString(),
            mPlayer == null ? "NULL" : mPlayer.ToString(), mIsConnectedToRoom);
    }

    public int CompareTo(Participant other) {
        return mParticipantId.CompareTo(other.mParticipantId);
    }

    public override bool Equals(object obj) {
        if (obj == null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != typeof(Participant))
            return false;
        Participant other = (Participant)obj;
        return mParticipantId.Equals(other.mParticipantId);
    }

    public override int GetHashCode() {
        return mParticipantId != null ? mParticipantId.GetHashCode() : 0;
    }

}
}

