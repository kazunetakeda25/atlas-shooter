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

public class NoButtonScript : MonoBehaviour {

	public GameObject quitMenu;
	public GameObject mainMenu;
	public GameObject soundON;
	public GameObject soundOFF;
	public GameObject playButton;
	public GameObject more_Button,share_Button;
	public mainMenuScript menuScript;
	public GameObject me;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick()
	{
		quitMenu.SetActive(false);
		mainMenu.SetActive(true);
		playButton.SetActive(true);
		more_Button.SetActive(true);
		share_Button.SetActive(true);
		mainMenuScript.quitmenuVisible = true;

		if (mainMenuScript.gameSound == true)
		{
			if ((mainMenuScript.quitmenuVisible))
			{
			//	print ("No Button Start " + mainMenuScript.quitmenuVisible);
			}
			else
			{
			//	print ("No Button Start Else " + mainMenuScript.quitmenuVisible);
				soundON.SetActive(true);
				soundOFF.SetActive(false);
				AudioListener.volume = 1;
			}

		}
		else if (mainMenuScript.gameSound == false)
		{
			if ((mainMenuScript.quitmenuVisible))
			{
			//	print ("No Button Else Start " + mainMenuScript.quitmenuVisible);
			}
			else
			{
			//	print ("No Button Else Else " + mainMenuScript.quitmenuVisible);
				soundON.SetActive(false);
				soundOFF.SetActive(true);
				AudioListener.volume = 0;
			}
		}
		me.SetActive (true);
	}
}
