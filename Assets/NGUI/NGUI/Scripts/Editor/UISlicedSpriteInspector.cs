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
/// Inspector class used to edit UISlicedSprites.
/// </summary>

[CustomEditor(typeof(UISlicedSprite))]
public class UISlicedSpriteInspector : UISpriteInspector
{
	/// <summary>
	/// Draw the atlas and sprite selection fields.
	/// </summary>

	override protected bool OnDrawProperties ()
	{
		if (base.OnDrawProperties())
		{
			UISlicedSprite sp = mSprite as UISlicedSprite;
			bool fill = EditorGUILayout.Toggle("Fill Center", sp.fillCenter);

			if (sp.fillCenter != fill)
			{
				NGUIEditorTools.RegisterUndo("Sprite Change", sp);
				sp.fillCenter = fill;
				EditorUtility.SetDirty(sp.gameObject);
			}
			return true;
		}
		return false;
	}
}
