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

public class GunHanddle : MonoBehaviour
{
	public Camera FPScamera;
	public Gun[] Guns;
	public int GunIndex;
	[HideInInspector]
	public Gun CurrentGun;
	
	void Start ()
	{
		if (Guns.Length < 1) {
			Guns = this.gameObject.GetComponentsInChildren<Gun> ();
		}
		for (int i=0; i<Guns.Length; i++) {
			if (FPScamera)
				Guns [i].NormalCamera = FPScamera;	
			Guns [i].fovTemp = FPScamera.fieldOfView;
		}
		SwitchGun (0);
	}

	void Update ()
	{
			
	}
	
	void Hide (GameObject gameObject, bool show)
	{
		/*Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
    	foreach (Renderer r in renderers) {
        	r.enabled = show;
    	}*/
	}
	
	public void Zoom ()
	{
		if (CurrentGun)
			CurrentGun.Zoom ();
	}
	
	public void Reload ()
	{
		if (CurrentGun)
			CurrentGun.Reload ();
	}
	
	public void ZoomAdjust (int delta)
	{
		if (CurrentGun)
			CurrentGun.ZoomDelta (delta);
	}
	
	public void SwitchGun (int index)
	{
		if (FPScamera.enabled) {
			for (int i=0; i<Guns.Length; i++) {
				Hide (Guns [i].gameObject, false);
				Guns [i].SetActive (false);
			}
			if (Guns.Length > 0 && index < Guns.Length && index >= 0) {
				GunIndex = index;
				CurrentGun = Guns [GunIndex].gameObject.GetComponent<Gun> ();
				Hide (Guns [GunIndex].gameObject, true);
				Guns [GunIndex].SetActive (true);
			}
		}
	}

	public void SwitchGun ()
	{
		int index = GunIndex + 1;
		if (index >= Guns.Length)
			index = 0;
		
		SwitchGun (index);
	}
	
	public void Shoot ()
	{
		if (CurrentGun)
			CurrentGun.Shoot ();
	}
	
	public void HoldBreath (int noiseMult)
	{
		if (CurrentGun)
			CurrentGun.FPSmotor.Holdbreath (noiseMult);
	}
}
