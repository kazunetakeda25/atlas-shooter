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
using GooglePlayGames.BasicApi;
using GooglePlayGames.OurUtils;

namespace GooglePlayGames {
internal class PlayGamesClientFactory {
    internal static IPlayGamesClient GetPlatformPlayGamesClient(
        PlayGamesClientConfiguration config) {
        if (Application.isEditor) {
            Logger.d("Creating IPlayGamesClient in editor, using DummyClient.");
            return new GooglePlayGames.BasicApi.DummyClient();
        }
#if (UNITY_ANDROID || UNITY_IPHONE)
        Logger.d("Creating real IPlayGamesClient");
        return new GooglePlayGames.Native.NativeClient(config);
#else
            Logger.d("Cannot create IPlayGamesClient for unknown platform, returning DummyClient");
            return new GooglePlayGames.BasicApi.DummyClient();
#endif
    }
}
}

