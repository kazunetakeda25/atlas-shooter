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


//message example script for iMove/hoMove
public class MessageExample : MonoBehaviour
{
    private iMove iScript;
    private hoMove hoScript;
    private Transform thisObject;


    void Start()
    {
        iScript = GetComponent<iMove>();
        hoScript = GetComponent<hoMove>();
        thisObject = transform;
    }


    void PositionObject(Object point)
    {
        GameObject waypoint = (GameObject)point as GameObject;

        HOTween.To(thisObject, 1,
            new TweenParms().Prop("position", waypoint.transform.position + new Vector3(0, 10, 0))
            .Ease(EaseType.Linear)
            .Loops(2, LoopType.Yoyo));  
    }


    void RotateObject(Vector3 rot)
    {
        HOTween.To(thisObject, 1, 
            new TweenParms()
            .Prop("rotation", rot)
            .Ease(EaseType.Linear)
            .Loops(2, LoopType.Yoyo));    
    }


    //only hoMove
    void UpdatePoints()
    {
        hoScript.Stop();
        hoScript.currentPoint = 0;
        hoScript.moveToPath = true;
        hoScript.StartMove();
    }


    //only iMove
    IEnumerator StopAndResume(float seconds)
    {
        iScript.Stop();

        yield return new WaitForSeconds(seconds);

        iScript.StartMove();        
    }


    //only hoMove
    IEnumerator PauseAndResume(float seconds)
    {
       	hoScript.Pause();

        yield return new WaitForSeconds(seconds);

        hoScript.Resume();
    }


    void PrintProgress()
    {
        Debug.Log(gameObject.name + ": I'm now at waypoint " + (hoScript.currentPoint + 1) + ".");
    }


    void PrintText(string text)
    {
        Debug.Log(text);
    }


    void Method1()
    {
        //your own method!
    }

}
