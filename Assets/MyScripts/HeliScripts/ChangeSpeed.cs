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

public class ChangeSpeed : MonoBehaviour 
{
	public GameObject heli;
	public hoMove script;
//	public GameObject ;
	public static float attackDist=50f;
	public Transform target,FirstStop ,SecondStop ,ThirdStop;
	public Transform Player;
	public hoMove speedcontroller ;
	void Start(){
		Player = GameObject.Find("Player").transform;
		PlayerHelthScript.pausemenuVisible = true;
	}
	void Update (){
		speedcontroller=GameObject.Find ("GameObject (For WayPoint)").GetComponent<hoMove> ();
		if(Application.loadedLevelName=="Scene1"){
			if (Vector3.Distance(Player.position, FirstStop.position) <= 20)
			{	

				//speedcontroller.ChangeSpeed(0.01f);


			}
		}
	
	}
//	void helispeedchange()
//	{
//		if (Application.loadedLevelName == "Scene1")
//		{
//			script.ChangeSpeed(30f);
//		}
//		else if (Application.loadedLevelName == "Scene2")
//		{
//			script.ChangeSpeed(30f);
//		}
//		else if (Application.loadedLevelName == "Scene3")
//		{
//			script.ChangeSpeed(30f);
//		}
//
//		if (mainMenuScript.gameSound == true)
//		{
//			AudioListener.volume = 1;
//		}
//	}
//
//	void helispeedchangeAgain()
//	{
//		
//		script.ChangeSpeed(30f);
//		if (mainMenuScript.gameSound == true)
//		{
//			AudioListener.volume = 1;
//		}
//	}
//
//
//	public void rotateHeli()
//	{
//
//		if (mainMenuScript.gameSound == true)
//		{
//			AudioListener.volume = 1;
//		}
//
//	}
//

}


