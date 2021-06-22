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
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// Inspector class used to edit UITextures.
/// </summary>

[CustomEditor(typeof(UITexture))]
public class UITextureInspector : UIWidgetInspector
{
	UITexture mTex;

	override protected bool OnDrawProperties ()
	{
		mTex = mWidget as UITexture;

		if (!mTex.hasDynamicMaterial && (mTex.material != null || mTex.mainTexture == null))
		{
			Material mat = EditorGUILayout.ObjectField("Material", mTex.material, typeof(Material), false) as Material;

			if (mTex.material != mat)
			{
				NGUIEditorTools.RegisterUndo("Material Selection", mTex);
				mTex.material = mat;
			}
		}

		if (mTex.material == null || mTex.hasDynamicMaterial)
		{
			Shader shader = EditorGUILayout.ObjectField("Shader", mTex.shader, typeof(Shader), false) as Shader;

			if (mTex.shader != shader)
			{
				NGUIEditorTools.RegisterUndo("Shader Selection", mTex);
				mTex.shader = shader;
			}

			Texture tex = EditorGUILayout.ObjectField("Texture", mTex.mainTexture, typeof(Texture), false) as Texture;

			if (mTex.mainTexture != tex)
			{
				NGUIEditorTools.RegisterUndo("Texture Selection", mTex);
				mTex.mainTexture = tex;
			}
		}

		if (mTex.mainTexture != null)
		{
			Rect rect = EditorGUILayout.RectField("UV Rectangle", mTex.uvRect);

			if (rect != mTex.uvRect)
			{
				NGUIEditorTools.RegisterUndo("UV Rectangle Change", mTex);
				mTex.uvRect = rect;
			}
		}
		return (mWidget.material != null);
	}
}
