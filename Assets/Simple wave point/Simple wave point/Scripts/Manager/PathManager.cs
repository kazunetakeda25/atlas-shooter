/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class PathManager : MonoBehaviour
{
    //array to store all waypoint transforms of this path
    public Transform[] waypoints;
    //toggle drawing of straight and curved lines
    public bool drawStraight = true;
    public bool drawCurved = true;

    public Color color1 = new Color(1, 0, 1, 0.5f); //cube color
    public Color color2 = new Color(1, 235 / 255f, 4 / 255f, 0.5f); //sphere color
    public Color color3 = new Color(1, 235 / 255f, 4 / 255f, 0.5f); //curved lines color

    //waypoint gizmo radius
    private float radius = .4f;
    //waypointStart/-End box gizmo size
    private Vector3 size = new Vector3(.7f, .7f, .7f);

    public GameObject waypointPrefab;


    void OnDrawGizmos()
    {
        //differ between children waypoint types:
        //waypointStart or waypointEnd, draw small cube gizmo using color2
        //standard waypoint, draw small sphere using color1
        foreach (Transform child in transform)
        {
            if (child.name == "Waypoint")
            {
                //assign chosen color2 to current gizmo color
                Gizmos.color = color2;
                //draw wire sphere at waypoint position
                Gizmos.DrawWireSphere(child.position, radius);
            }
            else if(child.name == "WaypointStart" || child.name == "WaypointEnd")
            {
                //assign chosen color1 to current gizmo color
                Gizmos.color = color1;
                //draw wire cube at waypoint position
                Gizmos.DrawWireCube(child.position, size);
            }
        }

        //draw straight lines
        if (drawStraight)
            DrawStraight();

        //draw curved lines
        if (drawCurved)
            DrawCurved();
    }


    void DrawStraight()
    {
        //let iTween draw lines between waypoints with color2
        iTween.DrawLine(waypoints, color2);
    }


    //helper array for curved paths, includes control points for waypoint array
    Vector3[] points;
    
    //taken and modified from
    //http://code.google.com/p/hotween/source/browse/trunk/Holoville/HOTween/Core/Path.cs
    //draws the full path
    void DrawCurved()
    {
        if (waypoints.Length < 2) return;

        points = new Vector3[waypoints.Length + 2];

        for (int i = 0; i < waypoints.Length; i++)
        {
            points[i + 1] = waypoints[i].position;
        }

        points[0] = points[1];
        points[points.Length - 1] = points[points.Length - 2];

        Gizmos.color = color3;
        Vector3[] drawPs;
        Vector3 currPt;

        // Store draw points.
        int subdivisions = points.Length * 10;
        drawPs = new Vector3[subdivisions + 1];
        for (int i = 0; i <= subdivisions; ++i)
        {
            float pm = i / (float)subdivisions;
            currPt = GetPoint(pm);
            drawPs[i] = currPt;
        }

        // Draw path.
        Vector3 prevPt = drawPs[0];
        for (int i = 1; i < drawPs.Length; ++i)
        {
            currPt = drawPs[i];
            Gizmos.DrawLine(currPt, prevPt);
            prevPt = currPt;
        }
    }


    //taken from
    //http://code.google.com/p/hotween/source/browse/trunk/Holoville/HOTween/Core/Path.cs
    // Gets the point on the curve at the given percentage (0 to 1).
    // t: The percentage (0 to 1) at which to get the point.
    private Vector3 GetPoint(float t)
    {
        int numSections = points.Length - 3;
        int tSec = (int)Math.Floor(t * numSections);
        int currPt = numSections - 1;
        if (currPt > tSec)
        {
            currPt = tSec;
        }
        float u = t * numSections - currPt;

        Vector3 a = points[currPt];
        Vector3 b = points[currPt + 1];
        Vector3 c = points[currPt + 2];
        Vector3 d = points[currPt + 3];

        return .5f * (
                       (-a + 3f * b - 3f * c + d) * (u * u * u)
                       + (2f * a - 5f * b + 4f * c - d) * (u * u)
                       + (-a + c) * u
                       + 2f * b
                   );
    }
}

