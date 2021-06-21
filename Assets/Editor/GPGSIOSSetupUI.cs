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

public class GPGSIOSSetupUI : EditorWindow {

    private const string GameInfoPath = "Assets/GooglePlayGames/GameInfo.cs";

    private string mClientId = "";
    private string mBundleId = "";

    [MenuItem("Google Play Games/iOS Setup...", false, 1)]
    public static void MenuItemGPGSIOSSetup() {
        EditorWindow.GetWindow(typeof(GPGSIOSSetupUI));
    }

    [MenuItem("File/Play Games - iOS setup...")]
    public static void MenuItemFileGPGSIOSSetup() {
        EditorWindow.GetWindow(typeof(GPGSIOSSetupUI));
    }

    void OnEnable() {
        mClientId = GPGSProjectSettings.Instance.Get("ios.ClientId");
        mBundleId = GPGSProjectSettings.Instance.Get("ios.BundleId");

        if (mBundleId.Trim().Length == 0) {
            mBundleId = PlayerSettings.bundleIdentifier;
        }
    }

    void Save() {
        GPGSProjectSettings.Instance.Set("ios.ClientId", mClientId);
        GPGSProjectSettings.Instance.Set("ios.BundleId", mBundleId);
        GPGSProjectSettings.Instance.Save();
    }

    void OnGUI() {
        // Title
        GUILayout.BeginArea(new Rect(20, 20, position.width - 40, position.height - 40));
        GUILayout.Label(GPGSStrings.IOSSetup.Title, EditorStyles.boldLabel);
        GUILayout.Label(GPGSStrings.IOSSetup.Blurb);
        GUILayout.Space(10);

        // Client ID field
        GUILayout.Label(GPGSStrings.IOSSetup.ClientIdTitle, EditorStyles.boldLabel);
        GUILayout.Label(GPGSStrings.IOSSetup.ClientIdBlurb);
        mClientId = EditorGUILayout.TextField(GPGSStrings.IOSSetup.ClientId, mClientId);
        GUILayout.Space(10);

        // Bundle ID field
        GUILayout.Label(GPGSStrings.IOSSetup.BundleIdTitle, EditorStyles.boldLabel);
        GUILayout.Label(GPGSStrings.IOSSetup.BundleIdBlurb);
        mBundleId = EditorGUILayout.TextField(GPGSStrings.IOSSetup.BundleId, mBundleId);
        GUILayout.Space(10);

        // Setup button
        if (GUILayout.Button(GPGSStrings.Setup.SetupButton)) {
            DoSetup();
        }
        GUILayout.EndArea();
    }

    private void FillInAppData(string sourcePath, string outputPath) {
        string fileBody = GPGSUtil.ReadFully(sourcePath);
        fileBody = fileBody.Replace("__CLIENTID__", mClientId);
        fileBody = fileBody.Replace("__BUNDLEID__", mBundleId);
        GPGSUtil.WriteFile(outputPath, fileBody);
    }

    void DoSetup() {

        if (!GPGSUtil.LooksLikeValidClientId(mClientId)) {
            GPGSUtil.Alert(GPGSStrings.IOSSetup.ClientIdError);
            return;
        }
        if (!GPGSUtil.LooksLikeValidBundleId(mBundleId)) {
            GPGSUtil.Alert(GPGSStrings.IOSSetup.BundleIdError);
            return;
        }

        Save();
        GPGSUtil.UpdateGameInfo();

        FillInAppData(GameInfoPath, GameInfoPath);

        // Finished!
        GPGSProjectSettings.Instance.Set("ios.SetupDone", true);
        GPGSProjectSettings.Instance.Save();
        AssetDatabase.Refresh();
        GPGSUtil.Alert(GPGSStrings.Success, GPGSStrings.IOSSetup.SetupComplete);
    }
}
