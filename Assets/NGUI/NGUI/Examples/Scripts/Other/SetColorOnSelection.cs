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
/// Simple script used by Tutorial 11 that sets the color of the sprite based on the string value.
/// </summary>

[ExecuteInEditMode]
[RequireComponent(typeof(UIWidget))]
[AddComponentMenu("NGUI/Examples/Set Color on Selection")]
public class SetColorOnSelection : MonoBehaviour
{
	UIWidget mWidget;

	void OnSelectionChange (string val)
	{
		if (mWidget == null) mWidget = GetComponent<UIWidget>();

		switch (val)
		{
			case "White":	mWidget.color = Color.white;	break;
			case "Red":		mWidget.color = Color.red;		break;
			case "Green":	mWidget.color = Color.green;	break;
			case "Blue":	mWidget.color = Color.blue;		break;
			case "Yellow":	mWidget.color = Color.yellow;	break;
			case "Cyan":	mWidget.color = Color.cyan;		break;
			case "Magenta": mWidget.color = Color.magenta;	break;
		}
	}
}
