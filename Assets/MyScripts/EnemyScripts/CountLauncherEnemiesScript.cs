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

public class CountLauncherEnemiesScript : MonoBehaviour {


	public GameObject bullet;
	public AS_Bullet bulletScript ;

	public GameObject launcher_enemy1;
	public GameObject launcher_enemy2;
	public GameObject launcher_enemy3;
	public GameObject launcher_enemy4;
	public GameObject launcher_enemy5;
	public GameObject launcher_enemy6;
	public GameObject launcher_enemy7;
	public GameObject launcher_enemy8;
	public GameObject launcher_enemy9;
	public GameObject launcher_enemy10;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
//		arrlauncherEnemy = GameObject.FindGameObjectsWithTag("Enemy1");
//		launcher_Count = launcher_Count - AS_Bullet.killedLauncherEnemies;
//
//
//		for (int i = activeEnemyCount; i < launcherEnemy.Length; i++)
//		{
//			print ("length is " + launcherEnemy.Length);
//			if (launcher_Count < 3)
//			{
//				launcherEnemy[i].SetActive(true);
//				launcher_Count++;
//			}
//		}
	}

	void activeBnday34()
	{
		print ("ActiveBanday34");
		launcher_enemy3.SetActive(true);
		launcher_enemy4.SetActive(true);
	}

	void activeBnday5()
	{
		print ("ActiveBanday 5 ");
		launcher_enemy5.SetActive(true);
	}

	void activeBnday6()
	{
		print ("ActiveBanday 6 ");
		launcher_enemy6.SetActive(true);
	}

	void activeBnday7()
	{
		print ("ActiveBanday 7 ");
		launcher_enemy7.SetActive(true);
	}

	void activeBnday8()
	{
		print ("ActiveBanday 8 ");
		launcher_enemy8.SetActive(true);
	}

	void activeBnday9()
	{
		print ("ActiveBanday 9 ");
		launcher_enemy9.SetActive(true);
	}

	void activeBnday10()
	{
		print ("ActiveBanday 10 ");
		launcher_enemy10.SetActive(true);
	}
	
}
