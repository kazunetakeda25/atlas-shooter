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
/// Placing this script on the game object will make that game object pan with mouse movement.
/// </summary>

[AddComponentMenu("NGUI/Examples/Pan With Mouse")]
public class PanWithMouse : IgnoreTimeScale
{
	public Vector2 degrees = new Vector2(5f, 3f);
	public float range = 1f;

	Transform mTrans;
	Quaternion mStart;
	Vector2 mRot = Vector2.zero;

	void Start ()
	{
		mTrans = transform;
		mStart = mTrans.localRotation;
	}

	void Update ()
	{
		float delta = UpdateRealTimeDelta();
		Vector3 pos = Input.mousePosition;

		float halfWidth = Screen.width * 0.5f;
		float halfHeight = Screen.height * 0.5f;
		if (range < 0.1f) range = 0.1f;
		float x = Mathf.Clamp((pos.x - halfWidth) / halfWidth / range, -1f, 1f);
		float y = Mathf.Clamp((pos.y - halfHeight) / halfHeight / range, -1f, 1f);
		mRot = Vector2.Lerp(mRot, new Vector2(x, y), delta * 5f);

		mTrans.localRotation = mStart * Quaternion.Euler(-mRot.y * degrees.y, mRot.x * degrees.x, 0f);
	}
}
