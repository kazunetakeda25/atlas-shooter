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
using Holoville.HOTween;
using Holoville.HOTween.Plugins;


//simple helper script for rotating an object
public class RotationHelper : MonoBehaviour
{
    public float multiplier = 1;

    //could also do this with HOTween
    /*
    void Start()
    {
        HOTween.To(transform, 1,
            new TweenParms()
            .Prop("rotation", new Vector3(180,0,0))
            .Ease(EaseType.Linear)
            .Loops(-1, LoopType.Incremental);   
    }
     * */

    void Update()
    {
        // Slowly rotate the object around its X axis at x degree/second.
        transform.Rotate(Vector3.right * (multiplier * 10) * Time.deltaTime);
    }
}
