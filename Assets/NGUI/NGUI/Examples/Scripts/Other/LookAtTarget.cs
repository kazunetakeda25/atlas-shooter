/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

/// <summary>
/// Attaching this script to an object will make that object face the specified target.
/// The most ideal use for this script is to attach it to the camera and make the camera look at its target.
/// </summary>

[AddComponentMenu("NGUI/Examples/Look At Target")]
public class LookAtTarget : MonoBehaviour
{
	public int level = 0;
	public Transform target;
	public float speed = 8f;

	Transform mTrans;

	void Start ()
	{
		mTrans = transform;
	}

	void LateUpdate ()
	{
		if (target != null)
		{
			Vector3 dir = target.position - mTrans.position;
			float mag = dir.magnitude;

			if (mag > 0.001f)
			{
				Quaternion lookRot = Quaternion.LookRotation(dir);
				mTrans.rotation = Quaternion.Slerp(mTrans.rotation, lookRot, Mathf.Clamp01(speed * Time.deltaTime));
			}
		}
	}
}
