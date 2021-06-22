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

public class MissileTrajectory : MonoBehaviour {
	//public GameObject flare;
	public bool destroyFlare=false;
	public static Vector3 position=Vector3.zero;
	public static Quaternion rotation=Quaternion.identity;
	public GameObject explosion,explosion1;
public float damage = 5.0F;
public float speedFactor = 150.0F;	
public float autodestroySec = 2f;	
	public AudioClip explo_sound_missile_collide;
	public GameObject smoke,smokeLarge,smokeLarge1;
public GameObject bigExplosion,bigExplosionForTower;
public string objectDestructibleTag = "destructible";
	public GameObject cameraFollow;

	// Use this for initialization
	void Start () {
      Destroy(gameObject,autodestroySec);	
	}
	
  void FixedUpdate () {
		 rigidbody.AddForce (transform.TransformDirection (Vector3.forward) * speedFactor);
  }
	
  void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "HeliEffct"  || collision.gameObject.tag == "HELIHIT" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "hitobjectnew" || collision.gameObject.tag == "waterPlane" || collision.gameObject.tag == "Guns" || collision.gameObject.tag == "GameObject" ) 
		{

			//Instantiate (explosion,transform.position, Quaternion.identity);
			//Instantiate (bigExplosion, collision.gameObject.transform.position, Quaternion.identity);
		
			if (collision.gameObject.tag == "HeliEffct" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Guns" || collision.gameObject.tag == "HELIHIT"|| collision.gameObject.tag == "GameObject" ){
		//	GameObject.Find ("Main Camera").GetComponent<PlayerHelthScript> ().DecreaseHealthOnGetFire (70f);

				PlayerHelthScript.DecreaseHealthOnGetFire(40f);
			}
			Destroy (gameObject,0);	
			//audio.PlayOneShot(explo_sound_missile_collide);
		
		}	
  }
	
}
