/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

 
using UnityEngine;
using UnityEditor;

//implement UnityEditor and inherit from EditorWindow
//this will be our editor waypoint manager creator 
public class CreateWPManager : EditorWindow {

	//add menu named "Waypoint Manager" to the Window menu
	[MenuItem ("Window/Simple Waypoint System/Waypoint Manager")]

    //initialize/on click - method
	static void Init()
	{
        //search for a waypoint manager object within current scene
        GameObject wpManager = GameObject.Find("Waypoint Manager");

        //if no waypoint manager object was found
		if(wpManager == null)
		{
            //create a new gameobject with that name
			wpManager = new GameObject("Waypoint Manager");
            //and attach the WaypointManager component to it
			wpManager.AddComponent<WaypointManager>();
		}

        //in both cases, initial waypoint manager found or not, select old/new one
        Selection.activeGameObject = wpManager;
	}
}
