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
using GooglePlayGames;

public class GPGSAndroidSetupUI : EditorWindow {
	string mAppId = "";
	
	[MenuItem("Google Play Games/Android Setup...", false, 0)]
	public static void MenuItemGPGSAndroidSetup() {
		EditorWindow.GetWindow(typeof(GPGSAndroidSetupUI));
	}
	
	[MenuItem("File/Play Games - Android setup...")]
	public static void MenuItemFileGPGSAndroidSetup() {
		EditorWindow.GetWindow(typeof(GPGSAndroidSetupUI));
	}
	
	void OnEnable() {
		mAppId = GPGSProjectSettings.Instance.Get("proj.AppId");
	}
	
	void OnGUI() {
		GUILayout.BeginArea(new Rect(20, 20, position.width - 40, position.height - 40));
		GUILayout.Label(GPGSStrings.AndroidSetup.Title, EditorStyles.boldLabel);
		GUILayout.Label(GPGSStrings.AndroidSetup.Blurb);
		GUILayout.Space(10);
		
		GUILayout.Label(GPGSStrings.Setup.AppId, EditorStyles.boldLabel);
		GUILayout.Label(GPGSStrings.Setup.AppIdBlurb);
		mAppId = EditorGUILayout.TextField(GPGSStrings.Setup.AppId, mAppId);
		
		GUILayout.Space(10);
		if (GUILayout.Button(GPGSStrings.Setup.SetupButton)) {
			DoSetup();
		}
		GUILayout.EndArea();
	}
	void DoSetup() {
		PerformSetup(mAppId);
	}
	
	public static void PerformSetup(string appId) {
		string sdkPath = GPGSUtil.GetAndroidSdkPath();
		string libProjPath = sdkPath +
			GPGSUtil.SlashesToPlatformSeparator(
				"/extras/google/google_play_services/libproject/google-play-services_lib");
		string libProjAM =
			libProjPath + GPGSUtil.SlashesToPlatformSeparator("/AndroidManifest.xml");
		string libProjDestDir = GPGSUtil.SlashesToPlatformSeparator(
			"Assets/Plugins/Android/google-play-services_lib");
		string projAM = GPGSUtil.SlashesToPlatformSeparator(
			"Assets/Plugins/Android/MainLibProj/AndroidManifest.xml");
		
		GPGSProjectSettings.Instance.Set("proj.AppId", appId);
		GPGSProjectSettings.Instance.Save();
		
		// check for valid app id
		if (!GPGSUtil.LooksLikeValidAppId(appId)) {
			GPGSUtil.Alert(GPGSStrings.Setup.AppIdError);
			return;
		}
		
		// check that Android SDK is there
		if (!GPGSUtil.HasAndroidSdk()) {
			Debug.LogError("Android SDK not found.");
			EditorUtility.DisplayDialog(GPGSStrings.AndroidSetup.SdkNotFound,
			                            GPGSStrings.AndroidSetup.SdkNotFoundBlurb, GPGSStrings.Ok);
			return;
		}
		
		// check that the Google Play Services lib project is there
		if (!System.IO.Directory.Exists(libProjPath) || !System.IO.File.Exists(libProjAM)) {
			Debug.LogError("Google Play Services lib project not found at: " + libProjPath);
			EditorUtility.DisplayDialog(GPGSStrings.AndroidSetup.LibProjNotFound,
			                            GPGSStrings.AndroidSetup.LibProjNotFoundBlurb, GPGSStrings.Ok);
			return;
		}
		
		string supportJarPath = sdkPath +
			GPGSUtil.SlashesToPlatformSeparator(
				"/extras/android/support/v4/android-support-v4.jar");
		string supportJarDest =
			GPGSUtil.SlashesToPlatformSeparator("Assets/Plugins/Android/android-support-v4.jar");
		
		if (!System.IO.File.Exists(supportJarPath)) {
			Debug.LogError("Android support library v4 not found at: " + supportJarPath);
			EditorUtility.DisplayDialog(GPGSStrings.AndroidSetup.SupportJarNotFound,
			                            GPGSStrings.AndroidSetup.SupportJarNotFoundBlurb, GPGSStrings.Ok);
			return;
		}
		
		// check lib project version
		if (!CheckAndWarnAboutGmsCoreVersion(libProjAM)) {
			return;
		}
		
		// create needed directories
		EnsureDirExists("Assets/Plugins");
		EnsureDirExists("Assets/Plugins/Android");
		
		// clear out the destination library project
		DeleteDirIfExists(libProjDestDir);
		
		// Clear out any stale version of the support jar.
		System.IO.File.Delete(supportJarDest);
		
		// Copy Google Play Services library
		FileUtil.CopyFileOrDirectory(libProjPath, libProjDestDir);
		
		// Copy Android Support Library
		FileUtil.CopyFileOrDirectory(supportJarPath, supportJarDest);
		
		// Generate AndroidManifest.xml
		string manifestBody = GPGSUtil.ReadEditorTemplate("template-AndroidManifest");
		manifestBody = manifestBody.Replace("___APP_ID___", appId);
		GPGSUtil.WriteFile(projAM, manifestBody);
		GPGSUtil.UpdateGameInfo();
		
		// refresh assets, and we're done
		AssetDatabase.Refresh();
		GPGSProjectSettings.Instance.Set("android.SetupDone", true);
		GPGSProjectSettings.Instance.Save();
		// if (!UnityEditorInternal.InternalEditorUtility.inBatchMode) {
		EditorUtility.DisplayDialog(GPGSStrings.Success,
		                            GPGSStrings.AndroidSetup.SetupComplete, GPGSStrings.Ok);
		// }
		// else {
		Debug.Log ("Android setup complete!");
		//}
	}
	
	private static bool CheckAndWarnAboutGmsCoreVersion(string libProjAMFile) {
		string manifestContents = GPGSUtil.ReadFile(libProjAMFile);
		string[] fields = manifestContents.Split('\"');
		int i;
		long vercode = 0;
		for(i = 0; i < fields.Length; i++) {
			if (fields[i].Contains("android:versionCode") && i + 1 < fields.Length) {
				vercode = System.Convert.ToInt64(fields[i + 1]);
			}
		}
		if (vercode == 0) {
			return EditorUtility.DisplayDialog(GPGSStrings.Warning, string.Format(
				GPGSStrings.AndroidSetup.LibProjVerNotFound,
				GooglePlayGames.PluginVersion.MinGmsCoreVersionCode),
			                                   GPGSStrings.Ok, GPGSStrings.Cancel);
		} else if (vercode < GooglePlayGames.PluginVersion.MinGmsCoreVersionCode) {
			return EditorUtility.DisplayDialog(GPGSStrings.Warning, string.Format(
				GPGSStrings.AndroidSetup.LibProjVerTooOld, vercode,
				GooglePlayGames.PluginVersion.MinGmsCoreVersionCode),
			                                   GPGSStrings.Ok, GPGSStrings.Cancel);
		}
		return true;
	}
	
	private static void EnsureDirExists(string dir) {
		dir = dir.Replace("/", System.IO.Path.DirectorySeparatorChar.ToString());
		if (!System.IO.Directory.Exists(dir)) {
			System.IO.Directory.CreateDirectory(dir);
		}
	}
	
	private static void DeleteDirIfExists(string dir) {
		if (System.IO.Directory.Exists(dir)) {
			System.IO.Directory.Delete(dir, true);
		}
	}
}
