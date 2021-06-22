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

public class PlayerHelthScript : MonoBehaviour {

	public GameObject levelComplete;
	public GameObject levelFailed;
	public GameObject myPlayer,Group_launcher1,Group_launcher2,Group_launcher3;
	public ApnaController myPlayerScript;
	public PlayerHelthScript script;
	public MouseLook mouseLookScript;
	public GameObject myShip;
	public GameObject EnemyShip1;
	public GUIStyle	 Style_b = new GUIStyle();
	//public GameObject playerCamera;
	public GameObject pauseButton;
	public GameObject pauseButtonCamera;
	public GameObject pauseMenu;
	public GameObject skipButton;

	public GameObject bndaKhatam ;
	public AudioClip audioSound;
	public AudioClip destroyHeliSound;

	public GameObject mainCameraSF;   // For destroy heli and on it 
	 

	public Texture2D missionCompleteTexture;
	public Texture2D missionFailedTexture;

	public GameObject explosionEffectOnDestroyHeli;

	static public int EnemyKilledScore;
	public Texture2D score;
	public Texture2D scoreCoin;
	public GUIStyle myGUIStyle;
	public int scoreInt;
	public GameObject bullet;// = GameObject.Find("MachineGunBullet");
	public AS_Bullet bulletScript ; //= bullet.GetComponent<AS_Bullet>();

	public Texture2D fullTexture;
	public Texture2D emptyTexture;
	public Texture2D tabToStart;
	public static float bardisplay ;


	public static bool pausemenuVisible = true;

	public static bool health_ScoreVisible = true;

	public GUIStyle topTextGUIStyle;

	public int totalEnemies;
	static public float health = 1000f;
	public static int earnedCoins=0;// for store the coins in game
	public static int coins=0;//for scoring only not for storing

	//public float healthDecreaseRate = 1f; 
	// Use this for initialization
	public void Start () {
		earnedCoins=PlayerPrefs.GetInt ("highScoreCoin");// get the high score
		pausemenuVisible = true;
		bardisplay = health;
		EnemyKilledScore = 0;
		Style_b.fontSize = Screen.width/32;
		AS_Bullet.killedEnemies = 0;
		AS_Bullet.killedLauncherEnemies = 0;
		health_ScoreVisible = true;
		if (Application.loadedLevelName == "Scene2")
		{
			myShip.SetActive(false);
		}
		if (Application.loadedLevelName == "Scene2")
		{
			EnemyShip1.SetActive(false);
		}


	}
	
	// Update is called once per frame
	public void Update () 
	{
		EnemyKilledScore = (AS_Bullet.killedEnemies + AS_Bullet.killedLauncherEnemies);

		if (Application.loadedLevelName == "Scene1")
		{

			totalEnemies = 7;
		}
		else if (Application.loadedLevelName == "Scene2")
		{

			totalEnemies = 10;
		}
		else if (Application.loadedLevelName == "Scene3")
		{

			totalEnemies = 13;
		}
		else if (Application.loadedLevelName == "Scene4")
		{
			
			totalEnemies = 15;
		}
		else if (Application.loadedLevelName == "Scene5")
		{
			
			totalEnemies = 18;
		}
		else if (Application.loadedLevelName == "Scene6")
		{
			
			totalEnemies = 21;
		}
		else if (Application.loadedLevelName == "Scene7")
		{
			
			totalEnemies = 24;
		}
		else if (Application.loadedLevelName == "Scene8")
		{
			
			totalEnemies = 27;
		}
		else if (Application.loadedLevelName == "Scene9")
		{
			
			totalEnemies = 28;
		}
		else if (Application.loadedLevelName == "Scene10")
		{
			
			totalEnemies = 29;
		}
		else if (Application.loadedLevelName == "Scene11")
		{
			
			totalEnemies = 30;
		}
		else if (Application.loadedLevelName == "Scene13")
		{
			
			totalEnemies = 31;
		}



		else if (Application.loadedLevelName == "Scene12")
		{

			/// here Should Define name of working
			/// 
			/// 
			switch( CallLevel.selectedLevel3){
			case 1:
				totalEnemies = 7;
				break;
			case 2:
				totalEnemies = 10;
				break;
			case 3:
				totalEnemies = 13;
				break;
			case 4:
				totalEnemies = 15;
				break;
			case 5:
				totalEnemies = 18;
				break;
			case 6:
				totalEnemies = 21;
				break;
			case 7:
				totalEnemies = 24;
				break;
			case 8:
				totalEnemies = 27;
				break;
			case 9:
				totalEnemies = 28;
				break;
			case 10:
				totalEnemies = 29;
				break;
			case 11:
				totalEnemies = 30;
				break;
			case 13:
				totalEnemies = 31;
				break;
			
			}

		}

		if (EnemyKilledScore >= totalEnemies)
		{
			Invoke("missionCompleteMenuShow" , 1f);
		}
		if(AS_Bullet.killedLauncherEnemies==2 && Application.loadedLevelName=="Scene2"){
			Group_launcher1.SetActive(true);
		}
		if(AS_Bullet.killedLauncherEnemies==4 && Application.loadedLevelName=="Scene2"){
			Group_launcher2.SetActive(true);
		}
		if(AS_Bullet.killedLauncherEnemies==5 && Application.loadedLevelName=="Scene2"){
			Group_launcher3.SetActive(true);
		}


		if (health <= 1f)
		{
			mouseLookScript.enabled = false;
			bndaKhatam.SetActive(false);
			audio.PlayOneShot(destroyHeliSound);
			//playerCamera.SetActive(false);
			//mainCameraSF.SetActive(true);
			//explosionEffectOnDestroyHeli.SetActive(true);
			Invoke("missionFailedMenuShow", 1.1f);
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (pausemenuVisible)
			{
//				AdsManager manager = AdsManager.SharedObject();
//				manager.ShowHeyzapInterstitial();
//				manager.ShowBanner ();

				health_ScoreVisible = false;
				Time.timeScale = 0;
				if (mainMenuScript.gameSound == true)
				{
					AudioListener.volume = 0.0f;
				}
				myPlayerScript.enabled = false;
				mouseLookScript.enabled = false;
				pauseButton.SetActive(false);
				pauseButtonCamera.SetActive(false);
				pauseMenu.SetActive(true);
				pausemenuVisible = false;

			}
			else
			{
				Time.timeScale = 1;
				health_ScoreVisible = true;
				pauseButton.SetActive(true);
				pauseButtonCamera.SetActive(true);
				myPlayerScript.enabled = true;
				mouseLookScript.enabled = true;
				pauseMenu.SetActive(false);
				if (mainMenuScript.gameSound == true)
				{
					AudioListener.volume = 1;
				}
				pausemenuVisible = true;
//				AdsManager manager = AdsManager.SharedObject();
//				manager.HideHeyzapInterstitial();
//				manager.HideBanner();

			}
		}
	}

	public static  void DecreaseHealthOnGetFire(float value)
	{

		if (Application.loadedLevelName == "Scene1")
		{
			health -= value;
		}
		else if (Application.loadedLevelName == "Scene2")
		{
			health -= value+0.5f;
			//Debug.Log("health"+health);
			//GameObject.Find("Player").GetComponent<CameraShake>().shake=2;
		}
		else if (Application.loadedLevelName == "Scene3")
		{
			health -= value+.5f;
		}
		else if (Application.loadedLevelName == "Scene4")
		{
			health -= value+.5f;
		}
		else if (Application.loadedLevelName == "Scene5")
		{
			health -= value+.5f;
		}
		else if (Application.loadedLevelName == "Scene6")
		{
			health -= value+.5f;
		}
		else if (Application.loadedLevelName == "Scene7")
		{
			health -= value+.5f;
		}
		else if (Application.loadedLevelName == "Scene8")
		{
			health -= value+.5f;
		}
		else if (Application.loadedLevelName == "Scene9")
		{
			health -= value+.5f;
		}
		else if (Application.loadedLevelName == "Scene10")
		{
			health -= value+.5f;
		}
		else if (Application.loadedLevelName == "Scene11")
		{
			health -= value+.5f;
		}
		else if (Application.loadedLevelName == "Scene13")
		{
			health -= value+.5f;
		}
		else if (Application.loadedLevelName == "Scene12")
		{
			health -= value+5.5f;

			Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaa");
		}
				
		bardisplay = health;

	}

	public void OnGUI()
	{

		if (health_ScoreVisible)
		{
			pauseButton.SetActive(true);

			GUI.DrawTexture (new Rect (Screen.width*0.17f,Screen.height*0.092500f, Screen.width*0.160f, Screen.height*.057f), score);
			GUI.Label(new Rect(Screen.width*0.25f, Screen.height*0.0999999f, Screen.width*0.11f, Screen.height*.085f), EnemyKilledScore + "/" + totalEnemies , Style_b);

			GUI.DrawTexture (new Rect (Screen.width*0.643f,Screen.height*0.092500f, Screen.width*0.160f, Screen.height*.057f), scoreCoin);
			GUI.Label(new Rect(Screen.width*0.70f,Screen.height*0.0999999f, Screen.width*0.11f, Screen.height*.085f)," " + earnedCoins , Style_b);//coins
			if (bardisplay >= 0) 
			{
				GUI.DrawTexture (new Rect (Screen.width*0.336f, Screen.height*0.091500f, Screen.width*0.3f, Screen.height*.06f), emptyTexture);
				GUI.DrawTexture (new Rect (Screen.width*0.382f, Screen.height*0.114500f, Screen.width*(0.000242f * bardisplay), Screen.height*.0125f), fullTexture);
			
			} 
			else
			{ 
				GUI.DrawTexture (new Rect (Screen.width*0.276f, Screen.height*0.091500f, Screen.width*0.3f, Screen.height*.06f), emptyTexture);
				GUI.DrawTexture (new Rect (Screen.width*0.322f,Screen.height*0.094500f, 0, Screen.height*.0125f), fullTexture);
			}

		}

		skipButton.SetActive(false);

		if (EnemyKilledScore >= totalEnemies)
		{

			GUI.DrawTexture (new Rect ((Screen.width-Screen.width*0.60f)/2, (Screen.height-Screen.width*0.60f*62/674)/2, Screen.width*0.60f,Screen.width*0.60f*62/674), missionCompleteTexture);
		
		}

		if (health <= 1f)
		{
			GUI.DrawTexture (new Rect ((Screen.width-Screen.width*0.550f)/2, (Screen.height-Screen.width*0.550f*62/549)/2, Screen.width*0.550f,Screen.width*0.550f*62/549), missionFailedTexture);
		
		}

	}


	public void missionCompleteMenuShow()
	{

//		AdsManager manager = AdsManager.SharedObject();
//		manager.ShowLeadboltInterstitial() ;
//		manager.ShowBanner ();

		health_ScoreVisible = false;
		AudioListener.volume = 0;
		myPlayerScript.enabled = false;
		mouseLookScript.enabled = false;
		pauseButton.SetActive(false);
		script.enabled = false;
		levelComplete.SetActive(true);
		Time.timeScale = 0;
		bndaKhatam.SetActive(false);

	}
	

	public void missionFailedMenuShow()
	{
//		AdsManager manager = AdsManager.SharedObject();
//		manager.ShowChartboostInterstitial();
//		manager.ShowBanner ();

		health_ScoreVisible = false;
		levelFailed.SetActive(true);
		AudioListener.volume = 0;
		myPlayerScript.enabled = false;
		mouseLookScript.enabled = false;
		levelComplete.SetActive(false);
		script.enabled = false;
		Time.timeScale = 0;
		pauseButton.SetActive(false);
		bndaKhatam.SetActive(false);
	}



}


