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

public class ScreenShotScript : MonoBehaviour {
	public string ImagePrefix = "Image ";
	int imageName = 0;
	public int resolutionX = 2;

	public float CurrentTime;
	public bool TakingScreenShots = false;

	public float VideoRecordingFPS = 12.0f;

	private bool StartRecording = false;
	bool inScreenShot = false;
	bool paused = false;

	// Use this for initialization
	void Start () {
//		PlayerPrefs.SetInt ("ImageName", 0);
		imageName = PlayerPrefs.GetInt ("ImageName");


	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Input.GetKeyUp(KeyCode.F))
		{
			TakeScreenShot();
		}
		if (Input.GetKeyUp (KeyCode.I)) {
				
//			InvokeRepeating("TakeScreenShot", 1.0f/VideoRecordingFPS, 1.0f/VideoRecordingFPS);
			StartRecording = true;		
		}
		if (Input.GetKeyUp (KeyCode.O)) {
			
			StartRecording = false;		

			CancelInvoke("TakeScreenShot");
		}
		if (StartRecording == true) {
						TakingScreenShots = true;
//						Time.timeScale = 0.0f;
//			Invoke("TakeScreenShot",1.0f/VideoRecordingFPS);
				} else {
			TakingScreenShots = false;
			Time.timeScale = 1.0f;

		
		}
//		Debug.Log ("Taking Screen Shot");
	}
	void Update()
	{

//		Debug.Log ("Time Scale"+Time.timeScale);
		if(Input.GetKeyUp(KeyCode.F))
		{
			TakeScreenShot();
		}
		if(Input.GetKeyUp(KeyCode.P))
		{
			
			if(paused==false)
			{
				Debug.Log ("Pause");
				
				paused = true;
				
				Time.timeScale = 0.0f;
			}
			else{
				paused = false;
				Time.timeScale = 1.0f;
				Debug.Log ("Resume");
				
				
			}
		}


		if (TakingScreenShots == true) {
			CurrentTime+=Time.deltaTime;
			Debug.Log("Current time"+CurrentTime);

			if(CurrentTime>(1.0/VideoRecordingFPS))
			{
//				Debug.Log("Current time"+CurrentTime);
				CurrentTime = 0.0f;
				Time.timeScale = 0.0f;
				
				Invoke("TakeScreenShot",0);
				
				//			TakeScreenShot();
				//			Time.timeScale  =1.0f;


			}


		}
		if (inScreenShot == true) {
			Debug.Log("Out of Screen Shot");	
			inScreenShot = false;
			Time.timeScale = 1.0f;

		}
	}
	void TakeScreenShot()
	{

//		if(TakingScreenShots)
//		TakingScreenShots = true;
		inScreenShot = true;
		Debug.Log ("Taking Screen Shot");
		imageName++;
		PlayerPrefs.SetInt ("ImageName", imageName);
		Debug.Log ("Capturing Screen Shot");
		Application.CaptureScreenshot(ImagePrefix+imageName+".png", resolutionX);
		Debug.Log ("Done Screen Shot Capture");
//		Time.timeScale = 1.0f;

	}
	void OnMouseDown()
	{
	}
}
