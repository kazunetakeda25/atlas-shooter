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

public class GunJerk : MonoBehaviour {

    public float jerkOffset = 1f;

    public float speed = 0.1f;

	// Use this for initialization
    void Start()
    {
        //transform.localPosition -= new Vector3(0, 0, jerkOffset);
	}
	
	// Update is called once per frame
	void Update () {

        //if (jerkOffset < 0)
        //{
        //    print("pohnch gya");
        //}
        //else
        //{
        //    jerkOffset -= speed;
        //    transform.localPosition -= new Vector3(0, 0, speed);
        //}

	
	}
}
