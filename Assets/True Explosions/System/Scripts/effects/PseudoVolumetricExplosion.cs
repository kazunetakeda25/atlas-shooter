/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;

public class PseudoVolumetricExplosion : MonoBehaviour {
	public float loopDuration = 1;
	public float loopOffset = 0;
	public bool randomizeLoopOffset = true;
	public AnimationCurve scale = AnimationCurve.EaseInOut(0, 0.2f, 1, 2);
	public AnimationCurve minRange = AnimationCurve.Linear(0, 0, 1, 0.5f);
	public AnimationCurve maxRange = AnimationCurve.Linear(0, 0.2f, 1, 1);
	public AnimationCurve clip = AnimationCurve.Linear(0.5f, 0.7f, 1, 0.5f);
	public float timeScale = 1;

	private Vector3 endScale;
	private float startTime;

	void Start () {
		loopDuration *= timeScale;
		loopOffset *= timeScale;
		if (randomizeLoopOffset) {
			loopOffset = Random.Range(0, loopDuration);
		}
		endScale = transform.localScale;
		startTime = Time.time;
	}

	void Update () {
		float timeFromBegin = Time.time - startTime;
		float pos = (loopOffset + timeFromBegin) / loopDuration;
		float r = Mathf.Sin((pos) * (2 * Mathf.PI)) * 0.5f + 0.25f;
		float g = Mathf.Sin((pos + 0.33333333f) * 2 * Mathf.PI) * 0.5f + 0.25f;
		float b = Mathf.Sin((pos + 0.66666667f) * 2 * Mathf.PI) * 0.5f + 0.25f;
		float correction = 1 / (r + g + b);
		r *= correction;
		g *= correction;
		b *= correction;
		renderer.material.SetVector("_ChannelFactor", new Vector4(r,g,b,0));

		float scaleFactor = scale.Evaluate(timeFromBegin / timeScale);
		transform.localScale = endScale * scaleFactor;

		float beginRange = minRange.Evaluate(timeFromBegin / timeScale);
		float endRange = maxRange.Evaluate(timeFromBegin / timeScale);
		float clipVal = clip.Evaluate(timeFromBegin / timeScale);
		renderer.material.SetVector("_Range", new Vector4(beginRange, endRange, 0, 0));
		renderer.material.SetFloat("_ClipRange", clipVal);
	}
}
