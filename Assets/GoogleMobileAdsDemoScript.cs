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
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class GoogleMobileAdsDemoHandler : IDefaultInAppPurchaseProcessor
{
    private readonly string[] validSkus = { "android.test.purchased" };

    //Will only be sent on a success.
    public void ProcessCompletedInAppPurchase(IInAppPurchaseResult result)
    {
        result.FinishPurchase();
        GoogleMobileAdsDemoScript.OutputMessage = "Purchase Succeeded! Credit user here.";
    }

    //Check SKU against valid SKUs.
    public bool IsValidPurchase(string sku)
    {
        foreach(string validSku in validSkus)
        {
            if (sku == validSku)
            {
                return true;
            }
        }
        return false;
    }

    //Return the app's public key.
    public string AndroidPublicKey
    {
        //In a real app, return public key instead of null.
        get { return null; }
    }
}

// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class GoogleMobileAdsDemoScript : MonoBehaviour
{

    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;
    private float deltaTime = 0.0f;
    private static string outputMessage = "";
	public bool onceBanner=false;
    public static string OutputMessage
    {
        set { outputMessage = value; }
    }


	void Awake(){

		if (onceBanner) {
			onceBanner=false;
			RequestBanner();
			bannerView.Show();
		}

	}

    void Start()
    {
		RequestInterstitial();
        // Get singleton reward based video ad reference.
        rewardBasedVideo = RewardBasedVideoAd.Instance;

        // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
    }

    void Update()
    {
        // Calculate simple moving average for time to render screen. 0.1 factor used as smoothing
        // value.
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

//    void OnGUI()
//    {
//        GUIStyle style = new GUIStyle();
//
//        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
//        style.alignment = TextAnchor.LowerRight;
//        style.fontSize = (int)(Screen.height * 0.06);
//        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
//        float fps = 1.0f / deltaTime;
//        string text = string.Format("{0:0.} fps", fps);
//        GUI.Label(rect, text, style);
//
//        // Puts some basic buttons onto the screen.
//        GUI.skin.button.fontSize = (int)(0.03f * Screen.height);
//
//        Rect requestBannerRect = new Rect(0.1f * Screen.width, 0.05f * Screen.height,
//                                     0.8f * Screen.width, 0.1f * Screen.height);
//        if (GUI.Button(requestBannerRect, "Request Banner"))
//        {
//            RequestBanner();
//        }
//
//        Rect showBannerRect = new Rect(0.1f * Screen.width, 0.175f * Screen.height,
//                                  0.8f * Screen.width, 0.1f * Screen.height);
//        if (GUI.Button(showBannerRect, "Show Banner"))
//        {
//            bannerView.Show();
//        }
//
//        Rect destroyBannerRect = new Rect(0.1f * Screen.width, 0.3f * Screen.height,
//                                     0.8f * Screen.width, 0.1f * Screen.height);
//        if (GUI.Button(destroyBannerRect, "Destroy Banner"))
//        {
//            bannerView.Destroy();
//        }
//
//        Rect requestInterstitialRect = new Rect(0.1f * Screen.width, 0.425f * Screen.height,
//                                           0.8f * Screen.width, 0.1f * Screen.height);
//        if (GUI.Button(requestInterstitialRect, "Request Interstitial"))
//        {
//            RequestInterstitial();
//        }
//
//        Rect showInterstitialRect = new Rect(0.1f * Screen.width, 0.55f * Screen.height,
//                                        0.8f * Screen.width, 0.1f * Screen.height);
//        if (GUI.Button(showInterstitialRect, "Show Interstitial"))
//        {
//            ShowInterstitial();
//        }
//
//        Rect requestRewardedRect = new Rect(0.1f * Screen.width, 0.675f * Screen.height,
//                                       0.8f * Screen.width, 0.1f * Screen.height);
//        if (GUI.Button(requestRewardedRect, "Request Rewarded Video"))
//        {
//            RequestRewardBasedVideo();
//        }
//
//        Rect showRewardedRect = new Rect(0.1f * Screen.width, 0.8f * Screen.height,
//                                    0.8f * Screen.width, 0.1f * Screen.height);
//        if (GUI.Button(showRewardedRect, "Show Rewarded Video"))
//        {
//            ShowRewardBasedVideo();
//        }
//
//        Rect textOutputRect = new Rect(0.1f * Screen.width, 0.925f * Screen.height,
//                                  0.8f * Screen.width, 0.05f * Screen.height);
//        GUI.Label(textOutputRect, outputMessage);
//    }

    private void RequestBanner()
    {
        #if UNITY_EDITOR
            string adUnitId = "unused";
        #elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-9149670982211224/8155661595";
        #elif UNITY_IPHONE
            string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
        // Register for ad events.
        bannerView.OnAdLoaded += HandleAdLoaded;
        bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
        bannerView.OnAdLoaded += HandleAdOpened;
        bannerView.OnAdClosed += HandleAdClosed;
        bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
        // Load a banner ad.
        bannerView.LoadAd(createAdRequest());
    }

    private void RequestInterstitial()
    {
        #if UNITY_EDITOR
            string adUnitId = "unused";
        #elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-9149670982211224/1558044793";
        #elif UNITY_IPHONE
            string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create an interstitial.
        interstitial = new InterstitialAd(adUnitId);
        // Register for ad events.
        interstitial.OnAdLoaded += HandleInterstitialLoaded;
        interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
        interstitial.OnAdOpening += HandleInterstitialOpened;
        interstitial.OnAdClosed += HandleInterstitialClosed;
        interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;
        // Load an interstitial ad.
        interstitial.LoadAd(createAdRequest());
    }

    // Returns an ad request with custom ad targeting.
    private AdRequest createAdRequest()
    {
        return new AdRequest.Builder()
                .AddTestDevice(AdRequest.TestDeviceSimulator)
                .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
                .AddKeyword("game")
                .SetGender(Gender.Male)
                .SetBirthday(new DateTime(1985, 1, 1))
                .TagForChildDirectedTreatment(false)
                .AddExtra("color_bg", "9B30FF")
                .Build();
    }

    private void RequestRewardBasedVideo()
    {
        #if UNITY_EDITOR
            string adUnitId = "unused";
        #elif UNITY_ANDROID
            string adUnitId = "INSERT_ANDROID_REWARD_BASED_VIDEO_AD_UNIT_ID_HERE";
        #elif UNITY_IPHONE
            string adUnitId = "INSERT_IOS_REWARD_BASED_VIDEO_AD_UNIT_ID_HERE";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        rewardBasedVideo.LoadAd(createAdRequest(), adUnitId);
    }

    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
			Invoke("RequestInterstitial",5);
        }
        else
        {
            print("Interstitial is not ready yet.");
        }
    }

    private void ShowRewardBasedVideo()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        } else
        {
            print("Reward based video ad is not ready yet.");
        }
    }

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        print("HandleAdLoaded event received.");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        print("HandleAdOpened event received");
    }

    void HandleAdClosing(object sender, EventArgs args)
    {
        print("HandleAdClosing event received");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        print("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        print("HandleAdLeftApplication event received");
    }

    #endregion

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        print("HandleInterstitialLoaded event received.");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        print("HandleInterstitialOpened event received");
    }

    void HandleInterstitialClosing(object sender, EventArgs args)
    {
        print("HandleInterstitialClosing event received");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        print("HandleInterstitialClosed event received");
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        print("HandleInterstitialLeftApplication event received");
    }

    #endregion

    #region RewardBasedVideo callback handlers

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoLoaded event received.");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        print("HandleRewardBasedVideoRewarded event received for " + amount.ToString() + " " +
                type);
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        print("HandleRewardBasedVideoLeftApplication event received");
    }

    #endregion
}
