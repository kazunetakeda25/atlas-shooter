/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

[InitializeOnLoad]
public class GPGSUpgrader {
    private static string CUR_VER = "00911";

    static GPGSUpgrader() {
        string prevVer = GPGSProjectSettings.Instance.Get("lastUpgrade", "00000");
        if (prevVer != CUR_VER) {
            Upgrade(prevVer);
            string msg = GPGSStrings.PostInstall.Text.Replace("$VERSION",
                             GooglePlayGames.PluginVersion.VersionString);
            EditorUtility.DisplayDialog(GPGSStrings.PostInstall.Title, msg, "OK");
        }
    }

    private static void Upgrade(string prevVer) {
        Debug.Log("Upgrading from format version " + prevVer + " to " + CUR_VER);

        // delete obsolete files, if they are there
        string[] obsoleteFiles = {
            "Assets/GooglePlayGames/OurUtils/Utils.cs",
            "Assets/GooglePlayGames/OurUtils/Utils.cs.meta",
            "Assets/GooglePlayGames/OurUtils/MyClass.cs",
            "Assets/GooglePlayGames/OurUtils/MyClass.cs.meta",
            "Assets/Plugins/GPGSUtils.dll",
            "Assets/Plugins/GPGSUtils.dll.meta",
        };

        foreach (string file in obsoleteFiles) {
            if (File.Exists(file)) {
                Debug.Log("Deleting obsolete file: " + file);
                File.Delete(file);
            }
        }

        // delete obsolete directories, if they are there
        string[] obsoleteDirectories = {
            "Assets/GooglePlayGames/Platforms/Android",
            "Assets/GooglePlayGames/Platforms/iOS",
            "Assets/Plugins/Android/BaseGameUtils",
        };

        foreach (string directory in obsoleteDirectories) {
            if (Directory.Exists(directory)) {
                Debug.Log("Deleting obsolete directory: " + directory);
                Directory.Delete(directory, true);
            }
        }

        GPGSProjectSettings.Instance.Set("lastUpgrade", CUR_VER);
        GPGSProjectSettings.Instance.Save();
        Debug.Log("Done upgrading from format version " + prevVer + " to " + CUR_VER);
        AssetDatabase.Refresh();
    }
}
