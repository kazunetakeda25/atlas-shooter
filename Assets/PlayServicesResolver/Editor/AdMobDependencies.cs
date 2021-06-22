/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using Google.JarResolver;
using UnityEditor;

/// AdMob dependencies file.
[InitializeOnLoad]
public static class AdMobDependencies
{
    /// The name of the plugin.
    private static readonly string PluginName = "AdMobUnity";

    /// Initializes static members of the class.
    static AdMobDependencies()
    {
        PlayServicesSupport svcSupport =
            PlayServicesSupport.CreateInstance(PluginName, EditorPrefs.GetString("AndroidSdkRoot"),
                    "ProjectSettings");

        svcSupport.DependOn("com.google.android.gms", "play-services-ads", "LATEST");

        // Marshmallow permissions requires app-compat.
        svcSupport.DependOn("com.android.support", "appcompat-v7", "23.1.0+");
    }
}
