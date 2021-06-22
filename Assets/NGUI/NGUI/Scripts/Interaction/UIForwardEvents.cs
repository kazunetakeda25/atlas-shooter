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
/// This script can be used to forward events from one object to another.
/// In most cases you should use UIEventListener script instead. For example:
/// UIEventListener.Get(gameObject).onClick += MyClickFunction;
/// </summary>

[AddComponentMenu("NGUI/Interaction/Forward Events")]
public class UIForwardEvents : MonoBehaviour
{
	public GameObject target;
	public bool onHover			= false;
	public bool onPress			= false;
	public bool onClick			= false;
	public bool onDoubleClick	= false;
	public bool onSelect		= false;
	public bool onDrag			= false;
	public bool onDrop			= false;
	public bool onInput			= false;
	public bool onSubmit		= false;

	void OnHover (bool isOver)
	{
		if (onHover && target != null)
		{
			target.SendMessage("OnHover", isOver, SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnPress (bool pressed)
	{
		if (onPress && target != null)
		{
			target.SendMessage("OnPress", pressed, SendMessageOptions.DontRequireReceiver);
		}
	}
	
	void OnClick ()
	{
		if (onClick && target != null)
		{
			target.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnDoubleClick ()
	{
		if (onDoubleClick && target != null)
		{
			target.SendMessage("OnDoubleClick", SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnSelect (bool selected)
	{
		if (onSelect && target != null)
		{
			target.SendMessage("OnSelect", selected, SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnDrag (Vector2 delta)
	{
		if (onDrag && target != null)
		{
			target.SendMessage("OnDrag", delta, SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnDrop (GameObject go)
	{
		if (onDrop && target != null)
		{
			target.SendMessage("OnDrop", go, SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnInput (string text)
	{
		if (onInput && target != null)
		{
			target.SendMessage("OnInput", text, SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnSubmit ()
	{
		if (onSubmit && target != null)
		{
			target.SendMessage("OnSubmit", SendMessageOptions.DontRequireReceiver);
		}
	}
}
