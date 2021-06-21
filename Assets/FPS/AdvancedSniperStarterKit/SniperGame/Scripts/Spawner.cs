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

public class Spawner : MonoBehaviour {

	public GameObject Objectman;
	private float timetemp = 0;
	public float timeSpawn = 3;
	public int enemyCount = 0;
	public int radiun;
	void Start () {
		if(renderer)
  			renderer.enabled = false;
		timetemp = Time.time;
	}

	void Update () {
   		GameObject[] gos = GameObject.FindGameObjectsWithTag(Objectman.tag);

   		if(gos.Length < enemyCount){
   			if(Time.time > timetemp+timeSpawn){
   	  			timetemp = Time.time;
				
   	  			GameObject.Instantiate(Objectman, TerrainFloor(transform.position+ new Vector3(Random.Range(-radiun,radiun),this.transform.position.y,Random.Range(-radiun,radiun))), Quaternion.identity);
   	  		}
   		}
	}
	
	public RaycastHit PositionOnTerrain(Vector3 position){
		RaycastHit res = new RaycastHit();
		res.point = position;
		if(GameObject.FindObjectOfType(typeof(Terrain))){
			Terrain terrain = (Terrain)GameObject.FindObjectOfType(typeof(Terrain));
			if(terrain){
				RaycastHit hit;
        		if (Physics.Raycast(position, -Vector3.up,out hit)) {
            		res = hit;
        		}
			}else{
				Debug.Log("No Terrain");	
			}	
		}
		return res;
	}
	public Vector3 TerrainFloor(Vector3 position){
		Vector3 res = position;
		RaycastHit positionSpawn = PositionOnTerrain(position + (Vector3.up * 100));
		
		res = new Vector3(position.x,positionSpawn.point.y+1,position.z);
		
		return res;
	}
}
