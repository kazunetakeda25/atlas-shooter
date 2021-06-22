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
using System.Collections.Generic;

/// <summary>
/// UIPanel creates one of these records for each child transform under it.
/// This makes it possible to watch for transform changes, and if something does
/// change -- rebuild the buffer as necessary.
/// </summary>

public class UINode
{
	int mVisibleFlag = -1;

	public Transform trans;			// Managed transform
	public UIWidget widget;			// Widget on this transform, if any

	public bool lastActive = false;	// Last active state
	public Vector3 lastPos;			// Last local position, used to see if it has changed
	public Quaternion lastRot;		// Last local rotation
	public Vector3 lastScale;		// Last local scale

	public int changeFlag = -1;		// -1 = not checked, 0 = not changed, 1 = changed

	GameObject mGo;

	/// <summary>
	/// -1 = not initialized, 0 = not visible, 1 = visible.
	/// </summary>

	public int visibleFlag
	{
		get
		{
			return (widget != null) ? widget.visibleFlag : mVisibleFlag;
		}
		set
		{
			if (widget != null) widget.visibleFlag = value;
			else mVisibleFlag = value;
		}
	}

	/// <summary>
	/// Must always have a transform.
	/// </summary>

	public UINode (Transform t)
	{
		trans = t;
		lastPos = trans.localPosition;
		lastRot = trans.localRotation;
		lastScale = trans.localScale;
		mGo = t.gameObject;
	}

	/// <summary>
	/// Check to see if the local transform has changed since the last time this function was called.
	/// </summary>

	public bool HasChanged ()
	{
		bool isActive = NGUITools.GetActive(mGo) && (widget == null || (widget.enabled && widget.color.a > 0.001f));

		if (lastActive != isActive || (isActive &&
			(lastPos != trans.localPosition ||
			 lastRot != trans.localRotation ||
			 lastScale != trans.localScale)))
		{
			lastActive = isActive;
			lastPos = trans.localPosition;
			lastRot = trans.localRotation;
			lastScale = trans.localScale;
			return true;
		}
		return false;
	}
}
