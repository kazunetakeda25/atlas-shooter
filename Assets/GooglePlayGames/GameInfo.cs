/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using System;

/// <summary>
/// File containing information about the game. This is automatically updated by running the
/// platform-appropriate setup commands in the Unity editor (which does a simple search / replace
/// on the IDs in the form "__ID__"). We can check whether any particular field has been updated
/// by checking whether it still retains its initial value - we prevent the constants from being
/// replaced in the aforementioned search/replace by stripping off the leading and trailing "__".
/// </summary>
namespace GooglePlayGames {
public static class GameInfo {

    private const string UnescapedApplicationId = "APPID";
    private const string UnescapedIosClientId = "CLIENTID";

    public const string ApplicationId = "890105038645"; // Filled in automatically
    public const string IosClientId = "__CLIENTID__"; // Filled in automatically

    public static bool ApplicationIdInitialized() {
        return !ApplicationId.Equals(ToEscapedToken(UnescapedApplicationId));
    }

    public static bool IosClientIdInitialized() {
        return !IosClientId.Equals(ToEscapedToken(UnescapedIosClientId));
    }

    /// <summary>
    /// Returns an escaped token (i.e. one flanked with "__") for the passed token
    /// </summary>
    /// <returns>The escaped token.</returns>
    /// <param name="token">The Token</param>
    private static string ToEscapedToken(string token) {
        return string.Format("__{0}__", token);
    }

}
}


