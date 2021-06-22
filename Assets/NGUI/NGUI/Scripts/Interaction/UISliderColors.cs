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

/// <summary>
/// This script automatically changes the color of the specified sprite based on the value of the slider.
/// </summary>

[ExecuteInEditMode]
[RequireComponent(typeof(UISlider))]
[AddComponentMenu("NGUI/Examples/Slider Colors")]
public class UISliderColors : MonoBehaviour
{
	public UISprite sprite;

	public Color[] colors = new Color[] { Color.red, Color.yellow, Color.green };

	UISlider mSlider;

	void Start () { mSlider = GetComponent<UISlider>(); Update(); }

	void Update ()
	{
		if (sprite == null || colors.Length == 0) return;

		float val = mSlider.sliderValue;
		val *= (colors.Length - 1);
		int startIndex = Mathf.FloorToInt(val);

		Color c = colors[0];

		if (startIndex >= 0)
		{
			if (startIndex + 1 < colors.Length)
			{
				float factor = (val - startIndex);
				c = Color.Lerp(colors[startIndex], colors[startIndex + 1], factor);
			}
			else if (startIndex < colors.Length)
			{
				c = colors[startIndex];
			}
			else c = colors[colors.Length - 1];
		}

		c.a = sprite.color.a;
		sprite.color = c;
	}
}
