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
using ChartboostSDK;
public class pauseButtonScript : MonoBehaviour {

	

	public GameObject pauseButtonCamera;
	public GameObject pauseButton;
	public GameObject pauseMenu;
	public GameObject myPlayer;
	public ApnaController myPlayerScript;
	public PlayerHelthScript bndascript;
	public MouseLook mouseLookScript;


	// Use this for initialization
	void Start () 
	{
		//pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnClick()
	{
//		AdsManager manager = AdsManager.SharedObject();
//		manager.ShowHeyzapInterstitial();
//		manager.ShowBanner ();

		Chartboost.showInterstitial(CBLocation.HomeScreen);


		PlayerHelthScript.health_ScoreVisible = false;
		PlayerHelthScript.pausemenuVisible = false;
		AudioListener.volume = 0;
		if (mainMenuScript.gameSound == true)
		{
			AudioListener.volume = 0.0f;
		}
		myPlayerScript.enabled = false;
		mouseLookScript.enabled = false;
		pauseButton.SetActive(false);
		pauseButtonCamera.SetActive(false);
		//bndascript.enabled = false;
		pauseMenu.SetActive(true);
		Time.timeScale = 0;
		if (mainMenuScript.gameSound == true)
		{
			AudioListener.volume = 0;
		}

		if (!PlayerHelthScript.pausemenuVisible)
		{
			print ("Pause Start " + PlayerHelthScript.pausemenuVisible);
			pauseButton.SetActive(false);
			pauseButtonCamera.SetActive(false);

			
		}
		else
		{
			print ("Pause Else " + PlayerHelthScript.pausemenuVisible);
			pauseButton.SetActive(true);
			pauseButtonCamera.SetActive(true);
		}
	}
}
