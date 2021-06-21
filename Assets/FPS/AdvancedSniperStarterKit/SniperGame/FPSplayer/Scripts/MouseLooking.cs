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

public class MouseLooking : MonoBehaviour {

	public float sensitivityX = 15;
	public float sensitivityY = 15;
	public float minimumX = -360;
	public float maximumX = 360;
	public float minimumY = -60;
	public float maximumY = 60;
	public float delayMouse = 3;
	public float noiseX = 0.1f;
	public float noiseY = 0.1f;
	public bool Noise;

	private float rotationX = 0;
	private float rotationY = 0;
	private float rotationXtemp = 0;
	private float rotationYtemp = 0;
	private Quaternion originalRotation;
	private float noisedeltaX;
	private float noisedeltaY;
	private float stunY;
	private float breathHolderValtarget = 1;
	private float breathHolderVal = 1;
	private TouchScreenVal touch;
	
	
	void Start () {
    	if (rigidbody)
    	    rigidbody.freezeRotation = true;
   			originalRotation = transform.localRotation;
		#if !UNITY_EDITOR
		//touch = new TouchScreenVal(new Rect(Screen.width/2,0,Screen.width,Screen.height));
		#endif
	}
	
	
	
	void Update () {
		sensitivityY = sensitivityX;
		
    
    	stunY+= (0-stunY)/20f;
    	
    	if(Noise){
        	noisedeltaX += ((((Mathf.Cos(Time.time) * Random.Range(-10,10)/5f) * noiseX) - noisedeltaX)/100);
        	noisedeltaY += ((((Mathf.Sin(Time.time) * Random.Range(-10,10)/5f) * noiseY) - noisedeltaY)/100);
		}else{
			
			noisedeltaX = 0;
			noisedeltaY = 0;
		}
		#if UNITY_EDITOR || UNITY_WEBPLAYER || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
		Screen.lockCursor = true;
		rotationXtemp += (Input.GetAxis("Mouse X") * sensitivityX) + (noisedeltaX * breathHolderVal);
		rotationYtemp += (Input.GetAxis("Mouse Y") * sensitivityY) + (noisedeltaY * breathHolderVal);
		rotationX += (rotationXtemp - rotationX)/delayMouse;
		rotationY += (rotationYtemp - rotationY)/delayMouse;
		#else
		//rotationX = rotationXtemp + (touch.OnDragDirection(true).x * sensitivityX * Time.deltaTime) + (noisedeltaX * breathHolderVal);
		//rotationY = rotationYtemp + (-touch.OnDragDirection(true).y * sensitivityY * Time.deltaTime) + (noisedeltaY * breathHolderVal);
		#endif

        if(rotationX>=360){
        	rotationX = 0;
        	rotationXtemp = 0;
        }
         if(rotationX<=-360){
        	rotationX = 0;
        	rotationXtemp = 0;
        }
		
        rotationX = ClampAngle (rotationX, minimumX, maximumX);
        rotationY = ClampAngle (rotationY, minimumY, maximumY);
		rotationYtemp = ClampAngle (rotationYtemp, minimumY, maximumY);
        

        Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis (rotationY+stunY, Vector3.left);

        transform.localRotation = originalRotation * xQuaternion * yQuaternion;
		breathHolderVal += (breathHolderValtarget-breathHolderVal)/10;	
		
		//#if !UNITY_EDITOR
		//rotationXtemp = rotationX;
		//rotationYtemp = rotationY;
		//#endif
	}
	
	public void Holdbreath(float val){
		breathHolderValtarget = val;
	}
	
	public void Stun(float val){
		stunY = val;
	}

	static float ClampAngle (float angle,float min,float max) {
    	if (angle < -360.0f)
        	angle += 360.0f;

    	if (angle > 360.0f)
        	angle -= 360.0f;

    	return Mathf.Clamp (angle, min, max);
	}
}
