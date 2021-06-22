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

public class EnvironmentController3 : MonoBehaviour {
	public GameObject [] leve2;
	public GameObject [] leve3;
	public GameObject [] leve4;
	public GameObject [] leve5;
	public GameObject [] leve6;
	public GameObject [] leve7;
	public GameObject [] leve8;
	public GameObject [] leve9;
	public GameObject [] leve10;
	public GameObject [] leve11;
	public GameObject [] leve12;
	// Use this for initialization
	void Start () {

		//CallLevel.selectedLevel3 = 8;// testing working here found
		SetPlayersData ();
	}

	void SetPlayersData(){
		switch( CallLevel.selectedLevel3-1){
		case 1:
			for (int i=0; i<leve2.Length; i++) {
				leve2[i].SetActive(true);
			}
			break;
		case 2:
					for (int i=0; i<leve3.Length; i++) {
						leve3[i].SetActive(true);
					}
		
			break;
		case 3:
					for (int i=0; i<leve4.Length; i++) {
						leve4[i].SetActive(true);
					}

			break;
		case 4:
			for (int i=0; i<leve5.Length; i++) {
				leve5[i].SetActive(true);
			}
		
			break;
		case 5:
			for (int i=0; i<leve6.Length; i++) {
				leve6[i].SetActive(true);
			}
		
			break;
		case 6:
			for (int i=0; i<leve7.Length; i++) {
				leve7[i].SetActive(true);
			}
		
			break;
		case 7:
			for (int i=0; i<leve8.Length; i++) {
				leve8[i].SetActive(true);
			}
		
			break;
		case 8:

			for (int i=0; i<leve9.Length; i++) {
				leve9[i].SetActive(true);
			}

			break;
		case 9:
			
			for (int i=0; i<leve10.Length; i++) {
				leve10[i].SetActive(true);
			}
			
			break;
		case 10:
			
			for (int i=0; i<leve11.Length; i++) {
				leve11[i].SetActive(true);
			}
			
			break;
		case 11:
			
			for (int i=0; i<leve12.Length; i++) {
				leve12[i].SetActive(true);
			}
			
			break;
			
		}





	}
	
	// Update is called once per frame
	void Update () {

	}
}
