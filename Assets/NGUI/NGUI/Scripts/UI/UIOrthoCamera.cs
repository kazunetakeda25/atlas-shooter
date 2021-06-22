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
/// Convenience script that resizes the camera's orthographic size to match the screen size.
/// This script can be used to create pixel-perfect UI, however it's usually more convenient
/// to create the UI that stays proportional as the screen scales. If that is what you
/// want, you don't need this script (or at least don't need it to be active).
/// </summary>

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/UI/Orthographic Camera")]
public class UIOrthoCamera : MonoBehaviour
{
	Camera mCam;
	Transform mTrans;

	void Start ()
	{
		mCam = camera;
		mTrans = transform;
		mCam.orthographic = true;
	}

	void Update ()
	{
		float y0 = mCam.rect.yMin * Screen.height;
		float y1 = mCam.rect.yMax * Screen.height;

		float size = (y1 - y0) * 0.5f * mTrans.lossyScale.y;
		if (!Mathf.Approximately(mCam.orthographicSize, size)) mCam.orthographicSize = size;
	}
}
