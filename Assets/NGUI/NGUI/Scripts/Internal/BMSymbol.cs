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
using System.Collections.Generic;

/// <summary>
/// Symbols are a sequence of characters such as ":)" that get replaced with a single glyph, such as the smiley face.
/// </summary>

[System.Serializable]
public class BMSymbol
{
	public string sequence;
	public int x;
	public int y;
	public int width;
	public int height;

	int mLength = 0;

	public int length { get { if (mLength == 0) mLength = sequence.Length; return mLength; } }
}
