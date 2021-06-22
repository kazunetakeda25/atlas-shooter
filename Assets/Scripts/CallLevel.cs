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

public class CallLevel : MonoBehaviour {
	public static int unlockDetail3;
	public  GameObject[] level3locks;
	public static int selectedLevel3;
	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey ("Unlock3")) {
			PlayerPrefs.SetInt ("Unlock3", 1);		
				} else {
			unlockDetail3=PlayerPrefs.GetInt("Unlock3");
		}

		Unlock3 ();
	}
	void Load1(){
		//Application.LoadLevel("Scene1");
	}
	void Load2(){
		Application.LoadLevel("Scene2");
	}
	void Load3(){
		Application.LoadLevel("Scene3");
	}

	void Load4(){
		Application.LoadLevel("Scene4");
	}
	void Load5(){
		Application.LoadLevel("Scene5");
	}
	void Load6(){
		Application.LoadLevel("Scene6");
	}
	void Load7(){
		Application.LoadLevel("Scene7");
	}
	void Load8(){
		Application.LoadLevel("Scene8");
	}
	void Load9(){
		Application.LoadLevel("Scene9");
	}
	void Load10(){
		Application.LoadLevel("Scene10");
	}
	void Load11(){
		Application.LoadLevel("Scene11");
	}
	void Load13(){
		Application.LoadLevel("Scene13");
	}

	void Unlock3(){
		if (unlockDetail3 >= 12||unlockDetail3 == 12) {
						unlockDetail3 = 12;
				}
						for (int i=0; i<unlockDetail3-1; i++) {
								level3locks [i].SetActive (false);
						}
				
	}
	void Load12(){
		Application.LoadLevel("Scene12");
	}
	// Level selected mission 3
	void SelectedLevel3_1(){
		selectedLevel3=1;
	}
	void SelectedLevel3_2(){
		selectedLevel3=2;
	}
	void SelectedLevel3_3(){
		selectedLevel3=3;
	}
	void SelectedLevel3_4(){
		selectedLevel3=4;
	}
	void SelectedLevel3_5(){
		selectedLevel3=5;
	}
	void SelectedLevel3_6(){
		selectedLevel3=6;
	}
	void SelectedLevel3_7(){
		selectedLevel3=7;
	}
	void SelectedLevel3_8(){
		selectedLevel3=8;
	}
	void SelectedLevel3_9(){
		selectedLevel3=9;
	}
	void SelectedLevel3_10(){
		selectedLevel3=10;
	}
	void SelectedLevel3_11(){
		selectedLevel3=11;
	}
	void SelectedLevel3_12(){
		selectedLevel3=12;
	}
	// Update is called once per frame
	void Update () {
//		Debug.Log (unlockDetail3);
	}
}
