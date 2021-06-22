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
/// Tween the camera's field of view.
/// </summary>

[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/Tween/Field of View")]
public class TweenFOV : UITweener
{
	public float from;
	public float to;

	Camera mCam;

	public Camera cachedCamera { get { if (mCam == null) mCam = camera; return mCam; } }
	public float fov { get { return cachedCamera.fov; } set { cachedCamera.fov = value; } }

	override protected void OnUpdate (float factor, bool isFinished) { cachedCamera.fov = from * (1f - factor) + to * factor; }

	/// <summary>
	/// Start the tweening operation.
	/// </summary>

	static public TweenFOV Begin (GameObject go, float duration, float to)
	{
		TweenFOV comp = UITweener.Begin<TweenFOV>(go, duration);
		comp.from = comp.fov;
		comp.to = to;
		return comp;
	}
}
