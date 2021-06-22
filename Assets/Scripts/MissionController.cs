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

public class MissionController : MonoBehaviour {
	public GameObject Envir1;
	public GameObject Envir2;
	public Material desert;
	GameObject player;
	// Use this for initialization
	void Start () {
		player= GameObject.Find ("GameObject (For WayPoint)");
		MissionSelection ();
		//UIcontroller.SelectedRegion = 2;/// <summary> testing on
		/// M//////////////////////////////////////////////////////////////////////////////////////////
		///////////testing/// </summary>
	}
	void MissionSelection(){

		if (UIcontroller.SelectedRegion == 1) {//Navy Mission
			Envir1.SetActive(true);
			//player.GetComponent<hoMove>().enabled=true;
			Debug.Log("panga hai");
		//	Instantiate(Envir1,Envir1.transform.position,Envir1.transform.rotation);
				} else {// mission Train
			//Instantiate(Envir2,Envir1.transform.position,Envir1.transform.rotation);
			//Envir1.SetActive(false);
			Envir2.SetActive(true);
			player.GetComponent<AudioSource>().enabled=true;
			RenderSettings.skybox=desert;
			//player.GetComponent<Movements>().enabled=true;
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
