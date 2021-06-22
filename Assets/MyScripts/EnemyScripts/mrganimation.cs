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
	
	public class mrganimation : MonoBehaviour {
	public Transform model;
    public Transform player;
	public AnimationClip attackAnim,dieAnim;
	public  bool model1_finish=false;
	public bool Alerttexturecheck=false;
	public Texture2D alerttexture_bg;
	public float incresing_value,decrement;
	public GameObject rocketObject;
	public GameObject rocketPostion ,RocketBullets;
	public GameObject target;
	private Vector3 targetPoint;
	private Quaternion targetRotation; 
	public AudioClip deathSound,explo_sound_missile;
		void Start () {
					incresing_value = 1f;
					decrement = 0.0051f;
		   
				    	//InvokeRepeating ("Alerttexture",1.0f,07f);
					   
		if (model1_finish == false && !model.animation.IsPlaying ("MRG_Daying_on_belt")) {			      
						InvokeRepeating ("EnemyFireanimation",0.3f,5f);
						
					}
					target = GameObject.FindWithTag("Player");	
			
		}

		public void EnemyFireanimation(){		  
				model.LookAt (player);
				if (!model.animation.IsPlaying ("MRG_Daying_on_belt")) {
						model.animation.Play (attackAnim.name);
						if (model.animation.Play (attackAnim.name)) {
								var prefebRL = Instantiate (rocketObject, rocketPostion.transform.position, rocketPostion.transform.rotation);//as GameObject;
				//audio.PlayOneShot(explo_sound_missile);			
			}
				}
		}
	public void destroyEnemyMRG()
	{	this.collider.enabled = false;
		if (!model.animation.IsPlaying ("MRG_Daying_on_belt")  ||  model1_finish==false) {
			if (model.animation.IsPlaying (attackAnim.name) == true) {
				//model.animation.Stop (runAnim.name);
				model.animation.Stop (attackAnim.name);
				model.animation.Stop ("MRG_Fire_Squat");
				model.animation.Stop ("MRG_IDLE");
				model.animation.Play (dieAnim.name);
				animation.Play ("MRG_Daying_on_belt");
			}
			animation.Play ("MRG_Daying_on_belt");
			print ("dieeeeeeee");
			if (model.animation.IsPlaying ("MRG_Daying_on_belt")) {
				Destroy (gameObject, 4f);			
			}
			model1_finish = true;
			
		}
		audio.PlayOneShot(deathSound);
	}			

}
