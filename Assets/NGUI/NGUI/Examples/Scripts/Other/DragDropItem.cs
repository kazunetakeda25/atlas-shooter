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

[AddComponentMenu("NGUI/Examples/Drag & Drop Item")]
public class DragDropItem : MonoBehaviour
{
	/// <summary>
	/// Prefab object that will be instantiated on the DragDropSurface if it receives the OnDrop event.
	/// </summary>

	public GameObject prefab;

	Transform mTrans;
	bool mIsDragging = false;
	Transform mParent;

	/// <summary>
	/// Update the table, if there is one.
	/// </summary>

	void UpdateTable ()
	{
		UITable table = NGUITools.FindInParents<UITable>(gameObject);
		if (table != null) table.repositionNow = true;
	}

	/// <summary>
	/// Drop the dragged object.
	/// </summary>

	void Drop ()
	{
		// Is there a droppable container?
		Collider col = UICamera.lastHit.collider;
		DragDropContainer container = (col != null) ? col.gameObject.GetComponent<DragDropContainer>() : null;

		if (container != null)
		{
			// Container found -- parent this object to the container
			mTrans.parent = container.transform;

			Vector3 pos = mTrans.localPosition;
			pos.z = 0f;
			mTrans.localPosition = pos;
		}
		else
		{
			// No valid container under the mouse -- revert the item's parent
			mTrans.parent = mParent;
		}

		// Notify the table of this change
		UpdateTable();

		// Make all widgets update their parents
		BroadcastMessage("CheckParent", SendMessageOptions.DontRequireReceiver);
	}

	/// <summary>
	/// Cache the transform.
	/// </summary>

	void Awake () { mTrans = transform; }

	/// <summary>
	/// Start the drag event and perform the dragging.
	/// </summary>

	void OnDrag (Vector2 delta)
	{
		if (UICamera.currentTouchID > -2)
		{
			if (!mIsDragging)
			{
				mIsDragging = true;
				mParent = mTrans.parent;
				mTrans.parent = DragDropRoot.root;
				
				Vector3 pos = mTrans.localPosition;
				pos.z = 0f;
				mTrans.localPosition = pos;
				
				mTrans.BroadcastMessage("CheckParent", SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				mTrans.localPosition += (Vector3)delta;
			}
		}
	}

	/// <summary>
	/// Start or stop the drag operation.
	/// </summary>

	void OnPress (bool isPressed)
	{
		mIsDragging = false;
		Collider col = collider;
		if (col != null) col.enabled = !isPressed;
		if (!isPressed) Drop();
	}
}
