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
// Copyright � 2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// This script makes it easy to change the alpha of all widgets at once.
/// Useful for fading out a window via a Unity Animation, for example.
/// Automatically disables colliders and game objects when needed.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Panel Alpha")]
public class UIPanelAlpha : MonoBehaviour
{
	public float alpha = 1f;

	Collider[] mColliders;
	UIWidget[] mWidgets;
	float[] mAlpha;
	float mLastAlpha = 1f;
	int mLevel = 2;

	void Start ()
	{
		mColliders = GetComponentsInChildren<Collider>(true);
		mWidgets = GetComponentsInChildren<UIWidget>(true);

		if (mWidgets.Length == 0)
		{
			Debug.LogError("Expected to find widgets to work with", this);
			enabled = false;
			return;
		}

		// Remember the initial alpha
		mAlpha = new float[mWidgets.Length];
		for (int i = 0, imax = mWidgets.Length; i < imax; ++i) mAlpha[i] = mWidgets[i].alpha;

		// Set the initial fade level
		mLastAlpha = Mathf.Clamp01(alpha);
		mLevel = (mLastAlpha > 0.99f) ? 2 : (mLastAlpha < 0.01f ? 0 : 1);

		UpdateAlpha();
	}

	void Update ()
	{
		alpha = Mathf.Clamp01(alpha);

		if (mLastAlpha != alpha)
		{
			mLastAlpha = alpha;
			UpdateAlpha();
		}
	}

	void UpdateAlpha ()
	{
		// Update the widget alpha
		for (int i = 0, imax = mWidgets.Length; i < imax; ++i)
		{
			UIWidget w = mWidgets[i];
			if (w != null) w.alpha = mAlpha[i] * alpha;
		}

		if (mLevel == 0)
		{
			// Fade in started -- enable all game objects
			Transform trans = transform;
			for (int i = 0, imax = trans.childCount; i < imax; ++i) NGUITools.SetActive(trans.GetChild(i).gameObject, true);
			for (int i = 0, imax = mColliders.Length; i < imax; ++i) mColliders[i].enabled = false;
			mLevel = 1;
		}
		else if (mLevel == 2 && alpha < 0.99f)
		{
			// Fade out started -- disable tweens and colliders
			TweenColor[] tweens = GetComponentsInChildren<TweenColor>();
			for (int i = 0, imax = tweens.Length; i < imax; ++i) tweens[i].enabled = false;
			for (int i = 0, imax = mColliders.Length; i < imax; ++i) mColliders[i].enabled = false;
			mLevel = 1;
		}

		if (mLevel == 1)
		{
			if (alpha < 0.01f)
			{
				// Fade out finished -- disable all game objects
				Transform trans = transform;
				for (int i = 0, imax = trans.childCount; i < imax; ++i) NGUITools.SetActive(trans.GetChild(i).gameObject, false);
				mLevel = 0;
			}
			else if (alpha > 0.99f)
			{
				// Fade in finished -- enable all colliders
				for (int i = 0, imax = mColliders.Length; i < imax; ++i) mColliders[i].enabled = true;
				mLevel = 2;
			}
		}
	}
}
