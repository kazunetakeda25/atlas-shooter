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
using UnityEditor;

/// <summary>
/// Inspector class used to edit UIFilledSprites.
/// </summary>

[CustomEditor(typeof(UIFilledSprite))]
public class UIFilledSpriteInspector : UISpriteInspector
{
	override protected bool OnDrawProperties()
	{
		UIFilledSprite sprite = mWidget as UIFilledSprite;

		if (!base.OnDrawProperties()) return false;

		if ((int)sprite.fillDirection > (int)UIFilledSprite.FillDirection.Radial360)
		{
			sprite.fillDirection = UIFilledSprite.FillDirection.Horizontal;
			EditorUtility.SetDirty(sprite);
		}

		UIFilledSprite.FillDirection fillDirection = (UIFilledSprite.FillDirection)EditorGUILayout.EnumPopup("Fill Dir", sprite.fillDirection);
		float fillAmount = EditorGUILayout.Slider("Fill Amount", sprite.fillAmount, 0f, 1f);
		bool invert = EditorGUILayout.Toggle("Invert Fill", sprite.invert);

		if (sprite.fillDirection != fillDirection || sprite.fillAmount != fillAmount || sprite.invert != invert)
		{
			NGUIEditorTools.RegisterUndo("Sprite Change", mSprite);
			sprite.fillDirection = fillDirection;
			sprite.fillAmount = fillAmount;
			sprite.invert = invert;
			EditorUtility.SetDirty(sprite);
		}
		return true;
	}
}
