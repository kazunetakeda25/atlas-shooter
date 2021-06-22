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

public class launcher_EnemyFiring : MonoBehaviour {

	private static bool isdead = false;
	
	public AnimationClip attackAnim,IDLE; 
	public AnimationClip dieAnim;

	private GameObject rocketObject;
	private GameObject prefebRL; 
	public GameObject rocketPostion;

	public GameObject WholeGameObjectHeli;
	public PlayerHelthScript script;

	public AudioClip zombieFootStep;
	public AudioClip zombieAttack1;
	public AudioClip zombieAttack2;
	public AudioClip fireSound;


	public Transform lookAtTarget;
	public Transform model;
	private Transform target;

	public AudioClip deathSound;

	private bool  isZombieHit = false;
	private bool  isZombieRun = false;
	public static bool  isZombieHitPlayer = false;
	private bool  isRocketInstantiate = false;  
	private bool  isRigidBodyAdd = false; 
	public static bool  isRocketFire = false;
	private bool  isAttackAnimationStart = false;
	//public AudioClip explosionSound;
	
	
	
	public void  Start ()
	{
		target = GameObject.Find("Player").transform;
		model.animation[IDLE.name].wrapMode= WrapMode.Loop;		
		model.animation[attackAnim.name].wrapMode= WrapMode.Once;		
	}


	// ========================= Update Method Start ===========================
	public void Update ()
	{
		target = GameObject.Find("Player").transform;
		transform.LookAt(target.transform.position);
		Attack();
		rigidbody.constraints = RigidbodyConstraints.FreezeAll;

		if(model.animation.IsPlaying("MRG_Daying_squat")  )
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
	// ========================= Update Method End ===========================



	public void  HideRocket ()
	{
		Destroy(GameObject.Find("Rocket(Clone)"),1f);
	}


	// ------------------------ Attack Method Start -------------------------
	public void Attack ()
	{	
		target = GameObject.Find("Player").transform;
		Vector3  targetDir1= target.position - transform.position; 
		Quaternion finalRotation=Quaternion.LookRotation(targetDir1*20.0f);
		finalRotation.x = 0;
		finalRotation.z = 0;
		transform.rotation = finalRotation;
		transform.LookAt(target.transform.position);
		if ( model.animation.IsPlaying ("MRG_Walking")) {
						//animation.Stop ();
			model.animation.Play(attackAnim.name);

				}
		if (!isAttackAnimationStart)
		{
			InvokeRepeating("Anim",0f,7f);
			isAttackAnimationStart = true;
		}

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
	// ------------------------ Attack Method End -------------------------


	public void ZombieHitPlayer ()
	{
		int randomHit = Random.Range (0,2);
		if (randomHit == 0)						
			audio.PlayOneShot (zombieAttack1, 2);
		else
			audio.PlayOneShot (zombieAttack2, 2);
	}
	
	public void ZombieRun ()
	{
		audio.PlayOneShot (zombieFootStep, 5);
	}




	// ^^^^^^^^^^^^^^^^^^^^^^^ DestroyEnemy Method Start ^^^^^^^^^^^^^^^^^^^^^^^
	public void destroyEnemy()
	{	


		//////////   Here Score Calculates//////////////////
		PlayerHelthScript.earnedCoins=PlayerPrefs.GetInt ("highScoreCoin");
		PlayerHelthScript.earnedCoins+=10;
		PlayerPrefs.SetInt ("highScoreCoin",PlayerHelthScript.earnedCoins);
		Debug.Log("hit count update here");
		PlayerHelthScript.coins+=10;
		///////////Ends here////////


		model.animation.Play(dieAnim.name);
		CancelInvoke("Anim");
		
		model.animation[attackAnim.name].layer = -10;
		model.animation[dieAnim.name].layer = 10;
		model.animation.Stop(attackAnim.name);
		
		
		this.collider.enabled = false;
		
		if (model.animation.IsPlaying("MRG_Daying_on_back"))
		{
			audio.PlayOneShot(deathSound);
			Destroy (gameObject,1f);
		}
		else if (model.animation.IsPlaying("MRG_Daying_squat"))
		{
			audio.PlayOneShot(deathSound);
			Destroy (gameObject,1.1f);
		}
		else if (model.animation.IsPlaying("MRG_Daying_on_belt"))
		{
			audio.PlayOneShot(deathSound);
			Destroy (gameObject,3f);
		}
	}



	
	// ************************** Anim Method Start *************************
	public void Anim ()
	{ 
		//audio.PlayOneShot(explosionSound);
		if (isdead)
		{
			isAttackAnimationStart = false;
			return;
		}
		Transform[] childCollection= GameObject.FindWithTag("Enemy1").GetComponentsInChildren<Transform>(); 
		foreach(Transform innerChild in childCollection)
		{
			if (innerChild.gameObject.name == "AnimationFreeObject"){ 
				innerChild.gameObject.active = true;
				if (!isRigidBodyAdd){
					innerChild.gameObject.AddComponent<Rigidbody>();  
					innerChild.gameObject.AddComponent<BoxCollider>();  
					innerChild.gameObject.tag = "freeObject";
					innerChild.rigidbody.mass = 0.4f;   
					innerChild.rigidbody.useGravity = false;
					isRigidBodyAdd = true;
				}
				if (!isRocketInstantiate)
				{
					rocketObject = innerChild.gameObject;
					rocketObject.transform.localScale = new Vector3 (50f,40f, 40f);//(0.5f,0.4f,0.3f)
					rocketObject.transform.LookAt(target.transform.position);
					model.animation[attackAnim.name].layer = 2;
					model.animation[attackAnim.name].speed = 0.7f;
					model.animation.Play(attackAnim.name);
					prefebRL = (GameObject)Instantiate(rocketObject, rocketPostion.transform.position, rocketPostion.transform.rotation);
					prefebRL.transform.LookAt(target.transform.position);

					if (prefebRL.rigidbody){
						Vector3 targetDir= GameObject.Find ("Player").transform.position - transform.position;
						float lancherYPosition = targetDir.y;
//						print ("Launcher Position " + lancherYPosition);
//						print ("Heli Position " + target.transform.position);
						prefebRL.transform.Translate((Vector3.forward*300f));//+(Vector3.right*50f));
					//	prefebRL.rigidbody.AddForce(transform.TransformDirection(new Vector3(targetDir.x*(-100),targetDir.y*5000,targetDir.z*12000)));
					//	prefebRL.rigidbody.AddForce(transform.TransformDirection(new Vector3((-50f),lancherYPosition,5000f)*1000));
						audio.PlayOneShot(fireSound);

//						if (target.transform.position.z > 7297.169)
//						{
//							lancherYPosition = lancherYPosition - 10f;
//							print ("Launcher Position in IF " + lancherYPosition);
//						}
						//Random.Range (600f , 650f);//140,160	
						//(0,240,500)
				
//						animation.Play("MRG_Fire_Squat");
						
						//Camera.main.transform.position - transform.position;
						RaycastHit hit;
						if (Physics.Raycast (transform.position, targetDir, out hit))
						{
							prefebRL.rigidbody.AddForce(transform.TransformDirection(new Vector3(target.transform.position.x,target.transform.position.y,target.transform.position.z)));
							Debug.DrawLine(transform.position, target.transform.position, Color.red ,1f);
//							print(hit.collider.tag);
							if (hit.collider.tag == "HeliEffct")
							{
//								print ("Hitting position " + rocketObject.transform.position);
								print(hit.collider.tag);

								Vector3 incomingVec= hit.point - transform.position;
								Vector3 reflectVec= Vector3.Reflect(incomingVec, hit.normal);
								Debug.DrawLine(transform.position, hit.point, Color.red);
								Debug.DrawRay(hit.point, reflectVec, Color.green); 
							} 
						}
						isRocketFire = true; 
						innerChild.gameObject.transform.localPosition =new Vector3 (-192.7407f,20.44312f,117.4433f);
						
						Invoke ("HideRocket",0.6f);	
					}
					else 
					{
						Destroy(prefebRL.gameObject);
					}
				}
			}
		}
	}
	// ************************** Anim Method End *************************
}
