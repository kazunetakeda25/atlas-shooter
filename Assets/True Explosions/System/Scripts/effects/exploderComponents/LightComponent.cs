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

public class LightComponent : ExploderComponent {
	
	public Light lightning; 
	public float radius = 0;

	IEnumerator lightUp(Exploder exploder) {
		Light light = (Light) GameObject.Instantiate(lightning, transform.position, transform.rotation);
		light.transform.parent = transform;
		light.range = radius;
		float startIntencity = light.intensity;
		float startTime = Time.time;
		while (exploder.explodeDuration > Time.time - startTime) {
			light.intensity = Mathf.Lerp(startIntencity, 0, (Time.time - startTime) / exploder.explodeDuration); 
			yield return new WaitForEndOfFrame();
		}
		GameObject.Destroy(light);
		yield return null;
	}

	public override void onExplosionStarted(Exploder exploder) {
		if (radius < 0.0001f) {
			radius = exploder.radius;
		}
		StartCoroutine("lightUp", exploder);
	}
}
