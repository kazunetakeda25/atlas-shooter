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

public class Explode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Enemy"){
			if(other.collider.gameObject.GetComponent<EnemyFiring>()){
		other.collider.gameObject.GetComponent<EnemyFiring>().destroyEnemy();
			}
			else if(other.collider.gameObject.GetComponent<PatrolBehavior>()){ 
		other.collider.gameObject.GetComponent<PatrolBehavior>().destroyEnemy();
			}
			AS_Bullet.killedEnemies += 1;
		}

		if(other.gameObject.tag=="Enemy1"){
			if(other.collider.gameObject.GetComponent<launcher_EnemyFiring>()){ 
				other.collider.gameObject.GetComponent<launcher_EnemyFiring>().destroyEnemy();
				AS_Bullet.killedEnemies += 1;
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
