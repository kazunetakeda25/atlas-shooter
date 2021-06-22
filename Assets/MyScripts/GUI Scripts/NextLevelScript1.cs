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

public class NextLevelScript1 : MonoBehaviour {

	public GameObject pauseButton;
	public GameObject pauseButtonCamera;
	public GameObject levelMenu;
	public GameObject bnda;
	public AS_Bullet bndascript;
	public GameObject loading;
	public string m2_on;
	private int holder;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnClick()
	{
//		AdsManager manager = AdsManager.SharedObject();
//		manager.HideLeadboltInterstitial() ;
//		manager.HideBanner();
		if (UIcontroller.SelectedRegion == 1) {
			//holder=Application.loadedLevel;
			//if(holder==2){
		PlayerPrefs.SetString("m2_on" , "true");
			//}
		PlayerPrefs.SetString("m3_on" , "true");
		}
		levelMenu.SetActive(false);
		AS_Bullet.killedEnemies = 0;
		loading.SetActive(true);
		Application.LoadLevel("Scene3");

		Time.timeScale = 1;
		pauseButton.SetActive(true);
		pauseButtonCamera.SetActive(true);

		if (UIcontroller.SelectedRegion == 2) {
			holder=Application.loadedLevel;
			PlayerPrefs.SetInt ("Unlock2",holder);//unlocked 2d mission		
		}


	}
}
