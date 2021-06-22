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

namespace AnimationOrTween
{
	public enum Trigger
	{
		OnClick,
		OnHover,
		OnPress,
		OnHoverTrue,
		OnHoverFalse,
		OnPressTrue,
		OnPressFalse,
		OnActivate,
		OnActivateTrue,
		OnActivateFalse,
		OnDoubleClick,
		OnSelect,
		OnSelectTrue,
		OnSelectFalse,
	}

	public enum Direction
	{
		Reverse = -1,
		Toggle = 0,
		Forward = 1,
	}

	public enum EnableCondition
	{
		DoNothing = 0,
		EnableThenPlay,
	}

	public enum DisableCondition
	{
		DisableAfterReverse = -1,
		DoNotDisable = 0,
		DisableAfterForward = 1,
	}
}
