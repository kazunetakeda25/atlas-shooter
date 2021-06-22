/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright � 2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using System.Collections.Generic;
//using UnityEditor;

/// <summary>
/// This class is meant to be used only internally. It's like Debug.Log, but prints using OnGUI to screen instead.
/// </summary>

[AddComponentMenu("NGUI/Internal/Debug")]
public class NGUIDebug : MonoBehaviour
{
	static List<string> mLines = new List<string>();
	static NGUIDebug mInstance = null;
	
	static public void Log (string text)
	{
		if (Application.isPlaying)
		{
			//Debug.Log(text);

			if (mLines.Count > 20) mLines.RemoveAt(0);
			mLines.Add(text);

			if (mInstance == null)
			{
				GameObject go = new GameObject("_NGUI Debug");
				mInstance = go.AddComponent<NGUIDebug>();
				DontDestroyOnLoad(go);
			}
		}
		else
		{
			Debug.Log(text);
		}
	}

	static public void DrawBounds (Bounds b)
	{
		Vector3 c = b.center;
		Vector3 v0 = b.center - b.extents;
		Vector3 v1 = b.center + b.extents;
		Debug.DrawLine(new Vector3(v0.x, v0.y, c.z), new Vector3(v1.x, v0.y, c.z), Color.red);
		Debug.DrawLine(new Vector3(v0.x, v0.y, c.z), new Vector3(v0.x, v1.y, c.z), Color.red);
		Debug.DrawLine(new Vector3(v1.x, v0.y, c.z), new Vector3(v1.x, v1.y, c.z), Color.red);
		Debug.DrawLine(new Vector3(v0.x, v1.y, c.z), new Vector3(v1.x, v1.y, c.z), Color.red);
	}
	
	void OnGUI()
	{
		for (int i = 0, imax = mLines.Count; i < imax; ++i)
		{
			GUILayout.Label(mLines[i]);
		}
//		EditorGUIUtility.ExitGUI();
	}
}
