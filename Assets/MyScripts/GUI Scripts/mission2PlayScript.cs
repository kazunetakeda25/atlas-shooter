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

public class mission2PlayScript : MonoBehaviour {


	public GUIStyle textGUIStyle;
	public GameObject lock_m2;
	static public bool m2 = true;
	public string m2_on;
	public bool clicked;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (clicked)
		{
			Invoke("finishSms", 3f);
		}
	}

	public void OnClick()
	{
		clicked = true;
		if (PlayerPrefs.GetString("m2_on") == "true")
		{
			lock_m2.SetActive(false);
			m2 = true;
			Application.LoadLevel("Scene2");
		}
		else if (PlayerPrefs.GetString("m2_on") == "false")
		{
			lock_m2.SetActive(true);
			m2 = false;

		}

	}

	public void OnGUI()
	{
		if (m2 == false)
		{
			GUI.Label(new Rect(350f, 250f, Screen.width*0.275f, Screen.height*.100f),"Complete the MISSION 1 to play it!" ,textGUIStyle);
		}
	}

	public void finishSms()
	{
		m2 = true;

	}
}
