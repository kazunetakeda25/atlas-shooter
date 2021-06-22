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
using System.Collections.Generic;

/// <summary>
/// Inspector class used to edit UISprites.
/// </summary>

[CustomEditor(typeof(UIImageButton))]
public class UIImageButtonInspector : Editor
{
	UIImageButton mButton;
	UISprite mSprite;

	/// <summary>
	/// Atlas selection callback.
	/// </summary>

	void OnSelectAtlas (MonoBehaviour obj)
	{
		if (mButton.target != null)
		{
			NGUIEditorTools.RegisterUndo("Atlas Selection", mButton.target);
			mButton.target.atlas = obj as UIAtlas;
			mButton.target.MakePixelPerfect();
		}
	}

	public override void OnInspectorGUI ()
	{
		EditorGUIUtility.LookLikeControls(80f);
		mButton = target as UIImageButton;
		mSprite = EditorGUILayout.ObjectField("Sprite", mButton.target, typeof(UISprite), true) as UISprite;

		if (mButton.target != mSprite)
		{
			NGUIEditorTools.RegisterUndo("Image Button Change", mButton);
			mButton.target = mSprite;
			if (mSprite != null) mSprite.spriteName = mButton.normalSprite;
		}

		if (mSprite != null)
		{
			ComponentSelector.Draw<UIAtlas>(mSprite.atlas, OnSelectAtlas);

			if (mSprite.atlas != null)
			{
				NGUIEditorTools.SpriteField("Normal", mSprite.atlas, mButton.normalSprite, OnNormal);
				NGUIEditorTools.SpriteField("Hover", mSprite.atlas, mButton.hoverSprite, OnHover);
				NGUIEditorTools.SpriteField("Pressed", mSprite.atlas, mButton.pressedSprite, OnPressed);
			}
		}
	}

	void OnNormal (string spriteName)
	{
		NGUIEditorTools.RegisterUndo("Image Button Change", mButton, mButton.gameObject, mSprite);
		mButton.normalSprite = spriteName;
		mSprite.spriteName = spriteName;
		mSprite.MakePixelPerfect();
		if (mButton.collider == null || (mButton.collider is BoxCollider)) NGUITools.AddWidgetCollider(mButton.gameObject);
		Repaint();
	}

	void OnHover (string spriteName)
	{
		NGUIEditorTools.RegisterUndo("Image Button Change", mButton, mButton.gameObject, mSprite);
		mButton.hoverSprite = spriteName;
		Repaint();
	}

	void OnPressed (string spriteName)
	{
		NGUIEditorTools.RegisterUndo("Image Button Change", mButton, mButton.gameObject, mSprite);
		mButton.pressedSprite = spriteName;
		Repaint();
	}
}
