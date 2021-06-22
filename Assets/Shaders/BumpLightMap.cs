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

public class BumpLightMap : MonoBehaviour {
	public Color lightColor;
	public Texture specularBake;
	// Update is called once per frame
	void Update () {
		Color col = Color.white;
		Vector3 fwd = transform.forward;
		col.r = -fwd.x;
		col.g = -fwd.y;
		col.b = -fwd.z;
		Shader.SetGlobalColor ("_LightmapDir", col);
		Shader.SetGlobalColor ("_LightmapColor", lightColor);
		Shader.SetGlobalTexture ("_SpecCube", specularBake);
	}
	
	void OnDrawGizmos () {
		Update ();	
	}
	void OnDrawGizmosSelected () {
		Update ();	
	}
}
