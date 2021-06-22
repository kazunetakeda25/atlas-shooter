/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;
using UnityEngine.SocialPlatforms;

namespace GooglePlayGames {
/// <summary>
/// Represents a Google Play Games user profile. In the current implementation,
/// this is only used as a base class of <see cref="PlayGamesLocalUser" />
/// and should not be used directly.
/// </summary>
public class PlayGamesUserProfile : IUserProfile {
    internal PlayGamesUserProfile() {
    }

    public string userName {
        get {
            return "";
        }
    }

    public string id {
        get {
            return "";
        }
    }

    public bool isFriend {
        get {
            return false;
        }
    }

    public UserState state {
        get {
            return UserState.Online;
        }
    }

    public UnityEngine.Texture2D image {
        get {
            return null;
        }
    }
}
}

