/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Attaching this script to a widget makes it react to key events such as tab, up, down, etc.
/// </summary>

[RequireComponent(typeof(Collider))]
[AddComponentMenu("NGUI/Interaction/Button Keys")]
public class UIButtonKeys : MonoBehaviour
{
	public bool startsSelected = false;
	public UIButtonKeys selectOnClick;
	public UIButtonKeys selectOnUp;
	public UIButtonKeys selectOnDown;
	public UIButtonKeys selectOnLeft;
	public UIButtonKeys selectOnRight;
	
	void Start ()
	{
		if (startsSelected && (UICamera.selectedObject == null || !NGUITools.GetActive(UICamera.selectedObject)))
		{
			UICamera.selectedObject = gameObject;
		}
	}
	 
	void OnKey (KeyCode key)
	{
		if (enabled && NGUITools.GetActive(gameObject))
		{
			switch (key)
			{
			case KeyCode.LeftArrow:
				if (selectOnLeft != null) UICamera.selectedObject = selectOnLeft.gameObject;
				break;
			case KeyCode.RightArrow:
				if (selectOnRight != null) UICamera.selectedObject = selectOnRight.gameObject;
				break;
			case KeyCode.UpArrow:
				if (selectOnUp != null) UICamera.selectedObject = selectOnUp.gameObject;
				break;
			case KeyCode.DownArrow:
				if (selectOnDown != null) UICamera.selectedObject = selectOnDown.gameObject;
				break;
			case KeyCode.Tab:
				if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
				{
					if (selectOnLeft != null) UICamera.selectedObject = selectOnLeft.gameObject;
					else if (selectOnUp != null) UICamera.selectedObject = selectOnUp.gameObject;
					else if (selectOnDown != null) UICamera.selectedObject = selectOnDown.gameObject;
					else if (selectOnRight != null) UICamera.selectedObject = selectOnRight.gameObject;
				}
				else
				{
					if (selectOnRight != null) UICamera.selectedObject = selectOnRight.gameObject;
					else if (selectOnDown != null) UICamera.selectedObject = selectOnDown.gameObject;
					else if (selectOnUp != null) UICamera.selectedObject = selectOnUp.gameObject;
					else if (selectOnRight != null) UICamera.selectedObject = selectOnRight.gameObject;
				}
				break;
			}
		}
	}

	void OnClick ()
	{
		if (enabled && selectOnClick != null)
		{
			UICamera.selectedObject = selectOnClick.gameObject;
		}
	}
}
