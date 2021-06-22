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
using System.Collections.Generic;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;


public class WaypointManager : MonoBehaviour {

    //this dictionary stores all path names and for each path its manager component with waypoint positions
    //enemies will receive their specific path component
    public static readonly Dictionary<string, PathManager> Paths = new Dictionary<string, PathManager>();

    //execute this before any other Start() or Update() function
    //since we need the data of all paths before we call them
    void Awake()
    {
        //for each child/path of this gameobject, add path to dictionary
        foreach (Transform path in transform) 
        {
            AddPath(path.gameObject);
        }

        //http://www.holoville.com/hotween/documentation.html#hotweeninit
        //initialize HOTween immediately instead than having it being
        //automatically initialized when the first Tweener is created.
        HOTween.Init(true, true, true);
        //HOTween's OverwriteManager works in the background, and automatically
        //checks if a running tween needs to be overwritten by a newly started one.
        HOTween.EnableOverwriteManager();
        //If true, shows the eventual paths in use by PlugVector3Path while playing
        //inside Unity's Editor (and if the Editor's Gizmos button is on). 
        HOTween.showPathGizmos = true;
    }

	
	//this adds a path to the dictionary above, so our walker objects can access them
	public static void AddPath(GameObject path)
	{
        //check if path contains the name "Clone" (path was instantiated)
        if (path.name.Contains("Clone"))
        {
            //replace/remove "(Clone)" with an empty character
            path.name = path.name.Replace("(Clone)", "");
        }

        //check if path dictionary already contains this path name
        if (Paths.ContainsKey(path.name))
        {
            //debug warning and abort
            Debug.LogWarning("Called AddPath() but Scene already contains Path " + path.name + ".");
            return;
        }

		//get PathManager component
        PathManager pathMan = path.GetComponentInChildren<PathManager>();
        
        //if pathMan is null, so our path GameObject has no PathManager, debug warning and abort
        if (pathMan == null)
        {
            Debug.LogWarning("Called AddPath() but Transform " + path.name + " has no PathManager attached.");
            return;
        }

        //add path name and its manager reference to above dictionary to allow indirect access
        Paths.Add(path.name, pathMan);
	}


    //static dictionaries keep their variables between scenes,
    //we don't want that to happen - clear the path dictionary
    //whenever this object gets destroyed (e.g. on scene change)
    void OnDestroy()
    {
        Paths.Clear();
    }
}

//send message option list for movement script iMove/hoMove
[System.Serializable]
public class MessageOptions
{
    //message name
    public List<string> message = new List<string>();
    //value type enum
    public List<ValueType> type = new List<ValueType>();
    //object value
    public List<UnityEngine.Object> obj = new List<UnityEngine.Object>();
    //text value
    public List<string> text = new List<string>();
    //numerical value
    public List<float> num = new List<float>();
    //vector2 value
    public List<Vector2> vect2 = new List<Vector2>();
    //vector3 value
    public List<Vector3> vect3 = new List<Vector3>();
    //available data types for message parameters
    public enum ValueType
    {
        None,
        Object,
        Text,
        Numeric,
        Vector2,
        Vector3
    }
}
