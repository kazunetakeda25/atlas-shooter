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

public class DummyTarget : MonoBehaviour {

	public GameObject Target;
	Vector3 positionTemp;
	Quaternion rotationTemp;
	float timeTemp;
	bool hited = false;
	
	void Start () {
		if(Target){
			positionTemp = Target.transform.position;
			rotationTemp = Target.transform.rotation;
		}
		timeTemp = Time.time;
	}
	

	void Update () {
		if(Target){
		if(!hited){
			if(Target.transform.rotation != rotationTemp){
				hited = true;
				timeTemp = Time.time;
			}
		}else{
			if(Time.time > timeTemp + (5 * Time.timeScale)){
				Target.transform.position = positionTemp;
				Target.transform.rotation = rotationTemp;
				hited = false;
			}	
		}
		}
	}
}
