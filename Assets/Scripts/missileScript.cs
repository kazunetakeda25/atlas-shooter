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

public class missileScript : MonoBehaviour {

	public float missileSpeed;
	public float autoDestroytime;
	public AudioClip explosionSound;
	public GameObject explosionEffectOnPlayerCamera;

//	public GameObject WholeGameObjectHeli;
//	public PlayerHelthScript script;

	// Use this for initialization
	void Start () 
	{
	//	explosionEffectOnPlayerCamera = GameObject.Find("Explosion Particle Systembk");
//		WholeGameObjectHeli = GameObject.FindWithTag("PlayerCamera");
//		script = GameObject.FindWithTag("PlayerCamera").GetComponent<PlayerHelthScript>();
		Destroy(gameObject, autoDestroytime);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		explosionEffectOnPlayerCamera = GameObject.Find("Explosion Particle Systembk");
	}

	void FixedUpdate()
	{
		rigidbody.AddRelativeForce(Vector3.forward*missileSpeed);
	}

	void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.tag == "GameObject")
		{
			print ("Collision Detected ");
			audio.PlayOneShot(explosionSound);
		//	explosionEffectOnPlayerCamera.SetActive(true);
			GameObject child = Instantiate (explosionEffectOnPlayerCamera, explosionEffectOnPlayerCamera.transform.position, explosionEffectOnPlayerCamera.transform.rotation) as GameObject;
			child.transform.parent = GameObject.Find("Main Camera").transform;
			//	Invoke("cancelEffect" , 2f);
			print (other.gameObject.name);
			PlayerHelthScript.DecreaseHealthOnGetFire(50f);
		//	Destroy(this.gameObject);
		}
	//	print (other.gameObject.name);
	//	print ("Collision Detected ");
	}

	void cancelEffect()
	{
		//explosionEffectOnPlayerCamera.SetActive(false);
	}
}
