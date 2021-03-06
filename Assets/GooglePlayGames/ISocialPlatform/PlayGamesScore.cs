/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace GooglePlayGames {
/// <summary>
/// Represents a Google Play Games score that can be sent to a leaderboard.
/// </summary>
public class PlayGamesScore : IScore {
    string mLbId = null;
    long mValue = 0;

    /// <summary>
    /// Reports the score. Equivalent to <see cref="PlayGamesPlatform.ReportScore" />.
    /// </summary>
    public void ReportScore(Action<bool> callback) {
        PlayGamesPlatform.Instance.ReportScore(mValue, mLbId, callback);
    }

    /// <summary>
    /// Gets or sets the leaderboard id.
    /// </summary>
    /// <returns>
    /// The leaderboard id.
    /// </returns>
    public string leaderboardID {
        get {
            return mLbId;
        }
        set {
            mLbId = value;
        }
    }

    /// <summary>
    /// Gets or sets the score value.
    /// </summary>
    /// <returns>
    /// The value.
    /// </returns>
    public long value {
        get {
            return mValue;
        }
        set {
            mValue = value;
        }
    }

    /// <summary>
    /// Not implemented. Returns Jan 01, 1970, 00:00:00
    /// </summary>
    public DateTime date {
        get {
            return new DateTime(1970, 1, 1, 0, 0, 0);
        }
    }

    /// <summary>
    /// Not implemented. Returns the value converted to a string, unformatted.
    /// </summary>
    public string formattedValue {
        get {
            return mValue.ToString();
        }
    }

    /// <summary>
    /// Not implemented. Returns the empty string.
    /// </summary>
    public string userID {
        get {
            return "";
        }
    }

    /// <summary>
    /// Not implemented. Returns 1.
    /// </summary>
    public int rank {
        get {
            return 1;
        }
    }
}
}
