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

[RequireComponent (typeof (Detonator))]
[AddComponentMenu("Detonator/Sound")]
public class DetonatorSound : DetonatorComponent {
	
	public AudioClip[] nearSounds;
	public AudioClip[] farSounds;
	
	public float distanceThreshold = 50f; //threshold in m between playing nearSound and farSound
	public float minVolume = .4f;
	public float maxVolume = 1f;
	public float rolloffFactor = 0.5f;
	
	private AudioSource _soundComponent;
	private bool _delayedExplosionStarted = false;
	private float _explodeDelay;
	
	override public void Init()
	{
		_soundComponent = (AudioSource)gameObject.AddComponent ("AudioSource");
	}

	void Update()
	{
		if (_soundComponent == null) return;

		_soundComponent.pitch = Time.timeScale;
		
		if (_delayedExplosionStarted)
		{
			_explodeDelay = (_explodeDelay - Time.deltaTime);
			if (_explodeDelay <= 0f)
			{
				Explode();
			}
		}
	}
	
	private int _idx;
	override public void Explode()
	{
		if (detailThreshold > detail) return;
	
		if (!_delayedExplosionStarted)
		{
			_explodeDelay = explodeDelayMin + (Random.value * (explodeDelayMax - explodeDelayMin));
		}		
		if (_explodeDelay <= 0) 
		{
	//		_soundComponent.minVolume = minVolume;
	//		_soundComponent.maxVolume = maxVolume;
	//		_soundComponent.rolloffFactor = rolloffFactor;
			
			if (Vector3.Distance(Camera.main.transform.position, this.transform.position) < distanceThreshold)
			{
				_idx = (int)(Random.value * nearSounds.Length);
				_soundComponent.PlayOneShot(nearSounds[_idx]);
			}
			else
			{
				_idx = (int)(Random.value * farSounds.Length);
				_soundComponent.PlayOneShot(farSounds[_idx]);
			}	
			_delayedExplosionStarted = false;
			_explodeDelay = 0f;			
		}
		else
		{
			_delayedExplosionStarted = true;
		}
	}
	
	public void Reset()
	{
	}
}
