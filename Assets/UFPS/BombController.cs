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

public class BombController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void BombTrough(){
		GetComponent<Animation> ().CrossFade ("Throw");
		Invoke ("ResetIdle", 2);
		Invoke ("BombCreate", 1.5f);
	}

	public void BombCreate(){
		//GameObject bomb = Instantiate (Resources.Load ("RPGBullet"), transform.position, transform.rotation)as GameObject;
		GetComponent<RPGLauncher>().Fire();
	}

	void ResetIdle(){
		GetComponent<Animation> ().CrossFade ("idle");
//		GameObject.Find ("Guns").GetComponent<GunContainer> ().bombOnce = false;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
