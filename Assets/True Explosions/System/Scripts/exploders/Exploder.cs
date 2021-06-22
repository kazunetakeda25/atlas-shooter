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
using System.Collections;

public class Exploder : MonoBehaviour {

	public float explosionTime = 0;
	public float randomizeExplosionTime = 0;
	public float radius = 15;
	public float power = 1;
	public int probeCount = 150;
	public float explodeDuration = 0.5f;

	protected bool exploded = false;
	
	public virtual IEnumerator explode() {
		ExploderComponent[] components = GetComponents<ExploderComponent>(); 
		foreach (ExploderComponent component in components) {
			if (component.enabled) {
				component.onExplosionStarted(this);
			}
		}		
		while (explodeDuration > Time.time - explosionTime) {
			disableCollider();
			for (int i = 0; i < probeCount; i++) {
				shootFromCurrentPosition();
			}
			enableCollider();
			yield return new WaitForFixedUpdate();
		}
	}
	
	protected virtual void shootFromCurrentPosition() {
		Vector3 probeDir = Random.onUnitSphere;
		Ray testRay = new Ray(transform.position, probeDir);
		shootRay(testRay, radius);
	}

	protected bool wasTrigger;
	public virtual void disableCollider() {
		if (collider) {
			wasTrigger = collider.isTrigger;
			collider.isTrigger = true;
		}
	}

	public virtual void enableCollider() {
		if (collider) {
			collider.isTrigger = wasTrigger;
		}
	}

	
	protected virtual void init() {
		power *= 500000;
		
		if (randomizeExplosionTime > 0.01f) {
			explosionTime += Random.Range(0.0f, randomizeExplosionTime);
		}
	}

	void Start() {
		init();
	}

	void FixedUpdate() {
		if (Time.time > explosionTime && !exploded) {
			exploded = true;
			StartCoroutine("explode");
		}
	}

	private void shootRay(Ray testRay, float estimatedRadius) {
		RaycastHit hit;
		if (Physics.Raycast(testRay, out hit, estimatedRadius)) {
			if (hit.rigidbody != null) {
				hit.rigidbody.AddForceAtPosition(power * Time.deltaTime * testRay.direction / probeCount, hit.point);
				estimatedRadius /= 2;
			} else {
				Vector3 reflectVec = Random.onUnitSphere;
				if (Vector3.Dot(reflectVec, hit.normal) < 0) {
					reflectVec *= -1;
				}
				Ray emittedRay = new Ray(hit.point, reflectVec);
				shootRay(emittedRay, estimatedRadius - hit.distance);
			}
		}
	}
}
