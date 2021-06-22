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

public class Exploder2D : Exploder {
	public override void disableCollider() {
		if (collider2D) {
			wasTrigger = collider2D.isTrigger;
			collider2D.isTrigger = true;
		}
	}
	
	public override void enableCollider() {
		if (collider2D) {
			collider2D.isTrigger = wasTrigger;
		}
	}


	protected override void shootFromCurrentPosition() {
		Vector2 probeDir = Random.insideUnitCircle;
		probeDir.Normalize();
		Vector2 start = new Vector2(transform.position.x, transform.position.y);
		Ray2D testRay = new Ray2D(start, probeDir);
		shootRay(testRay, radius);
	}

	void Start() {
		init();
		power *= 10;
	}

	private void shootRay(Ray2D testRay, float estimatedRadius) {
		RaycastHit2D hit = Physics2D.Raycast(testRay.origin, testRay.direction, estimatedRadius);
		if (hit.collider != null) {
			if (hit.rigidbody != null) {
				hit.rigidbody.AddForceAtPosition(power * Time.deltaTime * testRay.direction / probeCount, hit.point);
				estimatedRadius /= 2;
			} else {
				Vector2 reflectVec = Random.insideUnitCircle.normalized;
				if (Vector2.Dot(reflectVec, hit.normal) < 0) {
					reflectVec *= -1;
				}
				Ray2D emittedRay = new Ray2D(hit.point, reflectVec);
				if (Random.Range(0, 20) > 1) shootRay(emittedRay, estimatedRadius - hit.fraction);
			}
		}
	}

}

