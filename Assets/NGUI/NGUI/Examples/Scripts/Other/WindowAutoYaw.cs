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
/// Attaching this script to an object will make it turn as it gets closer to left/right edges of the screen.
/// Look at how it's used in Example 6.
/// </summary>

[AddComponentMenu("NGUI/Examples/Window Auto-Yaw")]
public class WindowAutoYaw : MonoBehaviour
{
	public int updateOrder = 0;
	public Camera uiCamera;
	public float yawAmount = 20f;

	Transform mTrans;

	void OnDisable ()
	{
		mTrans.localRotation = Quaternion.identity;
	}

	void Start ()
	{
		if (uiCamera == null) uiCamera = NGUITools.FindCameraForLayer(gameObject.layer);
		mTrans = transform;
		UpdateManager.AddCoroutine(this, updateOrder, CoroutineUpdate);
	}

	void CoroutineUpdate (float delta)
	{
		if (uiCamera != null)
		{
			Vector3 pos = uiCamera.WorldToViewportPoint(mTrans.position);
			mTrans.localRotation = Quaternion.Euler(0f, (pos.x * 2f - 1f) * yawAmount, 0f);
		}
	}
}
