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

public class HideMe : MonoBehaviour {
	public GameObject Path;
	public float radius = 5.0F;
	public float power = 10.0F;
	private bool RotateM = false;
	public bool NewHeli=false;
	public bool onceTrigger=false;
	private int bullet_count=0;
	// Use this for initialization
	void Start () {
		//Physics.gravity = new Vector3(0, -9.86F, 0);//initize at start
	}
	// For Machine Gun work
	void OnCollisionEnter(Collision col){
		Debug.Log (col.gameObject.name);
		bullet_count += 1;
		if (bullet_count > 10) { //Count 10 bullets to blast
			bullet_count=0;
			transform.parent.GetComponent<Animator>().enabled=false;
			this.gameObject.rigidbody.constraints=RigidbodyConstraints.None;
			RotateM=true;
			Invoke("DestroyMe",3);		//	this.gameObject.SetActive (false);

			GameObject blastArea=Instantiate(Resources.Load("Exploson5",typeof(GameObject))) as GameObject;
			blastArea.transform.localPosition=GameObject.Find("ins").transform.position;
			blastArea.transform.localRotation=col.gameObject.transform.localRotation;



			//////////   Here Score Calculates//////////////////
			PlayerHelthScript.earnedCoins=PlayerPrefs.GetInt ("highScoreCoin");
			PlayerHelthScript.earnedCoins+=20;
			PlayerPrefs.SetInt ("highScoreCoin",PlayerHelthScript.earnedCoins);
			Debug.Log("hit count update here");
			PlayerHelthScript.coins+=20;
			///////////Ends here////////
			/// 
			/// 

			Debug.Log (col.gameObject.name);
			Physics.gravity = new Vector3(0, -190.0F, 0);
			
			if(NewHeli){// if ake it new heli should instiate then make it true
				if (Application.loadedLevelName == "Scene12") {
					if(CallLevel.selectedLevel3>4){
						GameObject hele = Instantiate (Resources.Load ("Hele2", typeof(GameObject))) as GameObject;
					}
					
				} else {
					GameObject hele = Instantiate (Resources.Load ("Hele", typeof(GameObject))) as GameObject;
				}
			}
		
		}
//		if(col.gameObject.name=="RPGBullet(Clone)"){
//			Invoke("DestroyMe",7);
//			transform.parent.GetComponent<Animator>().enabled=false;
//		Debug.Log (col.gameObject.name);
//

		//}
	//	Debug.Log (col.gameObject.name);
	}



	void DestroyMe(){
		Physics.gravity = new Vector3(0, -9.86F, 0);
		this.gameObject.SetActive (false);
	}
	// blastr
	void OnTriggerEnter(Collider col){
		//Debug.Log ("bullet_count:" + col.gameObject.transform.position);
		if(col.gameObject.name=="Cube" && onceTrigger==false){
			onceTrigger=true;
			transform.parent.GetComponent<Animator>().enabled=false;
			this.gameObject.rigidbody.constraints=RigidbodyConstraints.None;
			RotateM=true;
//			rigidbody.AddForce(1000,1000,100);
//			rigidbody.AddTorque(1000,1000,100);
			//Fun();
			//Path.SetActive(true);
			Invoke("DestroyMe",3);		//	this.gameObject.SetActive (false);



			//////////   Here Score Calculates//////////////////
			PlayerHelthScript.earnedCoins=PlayerPrefs.GetInt ("highScoreCoin");
			PlayerHelthScript.earnedCoins+=20;
			PlayerPrefs.SetInt ("highScoreCoin",PlayerHelthScript.earnedCoins);
			Debug.Log("hit count update here");
			PlayerHelthScript.coins+=20;
			///////////Ends here////////
			/// 
			/// 

			Debug.Log (col.gameObject.name);
			Physics.gravity = new Vector3(0, -190.0F, 0);

			if(NewHeli){// if ake it new heli should instiate then make it true
				if (Application.loadedLevelName == "Scene12") {
					if(CallLevel.selectedLevel3>4){
						GameObject hele = Instantiate (Resources.Load ("Hele2", typeof(GameObject))) as GameObject;
					}
					
				} else {
					GameObject hele = Instantiate (Resources.Load ("Hele", typeof(GameObject))) as GameObject;
				}
			}
		}
		Debug.Log (col.gameObject.name);
	}


	void Fun(){

	
	}

	// Update is called once per frame
	void Update () {
		if (RotateM) {
						transform.Rotate (0, 2, 1);

				}
	}
}
