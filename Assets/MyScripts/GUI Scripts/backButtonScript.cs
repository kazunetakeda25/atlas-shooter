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

public class backButtonScript : MonoBehaviour 
{
	
	public GameObject mainmenu;
	public GameObject missionsSelectionMenu;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void OnClick()
	{
		//Invoke ("DelayAnim", 1.4f);
		DelayAnim ();
	}

	private void DelayAnim(){
		//restartButton.SetActive(false);
		PlayerHelthScript.pausemenuVisible = true;
		if (mainMenuScript.gameSound == true)
		{
			AudioListener.volume = 1;
		}
		else if (mainMenuScript.gameSound == false)
		{
			AudioListener.volume = 0;
		}
		mainmenu.SetActive(true);
		missionsSelectionMenu.SetActive(false);
		//		loading.SetActive(true);
		//		Time.timeScale = 1;
		//		Application.LoadLevel("Scene1");

	}
}
