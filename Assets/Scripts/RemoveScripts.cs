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

public class RemoveScripts : MonoBehaviour {
	public float timeRemovel;
	public GameObject target;
	public GameObject Player;
	// Use this for initialization
	void Start () {
		Invoke ("callRemove", timeRemovel);


	}
	void OnEnable(){
		if (GameObject.Find ("POINTER")) {
			target=GameObject.Find ("POINTER");
		}
		if (GameObject.Find ("GameObject (For WayPoint)")) {
			Player=GameObject.Find ("GameObject (For WayPoint)");
			Destroy (Player.GetComponent<hoMove> ());
			Player.transform.position = target.transform.position;
			//		this.transform.localEulerAngles = target.transform.localEulerAngles;
			Player.transform.parent = target.transform;
		}



	}
	// Update is called once per frame
	void Update () {
	
	}
}
