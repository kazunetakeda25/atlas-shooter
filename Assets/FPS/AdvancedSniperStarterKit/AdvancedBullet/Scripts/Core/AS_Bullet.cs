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
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

struct casthit{
	public int index;
	public float distance;
	public string name;
}

[RequireComponent(typeof(Rigidbody))]
public class AS_Bullet : MonoBehaviour
{
	static public int killedEnemies = 0; 
	static public int killedLauncherEnemies = 0;

    public bool vibratePlayer = false;
	public GameObject ParticleHit;
	public GameObject bloodParticles;
	public GameObject waterEffect;

	public GameObject shipGunN19;
	public ShipGunN19Script gunN19Script;


	public GameObject metalEffect;
	public AudioClip metalSound;
	public AudioClip waterSound;
	public AudioClip enemyDeathSound1;
	public AudioClip enemyDeathSound2;
    public int Damage = 10;
    public float PlayerDamage = 1;
	public float ForceShoot = 15000;
	public int LifeTime = 3;
	public int HitForce = 3000;
	public int HitCountMax = 10;
	public bool DestroyWhenHit = true;
	public float RunningRaylength = 40;
	public float FirstRaylength = 20;
	public float DetectorLength = 2000;
	public string[] IgnoreTag = {"Player"};
	public string[] DestroyerTag = {"scene"};
	public LineRenderer lineRenderer;


	private bool hited = false;
	private bool hitedaction = false;
	private bool firsthited = false;
	private bool destroyed = false;
	private bool detected = false;
    //private AS_ActionPreset actionPreset;
	private float runningLength;
	private Vector3 pointShoot;
	private const int ignoreWalkThru = ~((1 << 29) | (1 << 2) | (1 << 27) | (1 << 4) | (1 << 26));
	private Vector3 initialPosition;
	private Vector3 initialVelocity;
	private Vector3 initialDirection;
	private List<Collider> hittedList = new List<Collider> ();


//	void Start()
//	{
//				
//	}

	public void Awake ()
	{
		initialPosition = this.gameObject.transform.position;
        //AS_ActionCamera actioncam = (AS_ActionCamera)GameObject.FindObjectOfType (typeof(AS_ActionCamera));

        //if (actioncam != null) {
        //    actionPreset = actioncam.GetPresets ();
        //    if (actionPreset != null) {
        //        actionPreset.Shoot (this.gameObject);
        //    }
        //}
		this.renderer.enabled = true;	
	}

	//post score
	void PostShowleaderBoard(){
		
		if (Social.localUser.authenticated)
		{
			Social.ReportScore(PlayerPrefs.GetInt ("PlayerScore"), "CgkItY6U8_MZEAIQBg", (bool success) =>{});
			                  // {
//				if (success)
//				{
//					((PlayGamesPlatform)Social.Active).ShowLeaderboardUI("CgkItY6U8_MZEAIQBg");
//				}
//				else
//				{
//					//Debug.Log("Login failed for some reason");
//				}
			//}
		}
	}


	public void  Start ()
	{
		if (!PlayerPrefs.HasKey ("PlayerScore")) {
//			int holder=0;
//			holder=PlayerPrefs.GetInt("PlayerScore");
//			holder+=10;
			PlayerPrefs.SetInt("PlayerScore",0);
		}
		PlayGamesPlatform.Activate ();

		initialVelocity = this.transform.forward * ForceShoot;
		initialDirection = this.transform.forward;
		//initialPosition = this.gameObject.transform.position;
		pointShoot = this.gameObject.transform.position;
		latestPosition = this.gameObject.transform.position;
		rigidbody.mass = 1;
		rigidbody.drag = 0;
		rigidbody.angularDrag = 0;

		hited = false;
	    hitedaction = false;
	    firsthited = false;
	    destroyed = false;
	    detected = false;
		
		//Debug.Log ("Shoot");
		if (!RayShoot (true)) {
			if (rigidbody.useGravity) {
				PredictionTrajectory ();
			} else {
				FirstDetectTarget ();
			}
		}
		GameObject.Destroy (this.gameObject, LifeTime);
		this.rigidbody.velocity = (initialVelocity);
		this.transform.forward = initialVelocity.normalized;
	}

	private bool tagCheck (string tag)
	{
		for (int i=0; i<IgnoreTag.Length; i++) {
			if (IgnoreTag [i] == tag) {
				return false;	
			}
		}
		return true;
	}

	private bool tagDestroyerCheck (string tag)
	{
		for (int i=0; i<DestroyerTag.Length; i++) {
			if (DestroyerTag [i] == tag) {
				return true;	
			}
		}
		return false;
	}

	private bool hitedCheck (Collider ob)
	{
		foreach (Collider trans in hittedList) {
			if (ob == trans) {
				return false;	
			}
		}
		hittedList.Add (ob);
		return true;
	}
	
	void FixedUpdate ()
	{
		if (rigidbody) {
			this.transform.forward = rigidbody.velocity.normalized;
		}
		if (!destroyed) {
			RayShoot (false);
			if (!hited)
			RunningDetectTarget ();
		}
		latestPosition = this.transform.position;
	}
	
	private float runningmMagnitude;

	void Update ()
	{
//		Debug.Log (PlayerPrefs.GetInt ("PlayerScore"));
		runningmMagnitude = (this.transform.position - latestPosition).magnitude;
		if (runningmMagnitude <= 0)
			runningmMagnitude = 0.2f;
		

	}
	
	
	private Vector3 latestPosition;
	private int hitcount;
	public bool RayShoot (bool first)
	{
		bool res = false;
		RaycastHit[] hits;
		List<casthit> castHits = new List<casthit> ();

		float raySize = runningmMagnitude;
		Vector3 direction = rigidbody.velocity.normalized;

		if (first) {
			raySize = FirstRaylength;
			direction = initialDirection;
		}
		
		if (raySize <= 2.0f) {
			raySize = 2.0f;	
		}

		Vector3 pos1 = this.transform.position - (direction * raySize);
		Vector3 pos2 = pos1 + (direction * raySize);

		if(first){
			pos1 = initialPosition;
			pos2 = pos1 + (direction * raySize);
		}

		if (lineRenderer) {
			LineRenderer line = (LineRenderer)GameObject.Instantiate(lineRenderer,pos1,Quaternion.identity);
			line.SetPosition (0, pos1);
			line.SetPosition (1, pos1 + (raySize * direction));
			line.name = "laser "+raySize+" direction "+direction;
			GameObject.Destroy(line,10);
			//Debug.Log ("Shoot with size " + raySize);
		}


		// shoot ray to cast all objects
		int castcount = 0;
		RaycastHit[] casterhits = Physics.RaycastAll (pos1, direction, raySize,ignoreWalkThru);
		for (int i=0;i<casterhits.Length;i++) {
			if (casterhits[i].collider && Vector3.Dot((casterhits[i].point - initialPosition).normalized,initialDirection) > 0.5f) {
				if (tagCheck (casterhits[i].collider.tag) && casterhits[i].collider.tag != this.gameObject.tag){
					if (hitedCheck (casterhits[i].collider)) {
						castcount++;
						casthit casted = new casthit();
						casted.distance = Vector3.Distance(initialPosition,casterhits[i].point);
						casted.index = i;
						casted.name = casterhits[i].collider.name;
						castHits.Add(casted);
						//Debug.Log("cast "+casterhits[i].collider.name +"  ("+Vector3.Distance(initialPosition,casterhits[i].point)+")");
					}
				}
			}
//			Debug.Log("all cast "+casterhits[i].collider.name);
		}

		// sorted first to the last

		hits = new RaycastHit[castcount];
		castHits.Sort((x,y) => x.distance.CompareTo(y.distance));

		for (int i=0;i<castHits.Count;i++) {
			hits[i] = casterhits[castHits[i].index];
			//Debug.Log("soted cast "+castHits[i].index+" to "+i+" "+castHits[i].name+"  ("+castHits[i].distance+")");
		}

		for (var i = 0; i < hits.Length && hitcount < HitCountMax; i++) {
			RaycastHit hit = hits [i];
			detected = true;
				
			if (first) {
				firsthited = true;	
			} else {
				hited = true;	
			}

			GameObject hitparticle = null;

			if (hit.collider.rigidbody) {
				hit.rigidbody.AddForce (direction * HitForce, ForceMode.Force);
				
			}


            //////////////************
			if (hit.collider.gameObject.tag == "Enemy" && Application.loadedLevelName == "Scene3")
            {
				//get scrypt of Enemy
				// call destroy method of enemy

				hitparticle = (GameObject)Instantiate(bloodParticles, hit.collider.transform.position, hit.transform.rotation);
				//hitparticle = (GameObject)Instantiate(bloodParticles, hit.point, hit.transform.rotation);
				hit.collider.gameObject.GetComponent<PatrolBehavior>().destroyEnemy();
				killedEnemies += 1;
				Debug.Log("testing " + hit.collider.gameObject.name);
				Debug.Log(hit.collider.gameObject.name + " Killed!");
				PostShowleaderBoard();

				//hit.collider.collider.transform.root.GetComponent<ApnaStatus>().ApplyDamage(this.PlayerDamage, this.vibratePlayer);
 
            }
			if (hit.collider.gameObject.tag == "Enemyrun" && Application.loadedLevelName == "Scene3")
			{
				//get scrypt of Enemy
				// call destroy method of enemy
				
				hitparticle = (GameObject)Instantiate(bloodParticles, hit.collider.transform.position, hit.transform.rotation);
				//hitparticle = (GameObject)Instantiate(bloodParticles, hit.point, hit.transform.rotation);
				hit.collider.gameObject.GetComponent<PatrolBehavior1>().destroyEnemy();
				killedEnemies += 1;
				Debug.Log("testing " + hit.collider.gameObject.name);
				Debug.Log(hit.collider.gameObject.name + " Killed!");

				//Scoring Work
				int holder=0;
				holder=PlayerPrefs.GetInt("PlayerScore");
				holder+=10;
				PlayerPrefs.SetInt("PlayerScore",holder);
				PostShowleaderBoard();
				//hit.collider.collider.transform.root.GetComponent<ApnaStatus>().ApplyDamage(this.PlayerDamage, this.vibratePlayer);
				
			}

			if (hit.collider.gameObject.tag == "Enemy" && Application.loadedLevelName != "Scene3")
			{
				//get scrypt of Enemy
				// call destroy method of enemy
				
				//hitparticle = (GameObject)Instantiate(bloodParticles, hit.collider.transform.position, hit.transform.rotation);
				if(hit.collider.gameObject.GetComponent<EnemyFiring>()){
				hit.collider.gameObject.GetComponent<EnemyFiring>().destroyEnemy();
				}
				//				hit.collider.gameObject.GetComponent<EnemyFiring>().Attack();
				//				CancelInvoke("Attack");
				killedEnemies += 1;
				Debug.Log("testing " + hit.collider.gameObject.name);
				Debug.Log(hit.collider.gameObject.name + " Killed!");


				//Scoring Work
				int holder=0;
				holder=PlayerPrefs.GetInt("PlayerScore");
				holder+=10;
				PlayerPrefs.SetInt("PlayerScore",holder);
				PostShowleaderBoard();

				//hit.collider.collider.transform.root.GetComponent<ApnaStatus>().ApplyDamage(this.PlayerDamage, this.vibratePlayer);
				
			}


			// For destroy Launcher Enemy .....Call to destroyEnemy from launcher_EnemyFiring Script
			if (hit.collider.gameObject.tag == "Enemy1")
			{
				//get scrypt of Enemy
				// call destroy method of enemy
				//hitparticle = (GameObject)Instantiate(bloodParticles, hit.collider.transform.position, hit.transform.rotation);
				hit.collider.gameObject.GetComponent<launcher_EnemyFiring>().destroyEnemy();

				killedLauncherEnemies += 1;
				Debug.Log("testing saad " + hit.collider.gameObject.name);
				Debug.Log(hit.collider.gameObject.name + " Killed!");


				//Scoring Work
				int holder=0;
				holder=PlayerPrefs.GetInt("PlayerScore");
				holder+=10;
				PlayerPrefs.SetInt("PlayerScore",holder);
				PostShowleaderBoard();

				//hit.collider.collider.transform.root.GetComponent<ApnaStatus>().ApplyDamage(this.PlayerDamage, this.vibratePlayer);
				
			}
			if (hit.collider.gameObject.tag == "MRG1" && Application.loadedLevelName == "Scene3")
			{
				//get scrypt of Enemy
				// call destroy method of enemy
				hitparticle = (GameObject)Instantiate(bloodParticles, hit.collider.transform.position, hit.transform.rotation);
				hit.collider.gameObject.GetComponent<mrganimation>().destroyEnemyMRG();
				
				killedLauncherEnemies += 1;
				Debug.Log("testing " + hit.collider.gameObject.name);
				Debug.Log(hit.collider.gameObject.name + " Killed!");

				//Scoring Work
				int holder=0;
				holder=PlayerPrefs.GetInt("PlayerScore");
				holder+=10;
				PlayerPrefs.SetInt("PlayerScore",holder);
				PostShowleaderBoard();
				
				//hit.collider.collider.transform.root.GetComponent<ApnaStatus>().ApplyDamage(this.PlayerDamage, this.vibratePlayer);
				
			}

		

			if (hit.collider.gameObject == GameObject.FindWithTag("gunnearEnemy19"))
			{
				hitparticle = (GameObject)Instantiate(bloodParticles, hit.collider.transform.position, hit.transform.rotation);
				hit.collider.gameObject.GetComponent<ShipGunN19Script>().DecreaseHealthOnGetFire(1);
				//GameObject.FindWithTag("gunnearEnemy19").GetComponent<gunN19Script>().DecreaseHealthOnGetFire(1);
			}
	

            if (ParticleHit)
            {
				if (hit.collider.gameObject.tag == "Enemy")
				{
					//hitparticle = (GameObject)Instantiate(bloodParticles, hit.point, hit.transform.rotation);
					audio.PlayOneShot(enemyDeathSound1);
				}
				if (hit.collider.gameObject.tag == "waterPlane")
				{
					hitparticle = (GameObject)Instantiate(waterEffect, hit.point, hit.transform.rotation);
					audio.PlayOneShot(waterSound);
				}
				if (hit.collider.gameObject.tag == "EnemyShip1")
				{
					hitparticle = (GameObject)Instantiate(metalEffect, hit.point, hit.transform.rotation);
					audio.PlayOneShot(metalSound);
				}


            }

					
			if (hitparticle != null) {
				hitparticle.transform.forward = hit.normal;
				GameObject.Destroy (hitparticle, 70);
			}
						
			res = true;
			hitcount++;
			if (DestroyWhenHit || hitcount >= HitCountMax || tagDestroyerCheck (hit.collider.tag)) {
				destroyed = true;

			}

		}
		if (destroyed) {
            //if (actionPreset) {
            //    actionPreset.OnBulletDestroy ();
            //}
			GameObject.Destroy (this.gameObject,3);
		}	

		return res;
	}

	public void RunningDetectTarget ()
	{
		RaycastHit hitcam;
		if (Physics.Raycast (transform.position, transform.forward, out hitcam, RunningRaylength)) {
			if (hitcam.collider) {
				if (tagCheck (hitcam.collider.tag) && hitcam.collider.tag != this.gameObject.tag) {
					detected = true;
                    //if (hitcam.collider.GetComponent<AS_BulletHiter> ()) {
                    //    AS_BulletHiter bulletHit = hitcam.collider.gameObject.GetComponent<AS_BulletHiter> ();
                    //    if (actionPreset && !firsthited) {
                    //        actionPreset.TargetDetected (this, bulletHit, hitcam.point);
                    //    }
                    //}
				}
			}
		}
	}
	
	public void FirstDetectTarget ()
	{
		RaycastHit[] camerahits;
		camerahits = Physics.RaycastAll (transform.position, transform.forward, DetectorLength);
		for (var i = 0; i < camerahits.Length; i++) {
			RaycastHit hitcam = camerahits [i];
			if (hitcam.collider) {
				if (tagCheck (hitcam.collider.tag) && hitcam.collider.tag != this.gameObject.tag) {
					detected = true;
                    //if (hitcam.collider.GetComponent<AS_BulletHiter> ()) {
                    //    AS_BulletHiter bulletHit = hitcam.collider.gameObject.GetComponent<AS_BulletHiter> ();
                    //    if (actionPreset && !firsthited) {
                    //        actionPreset.FirstDetected (this, bulletHit, hitcam.point);
                    //    }
                    //}
				}
			}
		}
	}
	
	void PredictionTrajectory ()
	{	
		Vector3 gravity = Vector3.zero;
		if (rigidbody.useGravity) {
			gravity = Physics.gravity;
		}
		int numSteps = (int)DetectorLength;
		float timeDelta = 1.0f / initialVelocity.magnitude;
 
		Vector3 position = initialPosition;
		Vector3 velocity = initialVelocity;
		Vector3 lastpos = initialPosition;
		bool targetdetected = false;

		for (int i = 0; i < numSteps && !targetdetected; ++i) {
			position += velocity * timeDelta + 0.5f * gravity * timeDelta * timeDelta;
			velocity += gravity * timeDelta;
			targetdetected = RayPrediction (lastpos, position, initialPosition, timeDelta);
			lastpos = position;
		}
	}

	bool RayPrediction (Vector3 lastpos, Vector3 currentpos, Vector3 initialPosition, float delta)
	{
		RaycastHit[] hits;
		Vector3 dir = (currentpos - lastpos);
		dir.Normalize ();

		hits = Physics.RaycastAll (lastpos, dir, 1);
		
		for (var i = 0; i < hits.Length; i++) {
			RaycastHit hit = hits [i];
            //AS_BulletHiter bulletHit = hit.collider.gameObject.GetComponent<AS_BulletHiter> ();
            //if (bulletHit) {
            //    detected = true;
            //    if (actionPreset && !firsthited) {
            //        actionPreset.FirstDetected (this, bulletHit, hit.point);
            //        return true;
            //    }
            //}	
			
		}
		return false;
	}
}
