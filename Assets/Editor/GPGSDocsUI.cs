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

public class GPGSDocsUI {
    [MenuItem("Google Play Games/Documentation/Plugin Getting Started Guide...", false, 100)]
    public static void MenuItemGettingStartedGuide() {
        Application.OpenURL(GPGSStrings.ExternalLinks.GettingStartedGuideURL);
    }

    [MenuItem("Google Play Games/Documentation/Google Play Games API...", false, 101)]
    public static void MenuItemPlayGamesServicesAPI() {
        Application.OpenURL(GPGSStrings.ExternalLinks.PlayGamesServicesApiURL);
    }

    [MenuItem("Google Play Games/Downloads/Google+ SDK (iOS)...", false, 200)]
    public static void MenuItemGooglePlusSdk() {
        EditorUtility.DisplayDialog(GPGSStrings.ExternalLinks.GooglePlusSdkTitle,
            GPGSStrings.ExternalLinks.GooglePlusSdkBlurb, GPGSStrings.Ok);
        Application.OpenURL(GPGSStrings.ExternalLinks.GooglePlusSdkUrl);
    }

    [MenuItem("Google Play Games/Downloads/Google Play Games SDK (iOS)...", false, 201)]
    public static void MenuItemGooglePlayGamesSdk() {
        EditorUtility.DisplayDialog(GPGSStrings.ExternalLinks.GooglePlayGamesSdkTitle,
            GPGSStrings.ExternalLinks.GooglePlayGamesSdkBlurb, GPGSStrings.Ok);
        Application.OpenURL(GPGSStrings.ExternalLinks.GooglePlayGamesUrl);
    }

    [MenuItem("Google Play Games/Downloads/Google Play Games SDK (Android)...", false, 203)]
    public static void MenuItemGooglePlayGamesAndroidSdk() {
        // check that Android SDK is there
        string sdkPath = GPGSUtil.GetAndroidSdkPath();
        if (!GPGSUtil.HasAndroidSdk()) {
            EditorUtility.DisplayDialog(GPGSStrings.AndroidSetup.SdkNotFound,
                GPGSStrings.AndroidSetup.SdkNotFoundBlurb, GPGSStrings.Ok);
            return;
        }

        bool launch = EditorUtility.DisplayDialog(
                          GPGSStrings.ExternalLinks.GooglePlayGamesAndroidSdkTitle,
                          GPGSStrings.ExternalLinks.GooglePlayGamesAndroidSdkBlurb, GPGSStrings.Yes,
                          GPGSStrings.No);
        if (launch) {
            string exeName =
                sdkPath + GPGSUtil.SlashesToPlatformSeparator("/tools/android");
            string altExeName =
                sdkPath + GPGSUtil.SlashesToPlatformSeparator("/tools/android.exe");

            EditorUtility.DisplayDialog(
                GPGSStrings.ExternalLinks.GooglePlayGamesAndroidSdkTitle,
                GPGSStrings.ExternalLinks.GooglePlayGamesAndroidSdkInstructions,
                GPGSStrings.Ok);

            if (System.IO.File.Exists(exeName)) {
                System.Diagnostics.Process.Start(exeName);
            } else if (System.IO.File.Exists(altExeName)) {
                System.Diagnostics.Process.Start(altExeName);
            } else {
                EditorUtility.DisplayDialog(
                    GPGSStrings.ExternalLinks.GooglePlayGamesSdkTitle,
                    GPGSStrings.ExternalLinks.GooglePlayGamesAndroidSdkManagerFailed,
                    GPGSStrings.Ok);
            }
        }
    }

    [MenuItem("Google Play Games/About/About the Plugin...", false, 300)]
    public static void MenuItemAbout() {
        EditorUtility.DisplayDialog(GPGSStrings.AboutTitle, GPGSStrings.AboutText +
        GooglePlayGames.PluginVersion.VersionString + " (" +
        string.Format("0x{0:X8}", GooglePlayGames.PluginVersion.VersionInt) + ")",
            GPGSStrings.Ok);
    }

    [MenuItem("Google Play Games/About/License...", false, 301)]
    public static void MenuItemLicense() {
        EditorUtility.DisplayDialog(GPGSStrings.LicenseTitle, GPGSStrings.LicenseText,
            GPGSStrings.Ok);
    }
}
