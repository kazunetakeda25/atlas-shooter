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

[CustomEditor(typeof(UISprite))]
public class UISpriteInspector : UIWidgetInspector
{
	protected UISprite mSprite;

	/// <summary>
	/// Atlas selection callback.
	/// </summary>

	void OnSelectAtlas (MonoBehaviour obj)
	{
		if (mSprite != null)
		{
			NGUIEditorTools.RegisterUndo("Atlas Selection", mSprite);
			bool resize = (mSprite.atlas == null);
			mSprite.atlas = obj as UIAtlas;
			if (resize) mSprite.MakePixelPerfect();
			EditorUtility.SetDirty(mSprite.gameObject);
		}
	}

	/// <summary>
	/// Sprite selection callback function.
	/// </summary>

	void SelectSprite (string spriteName)
	{
		if (mSprite != null && mSprite.spriteName != spriteName)
		{
			NGUIEditorTools.RegisterUndo("Sprite Change", mSprite);
			mSprite.spriteName = spriteName;
			mSprite.MakePixelPerfect();
			EditorUtility.SetDirty(mSprite.gameObject);
		}
	}

	/// <summary>
	/// Draw the atlas and sprite selection fields.
	/// </summary>

	override protected bool OnDrawProperties ()
	{
		mSprite = mWidget as UISprite;
		ComponentSelector.Draw<UIAtlas>(mSprite.atlas, OnSelectAtlas);
		if (mSprite.atlas == null) return false;
		NGUIEditorTools.AdvancedSpriteField(mSprite.atlas, mSprite.spriteName, SelectSprite, false);
		return true;
	}

	/// <summary>
	/// All widgets have a preview.
	/// </summary>

	public override bool HasPreviewGUI () { return true; }

	/// <summary>
	/// Draw the sprite preview.
	/// </summary>

	public override void OnPreviewGUI (Rect rect, GUIStyle background)
	{
		if (mSprite == null) return;

		Texture2D tex = mSprite.mainTexture as Texture2D;
		if (tex == null) return;

		Rect outer = new Rect(mSprite.sprite.outer);
		Rect inner = new Rect(mSprite.sprite.inner);
		Rect uv = outer;

		if (mSprite.atlas.coordinates == UIAtlas.Coordinates.Pixels)
		{
			uv = NGUIMath.ConvertToTexCoords(outer, tex.width, tex.height);
		}
		else
		{
			outer = NGUIMath.ConvertToPixels(outer, tex.width, tex.height, true);
			inner = NGUIMath.ConvertToPixels(inner, tex.width, tex.height, true);
		}
		NGUIEditorTools.DrawSprite(tex, rect, outer, inner, uv, mSprite.color);
	}
}
