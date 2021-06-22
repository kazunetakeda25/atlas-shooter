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

public class moveHintArrowScript : MonoBehaviour 
{
	public int hight = 100;//max height of Box's movement
	public float yCenter = 0f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(transform.position.x ,yCenter + Mathf.PingPong(Time.time * 40, hight) - hight/2f, transform.position.z);
	//	transform.Translate(Vector3.up);
	}
}
