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
/// Simple script that lets you localize a UIWidget.
/// </summary>

[RequireComponent(typeof(UIWidget))]
[AddComponentMenu("NGUI/UI/Localize")]
public class UILocalize : MonoBehaviour
{
	/// <summary>
	/// Localization key.
	/// </summary>

	public string key;

	string mLanguage;
	bool mStarted = false;

	/// <summary>
	/// This function is called by the Localization manager via a broadcast SendMessage.
	/// </summary>

	void OnLocalize (Localization loc) { if (mLanguage != loc.currentLanguage) Localize(); }

	/// <summary>
	/// Localize the widget on enable, but only if it has been started already.
	/// </summary>

	void OnEnable () { if (mStarted && Localization.instance != null) Localize(); }

	/// <summary>
	/// Localize the widget on start.
	/// </summary>

	void Start ()
	{
		mStarted = true;
		if (Localization.instance != null) Localize();
	}

	/// <summary>
	/// Force-localize the widget.
	/// </summary>

	public void Localize ()
	{
		Localization loc = Localization.instance;
		UIWidget w = GetComponent<UIWidget>();
		UILabel lbl = w as UILabel;
		UISprite sp = w as UISprite;

		// If no localization key has been specified, use the label's text as the key
		if (string.IsNullOrEmpty(mLanguage) && string.IsNullOrEmpty(key) && lbl != null) key = lbl.text;

		// If we still don't have a key, use the widget's name
		string val = string.IsNullOrEmpty(key) ? loc.Get(w.name) : loc.Get(key);

		if (lbl != null)
		{
			lbl.text = val;
		}
		else if (sp != null)
		{
			sp.spriteName = val;
			sp.MakePixelPerfect();
		}
		mLanguage = loc.currentLanguage;
	}
}
