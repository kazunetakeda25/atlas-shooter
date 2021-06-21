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
using System.Collections;
using System.Runtime.InteropServices;


namespace ChartboostSDK
{
	public class CBInPlay {

		#if UNITY_IPHONE
		// Extern functions
		[DllImport("__Internal")]
		private static extern void _chartBoostInPlayClick(IntPtr uniqueID);
		[DllImport("__Internal")]
		private static extern void _chartBoostInPlayShow(IntPtr uniqueID);
		[DllImport("__Internal")]
		private static extern IntPtr _chartBoostInPlayGetAppIcon(IntPtr uniqueID);
		[DllImport("__Internal")]
		private static extern int _chartBoostInPlayGetAppIconSize(IntPtr uniqueID);
		[DllImport("__Internal")]
		private static extern string _chartBoostInPlayGetAppName(IntPtr uniqueID);
		[DllImport("__Internal")]
		private static extern void _chartBoostFreeInPlayObject(IntPtr uniqueID);
		#endif
		// Class variables
		public Texture2D appIcon;
		public string appName;
		private IntPtr inPlayUniqueId;
		
		//Class functions
		#if UNITY_IPHONE
		public CBInPlay(IntPtr uniqueId) {
			// Set ID and get the appName and appIcon
			inPlayUniqueId = uniqueId;

			setAppName();
			setAppIcon();
		}

		private void setAppName() {
			appName = _chartBoostInPlayGetAppName(inPlayUniqueId);
		}

		private void setAppIcon() {
			int appIconSize = _chartBoostInPlayGetAppIconSize(inPlayUniqueId);

			IntPtr appIconPtr = _chartBoostInPlayGetAppIcon(inPlayUniqueId);
			byte[] appIconByteArray = new byte[appIconSize];
			Marshal.Copy(appIconPtr, appIconByteArray, 0, appIconSize);
			
			// Create the texture from the byteArray
			appIcon = new Texture2D(4, 4);
			appIcon.LoadImage(appIconByteArray);
		}
		#elif UNITY_ANDROID
		
		private AndroidJavaObject androidInPlayAd;
		
		public CBInPlay(AndroidJavaObject inPlayAd, AndroidJavaObject plugin) {
			androidInPlayAd = inPlayAd;
			// Set the app name and create appIcon texture
			appName = androidInPlayAd.Call<String>("getAppName");
			string appIconString = plugin.Call<String> ("getBitmapAsString", androidInPlayAd.Call<AndroidJavaObject> ("getAppIcon"));
			appIcon = new Texture2D (4, 4);
			appIcon.LoadImage(Convert.FromBase64String(appIconString));
		}
		#endif	
		public void show() {
			#if UNITY_IPHONE
			_chartBoostInPlayShow(inPlayUniqueId);
			#elif UNITY_ANDROID
			androidInPlayAd.Call ("show");
			#endif
		}
		public void click() {
			#if UNITY_IPHONE
			_chartBoostInPlayClick(inPlayUniqueId);
			#elif UNITY_ANDROID
			androidInPlayAd.Call ("click");
			#endif
		}
		~CBInPlay() {
			#if UNITY_IPHONE
			_chartBoostFreeInPlayObject(inPlayUniqueId);
			#endif
		}
	}
}

