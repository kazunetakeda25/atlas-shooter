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

public class csLightControl : MonoBehaviour {
	
	public Light _lihgt;
	float _time = 0;
	public float Delay = 0.5f;
	public float Down = 1;

	void Update ()
	{
		_time += Time.deltaTime;

		if(_time > Delay)
		{
			if(_lihgt.intensity > 0)
				_lihgt.intensity -= Time.deltaTime*Down;

			if(_lihgt.intensity <= 0)
				_lihgt.intensity = 0;
		}
	}
}
