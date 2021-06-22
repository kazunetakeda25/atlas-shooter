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

public class CameraRotation : MonoBehaviour 
{
	public Transform target;
	public float distanceMin = 10.0f;
	public float distanceMax = 15.0f;
	
	private float distanceInitial = 12.5f;
	
	public float yMinLimit = -40f;
	public float yMaxLimit = 80f;
	
	private float x = 0.0f;
	private float y = 0.0f;
	private float distanceCurrent = 0.0f;
	
	private bool left;
	private bool right;
	
	
	public void Start () {
		calibrateAccelerometer();
		
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		
		distanceCurrent = distanceInitial;
		
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
	
	public void LateUpdate () {
		//	if(!GameManager.isPause) {
		if (target) {
			if(right){
				x+=1f;//0.5;
			}else if(left){
				x-=1f;//0.5;
			}else{
				x-=1f;//0.5;//0.1
			}
			
			distanceCurrent -= Input.GetAxis("Mouse ScrollWheel");
			
			distanceCurrent = Mathf.Clamp(distanceCurrent, distanceMin, distanceMax);
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			
			Quaternion rotation = Quaternion.Euler(y, x, 0f);
			Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distanceCurrent) + target.position;
			
			transform.rotation = rotation;
			transform.position = position;
		}
		// }//pause
	}
	
	private Matrix4x4 calibrationMatrix ;
	
	static public float ClampAngle (float angle, float min, float max) {
		if (angle < -360f)
			angle += 360f;
		if (angle > 360f)
			angle -= 360f;
		return Mathf.Clamp (angle, min, max);
	}
	
	public void calibrateAccelerometer(){
		Vector3 wantedDeadZone = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0, 0, -1), wantedDeadZone);
		
		//create identity matrix ... rotate our matrix to match up with down vec
		Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1, 1, 1));
		
		//get the inverse of the matrix
		this.calibrationMatrix = matrix.inverse;
	}
	
	//Whenever you need an accelerator value from the user
	//call this function to get the 'calibrated' value
	Vector3 getAccelerometer(Vector3 accelerator) {
		Vector3 accel  = this.calibrationMatrix.MultiplyVector(accelerator);
		return accel;
	}
}



