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
/// Represents a player. A player is different from a participant! The participant is
/// an entity that takes part in a particular match; a Player is a real-world person
/// (tied to a Google account). The player exists across matches, the Participant
/// only exists in the context of a particular match.
/// </summary>
public class Player {
    private readonly string mDisplayName;
    private readonly string mPlayerId;
    private readonly string mAvatarUrl;

    internal Player(string displayName, string playerId, string avatarUrl) {
        mDisplayName = displayName;
        mPlayerId = playerId;
        mAvatarUrl = avatarUrl;
     }

    /// Player's display name.
    public string DisplayName {
        get {
            return mDisplayName;
        }
    }

    /// Player's ID. Always the same for a particular person. It does not vary across matches.
    public string PlayerId {
        get {
            return mPlayerId;
        }
    }

    /// Player's AvatarUrl - can be null if the user has no avatar.
    public string AvatarURL {
        get {
            return mAvatarUrl;
        }
    }

    public override string ToString() {
        return string.Format("[Player: '{0}' (id {1})]", mDisplayName, mPlayerId);
    }

    public override bool Equals(object obj) {
        if (obj == null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj.GetType() != typeof(Player))
            return false;
        Player other = (Player)obj;
        return mPlayerId == other.mPlayerId;
    }

    public override int GetHashCode() {
        return mPlayerId != null ? mPlayerId.GetHashCode() : 0;
    }
}
}

