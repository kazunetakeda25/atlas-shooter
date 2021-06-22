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
public class hit_explosion : MonoBehaviour {
	public static Vector3 position=Vector3.zero;
	public GameObject explosion;
	public GameObject poinout,pointout_dest;
	public GameObject heli,FirstGroup_enemy,FirstGroup_enemyPos;
	public float nearDistance;
	public AudioClip explo_sound_missile;
	// Use this for initialization
	void Start () {
		nearDistance = 50;
	}
	void Update(){
				if (Vector3.Distance (heli.transform.position, FirstGroup_enemyPos.transform.position) <= nearDistance) {
						FirstGroup_enemy.SetActive (true);
				}
		}
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "EnemyMissile" ) 
		{
			
			pointout_dest=(GameObject)Instantiate (explosion,poinout.transform.position, poinout.transform.rotation);
			//Instantiate (bigExplosion, collision.gameObject.transform.position, Quaternion.identity);
			
			//if (collision.gameObject.tag == "HeliEffct" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Guns" || collision.gameObject.tag == "HELIHIT"){
			//	GameObject.Find ("Main Camera").GetComponent<PlayerHelthScript> ().DecreaseHealthOnGetFire (70f);
			
			PlayerHelthScript.DecreaseHealthOnGetFire(10f);
			
			Destroy (pointout_dest,3f);	
			audio.PlayOneShot(explo_sound_missile);
			
		}	
	}
	
}
