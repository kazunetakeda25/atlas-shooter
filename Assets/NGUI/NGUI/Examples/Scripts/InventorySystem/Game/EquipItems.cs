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
// Copyright © 2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Equip the specified items on the character when the script is started.
/// </summary>

[AddComponentMenu("NGUI/Examples/Equip Items")]
public class EquipItems : MonoBehaviour
{
	public int[] itemIDs;

	void Start ()
	{
		if (itemIDs != null && itemIDs.Length > 0)
		{
			InvEquipment eq = GetComponent<InvEquipment>();
			if (eq == null) eq = gameObject.AddComponent<InvEquipment>();

			int qualityLevels = (int)InvGameItem.Quality._LastDoNotUse;

			for (int i = 0, imax = itemIDs.Length; i < imax; ++i)
			{
				int index = itemIDs[i];
				InvBaseItem item = InvDatabase.FindByID(index);

				if (item != null)
				{
					InvGameItem gi = new InvGameItem(index, item);
					gi.quality = (InvGameItem.Quality)Random.Range(0, qualityLevels);
					gi.itemLevel = NGUITools.RandomRange(item.minItemLevel, item.maxItemLevel);
					eq.Equip(gi);
				}
				else
				{
					Debug.LogWarning("Can't resolve the item ID of " + index);
				}
			}
		}
		Destroy(this);
	}
}
