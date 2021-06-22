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

public class PointTheTarget : MonoBehaviour {
	public Transform model;  //Follow
	public Transform player;  //Target
	// Use this for initialization
	void Start () {
		if(Application.loadedLevelName == "Scene3"){
			if(GameObject.Find("HELI_POINTER")){
		player=	GameObject.Find("HELI_POINTER").transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "Scene3") {
			if (player != null)
				model.rotation = Quaternion.Slerp (model.rotation, Quaternion.LookRotation (player.position - model.position), Time.deltaTime * 50);
		}
	}
}
