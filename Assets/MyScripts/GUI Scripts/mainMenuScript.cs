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

public class mainMenuScript : MonoBehaviour 
{
	public GameObject soundOFF;
	public GameObject soundON;
	public GameObject more_Button;
	public GameObject shre_Button;
	public GameObject playButton;
	public GameObject quitMenu;
	public GameObject level_window_show;
	static public bool quitmenuVisible = true;
	static public bool gameSound = true;
	public GameObject mainmenu;
	public GameObject missionsSelectionMenu;



	// Use this for initialization
	void Start () 
	{
		Invoke ("adsM",0);
//		AdsManager manager = AdsManager.SharedObject();
//		manager.ShowAdmobInterstitial ();
//		manager.ShowBanner ();

	}




	// Update is called once per frame
	void Update () 
	{
		if (gameSound == true)
		{
			if (!quitmenuVisible)
			{
				QuitsoundOFFController();
			}
			else
			{
				soundON.SetActive(true);
				soundOFF.SetActive(false);
				AudioListener.volume = 1;
			}

		}
		else if (gameSound == false)
		{
			if (!quitmenuVisible)
			{
				QuitsoundOFFController();
			}
			else
			{
				soundON.SetActive(false);
				soundOFF.SetActive(true);
				AudioListener.volume = 0;
			}

		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (quitmenuVisible)
			{
				print ("Start " + quitmenuVisible);
				more_Button.SetActive(false);
				shre_Button.SetActive(false);
				playButton.SetActive(false);
				quitMenu.SetActive(true);
				quitmenuVisible = false;
				print ("End " + quitmenuVisible);
			}
			else 
			{
				print ("Else Start " + quitmenuVisible);
				Time.timeScale = 1;
				more_Button.SetActive(true);
				shre_Button.SetActive(true);
				playButton.SetActive(true);
				quitMenu.SetActive(false);
				quitmenuVisible = true;
				print ("Else End " + quitmenuVisible);
			}
			
		}
		if(menuButtonScript.level_window==true){

			missionsSelectionMenu.SetActive(true);
			mainmenu.SetActive(false);

		}

	}
	public void adsM(){
//		AdsManager manager = AdsManager.SharedObject();
//		manager.ShowAdmobInterstitial ();
//		manager.ShowBanner ();
	}
	public void soundOFFController()
	{
		soundOFF.SetActive(true);
		soundON.SetActive(false);
	}

	public void soundONController()
	{
		soundON.SetActive(true);
		soundOFF.SetActive(false);
	}

	public void QuitsoundONController()
	{
		soundON.SetActive(true);
		soundOFF.SetActive(true);
	}

	public void QuitsoundOFFController()
	{
		soundON.SetActive(false);
		soundOFF.SetActive(false);
		AudioListener.volume = 0;
	}


}
