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

public class FindForword : MonoBehaviour {
	RaycastHit hit;
	public GameObject targetRay;

	// Use this for initialization
	void Start () {
	
	}
	public void ButtonFire(){
		//if(UIcontroller.SelectedRegion ==2){
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if (Physics.Raycast(transform.position, fwd,out hit, 1000f)) {
			if(hit.transform.gameObject.tag=="Enemy"){
				hit.transform.gameObject.GetComponent<EnemyFiring>().destroyEnemy();
				AS_Bullet.killedEnemies+=1;
				Debug.Log(""+hit.transform.gameObject.name);
				//print("There is something in front of the object!");
			}
		}
		//}
	}
	// Update is called once per frame
	void Update () {
		ButtonFire ();
	}
}
