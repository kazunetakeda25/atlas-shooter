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

public class ApnaController : MonoBehaviour {

    public GunContainer gunContainer;
    public MouseLook mouseLook;

	public GameObject player;
	public PlayerHelthScript playerScript;

//	static public bool zoomIn = true;
//	static public bool zoomInPressed = false;
//	public Texture2D zoomInTexture;

	public TouchScreenVal touchAim;
    public TouchScreenVal touchShoot;
    public TouchScreenVal touchZoom;
    
	public Texture2D ImgButton;
    public float TouchSensMult = 0.05f;

    bool isPaused = false;
    private float scwidth;
    private float scheight;

	// Use this for initialization
	void Start () {
        
	    scwidth = Screen.width;
	    scheight = Screen.height;


        touchAim = new TouchScreenVal(new Rect(0, 0, scwidth * 0.8f, scheight), TouchPosition.TopLeft);

        touchShoot.AreaTouch = new Rect(new Rect(0, 0, scheight * 0.4f, scheight * 0.4f));
        touchShoot.ButtonArea = new Rect(new Rect(0, 0, scheight * 0.4f, scheight * 0.4f));

//        touchZoom.AreaTouch = new Rect(new Rect(0, 0, scheight * 0.3f, scheight * 0.3f));
//        touchZoom.ButtonArea = new Rect(new Rect(0, 0, scheight * 0.3f, scheight * 0.3f));
	
	}
	
	// Update is called once per frame
	void Update () {


        if (isPaused) return;
        
		// Get the input vector from kayboard or analog stick
		#if UNITY_EDITOR || UNITY_WEBPLAYER || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        mouseLook.Aim(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
		


        if (Input.GetButton("Fire1"))
        {
            gunContainer.Fire();

//			if(UIcontroller.SelectedRegion ==2){
//				GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<FindForword>().ButtonFire();
//			}

        }

//        if (Input.GetKeyDown(KeyCode.Q))
//        {

          // gunHanddle.SwitchGun();
          // gunContainer.SwitchGun();
//			if (zoomIn)
//			{
//				zoomInPressed = true;
//				ZoomCamera();
//				TouchSensMult = 0.05f;
//				zoomIn = false;
//			}
//			else
//			{
//				zoomInPressed = false;
//				ZoomOutCamera();
//				TouchSensMult = 0.05f;
//				zoomIn = true;
//			}  
//        }

		// For Mobile Devices
		#else
        
		Vector2 aimdir = touchAim.OnDragDirection(true);
        //FPSmotor.Aim(new Vector2(aimdir.x,-aimdir.y)*TouchSensMult);
        mouseLook.Aim(new Vector2(aimdir.x,-aimdir.y)*TouchSensMult);
	
		if(touchShoot.OnTouchPress()){
            gunContainer.Fire();
		}

//		if (touchZoom.OnTouchPress())
//		{
//			if (zoomIn)
//			{
//				zoomInPressed = true;
//				ZoomCamera();
//				TouchSensMult = 0.0008f;
//				zoomIn = false;
//			}
//			else
//			{
//				zoomInPressed = false;
//				ZoomOutCamera();
//				TouchSensMult = 0.05f;
//				zoomIn = true;
//			}  
//		}
//		if(touchZoom.OnTouchRelease())
//		{
//			ZoomOutCamera();
//		}
	
        #endif
    }

    void OnGUI()
    {
        if (isPaused) return;

        #if !UNITY_EDITOR && !UNITY_WEBPLAYER && !UNITY_STANDALONE_WIN && !UNITY_STANDALONE_OSX

		touchAim.Draw();
		touchShoot.Draw();
//		touchZoom.Draw();
        #endif
	
//		if (zoomInPressed)
//		{
//			GUI.DrawTexture(new Rect(0,0,Screen.width , Screen.height), zoomInTexture);
//		}
    }

    void OnPauseGame()
    {
        isPaused = true;
    }

    void OnResumeGame()
    {
        isPaused = false;
    }

    public void HideGun(bool hide)
    {
        gunContainer.HideGun(hide);
    }

//	public void ZoomCamera()
//	{
//		camera.fieldOfView = 10;//Mathf.Lerp(60, 15, Time.deltaTime*1);
//	}
//
//	public void ZoomOutCamera()
//	{
//		camera.fieldOfView = 60;//Mathf.Lerp(60, 15, Time.deltaTime*1);
//	}

}
