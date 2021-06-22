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

public class LevelLoader : MonoBehaviour {
	public string levelName;
	public  string UnLockNo;//Unlock next one
	private string Merge;
	int holder;
	// Use this for initialization
	void Start () {
	
	}
	void LoadNext(){
		if (UIcontroller.SelectedRegion == 1) {
			//holder=Application.loadedLevel;
			Merge = "m" + UnLockNo + "_on";// merge Unlock no
				}

		if (UIcontroller.SelectedRegion == 2) {
			holder=Application.loadedLevel;
			PlayerPrefs.SetInt ("Unlock2",holder);//unlocked 2d mission		
		}

		Application.LoadLevel (""+levelName);
		Merge = "m" + UnLockNo + "_on";// merge Unlock no      saaad for testing 
		PlayerPrefs.SetString (Merge,"true");

	}
	// Update is called once per frame
	void Update () {
	
	}
}
