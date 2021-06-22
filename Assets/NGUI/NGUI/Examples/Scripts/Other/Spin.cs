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
/// Want something to spin? Attach this script to it. Works equally well with rigidbodies as without.
/// </summary>

[AddComponentMenu("NGUI/Examples/Spin")]
public class Spin : MonoBehaviour
{
	public Vector3 rotationsPerSecond = new Vector3(0f, 0.1f, 0f);

	Rigidbody mRb;
	Transform mTrans;

	void Start ()
	{
		mTrans = transform;
		mRb = rigidbody;
	}

	void Update ()
	{
		if (mRb == null)
		{
			ApplyDelta(Time.deltaTime);
		}
	}
	void FixedUpdate ()
	{
		if (mRb != null)
		{
			ApplyDelta(Time.deltaTime);
		}
	}

	public void ApplyDelta (float delta)
	{
		delta *= Mathf.Rad2Deg * Mathf.PI * 2f;
		Quaternion offset = Quaternion.Euler(rotationsPerSecond * delta);

		if (mRb == null)
		{
			mTrans.rotation = mTrans.rotation * offset;
		}
		else
		{
			mRb.MoveRotation(mRb.rotation * offset);
		}
	}
}
