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

public class PseudoVolumetricComponent : ExploderComponent {
	public GameObject volumetricExplosion;
	public int count = 30;
	public float scale = 1;
	public float randomness = 1;
	public float duration = 1;
 
	public IEnumerator generateExplosion(Exploder exploder) {
		for (int i = 0; i < count; i++) {
			GameObject explosion = (GameObject) GameObject.Instantiate(volumetricExplosion, Random.insideUnitSphere * scale * randomness + transform.position, Random.rotation);
			explosion.transform.localScale *= scale * (Random.Range(0.5f, 1) * randomness + 1);
			((PseudoVolumetricExplosion) explosion.GetComponent<PseudoVolumetricExplosion>()).timeScale = duration * Random.Range(1 - 0.35f * randomness, 1);
			yield return new WaitForSeconds(Random.Range(0, duration * 0.5f * randomness));
		}
	}

	public override void onExplosionStarted (Exploder exploder) {
		StartCoroutine("generateExplosion", exploder);
	}
}
