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
/// Attach this script to a child of a draggable window to make it tilt as it's dragged.
/// Look at how it's used in Example 6.
/// </summary>

[AddComponentMenu("NGUI/Examples/Window Drag Tilt")]
public class WindowDragTilt : MonoBehaviour
{
	public int updateOrder = 0;
	public float degrees = 30f;

	Vector3 mLastPos;
	Transform mTrans;
	float mAngle = 0f;
	bool mInit = true;

	void Start () { UpdateManager.AddCoroutine(this, updateOrder, CoroutineUpdate); }
	void OnEnable () { mInit = true; }

	void CoroutineUpdate (float delta)
	{
		if (mInit)
		{
			mInit = false;
			mTrans = transform;
			mLastPos = mTrans.position;
		}

		Vector3 deltaPos = mTrans.position - mLastPos;
		mLastPos = mTrans.position;

		mAngle += deltaPos.x * degrees;
		mAngle = NGUIMath.SpringLerp(mAngle, 0f, 20f, delta);

		mTrans.localRotation = Quaternion.Euler(0f, 0f, -mAngle);
	}
}
