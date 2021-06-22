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

public class lockedLevelScript : MonoBehaviour {

	 public GameObject mission1;
	 public GameObject mission2;
	 public GameObject mission3;
	 public GameObject mission4;
	 public GameObject mission5;
	 public GameObject mission6;
	 public GameObject mission7;
	 public GameObject mission8;
	 public GameObject mission9;
	 public GameObject mission10;
	 public GameObject mission11;
	 public GameObject mission12;
	 
	 public GameObject lock_m2;
	 public GameObject lock_m3;
	 public GameObject lock_m4;
	 public GameObject lock_m5;
	 public GameObject lock_m6;
	 public GameObject lock_m7;
	 public GameObject lock_m8;
	 public GameObject lock_m9;
	 public GameObject lock_m10;
	 public GameObject lock_m11;
	 public GameObject lock_m12;
	 public GameObject back_btn;

	public GameObject mainmenu;
	public GameObject missionsSelectionMenu;
	public GameObject  [] locks;
	
	// Use this for initialization
	void Start () 
	{
	
		mission2.SetActive(true);
		mission3.SetActive(true);
		mission4.SetActive(true);
		mission5.SetActive(true);
		mission6.SetActive(true);
		mission7.SetActive(true);
		mission8.SetActive(true);

		back_btn.SetActive(true);

		lock_m2.SetActive(true);
		lock_m3.SetActive(true);
		lock_m4.SetActive(true);
		lock_m5.SetActive(true);
		lock_m6.SetActive(true);
		lock_m7.SetActive(true);
		lock_m8.SetActive(true);
		menuButtonScript.level_window = false;
		// Level unlocking second region
		if (!PlayerPrefs.HasKey ("Unlock2")) {
			PlayerPrefs.SetInt ("Unlock2", 0);//unlocked 2d mission
		}
		//UIcontroller.SelectedRegion = 1;
		if (UIcontroller.SelectedRegion == 2) {
						Mission2Work ();
				}


//		PlayerPrefs.SetString ("m2_on", "false");
//		PlayerPrefs.SetString ("m3_on", "false");
//		PlayerPrefs.SetString ("m4_on", "false");
//		PlayerPrefs.SetString ("m5_on", "false");
//		PlayerPrefs.SetString ("m6_on", "false");
//		PlayerPrefs.SetString ("m7_on", "false");
//		PlayerPrefs.SetString ("m8_on", "false");
	}

	void Mission2Work(){

		lock_m2.SetActive(true);
		lock_m3.SetActive(true);
		lock_m4.SetActive(true);
		lock_m5.SetActive(true);
		lock_m6.SetActive(true);
		lock_m7.SetActive(true);
		lock_m8.SetActive(true);
		lock_m9.SetActive(true);
		lock_m10.SetActive(true);
		lock_m11.SetActive(true);
		lock_m12.SetActive(true);
		for (int i=0; i<PlayerPrefs.GetInt("Unlock2"); i++) {
			locks[i].SetActive(false);
			Debug.Log(i);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			
			missionsSelectionMenu.SetActive(false);
			mainmenu.SetActive(true);
		}

//		Debug.Log ("" + PlayerPrefs.GetInt ("Unlock2"));
		// For Region 1 Only
		if(UIcontroller.SelectedRegion==1){
		if (PlayerPrefs.GetString("m2_on") == "true")
		{
			lock_m2.SetActive(false);
		}
		else if (PlayerPrefs.GetString("m2_on") == "false")
		{
			lock_m2.SetActive(true);
		}
		if (PlayerPrefs.GetString("m3_on") == "true")
		{
			lock_m3.SetActive(false);
		}
		else if (PlayerPrefs.GetString("m3_on") == "false")
		{
			lock_m3.SetActive(true);
		}
		if (PlayerPrefs.GetString("m4_on") == "true")
		{
			lock_m4.SetActive(false);
		}
		else if (PlayerPrefs.GetString("m4_on") == "false")
		{
			lock_m4.SetActive(true);
		}
		if (PlayerPrefs.GetString("m5_on") == "true")
		{
			lock_m5.SetActive(false);
		}
		else if (PlayerPrefs.GetString("m5_on") == "false")
		{
			lock_m5.SetActive(true);
		}
		if (PlayerPrefs.GetString("m6_on") == "true")
		{
			lock_m6.SetActive(false);
		}
		else if (PlayerPrefs.GetString("m6_on") == "false")
		{
			lock_m6.SetActive(true);
		}
		if (PlayerPrefs.GetString("m7_on") == "true")
		{
			lock_m7.SetActive(false);
		}
		else if (PlayerPrefs.GetString("m7_on") == "false")
		{
			lock_m7.SetActive(true);
		}
		if (PlayerPrefs.GetString("m8_on") == "true")
		{
			lock_m8.SetActive(false);
		}
		else if (PlayerPrefs.GetString("m8_on") == "false")
		{
			lock_m8.SetActive(true);
		}
		
		if (PlayerPrefs.GetString("m9_on") == "true")
		{
			lock_m9.SetActive(false);
		}
		else if (PlayerPrefs.GetString("m9_on") == "false")
		{
			lock_m9.SetActive(true);
		}
		if (PlayerPrefs.GetString("m10_on") == "true")
		{
			lock_m10.SetActive(false);
		}
		else if (PlayerPrefs.GetString("m10_on") == "false")
		{
			lock_m10.SetActive(true);
		}


			if (PlayerPrefs.GetString("m11_on") == "true")
		{
			lock_m11.SetActive(false);
		}
		else if (PlayerPrefs.GetString("m11_on") == "false")
		{
			lock_m11.SetActive(true);
		}

		if (PlayerPrefs.GetString("m12_on") == "true")
		{
			lock_m12.SetActive(false);
		}
		else if (PlayerPrefs.GetString("m12_on") == "false")
		{
			lock_m12.SetActive(true);
		}


		}



	}
}
