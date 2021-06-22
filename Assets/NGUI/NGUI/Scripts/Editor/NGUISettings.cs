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
/// Unity doesn't keep the values of static variables after scripts change get recompiled. One way around this
/// is to store the references in EditorPrefs -- retrieve them at start, and save them whenever something changes.
/// </summary>

public class NGUISettings
{
	static bool mLoaded = false;
	static UIFont mFont;
	static UIAtlas mAtlas;
	static UIWidget.Pivot mPivot = UIWidget.Pivot.Center;
	static TextAsset mFontData;
	static Texture2D mFontTexture;
	static string mPartial = "";
	static string mFontName = "New Font";
	static string mAtlasName = "New Atlas";
	static int mAtlasPadding = 1;
	static public bool mAtlasTrimming = true;
	static bool mUnityPacking = true;

	static Object GetObject (string name)
	{
		int assetID = EditorPrefs.GetInt(name, -1);
		return (assetID != -1) ? EditorUtility.InstanceIDToObject(assetID) : null;
	}

	static void Load ()
	{
		mLoaded			= true;
		mPartial		= EditorPrefs.GetString("NGUI Partial");
		mFontName		= EditorPrefs.GetString("NGUI Font Name");
		mAtlasName		= EditorPrefs.GetString("NGUI Atlas Name");
		mFontData		= GetObject("NGUI Font Asset") as TextAsset;
		mFontTexture	= GetObject("NGUI Font Texture") as Texture2D;
		mFont			= GetObject("NGUI Font") as UIFont;
		mAtlas			= GetObject("NGUI Atlas") as UIAtlas;
		mAtlasPadding	= EditorPrefs.GetInt("NGUI Atlas Padding", 1);
		mAtlasTrimming	= EditorPrefs.GetBool("NGUI Atlas Trimming", true);
		mUnityPacking	= EditorPrefs.GetBool("NGUI Unity Packing", true);
		mPivot			= (UIWidget.Pivot)EditorPrefs.GetInt("NGUI Pivot", (int)mPivot);
	}

	static void Save ()
	{
		EditorPrefs.SetString("NGUI Partial", mPartial);
		EditorPrefs.SetString("NGUI Font Name", mFontName);
		EditorPrefs.SetString("NGUI Atlas Name", mAtlasName);
		EditorPrefs.SetInt("NGUI Font Asset", (mFontData != null) ? mFontData.GetInstanceID() : -1);
		EditorPrefs.SetInt("NGUI Font Texture", (mFontTexture != null) ? mFontTexture.GetInstanceID() : -1);
		EditorPrefs.SetInt("NGUI Font", (mFont != null) ? mFont.GetInstanceID() : -1);
		EditorPrefs.SetInt("NGUI Atlas", (mAtlas != null) ? mAtlas.GetInstanceID() : -1);
		EditorPrefs.SetInt("NGUI Atlas Padding", mAtlasPadding);
		EditorPrefs.SetBool("NGUI Atlas Trimming", mAtlasTrimming);
		EditorPrefs.SetBool("NGUI Unity Packing", mUnityPacking);
		EditorPrefs.SetInt("NGUI Pivot", (int)mPivot);
	}

	/// <summary>
	/// Default font used by NGUI.
	/// </summary>

	static public UIFont font
	{
		get
		{
			if (!mLoaded) Load();
			return mFont;
		}
		set
		{
			if (mFont != value)
			{
				mFont = value;
				mFontName = (mFont != null) ? mFont.name : "New Font";
				Save();
			}
		}
	}

	/// <summary>
	/// Default atlas used by NGUI.
	/// </summary>

	static public UIAtlas atlas
	{
		get
		{
			if (!mLoaded) Load();
			return mAtlas;
		}
		set
		{
			if (mAtlas != value)
			{
				mAtlas = value;
				mAtlasName = (mAtlas != null) ? mAtlas.name : "New Atlas";
				Save();
			}
		}
	}

	/// <summary>
	/// Default pivot point used by sprites.
	/// </summary>

	static public UIWidget.Pivot pivot
	{
		get
		{
			if (!mLoaded) Load();
			return mPivot;
		}
		set
		{
			if (mPivot != value)
			{
				mPivot = value;
				Save();
			}
		}
	}

	/// <summary>
	/// Name of the font, used by the Font Maker.
	/// </summary>

	static public string fontName { get { if (!mLoaded) Load(); return mFontName; } set { if (mFontName != value) { mFontName = value; Save(); } } }

	/// <summary>
	/// Data used to create the font, used by the Font Maker.
	/// </summary>

	static public TextAsset fontData { get { if (!mLoaded) Load(); return mFontData; } set { if (mFontData != value) { mFontData = value; Save(); } } }

	/// <summary>
	/// Texture used to create the font, used by the Font Maker.
	/// </summary>

	static public Texture2D fontTexture { get { if (!mLoaded) Load(); return mFontTexture; } set { if (mFontTexture != value) { mFontTexture = value; Save(); } } }

	/// <summary>
	/// Name of the atlas, used by the Atlas maker.
	/// </summary>

	static public string atlasName { get { if (!mLoaded) Load(); return mAtlasName; } set { if (mAtlasName != value) { mAtlasName = value; Save(); } } }

	/// <summary>
	/// Name of the partial sprite name, used to filter sprites.
	/// </summary>

	static public string partialSprite
	{
		get
		{
			if (!mLoaded) Load();
			return mPartial;
		}
		set
		{
			if (mPartial != value)
			{
				mPartial = value;
				EditorPrefs.SetString("NGUI Partial", mPartial);
			}
		}
	}

	/// <summary>
	/// Added padding in-between of sprites when creating an atlas.
	/// </summary>

	static public int atlasPadding { get { if (!mLoaded) Load(); return mAtlasPadding; } set { if (mAtlasPadding != value) { mAtlasPadding = value; Save(); } } }

	/// <summary>
	/// Whether the transparent pixels will be trimmed away when creating an atlas.
	/// </summary>

	static public bool atlasTrimming { get { if (!mLoaded) Load(); return mAtlasTrimming; } set { if (mAtlasTrimming != value) { mAtlasTrimming = value; Save(); } } }

	/// <summary>
	/// Whether Unity's method or MaxRectBinPack will be used when creating an atlas
	/// </summary>

	static public bool unityPacking { get { if (!mLoaded) Load(); return mUnityPacking; } set { if (mUnityPacking != value) { mUnityPacking = value; Save(); } } }
}
