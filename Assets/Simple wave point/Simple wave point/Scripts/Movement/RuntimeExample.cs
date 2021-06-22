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

//this class demonstrates the programmatic use of SWS at runtime
//iMove sample, but works for hoMove too
public class RuntimeExample : MonoBehaviour
{
    //walker object to instantiate at runtime
    public GameObject walkerPrefab;
    //path to instantiate at runtime
    public GameObject pathPrefab;

    //positions where to spawn and reposition objects
    public Transform position1;
    public Transform position2;
    public Transform position3;

    //example1: store instantiated objects
    private GameObject walkerObj1;
    private GameObject newPath1;
    private iMove walkeriM1;

    //example2: store instantiated objects
    private GameObject walkerObj2;
    private GameObject newPath2;
    private iMove walkeriM2;


    void OnGUI()
    {
        Example1();
        Example2();

        GUI.Label(new Rect(10, Screen.height - 30, Screen.width, 30),
                  "Example 3: UserInput - Press the left/right arrow key to move the capsule."); 
    }


    //--------- this short example visualizes: ---------\\
    //*instantiate a walker object and a path at runtime
    //*add path reference to our WaypointManager so other have access to it
    //*set path container of this object and start moving
    //*reposition path (walker object automatically gets new waypoint positions)
    //*stop movement
    //*continue movement
    void Example1()
    {
        GUI.Label(new Rect(10, 5, 120, 30), "Example 1");

        if (!walkerObj1 && GUI.Button(new Rect(10, 30, 130, 25), "Instantiate Objects"))
        {
            //instantiate walker prefab
            walkerObj1 = (GameObject)Instantiate(walkerPrefab, position1.position, Quaternion.identity);
            walkerObj1.name = "Soldier@" + System.DateTime.Now.TimeOfDay;
            //instantiate path prefab
            newPath1 = (GameObject)Instantiate(pathPrefab, position1.position, Quaternion.identity);
            //rename the path to ensure it is unique
            newPath1.name = "RuntimePath@" + System.DateTime.Now.TimeOfDay;

            //add newly instantiated path to the WaypointManager dictionary
            WaypointManager.AddPath(newPath1);
        }


        if (walkerObj1 && !walkeriM1 && GUI.Button(new Rect(140, 30, 130, 25), "Start Movement"))
        {
            //get iMove component of this walker object, here we cahce it once
            walkeriM1 = walkerObj1.GetComponent<iMove>();
            //set path container to path instantiated above - access WaypointManager dictionary
            //and start movement on new path
            walkeriM1.SetPath(WaypointManager.Paths[newPath1.name]);
        }


        //change instantiated path position from position1 to position2 or vice versa
        if (newPath1 && GUI.Button(new Rect(10, 30, 130, 25), "Reposition Path"))
        {
            Transform path = newPath1.transform;

            if (path.position == position1.position)
                path.position = position2.position;
            else
                path.position = position1.position;
        }


        //stop and reset movement to the first waypoint 
        if (walkerObj1 && walkeriM1 && GUI.Button(new Rect(140, 30, 130, 25), "Reset Walker"))
        {
            walkeriM1.Reset();
            walkeriM1 = null;
        }


        //stop any movement for the time being
        if (walkerObj1 && walkeriM1 && GUI.Button(new Rect(270, 30, 100, 25), "Stop Walker"))
        {
            walkeriM1.Stop();

            //don't call this method in hoMove if you want to resume the animation later,
            //call .Pause() and .Resume() instead
        }


        //continue movement
        if (walkerObj1 && walkeriM1 && GUI.Button(new Rect(370, 30, 100, 25), "Continue Walk"))
        {
            //set moveToPath boolean of instantiated walker to true,
            //so on calling StartMove() it does not appear at the next waypoint but walks to it instead
            walkeriM1.moveToPath = true;
            //continue movement
            walkeriM1.StartMove();
        }
    }


    //--------- this short example method visualizes: ---------\\
    //*instantiate a walker object and a path at runtime,
    //*add path reference to our WaypointManager so other have access to it
    //*set path container of path instantiated in method above ("RuntimePath1") and start moving
    //*change path at runtime - switch from "RuntimePath1" to "RuntimePath2"
    void Example2()
    {
        GUI.Label(new Rect(10, 60, 120, 30), "Example 2");

        if (!walkerObj2 && GUI.Button(new Rect(10, 85, 130, 25), "Instantiate Objects"))
        {
            //instantiate walker prefab
            walkerObj2 = (GameObject)Instantiate(walkerPrefab, position3.position, Quaternion.identity);
            walkerObj2.name = "Soldier@" + System.DateTime.Now.TimeOfDay;
            //instantiate path prefab
            newPath2 = (GameObject)Instantiate(pathPrefab, position3.position, Quaternion.identity);
            //rename the path to ensure it is unique
            newPath2.name = "RuntimePath@" + System.DateTime.Now.TimeOfDay;

            //add newly instantiated path to the WaypointManager dictionary
            WaypointManager.AddPath(newPath2);
        }


        if (walkerObj2 && !walkeriM2 && GUI.Button(new Rect(140, 85, 130, 25), "Start Movement"))
        {
            //get iMove component of this walker object, here we cache it once
            walkeriM2 = walkerObj2.GetComponent<iMove>();
            //set path container to path instantiated above - access WaypointManager dictionary
            //and start movement on new path
            walkeriM2.SetPath(WaypointManager.Paths[newPath2.name]);
        }


        //change instantiated path position from position1 to position2 or vice versa
        if (newPath1 && newPath2 && GUI.Button(new Rect(10, 85, 130, 25), "Switch Path"))
        {
            //set moveToPath boolean of instantiated walker to true,
            //so on calling SetPath() it does not appear at the new path but walks to it instead
            if (!walkeriM2) walkeriM2 = walkerObj2.GetComponent<iMove>();
            walkeriM2.moveToPath = true;

            //set path container from newPath1 to newPath2 or vice versa
            //- access WaypointManager dictionary and start movement on new path
            if (walkeriM2.pathContainer == WaypointManager.Paths[newPath1.name])
                walkeriM2.SetPath(WaypointManager.Paths[newPath2.name]);
            else
                walkeriM2.SetPath(WaypointManager.Paths[newPath1.name]);

            //you could call also that function within one line like this,
            //if you don't need to change other iMove properties:
            //walkeriM2.GetComponent<iMove>().SetPath(WaypointManager.Paths[newPath1.name]);
            //or
            //walkeriM2.SendMessage("SetPath", WaypointManager.Paths[newPath1.name]);
        }
    }
}
