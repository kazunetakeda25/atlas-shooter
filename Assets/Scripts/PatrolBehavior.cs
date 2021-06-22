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
[RequireComponent(typeof(AudioSource))]
public class PatrolBehavior : MonoBehaviour
{
	private enum PatrolBehaviorState { MovingToNextPatrolPoint = 0, WaitingForNextMove = 1 }
	public Transform model;
	public AnimationClip runAnim;
	public AnimationClip attackAnim;
	public GameObject damageGO;
	public bool isZombieHit=false;
	public AudioClip zombieAttack1;
	public AudioClip zombieAttack2;
	public float patrolWalkSpeed = 2.0f;
	public float delayAtPatrolPointMin = 2.0f;
	public float delayAtPatrolPointMax = 5.0f;
	
	private PatrolBehaviorState patrolBehaviorState;
	private int patrolPointIndex;
	private float timeToWaitBeforeNextMove;
	public AudioClip breathSound;
	public AudioClip walkingSound;
	public PlayerHelthScript script;
	public float attackDist1 =70.0f;
	public static int annimation_no=1;
	public GameObject blood;
	public AudioClip enemygunsound;
	public AnimationClip dieAnim;
	private bool killedenemy=false;
	public float attackEnemy=3700f;
	public  Transform player;
	public bool SitEnemie=false;
	void Start()
	{      
		player = GameObject.Find ("GameObject (For WayPoint)").transform;
		InvokeRepeating ("healthdecrease", 2, 4f);
		model.animation.Play(attackAnim.name);

		if (SitEnemie) {
						animation.Play ("Fire_squat");
				} else {
			animation.Play ("Fire_standing");
		}

//		if (Vector3.Distance (model.position, player.position) <= attackEnemy) {
//			print ("healthhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
//
//		}
	}
	public void Update(){

						Attack ();
						
		if (model.animation.IsPlaying ("Daying_on_back") || model.animation.IsPlaying ("Daying_on_belt") || model.animation.IsPlaying ("Daying_squat") || model.animation.IsPlaying ("Die_knocked_backward") || model.animation.IsPlaying ("Die_knocked_forward")) {
								model.animation.Stop (attackAnim.name);
			rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			                    model.animation.Stop (runAnim.name);
								CancelInvoke ("Attack()");
						}
				
	}
	public void  Attack()
	{
	
		rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		Vector3 targetDir1 = player.position - transform.position; 
		Quaternion finalRotation= Quaternion.LookRotation(targetDir1*20.0f);
		finalRotation.x = 0;
		finalRotation.z = 0;
		transform.rotation = finalRotation;

			if (model.animation.IsPlaying(dieAnim.name))
			{
			rigidbody.constraints = RigidbodyConstraints.FreezeAll;
				model.animation[attackAnim.name].layer = -10;
				model.animation[dieAnim.name].layer = 10;
				model.animation.Stop(attackAnim.name);
			}
		
	}
	public void healthdecrease(){
		print ("healthhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
		PlayerHelthScript.DecreaseHealthOnGetFire(1.4f);
	}


	public void destroyEnemy()
	{		
		if (model.animation.IsPlaying(runAnim.name)==true){
			model.animation.Stop(runAnim.name);
			attackDist1=1;
			
		}


		//////////   Here Score Calculates//////////////////
		PlayerHelthScript.earnedCoins=PlayerPrefs.GetInt ("highScoreCoin");
		PlayerHelthScript.earnedCoins+=10;
		PlayerPrefs.SetInt ("highScoreCoin",PlayerHelthScript.earnedCoins);
		Debug.Log("hit count update here");
		PlayerHelthScript.coins+=10;
		///////////Ends here////////





		model.animation.Stop("Run");
		model.animation.Stop("Fire_standing");
		model.animation.Stop("IDLE");
		print("Hitting");
		//isdead = true;
		model.animation.Play(dieAnim.name);
		//blood.SetActive(true);
//		(GameObject)Instantiate(blood, hit.point, hit.transform.rotation);
		model.animation[attackAnim.name].layer = -10; 
		model.animation.Stop(attackAnim.name);
		if (annimation_no == 1) {			
			animation.Play ("Daying_on_belt");			
		}
		else if (annimation_no == 2){			
			animation["Daying_squat"].speed = 0.38f;			
			animation.Play ("Daying_squat");
		}
		else if (annimation_no == 3){
			
			animation["Die_knocked_backward"].speed = 0.1800f;
			animation.Play ("Die_knocked_backward");
		}
		else if (annimation_no == 4){
			
			animation["Die_knocked_forward"].speed = 0.180f;
			animation.Play ("Die_knocked_forward");
			annimation_no=0;
		}
		
		//Destroy (GameObject.Find ("blood"),5f);		
		this.collider.enabled = false;
		if (model.animation.IsPlaying("Daying_on_belt"))
		{
			Destroy (gameObject,3f);			
		}
		else if (model.animation.IsPlaying("Daying_squat"))
		{
			Destroy (gameObject,2.2f);
		}
		else if (model.animation.IsPlaying("Die_knocked_backward"))
		{
			Destroy (gameObject,2.2f);
		}
		else if (model.animation.IsPlaying("Die_knocked_forward"))
		{
			Destroy (gameObject,2.2f);
		}
		
		annimation_no = annimation_no + 1;
		killedenemy=true;
	}
}
