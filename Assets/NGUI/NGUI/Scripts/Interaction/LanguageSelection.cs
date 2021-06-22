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
using System.Collections.Generic;

/// <summary>
/// Turns the popup list it's attached to into a language selection list.
/// </summary>

[RequireComponent(typeof(UIPopupList))]
[AddComponentMenu("NGUI/Interaction/Language Selection")]
public class LanguageSelection : MonoBehaviour
{
	UIPopupList mList;

	void Start ()
	{
		mList = GetComponent<UIPopupList>();
		UpdateList();
		mList.eventReceiver = gameObject;
		mList.functionName = "OnLanguageSelection";
	}

	void UpdateList ()
	{
		if (Localization.instance != null && Localization.instance.languages != null)
		{
			mList.items.Clear();

			for (int i = 0, imax = Localization.instance.languages.Length; i < imax; ++i)
			{
				TextAsset asset = Localization.instance.languages[i];
				if (asset != null) mList.items.Add(asset.name);
			}
			mList.selection = Localization.instance.currentLanguage;
		}
	}

	void OnLanguageSelection (string language)
	{
		if (Localization.instance != null)
		{
			Localization.instance.currentLanguage = language;
		}
	}
}
