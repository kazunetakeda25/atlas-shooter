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
/// Editable text input field that automatically saves its data to PlayerPrefs.
/// </summary>

[AddComponentMenu("NGUI/UI/Input (Saved)")]
public class UIInputSaved : UIInput
{
	public string playerPrefsField;

	void Start ()
	{
		if (!string.IsNullOrEmpty(playerPrefsField) && PlayerPrefs.HasKey(playerPrefsField))
		{
			text = PlayerPrefs.GetString(playerPrefsField);
		}
	}

	void OnApplicationQuit ()
	{
		if (!string.IsNullOrEmpty(playerPrefsField))
		{
			PlayerPrefs.SetString(playerPrefsField, text);
		}
	}
}
