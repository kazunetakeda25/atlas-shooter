/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

//gun_Emitter_Object.particleEmitter.emit = true;	
// Instantiate=> transform.rotation=>vector3=>random.range(...)
using UnityEngine;
using System.Collections;

public class enemyWeapon : MonoBehaviour 
{
	public GameObject enemyfire;
	public Transform Heli;
	public float shootingRate = 2.5f;
	public float shootCooldown;
	public float dist,range=600;
	public bool shoot=false;

	public AudioClip fireSound;
	

	// Use this for initialization
	void Start () 
	{
		//WholeGameObjectHeli = GameObject.FindWithTag("PlayerCamera");
		//script = GameObject.FindWithTag("PlayerCamera").GetComponent<PlayerHelthScript>();
		if (gameObject == GameObject.Find(""))
		shootCooldown = 3f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		dist = (Heli.position - transform.position).magnitude;

		if (dist < range) 
		{
			if (shootCooldown > 0) 
			{
				shootCooldown -= Time.deltaTime;
			}
			if (shootCooldown <= 0) 
			{

				Instantiate (enemyfire, transform.position, transform.rotation);
				audio.PlayOneShot(fireSound);
				shootCooldown = shootingRate;
			}
			if ((Heli.position - transform.position).magnitude < 0)
			{
				Destroy(gameObject);
			}
		}
	}

//	void OnCollisionEnter (Collision other)
//	{
//		if(other.gameObject.name == "GameObject (For WayPoint)")
//		{
//			print ("Collision Detected ");
//			script.DecreaseHealthOnGetFire(1f);
//			Destroy(this.gameObject);
//		}
//		print ("Collision Detected ");
//	}
//	
}
//public float smooth = 2.0F;
//public float tiltAngle = 30.0F;
//void Update() {
//	float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
//	float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
//	Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
//	transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
//}
