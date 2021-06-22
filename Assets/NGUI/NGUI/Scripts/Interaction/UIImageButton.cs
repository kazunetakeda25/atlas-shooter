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
/// Sample script showing how easy it is to implement a standard button that swaps sprites.
/// </summary>

[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Image Button")]
public class UIImageButton : MonoBehaviour
{
	public UISprite target;
	public string normalSprite;
	public string hoverSprite;
	public string pressedSprite;

	void OnEnable ()
	{
		if (target != null)
		{
			target.spriteName = UICamera.IsHighlighted(gameObject) ? hoverSprite : normalSprite;
		}
	}

	void Start ()
	{
		if (target == null) target = GetComponentInChildren<UISprite>();
	}

	void OnHover (bool isOver)
	{
		if (enabled && target != null)
		{
			target.spriteName = isOver ? hoverSprite : normalSprite;
			target.MakePixelPerfect();
		}
	}

	void OnPress (bool pressed)
	{
		if (enabled && target != null)
		{
			target.spriteName = pressed ? pressedSprite : normalSprite;
			target.MakePixelPerfect();
		}
	}
}
