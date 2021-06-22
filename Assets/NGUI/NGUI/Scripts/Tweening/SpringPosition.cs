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
/// Spring-like motion -- the farther away the object is from the target, the stronger the pull.
/// </summary>

[AddComponentMenu("NGUI/Tween/Spring Position")]
public class SpringPosition : IgnoreTimeScale
{
	public delegate void OnFinished (SpringPosition spring);

	/// <summary>
	/// Target position to tween to.
	/// </summary>

	public Vector3 target = Vector3.zero;

	/// <summary>
	/// How strong is the pull of the spring. Higher value means it gets to the target faster.
	/// </summary>

	public float strength = 10f;

	/// <summary>
	/// Is the calculation done in world space or local space?
	/// </summary>

	public bool worldSpace = false;

	/// <summary>
	/// Whether the time scale will be ignored. Generally UI components should set it to 'true'.
	/// </summary>

	public bool ignoreTimeScale = false;

	/// <summary>
	/// Game object on which to call the callback function.
	/// </summary>

	public GameObject eventReceiver;

	/// <summary>
	/// Function to call when the spring finishes moving.
	/// </summary>

	public string callWhenFinished;

	/// <summary>
	/// Delegate to trigger when the spring finishes.
	/// </summary>

	public OnFinished onFinished;

	Transform mTrans;
	float mThreshold = 0f;

	/// <summary>
	/// Cache the transform.
	/// </summary>

	void Start () { mTrans = transform; }

	/// <summary>
	/// Advance toward the target position.
	/// </summary>

	void Update ()
	{
		float delta = ignoreTimeScale ? UpdateRealTimeDelta() : Time.deltaTime;

		if (worldSpace)
		{
			if (mThreshold == 0f) mThreshold = (target - mTrans.position).magnitude * 0.001f;
			mTrans.position = NGUIMath.SpringLerp(mTrans.position, target, strength, delta);

			if (mThreshold >= (target - mTrans.position).magnitude)
			{
				mTrans.position = target;
				
				if (onFinished != null) onFinished(this);
				
				if (eventReceiver != null && !string.IsNullOrEmpty(callWhenFinished))
				{
					eventReceiver.SendMessage(callWhenFinished, this, SendMessageOptions.DontRequireReceiver);
				}
				enabled = false;
			}
		}
		else
		{
			if (mThreshold == 0f) mThreshold = (target - mTrans.localPosition).magnitude * 0.001f;
			mTrans.localPosition = NGUIMath.SpringLerp(mTrans.localPosition, target, strength, delta);

			if (mThreshold >= (target - mTrans.localPosition).magnitude)
			{
				mTrans.localPosition = target;
				
				if (onFinished != null) onFinished(this);

				if (eventReceiver != null && !string.IsNullOrEmpty(callWhenFinished))
				{
					eventReceiver.SendMessage(callWhenFinished, this, SendMessageOptions.DontRequireReceiver);
				}
				enabled = false;
			}
		}
	}

	/// <summary>
	/// Start the tweening process.
	/// </summary>

	static public SpringPosition Begin (GameObject go, Vector3 pos, float strength)
	{
		SpringPosition sp = go.GetComponent<SpringPosition>();
		if (sp == null) sp = go.AddComponent<SpringPosition>();
		sp.target = pos;
		sp.strength = strength;
		sp.onFinished = null;

		if (!sp.enabled)
		{
			sp.mThreshold = 0f;
			sp.enabled = true;
		}
		return sp;
	}
}
