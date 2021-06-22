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
using ChartboostSDK;
public class ChartCall : MonoBehaviour {
	//public bool showChartBool=false;
	// Use this for initialization
	void Start () {
		//if (showChartBool) {
			//showChartBool=false;	
			Invoke ("Call", 6);
		//}

	}
	void Call(){
		Chartboost.showInterstitial(CBLocation.HomeScreen);
	}


	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			// Show interstitial at location HomeScreen. 
			// See Chartboost.cs for available location options.
			//Chartboost.showInterstitial(CBLocation.HomeScreen);
		}
	}
}
