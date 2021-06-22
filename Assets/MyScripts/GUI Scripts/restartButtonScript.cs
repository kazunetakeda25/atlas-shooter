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

public class restartButtonScript : MonoBehaviour {
	
	public GameObject pauseButton;
	public GameObject pauseButtonCamera;
	public GameObject pauseMenu;
	public GameObject loading;

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
//		manager.HideChartboostInterstitial();
//		manager.HideHeyzapInterstitial();
//		manager.HideBanner();

		PlayerHelthScript.pausemenuVisible = true;
		pauseMenu.SetActive(false);
		loading.SetActive(true);
		Application.LoadLevel(Application.loadedLevel);
		Time.timeScale = 1;
		pauseButton.SetActive(true);
		pauseButtonCamera.SetActive(true);
		PlayerHelthScript.EnemyKilledScore = 0;
		//PlayerHelthScript.health_ScoreVisible = true;
	}
}
