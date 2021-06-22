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
/// Attach to a game object to make its position always lag behind its parent as the parent moves.
/// </summary>

[AddComponentMenu("NGUI/Examples/Lag Position")]
public class LagPosition : MonoBehaviour
{
	public int updateOrder = 0;
	public Vector3 speed = new Vector3(10f, 10f, 10f);
	public bool ignoreTimeScale = false;
	
	Transform mTrans;
	Vector3 mRelative;
	Vector3 mAbsolute;

	void Start ()
	{
		mTrans = transform;
		mRelative = mTrans.localPosition;
		if (ignoreTimeScale) UpdateManager.AddCoroutine(this, updateOrder, CoroutineUpdate);
		else UpdateManager.AddLateUpdate(this, updateOrder, CoroutineUpdate);
	}

	void OnEnable()
	{
		mTrans = transform;
		mAbsolute = mTrans.position;
	}

	void CoroutineUpdate (float delta)
	{
		Transform parent = mTrans.parent;
		
		if (parent != null)
		{
			Vector3 target = parent.position + parent.rotation * mRelative;
			mAbsolute.x = Mathf.Lerp(mAbsolute.x, target.x, Mathf.Clamp01(delta * speed.x));
			mAbsolute.y = Mathf.Lerp(mAbsolute.y, target.y, Mathf.Clamp01(delta * speed.y));
			mAbsolute.z = Mathf.Lerp(mAbsolute.z, target.z, Mathf.Clamp01(delta * speed.z));
			mTrans.position = mAbsolute;
		}
	}
}
