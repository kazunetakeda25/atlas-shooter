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

public class lookAtScript : MonoBehaviour {
	
	public Transform target;
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3  targetDir1= target.position - transform.position; 
		Quaternion finalRotation=Quaternion.LookRotation(targetDir1*20.0f);
		finalRotation.x = 0;
		finalRotation.z = 0;
		transform.rotation = finalRotation;
		transform.LookAt(target.transform.position);
	}
}
