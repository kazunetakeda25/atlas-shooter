/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames.BasicApi.SavedGame {
/// <summary>
/// A struct representing the mutation of saved game metadata. Fields can either have a new value
/// or be untouched (in which case the corresponding field in the saved game metadata will be
/// untouched). Instances must be built using <see cref="SavedGameMetadataUpdate.Builder"/>
/// and once created, these instances are immutable and threadsafe.
/// </summary>
public struct SavedGameMetadataUpdate {

    private readonly bool mDescriptionUpdated;
    private readonly string mNewDescription;
    private readonly bool mCoverImageUpdated;
    private readonly byte[] mNewPngCoverImage;
    private readonly TimeSpan? mNewPlayedTime;

    private SavedGameMetadataUpdate(Builder builder) {
        mDescriptionUpdated = builder.mDescriptionUpdated;
        mNewDescription = builder.mNewDescription;
        mCoverImageUpdated = builder.mCoverImageUpdated;
        mNewPngCoverImage = builder.mNewPngCoverImage;
        mNewPlayedTime = builder.mNewPlayedTime;
    }

    public bool IsDescriptionUpdated {
        get {
            return mDescriptionUpdated;
        }
    }

    public string UpdatedDescription {
        get {
            return mNewDescription;
        }
    }

    public bool IsCoverImageUpdated {
        get {
            return mCoverImageUpdated;
        }
    }

    public byte[] UpdatedPngCoverImage {
        get {
            return mNewPngCoverImage;
        }
    }

    public bool IsPlayedTimeUpdated {
        get {
            return mNewPlayedTime.HasValue;
        }
    }

    public TimeSpan? UpdatedPlayedTime {
        get {
            return mNewPlayedTime;
        }
    }

    public struct Builder {
        internal bool mDescriptionUpdated;
        internal string mNewDescription;
        internal bool mCoverImageUpdated;
        internal byte[] mNewPngCoverImage;
        internal TimeSpan? mNewPlayedTime;

        public Builder WithUpdatedDescription(string description) {
            mNewDescription = Misc.CheckNotNull(description);
            mDescriptionUpdated = true;
            return this;
        }

        public Builder WithUpdatedPngCoverImage(byte[] newPngCoverImage) {
            mCoverImageUpdated = true;
            mNewPngCoverImage = newPngCoverImage;
            return this;
        }

        public Builder WithUpdatedPlayedTime(TimeSpan newPlayedTime) {
            if (newPlayedTime.TotalMilliseconds > ulong.MaxValue) {
                throw new InvalidOperationException("Timespans longer than ulong.MaxValue " +
                    "milliseconds are not allowed");
            }
            mNewPlayedTime = newPlayedTime;
            return this;
        }

        public SavedGameMetadataUpdate Build() {
            return new SavedGameMetadataUpdate(this);
        }
    }
}
}

