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

public class ShipGunN19Script : MonoBehaviour 
{
	public Transform target;
	public Transform shipGun;

	public GameObject muzzleFlash;
	public GameObject muzzelFlashPosition;

	public GameObject objectForScript;
	public PlayerHelthScript script;

	public float attackDist = 600f;

	public int gunHealth = 5;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance(shipGun.position, target.position) <= attackDist)
		{	
			//print ("In ATTACK");
			Attack();
		}
		if (gunHealth <= 0)
		{
			CancelInvoke("Anim");
			Destroy(gameObject);
		}
	
	}



	public void  Attack()
	{
		target = GameObject.Find("Player").transform;
		Vector3 targetDir1 = target.position - transform.position; 
		Quaternion finalRotation= Quaternion.LookRotation(targetDir1*20.0f);
		finalRotation.x = 0;
		finalRotation.z = 0;
		transform.rotation = finalRotation;
		InvokeRepeating("Anim",5f, 5f);
	}


	public void DecreaseHealthOnGetFire(int value)
	{
		print("Gun health is " + gunHealth);
		gunHealth -= value;
	}

	public void Anim()
	{ 
		GameObject muzzleEffect = (GameObject)Instantiate(muzzleFlash, muzzelFlashPosition.transform.position, muzzelFlashPosition.transform.rotation);
		Debug.DrawLine(transform.position, target.transform.position, Color.red , 1f);
//		script.DecreaseHealthOnGetFire(0.5f);
		Destroy (muzzleEffect, 0.25f);
	}
}
