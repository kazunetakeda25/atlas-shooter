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

public class EnemyFiring : MonoBehaviour 
{
	private static bool isdead = false;
	//static int killedEnemies = 0;
	public GUIStyle myGUIStyle;
	public Transform target;
	public Transform model;

	public GameObject WholeGameObjectHeli;
	public PlayerHelthScript script;

	public GameObject blood;
	public GameObject bloodeffect;

	public GameObject muzzleFlash;
	public GameObject muzzelFlashPosition;
	
	public AnimationClip attackAnim;
	public AnimationClip dieAnim;
	
	public AudioClip zombieFootStep;
	public AudioClip zombieAttack1;
	public AudioClip zombieAttack2;
	public AudioClip metalHitSound;
	public AudioClip death1;
	public AudioClip death2;

	private bool isZombieHit = false;
	private bool isZombieRun = false;

	public static bool isZombieHitPlayer = false;
	private bool isAttackAnimationStart = false;
	

	private float damage = 0.5f;//0.5;
	//float attackDist = 150f;


	// Use this for initialization
	public void Start () 
	{
		model.animation[attackAnim.name].wrapMode= WrapMode.Once;
		model.animation[dieAnim.name].wrapMode= WrapMode.Once;	
		//destroyEnemy ();
	}
	
	// Update is called once per frame  ------------------------------
	public void Update () 
	{
			target = GameObject.Find("Player").transform;
			Attack();
	
			rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			
			if(model.animation.IsPlaying("Daying_on_back"))
			{
				model.animation.Stop(attackAnim.name);
				CancelInvoke("Attack()");
			}
			
			if (!isZombieRun)
			{
				isZombieRun = true;
				Invoke ("ZombieRun", 0.1f);
			}
		 
	}

	// -------------------------- Update Function end ----------------



	public void  Attack()
	{

		target = GameObject.Find("Player").transform;

		Vector3 targetDir1 = target.position - transform.position; 
		Quaternion finalRotation= Quaternion.LookRotation(targetDir1*20.0f);
		finalRotation.x = 0;
		finalRotation.z = 0;
		transform.rotation = finalRotation;


		if (!isAttackAnimationStart)
		{
			transform.LookAt(target);
			if (model.animation.IsPlaying("Fire_standing"))
			{
				InvokeRepeating("Anim",4f, 2.5f);
			}
			else if (model.animation.IsPlaying("Fire_squat"))
			{
				InvokeRepeating("Anim",4f, 2.5f);
				//InvokeRepeating("Anim",0.125f, 0.00125f);
			}

			isAttackAnimationStart = true;
			if (model.animation.IsPlaying(dieAnim.name))
			{
				CancelInvoke("Anim");
				model.animation[attackAnim.name].layer = -10;
				model.animation[dieAnim.name].layer = 10;
				model.animation.Stop(attackAnim.name);
			}
			else
			{

			}
		}
	}


	public void ZombieHitPlayer ()
	{
		int randomHit = Random.Range (0,2);
		if (randomHit == 0)
			audio.PlayOneShot (zombieAttack1, 2);
		else
			audio.PlayOneShot (zombieAttack2, 2);
	}


	public void ZombieRun()
	{
		audio.PlayOneShot (zombieFootStep, 5);
	}


	public void destroyEnemy()
	{	

		model.animation.Play(dieAnim.name);
		CancelInvoke("Anim");

		model.animation[attackAnim.name].layer = -10;
		model.animation[dieAnim.name].layer = 10;
		model.animation.Stop(attackAnim.name);
		//////////   Here Score Calculates//////////////////
		PlayerHelthScript.earnedCoins=PlayerPrefs.GetInt ("highScoreCoin");
		PlayerHelthScript.earnedCoins+=10;
		PlayerPrefs.SetInt ("highScoreCoin",PlayerHelthScript.earnedCoins);
		Debug.Log("hit count update here");
		PlayerHelthScript.coins+=10;
		///////////Ends here////////
		this.collider.enabled = false;

		if (model.animation.IsPlaying("Daying_on_back"))
		{
			audio.PlayOneShot(death1);
			Destroy (gameObject,1f);
		}
		else if (model.animation.IsPlaying("Daying_squat"))
		{
			audio.PlayOneShot(death1);
			Destroy (gameObject,1.1f);
		}
		else if (model.animation.IsPlaying("Daying_on_belt"))
		{
			audio.PlayOneShot(death2);
			Destroy (gameObject,3f);
		}
		else if (model.animation.IsPlaying("Die_knocked_backward"))
		{
			audio.PlayOneShot(death2);
			Destroy (gameObject,1f);
		}
		else if (model.animation.IsPlaying("Die_knocked_forward"))
		{
			audio.PlayOneShot(death2);
			Destroy (gameObject,1f);
		}
		else if (model.animation.IsPlaying("Daying_lying"))
		{
			audio.PlayOneShot(death1);
			Destroy (gameObject,0.5f);
		}
	}






	// Anim method is used to run animations Attack and Death of enemy  @@@@@@@@@@@@@@@@@@@@@@@@@@@ 
	public void Anim()
	{ 
		GameObject muzzleEffect = (GameObject)Instantiate(muzzleFlash, muzzelFlashPosition.transform.position, muzzelFlashPosition.transform.rotation);
		Debug.DrawLine(transform.position, target.transform.position, Color.red , 1f);

		PlayerHelthScript.DecreaseHealthOnGetFire(1f);
		audio.PlayOneShot(metalHitSound);
		Destroy (muzzleEffect, 0.25f);

		model.animation[attackAnim.name].layer = 1;
		model.animation.Play(attackAnim.name);
		if (isdead)
		{
			isAttackAnimationStart = false;
			return;
		}
//		Vector3 targetDir = GameObject.Find ("Player").transform.position - transform.position;//Camera.main.transform.position - transform.position;
//
//		RaycastHit hit = new RaycastHit();
//
//		if (Physics.Raycast (transform.position, targetDir, out hit))
//		{   
//			if (hit.collider.tag == "Player")
//			{
//
//				print ("Bnda Mar dia");
//			}
//			var incomingVec = hit.point - transform.position;
//			var reflectVec = Vector3.Reflect(incomingVec, hit.normal);
//			Debug.DrawLine(transform.position, hit.point, Color.red);
//			Debug.DrawRay(hit.point, reflectVec, Color.green); 	
//		} 
	}
	// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@   Anim method end   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


}

