/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Similar to SpringPosition, but also moves the panel's clipping. Works in local coordinates.
/// </summary>

[RequireComponent(typeof(UIPanel))]
[AddComponentMenu("NGUI/Internal/Spring Panel")]
public class SpringPanel : IgnoreTimeScale
{
	public Vector3 target = Vector3.zero;
	public float strength = 10f;

	UIPanel mPanel;
	Transform mTrans;
	float mThreshold = 0f;
	UIDraggablePanel mDrag;

	/// <summary>
	/// Cache the transform.
	/// </summary>

	void Start ()
	{
		mPanel = GetComponent<UIPanel>();
		mDrag = GetComponent<UIDraggablePanel>();
		mTrans = transform;
	}

	/// <summary>
	/// Advance toward the target position.
	/// </summary>

	void Update ()
	{
		float delta = UpdateRealTimeDelta();

		if (mThreshold == 0f) mThreshold = (target - mTrans.localPosition).magnitude * 0.005f;

		Vector3 before = mTrans.localPosition;
		Vector3 after = NGUIMath.SpringLerp(mTrans.localPosition, target, strength, delta);

		if (mThreshold >= Vector3.Magnitude(after - target))
		{
			after = target;
			enabled = false;
		}
		mTrans.localPosition = after;

		Vector3 offset = after - before;
		Vector4 cr = mPanel.clipRange;
		cr.x -= offset.x;
		cr.y -= offset.y;
		mPanel.clipRange = cr;

		if (mDrag != null) mDrag.UpdateScrollbars(false);
	}

	/// <summary>
	/// Start the tweening process.
	/// </summary>

	static public SpringPanel Begin (GameObject go, Vector3 pos, float strength)
	{
		SpringPanel sp = go.GetComponent<SpringPanel>();
		if (sp == null) sp = go.AddComponent<SpringPanel>();
		sp.target = pos;
		sp.strength = strength;

		if (!sp.enabled)
		{
			sp.mThreshold = 0f;
			sp.enabled = true;
		}
		return sp;
	}
}
