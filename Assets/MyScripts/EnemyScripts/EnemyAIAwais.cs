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

public class EnemyAIAwais : MonoBehaviour 
{
	
	public Transform target;
	public Transform Enemymodel;

	static float attackDist;
	
	// Use this for initialization
	void Start () 
	{
		if (Application.loadedLevelName == "Scene1")
		{
			attackDist = 1000f;

		}
		else if (Application.loadedLevelName == "Scene2")
		{
			attackDist = 1700f;

		}
		else if (Application.loadedLevelName == "Scene3")
		{
			attackDist =750f;
			
		}
		else if (Application.loadedLevelName == "Scene4")
		{
			attackDist =750f;
			
		}
		else if (Application.loadedLevelName == "Scene5")
		{
			attackDist =750f;
			
		}
		else if (Application.loadedLevelName == "Scene6")
		{
			attackDist =750f;
			
		}
		else if (Application.loadedLevelName == "Scene7")
		{
			attackDist =750f;
			
		}
		else if (Application.loadedLevelName == "Scene8")
		{
			attackDist =750f;
			
		}
		else if (Application.loadedLevelName == "Scene12")
		{
			attackDist =750f;
			
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

		target = GameObject.Find("Player").transform;
		if (Vector3.Distance(Enemymodel.position, target.position) <= attackDist)
		{	
			Attack();
		}
		else
		{

			Petrol();
		
		}	   
	}

	// Method of attack from Enemy to player ("Me") ...........
	public void  Attack()
	{

		EnemyFiring ef = gameObject.GetComponent<EnemyFiring>();
		ef.enabled = true;

		hoMove hm = gameObject.GetComponent<hoMove>();
		hm.ChangeSpeed(0f);
		hm.Pause();

		hm.enabled = false;

//		GameObject.Find("hm").SetActive(false);
//		GameObject.Find("ef").SetActive(true);
	}
	//  ......................................................
	
	

	// Enemy is moving on waypoint using hoMove script ***************
	public void Petrol()
	{

		EnemyFiring ef = gameObject.GetComponent<EnemyFiring>();
		ef.enabled = false;

		hoMove hm = gameObject.GetComponent<hoMove>();
		hm.enabled = true;
		hm.ChangeSpeed(0f);
		hm.Pause();

		//GameObject.Find("hm").SetActive(true);
	}
	// ***************************************************************

}



