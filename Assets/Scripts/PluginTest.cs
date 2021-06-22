/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;

public class PluginTest : MonoBehaviour
{
	// Use this for initialization
	void Awake()
	{
//		AdsManager manager = AdsManager.SharedObject();
//
//		manager.SetTestAdDelay(2f);
//		manager.DisableTestMode ();
//		manager.DisableLogger ();
//		manager.showBannerAtTop = false;
//
//		manager.admobBannerID = "ca-app-pub-/8722107606";
//		manager.admobIntertitialID = "ca-app-pub-1198840806";
//		manager.ChartboostAppID = "54ba3150f2e792c3305";
//		manager.ChartboostAppSignature = "35c30c11e29bf2bba6695a2037ec049edf0cd47e";
//		manager.LeadboltApiKey = "KeywSH4jfTPCG5bGdeLSDsxtJO";
//		manager.HeyzapPublisherID = "c1bb1a63df44f8d0503c77bfc1";
//		manager.AdBuddizPublisherKey = "8eb87b6f-27e6-4dae-adc4-ee09c060ac1d";
//		manager.StartAppID = "211668";
//		manager.StartAppDeveloperID = "111010";
//
//		manager.Initialize();
//
//		manager.ShowBanner ();

		Time.timeScale = 0;
	}

	private bool showingBanner = false;
	void OnGUI ()
	{
		if(GUI.Button(new Rect(0,60+Screen.height*0.01f+Screen.height*0.1f*0,Screen.width,Screen.height*0.1f),"Show Admob Interstitial"))
		//	AdsManager.SharedObject().ShowAdmobInterstitial();

		if(GUI.Button(new Rect(0,60+Screen.height*0.02f+Screen.height*0.1f*1,Screen.width,Screen.height*0.1f),"Show Chartboost Interstitial"))
			//AdsManager.SharedObject().ShowChartboostInterstitial();
	
		if(GUI.Button(new Rect(0,60+Screen.height*0.03f+Screen.height*0.1f*2,Screen.width,Screen.height*0.1f),"Show Heyzap Interstitial"))
			//AdsManager.SharedObject().ShowHeyzapInterstitial();
	
		if(GUI.Button(new Rect(0,60+Screen.height*0.04f+Screen.height*0.1f*3,Screen.width,Screen.height*0.1f),"Show Leadbolt Interstitial"))
		//	AdsManager.SharedObject().ShowLeadboltInterstitial();
	
		if(GUI.Button(new Rect(0,60+Screen.height*0.05f+Screen.height*0.1f*4,Screen.width,Screen.height*0.1f),"Show StartApp Interstitial"))
		//	AdsManager.SharedObject().ShowStartAppInterstitial();
	
		if(GUI.Button(new Rect(0,60+Screen.height*0.06f+Screen.height*0.1f*5,Screen.width,Screen.height*0.1f),"Show AdBuddiz Interstitial"))
		//	AdsManager.SharedObject().ShowAdBuddizInterstitial();

		if(showingBanner)
		{
			if(GUI.Button(new Rect(0,60+Screen.height*0.07f+Screen.height*0.1f*6,Screen.width,Screen.height*0.1f),"Hide Admob Banner"))
			{
				showingBanner = false;
				//AdsManager.SharedObject().HideBanner();
			}
		}
		else
		{
			if(GUI.Button(new Rect(0,60+Screen.height*0.07f+Screen.height*0.1f*6,Screen.width,Screen.height*0.1f),"Show Admob Banner"))
			{
				showingBanner = true;
				//AdsManager.SharedObject().ShowBanner();
			}
		}
	}
}
