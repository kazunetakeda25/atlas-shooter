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
/// Simple example of an OnDrop event accepting a game object. In this case we check to see if there is a DragDropObject present,
/// and if so -- create its prefab on the surface, then destroy the object.
/// </summary>

[AddComponentMenu("NGUI/Examples/Drag & Drop Surface")]
public class DragDropSurface : MonoBehaviour
{
	public bool rotatePlacedObject = false;

	void OnDrop (GameObject go)
	{
		DragDropItem ddo = go.GetComponent<DragDropItem>();
		
		if (ddo != null)
		{
			GameObject child = NGUITools.AddChild(gameObject, ddo.prefab);

			Transform trans = child.transform;
			trans.position = UICamera.lastHit.point;
			if (rotatePlacedObject) trans.rotation = Quaternion.LookRotation(UICamera.lastHit.normal) * Quaternion.Euler(90f, 0f, 0f);
			Destroy(go);
		}
	}
}
