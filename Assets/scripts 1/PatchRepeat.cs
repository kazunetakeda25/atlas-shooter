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

public class PatchRepeat : MonoBehaviour {
	public GameObject patchTerrain;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		
		if (other.collider.gameObject.tag.Equals ("Engine")) {
			
			Debug.Log("train hit");
			patchTerrain.transform.Translate(0,0,2000*Time.deltaTime);
			//patch2.transform.position=new Vector3(transform.position.x+5.42f,transform.position.y-103,transform.position.z+1932);
			
		}
		
		
	}
}
