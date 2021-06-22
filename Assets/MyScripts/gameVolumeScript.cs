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

public class gameVolumeScript : MonoBehaviour {

	public Texture2D mission1;
	public Texture2D m1_objective;
	public bool check = true;
	public GUIStyle textGUIStyle;
	public Texture2D[] missionText3;
	// Use this for initialization
	void Start () 
	{
		PlayerHelthScript.health = 1000f;
//		CallLevel.selectedLevel3 = 2;// testing working here found
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (mainMenuScript.gameSound == true)
		{
			AudioListener.volume = 1;
		}
	}




	public void OnGUI(){
		//Debug.Log ("" + CallLevel.selectedLevel3);
		if (check)
		{
			if (Application.loadedLevelName == "Scene12")
			{
				switch( CallLevel.selectedLevel3){
				case 1:
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 7 enemies and destroy 1 Heli to complete the mission" ,textGUIStyle);
					GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), missionText3[0]);
					break;
				case 2:
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 10 enemies and destroy 1 Heli to complete the mission" ,textGUIStyle);
					GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), missionText3[1]);	
					break;
				case 3:
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 13 enemies and destroy 1 Heli to complete the mission" ,textGUIStyle);	
					GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), missionText3[2]);
					break;
				case 4:
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 15 enemies and destroy 1 Heli to complete the mission" ,textGUIStyle);	
					GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), missionText3[3]);
					break;
				case 5:
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 18 enemies and destroy 2 Heli to complete the mission" ,textGUIStyle);	
					GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), missionText3[4]);
					break;
				case 6:
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 21 enemies and destroy 2 Heli to complete the mission" ,textGUIStyle);	
					GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), missionText3[5]);
					break;
				case 7:
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 24 enemies and  destroy 2 Heli to complete  the mission" ,textGUIStyle);
					GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), missionText3[6]);
					break;
				case 8:
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 27 enemies and  destroy 2 Heli to complete the mission" ,textGUIStyle);
					GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), missionText3[7]);
					break;
				case 9:
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 28 enemies and destroy 2 Heli to complete the mission" ,textGUIStyle);
					GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), missionText3[8]);
					break;
				case 10:
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 29 enemies and destroy 2 Heli to complete the mission" ,textGUIStyle);
					GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), missionText3[9]);
					break;
				case 11:
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 30 enemies  and destroy 2 Heli to complete the mission" ,textGUIStyle);
					GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), missionText3[10]);
					break;
				case 12:
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 31 enemies  and destroy 2 Heli to complete the mission" ,textGUIStyle);
					GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), missionText3[11]);
					break;


				}


				}
				
				
				
				
				
		



			GUI.DrawTexture (new Rect (310f, 145f, Screen.width*0.400f, Screen.height*.100f), m1_objective);
			if (Application.loadedLevelName == "Scene1")
			{
				GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), mission1);
			if(UIcontroller.SelectedRegion == 1){
			GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 7 enemies on target ship and complete the mission" ,textGUIStyle);
			}
			else if(UIcontroller.SelectedRegion == 2){
			GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 7 enemies on train and complete the mission" ,textGUIStyle);
			}
			}//Region 1 and two
			else if (Application.loadedLevelName == "Scene2")
			{
				if(UIcontroller.SelectedRegion == 1){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 10 enemies on target ship and complete the mission" ,textGUIStyle);
				}
				else if(UIcontroller.SelectedRegion == 2){
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 10 enemies on train and complete the mission" ,textGUIStyle);
				}
				
			}//Region 1 and two

			else if (Application.loadedLevelName == "Scene3")
			{
				if(UIcontroller.SelectedRegion == 1){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 13 enemies on target ship and complete the mission" ,textGUIStyle);
				}
				else if(UIcontroller.SelectedRegion == 2){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 13 enemies on train and complete the mission" ,textGUIStyle);
				}

				}//region 1 and 2
			else if (Application.loadedLevelName == "Scene4")
			{
				if(UIcontroller.SelectedRegion == 1){
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 15 enemies on target ship and destroy 1 Heli to complete the mission" ,textGUIStyle);
				}
				else if(UIcontroller.SelectedRegion == 2){
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 15 enemies on train and destroy 1 Heli to complete the mission" ,textGUIStyle);
				}

				}//Region 1 and 2
			else if (Application.loadedLevelName == "Scene5")
			{
				if(UIcontroller.SelectedRegion == 1){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 18 enemies on target ship and complete the mission" ,textGUIStyle);
				}
				else if(UIcontroller.SelectedRegion == 2){
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 18 enemies on train and destroy 2 Heli complete the mission" ,textGUIStyle);
				}

			}//Region 1 and 2
			else if (Application.loadedLevelName == "Scene6")
			{
				if(UIcontroller.SelectedRegion == 1){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 21 enemies on target ship and complete the mission" ,textGUIStyle);
				}
				else if(UIcontroller.SelectedRegion == 2){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 21 enemies on train and destroy 2 Heli complete the mission" ,textGUIStyle);
				}

			}//Region 1 and 2
			else if (Application.loadedLevelName == "Scene7")
			{
				if(UIcontroller.SelectedRegion == 1){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 24 enemies on target ship and complete the mission" ,textGUIStyle);
				}
				else if(UIcontroller.SelectedRegion == 2){
					GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 24 enemies on train and destroy 2 Heli complete the mission" ,textGUIStyle);
				}

			}//Region 1 and 2
			else if (Application.loadedLevelName == "Scene8")
			{
				GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), mission1);
				if(UIcontroller.SelectedRegion == 1){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 27 enemies on target ship and complete the mission" ,textGUIStyle);
				}
				else if(UIcontroller.SelectedRegion == 2){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 27 enemies on train and destroy 2 Heli complete the mission" ,textGUIStyle);
				}

			}//Region 1 and 2
			else if (Application.loadedLevelName == "Scene9")
			{
				GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), mission1);
				if(UIcontroller.SelectedRegion == 1){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 28 enemies on target ship and complete the mission" ,textGUIStyle);
				}
				else if(UIcontroller.SelectedRegion == 2){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 28 enemies on train and destroy 2 Heli complete the mission" ,textGUIStyle);
				}

			}//Region 1 and 2
			else if (Application.loadedLevelName == "Scene10")
			{
				GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), mission1);
				if(UIcontroller.SelectedRegion == 1){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 29 enemies on target ship and complete the mission" ,textGUIStyle);
				}
				else if(UIcontroller.SelectedRegion == 2){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 29 enemies on train and destroy 2 Heli complete the mission" ,textGUIStyle);
				}

			}//Region 1 1nd 2
			else if (Application.loadedLevelName == "Scene11")
			{
				GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), mission1);
				if(UIcontroller.SelectedRegion == 1){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 30 enemies on target ship and complete the mission" ,textGUIStyle);
				}
				else if(UIcontroller.SelectedRegion == 2){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 30 enemies on train and destroy 2 Heli complete the mission" ,textGUIStyle);
				}

			}//Region 1 adn 2
			else if (Application.loadedLevelName == "Scene13")// For 12 Level
			{
				GUI.DrawTexture (new Rect (350f, 65f, Screen.width*0.325f, Screen.height*.100f), mission1);
				if(UIcontroller.SelectedRegion == 1){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 31 enemies on target ship and complete the mission" ,textGUIStyle);
				}
				else if(UIcontroller.SelectedRegion == 2){
				GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Kill 31 enemies on train and destroy 2 Heli complete the mission" ,textGUIStyle);
				}


			}//Region 1 and 2
		}
	}
}
