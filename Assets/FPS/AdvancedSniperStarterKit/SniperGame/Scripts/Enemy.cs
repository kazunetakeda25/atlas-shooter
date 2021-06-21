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

public class Enemy : MonoBehaviour {
	
	public Transform Myself;
	public float Speed = 3;
	public AudioClip[] footstepSound;
	public Vector3 targetPosition;
	public int timethink = 0;
	
	void Start () {
		Myself.animation.CrossFade("Run", 0.3f);
	}


	void Update (){

		Myself.animation.CrossFade("Run", 0.3f);
	
		if(timethink<=0){
   			targetPosition = new Vector3(Random.Range(-200,200),0,Random.Range(-200,200));
   			timethink = Random.Range(100,500);
   		}else{
   			timethink-=1;
   		}
   	
   		targetPosition.y = transform.position.y;
		Quaternion rotationTarget = Quaternion.LookRotation((targetPosition - this.transform.position).normalized);
   		transform.rotation = Quaternion.Lerp(this.transform.rotation,rotationTarget,Time.deltaTime * 5);
   		transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * Speed);
	}
}
