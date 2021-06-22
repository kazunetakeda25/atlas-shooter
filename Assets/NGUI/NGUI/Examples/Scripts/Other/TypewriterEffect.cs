/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

/// <summary>
/// Trivial script that fills the label's contents gradually, as if someone was typing.
/// </summary>

[RequireComponent(typeof(UILabel))]
[AddComponentMenu("NGUI/Examples/Typewriter Effect")]
public class TypewriterEffect : MonoBehaviour
{
	public int charsPerSecond = 40;

	UILabel mLabel;
	string mText;
	int mOffset = 0;
	float mNextChar = 0f;

	void Update ()
	{
		if (mLabel == null)
		{
			mLabel = GetComponent<UILabel>();
			mLabel.supportEncoding = false;
			mLabel.symbolStyle = UIFont.SymbolStyle.None;
			mText = mLabel.font.WrapText(mLabel.text, mLabel.lineWidth / mLabel.cachedTransform.localScale.x, mLabel.maxLineCount, false, UIFont.SymbolStyle.None);
		}

		if (mOffset < mText.Length)
		{
			if (mNextChar <= Time.time)
			{
				charsPerSecond = Mathf.Max(1, charsPerSecond);

				// Periods and end-of-line characters should pause for a longer time.
				float delay = 1f / charsPerSecond;
				char c = mText[mOffset];
				if (c == '.' || c == '\n' || c == '!' || c == '?') delay *= 4f;

				mNextChar = Time.time + delay;
				mLabel.text = mText.Substring(0, ++mOffset);
			}
		}
		else Destroy(this);
	}
}
