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

public class UIcontroller : MonoBehaviour {
	public static int SelectedRegion=1;
	public GameObject levelSelect;
	public GameObject selectionPanel;
	public GameObject region1;
	public GameObject region2;
	public GameObject Gunselection;
	public GameObject MianGUi;
	public GameObject uiThree;

	// Use this for initialization
	void Start () {
		SelectedRegion=1;// bydefault region is 1
	}
	void Region1(){
		SelectedRegion=1;
		//levelSelect.SetActive (true);
		region1.SetActive (true);
		region2.SetActive (false);

	}
	void Region2(){
		SelectedRegion=2;
		//levelSelect.SetActive (true);
		region1.SetActive (false);
		region2.SetActive (true);
		GameObject.Find ("MissionSelectionMenu").SendMessage ("Mission2Work");
	}

	void HideSelection(){
		selectionPanel.SetActive (false);
	}
	void ShowSelection(){
		levelSelect.SetActive (true);
	}

	void ReverseAnim(){
//		GameObject g1= GameObject.Find ("Navy");
//		g1.GetComponent<Animator> ().SetBool ("one", true);
//		GameObject g2= GameObject.Find ("City");
//		g2.GetComponent<Animator> ().SetBool ("two", true);
//		GameObject g3= GameObject.Find ("Train");
//		g3.GetComponent<Animator> ().SetBool ("three", true);


	}

	void ShowWeapons(){

		selectionPanel.SetActive (false);
		Gunselection.SetActive (true);
	}

	void HideWeapon(){
		MianGUi.SetActive (true);
		Gunselection.SetActive (false);

	}
	void CallUi3(){
		uiThree.SetActive (true);
		selectionPanel.SetActive (false);
	}
	// Update is called once per frame
	void Update () {

	
	}
}
