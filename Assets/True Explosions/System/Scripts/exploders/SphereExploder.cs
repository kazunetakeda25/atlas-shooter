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

public class SphereExploder : Exploder {
	public override IEnumerator explode() 
	{
		exploded = true;
		
		ExploderComponent[] components = GetComponents<ExploderComponent>();
		foreach (ExploderComponent component in components) {
			component.onExplosionStarted(this);
		}


		while (explodeDuration > Time.time - explosionTime) {
			collider.isTrigger = true;
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
			foreach (Collider hit in colliders) {
				if (hit && hit.rigidbody) {
					hit.rigidbody.AddExplosionForce(power * Time.deltaTime, explosionPos, radius);
				} else if (hit.collider.gameObject.name == "MainCamera") {
					Vector3 dPos = Random.onUnitSphere * 0.01f;
					hit.transform.position = hit.transform.position + dPos;
				}
				
			}
			collider.isTrigger = false;
			yield return new WaitForEndOfFrame();
		}
	}

	void Start() {
		power *= 200;
		
		if (randomizeExplosionTime > 0.01f) {
			explosionTime += Random.Range(0.0f, randomizeExplosionTime);
		}
	}

	void FixedUpdate () {
		if (Time.time > explosionTime && !exploded) {
			StartCoroutine("explode");
		}
	}
}
