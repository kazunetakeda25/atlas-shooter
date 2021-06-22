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

internal delegate void ReportProgress(string id,double progress,Action<bool> callback);

/// <summary>
/// Represents a Google Play Games achievement. It can be used to report an achievement
/// to the API, offering identical functionality as <see cref="PlayGamesPlatform.ReportProgress" />.
/// </summary>
internal class PlayGamesAchievement : IAchievement {
    private readonly ReportProgress mProgressCallback;
    private string mId = "";
    private double mPercentComplete = 0.0f;
    private static readonly DateTime _sentinel = new DateTime(1970, 1, 1, 0, 0, 0, 0);

    internal PlayGamesAchievement() : this(PlayGamesPlatform.Instance.ReportProgress) {
    }

    internal PlayGamesAchievement(ReportProgress progressCallback) {
        mProgressCallback = progressCallback;
    }

    /// <summary>
    /// Reveals, unlocks or increment achievement. Call after setting
    /// <see cref="id" /> and <see cref="percentCompleted" />. Equivalent to calling
    /// <see cref="PlayGamesPlatform.ReportProgress" />.
    /// </summary>
    public void ReportProgress(Action<bool> callback) {
        mProgressCallback.Invoke(mId, mPercentComplete, callback);
    }

    /// <summary>
    /// Gets or sets the id of this achievement.
    /// </summary>
    /// <returns>
    /// The identifier.
    /// </returns>
    public string id {
        get {
            return mId;
        }
        set {
            mId = value;
        }
    }

    /// <summary>
    /// Gets or sets the percent completed.
    /// </summary>
    /// <returns>
    /// The percent completed.
    /// </returns>
    public double percentCompleted {
        get {
            return mPercentComplete;
        }
        set {
            mPercentComplete = value;
        }
    }

    /// <summary>
    /// Not implemented. Always returns false.
    /// </summary>
    public bool completed {
        get {
            return false;
        }
    }

    /// <summary>
    /// Not implemented. Always returns false.
    /// </summary>
    public bool hidden {
        get {
            return false;
        }
    }

    /// <summary>
    /// Not implemented.
    /// </summary>
    /// <returns>
    /// Not implemented. Always returns Jan 01, 1970, 00:00:00.
    /// </returns>
    public DateTime lastReportedDate {
        get {
            // NOTE: we don't implement this field. We always return
            // 1970-01-01 00:00:00
            return _sentinel;
        }
    }
}
}

