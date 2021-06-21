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

/*
	All pieces of Detonator inherit from this. 
*/
public abstract class DetonatorComponent : MonoBehaviour
{
	public bool on = true;
	public bool detonatorControlled = true;
	
	[HideInInspector] 
	public  float startSize = 1f;
	public  float size = 1f;
	
	public  float explodeDelayMin = 0f;
	public  float explodeDelayMax = 0f;
	
	[HideInInspector]  
	public  float startDuration = 2f;
	public  float duration = 2f;
	
	[HideInInspector]
	public  float timeScale = 1f;
	
	[HideInInspector] 
	public  float startDetail = 1f;
	public  float detail = 1f;
	
	[HideInInspector] 
	public  Color startColor = Color.white;
	public  Color color = Color.white;
	
	[HideInInspector]
	public  Vector3 startLocalPosition = Vector3.zero;
	public  Vector3 localPosition = Vector3.zero;
	
	[HideInInspector]
	public  Vector3 startForce = Vector3.zero;
	public  Vector3 force = Vector3.zero;
	
	[HideInInspector]
	public  Vector3 startVelocity = Vector3.zero;
	public  Vector3 velocity = Vector3.zero;
	
	public abstract void Explode();
	
	//The main Detonator calls this instead of using Awake() or Start() on subcomponents
	//which ensures it happens when we want.
	public abstract void Init();
	
	public  float detailThreshold;
	
	/*
		This exists because Detonator makes relative changes
		to set values once the game is running, so we need to store their beginning
		values somewhere to calculate against. An improved design could probably
		avoid this.
	*/
	public void SetStartValues()
	{
		startSize = size;
		startForce = force;
		startVelocity = velocity;
		startDuration = duration;
		startDetail = detail;
		startColor = color;
		startLocalPosition = localPosition;
	}
	
	//implement functions to find the Detonator on this GO and get materials if they are defined
	public Detonator MyDetonator()
	{
		Detonator _myDetonator = GetComponent("Detonator") as Detonator;
		return _myDetonator;
	}
}
