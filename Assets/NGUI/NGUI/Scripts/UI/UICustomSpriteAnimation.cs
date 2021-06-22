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


public class UICustomSpriteAnimation : UISpriteAnimation {

	// Use this for initialization
	private int totalIterations = 0;
	private bool allowedUpdate = false;
	private string callBackFunction;
	private GameObject callBackRefObj;
	
	protected void Start () {
		
//		this.RunCustomAnimation(null,null,5);
	}
	
	// Update is called once per frame
	protected  void Update () {
		
		if(allowedUpdate)
		{
			if(this.loopNumber < this.totalIterations)
			{
//				loop = true;
//				Reset();
				base.Update();
			}
			else if(this.loopNumber == this.totalIterations)
			{
//				loop = false;
				this.allowedUpdate = false;
				this.callBack();
			}
		}
	}	
	
	public void RunCustomAnimation(GameObject callBackObj,string callBackFn, int totalIterations = 1)
	{
		this.callBackRefObj = callBackObj;
		this.callBackFunction = callBackFn;
		this.totalIterations = totalIterations;
		if(this.totalIterations > 0)
		{
			loopNumber = 0;
			base.RebuildSpriteList();
			this.allowedUpdate = true;
		}
	}
	
	private void callBack()
	{
		if(this.callBackRefObj != null && !string.IsNullOrEmpty(this.callBackFunction))
		{
			this.callBackRefObj.SendMessage(this.callBackFunction);
		}
	}
}
