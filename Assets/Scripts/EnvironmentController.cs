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

public class EnvironmentController : MonoBehaviour {
public	GameObject Evn1;
public	GameObject Env2;
public  GameObject point1;
public  GameObject point2;
	bool contEnv;
	public float xPos=-4343f;
	// Use this for initialization
	void Start () {
		contEnv = false;
		Debug.Log("dsdsdsfdsfdsf"+Application.loadedLevelName);
	}
	// Change random environment
	public void ChangeEnv()
	{
		if (Application.loadedLevelName=="Scene12") {
			if (contEnv == false) {
				contEnv = true;
				Evn1.transform.localPosition = new Vector3 (xPos, -30f, Env2.transform.localPosition.z + 21327.98f);
			} else {
				contEnv = false;	
				Env2.transform.localPosition = new Vector3 (xPos, -30f, Evn1.transform.localPosition.z + 21327.98f);
				Debug.Log ("one");
			}   


		} 
		
		else {
			if (contEnv == false) {
								contEnv = true;
								Evn1.transform.localPosition = new Vector3 (xPos, -30f, Env2.transform.localPosition.z + 60000.98f);
						} else {
								contEnv = false;	
								Env2.transform.localPosition = new Vector3 (xPos, -30f, Evn1.transform.localPosition.z + 35000.98f);
								Debug.Log ("one");
						}   
			}
		}
}
