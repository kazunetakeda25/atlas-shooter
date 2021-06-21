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

public class Crosshair : MonoBehaviour {

	public Texture2D CrosshairImg;
	void Start () {
	
	}
	
	void OnGUI(){
		if(CrosshairImg){
			GUI.color = new Color(1, 1, 1, 0.8f);
			GUI.DrawTexture(new Rect((Screen.width * 0.5f) - (CrosshairImg.width * 0.5f),(Screen.height * 0.5f) - (CrosshairImg.height * 0.5f), CrosshairImg.width,CrosshairImg.height), CrosshairImg);
			GUI.color = Color.white;
		}
	}
}
