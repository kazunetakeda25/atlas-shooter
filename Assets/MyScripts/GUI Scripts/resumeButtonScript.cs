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

public class resumeButtonScript : MonoBehaviour {
	
	public GameObject pauseButton;
	public GameObject pauseButtonCamera;
	public GameObject pauseMenu;
	public GameObject myPlayer;
	public ApnaController myPlayerScript;
	public PlayerHelthScript bndascript;
	public MouseLook mouseLookScript;
	// Use this for initialization
	void Start () {
		//pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnClick()
	{

//		AdsManager manager = AdsManager.SharedObject();
//		manager.HideHeyzapInterstitial();
//		manager.HideBanner();

		Time.timeScale = 1.0f;
		PlayerHelthScript.health_ScoreVisible = true;
		PlayerHelthScript.pausemenuVisible = true;
		pauseButton.SetActive(true);
		pauseButtonCamera.SetActive(true);
		myPlayerScript.enabled = true;
		mouseLookScript.enabled = true;
		pauseMenu.SetActive (false);

		if (mainMenuScript.gameSound == true)
		{
			AudioListener.volume = 1;
		}
	
		PlayerHelthScript.pausemenuVisible = true;

	}
	
}
