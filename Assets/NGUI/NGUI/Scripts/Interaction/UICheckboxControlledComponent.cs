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
/// Example script showing how to activate or deactivate a MonoBehaviour when OnActivate event is received.
/// OnActivate event is sent out by the UICheckbox script.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Checkbox Controlled Component")]
public class UICheckboxControlledComponent : MonoBehaviour
{
	public MonoBehaviour target;
	public bool inverse = false;

	bool mUsingDelegates = false;

	void Start ()
	{
		UICheckbox chk = GetComponent<UICheckbox>();

		if (chk != null)
		{
			mUsingDelegates = true;
			chk.onStateChange += OnActivateDelegate;
		}
	}

	void OnActivateDelegate (bool isActive)
	{
		if (enabled && target != null) target.enabled = inverse ? !isActive : isActive;
	}

	/// <summary>
	/// Legacy functionality -- keeping it for backwards compatibility.
	/// </summary>

	void OnActivate (bool isActive) { if (!mUsingDelegates) OnActivateDelegate(isActive); }
}
