/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;

/// <summary>
/// Change the shader level-of-detail to match the quality settings.
/// </summary>

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Examples/Shader Quality")]
public class ShaderQuality : MonoBehaviour
{
	int mCurrent = 600;

	void Update ()
	{
#if UNITY_3_4
		int current = ((int)QualitySettings.currentLevel + 1) * 100;
#else
		int current = (QualitySettings.GetQualityLevel() + 1) * 100;
#endif

		if (mCurrent != current)
		{
			mCurrent = current;
			Shader.globalMaximumLOD = mCurrent;
		}
	}
}
