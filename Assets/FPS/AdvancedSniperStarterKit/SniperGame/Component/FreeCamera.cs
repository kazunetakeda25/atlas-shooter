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

public class FreeCamera : MonoBehaviour {

	public float Speed = 10;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float speedmult = 1;
		if (Input.GetKey (KeyCode.LeftShift)) {
			speedmult = 2;
		}
		this.transform.position += ((this.transform.forward * Input.GetAxis ("Vertical")) + (this.transform.right * Input.GetAxis ("Horizontal"))) * Speed * speedmult * Time.deltaTime;
	}
}
