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

public class Movements : MonoBehaviour {

	private GameObject PlayerTarget;

	public float rotationSpeed = 3.0f;

	public Transform [] targets;
	public int targetedIndex;

	public float moveSpeed = 1;
	private bool NxtPointBool;


	// Use this for initialization
	void Start(){
		NxtPointBool = false;
		PlayerTarget = GameObject.FindGameObjectWithTag("Player");
	}

	// rest bool for next point 
	void ResetNxtPointBool(){

		NxtPointBool=false;
	}


	// Update is called once per frame
	void Update () {

				if (moveSpeed < 1) {
						moveSpeed += Time.deltaTime * 2;		
				}

				float distance = (targets [targetedIndex].position - transform.position).magnitude;
				//Debug.Log(""+targets.Length);
				if (distance > 5) {

						var lookDir = targets [targetedIndex].position - transform.position;
						//transform.LookAt(target1);
						transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (lookDir), rotationSpeed * Time.deltaTime); 
						transform.position += transform.forward * moveSpeed * Time.deltaTime;	
				}
		  
		}



}
