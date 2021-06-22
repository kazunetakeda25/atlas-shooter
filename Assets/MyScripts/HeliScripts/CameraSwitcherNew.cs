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

public class CameraSwitcherNew : MonoBehaviour {
	public GameObject firstCamera ;
	public GameObject PlayerCamera ,FirstSceneCamera ,SecondSceneCamera,thirdGroupActive,secondGroupActive,launcherEnemy1,launcherEnemy2;
	public GameObject speedobj2  ;
	public  Transform player	;
    public hoMove speedcontroller 	;
	public bool onetime=true	;
	public bool thirdtime=true	;
	public bool secondtime=true 	;
	public   float timeCounter =300f	;
	public   float timeCounter1 =300f;
	public   float timeCounter2 =300f;
	public static float attackDist=40f ; 
	public static float attackDist1=20f ;
	public static float attackDist2=20f ;
	public Transform FirstStop ,SecondStop ,ThirdStop,secondEnemyGroup,secondEnemyGroup_pos;
	public bool Camra_Swith_Train=false;

void Start()
	{      Time.timeScale = 1;
		timeCounter =300f	;
		player = GameObject.Find("GameObject (For WayPoint)").transform;
		firstCamera.SetActive(true);
		speedcontroller=GameObject.Find ("GameObject (For WayPoint)").GetComponent<hoMove> ();
		//speedcontroller.ChangeSpeed(500);
		if(Application.loadedLevelName=="Scene1" ){

		Invoke ("switchtoPlayer",8);
		}
		if (Application.loadedLevelName=="Scene2"){
			Invoke ("switchtoPlayer",10);
		}
		if(Application.loadedLevelName=="Scene12" ){
			
			Invoke ("switchtoPlayer",8);
		}
	
} 

void Update () 
{
				if (Input.GetKey (KeyCode.F1)) {
						firstCamera.SetActive (true);
		
						PlayerCamera.SetActive (false);
				}
	
				if (Input.GetKey (KeyCode.F2)) {
						firstCamera.SetActive (false);
						PlayerCamera.SetActive (true);
				}
	
			//speedcontroller=GameObject.Find ("GameObject (For WayPoint)").GetComponent<hoMove> ();
		if (Vector3.Distance (player.position, speedobj2.transform.position) <=20  && Application.loadedLevelName=="Scene3") {
			launcherEnemy1.SetActive(true);
			launcherEnemy2.SetActive(true);
		}
		if(Application.loadedLevelName=="Scene3" && PlayerHelthScript.pausemenuVisible==true){
			if (Vector3.Distance(player.position, FirstStop.position) <= attackDist  && PlayerHelthScript.EnemyKilledScore <= 16){
			{     

				  
					speedcontroller.ChangeSpeed(0f);					

					if(PlayerHelthScript.EnemyKilledScore==8){
						secondGroupActive.SetActive(true);
					}
					if(PlayerHelthScript.EnemyKilledScore==11){
						thirdGroupActive.SetActive(true);
					}

						  }
				if(PlayerHelthScript.EnemyKilledScore>=16){

								speedcontroller.ChangeSpeed(120f);
					            attackDist=0;
								
				        }
			}


			 if (Vector3.Distance(player.position, SecondStop.position) <= attackDist1  && timeCounter1>=0)
						{	
				print ("attackDist2.."+timeCounter1);
							speedcontroller.ChangeSpeed(0f);					
							timeCounter1=timeCounter1-0.5f;
				            
			          }
				else if(timeCounter1<=0){
				            speedcontroller.ChangeSpeed(100f);
				             timeCounter1=-1;
							}

			if (Vector3.Distance(player.position, ThirdStop.position) <= attackDist2  && timeCounter2>=0)
			{
				print ("attackDist3.."+timeCounter2);
				speedcontroller.ChangeSpeed(0f);					
				timeCounter2=timeCounter2-0.5f;
			}
			else if(timeCounter2<=0){
				speedcontroller.ChangeSpeed(40f);
				timeCounter2=-1;
			}
					
			if (Vector3.Distance(player.position, secondEnemyGroup_pos.position) <= 30  && thirdtime==true)
			{	
				//secondEnemyGroup.SetActive(true);
				secondEnemyGroup.gameObject.SetActive(true);
				thirdtime=false;
				
			}			    
		
		}
		

	}

public void switchtoPlayer()
{	
		PlayerCamera.SetActive(true);
		Destroy (firstCamera,0);
		speedcontroller.ChangeSpeed(30f);
	    onetime=false	;	
		Time.timeScale = 1;
		///////////////////////////////////////////////////// Just Only for Train Mission//////////
		resetPlaneSpeed ();
	
}

	public void resetPlaneSpeed(){
//		GameObject.Find ("GameObject (For WayPoint)").GetComponent<Movements> ().moveSpeed = 1003f;
		//this.GetComponent<Movements> ().moveSpeed = 210f;
//		Debug.Log ("saaad");
		if (UIcontroller.SelectedRegion == 2) {
						GameObject.Find ("Terrain1").GetComponent<moveTrain> ().enabled = true;
						GameObject.Find ("Terrain2").GetComponent<moveTrain> ().enabled = true;
				}

	}
	
}
