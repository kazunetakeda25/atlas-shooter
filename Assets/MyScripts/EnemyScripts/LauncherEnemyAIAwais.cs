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

public class LauncherEnemyAIAwais : MonoBehaviour {


	public Transform target;
	public Transform Enemymodel;
	
	static float attackDist;
	
	// Use this for initialization
	void Start () 
	{
		target = GameObject.Find("Player").transform;
		if (Application.loadedLevelName == "Scene1")
		{
			attackDist = 1000f;
		}
		else if (Application.loadedLevelName == "Scene2")
		{
			attackDist = 1500f;
		}
		else if (Application.loadedLevelName == "Scene3")
		{
			attackDist = 150f;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{		

		if (Vector3.Distance(Enemymodel.position, target.position) <= attackDist)
		{	
			//print ("In ATTACK");
			Attack();
		}
		else
		{
			//print ("In PETROL");
			Petrol();
		}	   
	}
	
	// Method of attack from Enemy to player ("Me") ...........
	public void  Attack()
	{

		hoMove hm = gameObject.GetComponent<hoMove>();
		launcher_EnemyFiring l_ef = gameObject.GetComponent<launcher_EnemyFiring>();

		hm.enabled = false;
		l_ef.enabled = true;
		hm.ChangeSpeed(0f);
		//hm.Pause();
		

		
			//GameObject.Find("hm").SetActive(false);
			//	GameObject.Find("ef").SetActive(true);
	}
	//  ......................................................
	
	
	
	// Enemy is moving on waypoint using hoMove script ***************
	public void Petrol()
	{
		hoMove hm = gameObject.GetComponent<hoMove>();
		launcher_EnemyFiring l_ef = gameObject.GetComponent<launcher_EnemyFiring>();
		hm.enabled = true;
		l_ef.enabled = false;
		
		//GameObject.Find("hm").SetActive(true);
	}

}
