/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;
using System.Collections;
using UnityEngine.SocialPlatforms;
using UnityEngine;
using System.Collections.Generic;

namespace GooglePlayGames {
/// <summary>
/// Represents the Google Play Games local user.
/// </summary>
public class PlayGamesLocalUser : PlayGamesUserProfile, ILocalUser {
    PlayGamesPlatform mPlatform;

    private WWW mAvatarUrl;
    private Texture2D mImage;

    internal PlayGamesLocalUser(PlayGamesPlatform plaf) {
        mPlatform = plaf;
        mAvatarUrl = null;
        mImage = null;
    }

    /// <summary>
    /// Authenticates the local user. Equivalent to calling
    /// <see cref="PlayGamesPlatform.Authenticate" />.
    /// </summary>
    public void Authenticate(Action<bool> callback) {
        mPlatform.Authenticate(callback);
    }

    /// <summary>
    /// Authenticates the local user. Equivalent to calling
    /// <see cref="PlayGamesPlatform.Authenticate" />.
    /// </summary>
    public void Authenticate(Action<bool> callback, bool silent) {
        mPlatform.Authenticate(callback, silent);
    }

    /// <summary>
    /// Not implemented. Calls the callback with <c>false</c>.
    /// </summary>
    public void LoadFriends(Action<bool> callback) {
        if (callback != null) {
            callback.Invoke(false);
        }
    }

    /// <summary>
    /// Not implemented. Returns an empty list.
    /// </summary>
    public IUserProfile[] friends {
        get {
            return new IUserProfile[0];
        }
    }

    /// <summary>
    /// Returns whether or not the local user is authenticated to Google Play Games.
    /// </summary>
    /// <returns>
    /// <c>true</c> if authenticated; otherwise, <c>false</c>.
    /// </returns>
    public bool authenticated {
        get {
            return mPlatform.IsAuthenticated();
        }
    }

    /// <summary>
    /// Not implemented. As safety placeholder, returns true.
    /// </summary>
    public bool underage {
        get {
            return true;
        }
    }

    /// <summary>
    /// Gets the display name of the user.
    /// </summary>
    /// <returns>
    /// The display name of the user.
    /// </returns>
    public new string userName {
        get {
            return authenticated ? mPlatform.GetUserDisplayName() : "";
        }
    }

    /// <summary>
    /// Gets the user's Google id.
    /// </summary>
    /// <returns>
    /// The user's Google id.
    /// </returns>
    public new string id {
        get {
            return authenticated ? mPlatform.GetUserId() : "";
        }
    }

    /// <summary>
    /// Returns true (since this is the local user).
    /// </summary>
    public new bool isFriend {
        get {
            return true;
        }
    }

    /// <summary>
    /// Gets the local user's state. This is always <c>UserState.Online</c> for
    /// the local user.
    /// </summary>
    public new UserState state {
        get {
            return UserState.Online;
        }
    }

    /// <summary>
    /// Loads the local user's image from the url.  Loading urls
    /// is asynchronous so the return from this call is fast,
    /// the image is returned once it is loaded.  null is returned
    /// up to that point.
    /// </summary>
    private Texture2D LoadImage() {
        string url = mPlatform.GetUserImageUrl();

        // the url can be null if the user does not have an
        // avatar configured.
        if (url != null) {
          if (mAvatarUrl == null) {
              mAvatarUrl = new WWW(url);
          }
          if(mAvatarUrl.isDone) {
              return mAvatarUrl.texture;
          }
        }
        // if there is no url, always return null.
        return null;
    }

    /// <summary>
    /// Gets the display image of the user.
    /// </summary>
    /// <returns>
    /// null if the user has no avatar, or it has not loaded yet.
    /// </returns>
    public new Texture2D image {
        get {
            if (mImage == null) {
              mImage = LoadImage();
            }
            return mImage;
        }
    }
}
}

