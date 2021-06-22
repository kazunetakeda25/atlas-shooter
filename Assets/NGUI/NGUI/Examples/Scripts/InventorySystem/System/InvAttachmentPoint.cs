/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

[AddComponentMenu("NGUI/Examples/Item Attachment Point")]
public class InvAttachmentPoint : MonoBehaviour
{
	/// <summary>
	/// Item slot that this attachment point covers.
	/// </summary>

	public InvBaseItem.Slot slot;

	GameObject mPrefab;
	GameObject mChild;

	/// <summary>
	/// Attach an instance of the specified game object.
	/// </summary>

	public GameObject Attach (GameObject prefab)
	{
		if (mPrefab != prefab)
		{
			mPrefab = prefab;

			// Remove the previous child
			if (mChild != null) Destroy(mChild);

			// If we have something to create, let's do so now
			if (mPrefab != null)
			{
				// Create a new instance of the game object
				Transform t = transform;
				mChild = Instantiate(mPrefab, t.position, t.rotation) as GameObject;

				// Parent the child to this object
				Transform ct = mChild.transform;
				ct.parent = t;

				// Reset the pos/rot/scale, just in case
				ct.localPosition = Vector3.zero;
				ct.localRotation = Quaternion.identity;
				ct.localScale = Vector3.one;
			}
		}
		return mChild;
	}
}
