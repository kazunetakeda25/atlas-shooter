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
[AddComponentMenu("Detonator/Light")]
public class DetonatorLight : DetonatorComponent {
	
	private float _baseIntensity = 1f;
	private Color _baseColor = Color.white;
	private float _scaledDuration = 0f;
	private float _explodeTime = -1000f;
	
	private GameObject _light;
	private Light _lightComponent;
	public float intensity;
	
	override public void Init()
	{
		_light = new GameObject ("Light");
		_light.transform.parent = this.transform;
		_light.transform.localPosition = localPosition;
		_lightComponent = (Light)_light.AddComponent ("Light");
		_lightComponent.type = LightType.Point;
		_lightComponent.enabled = false;
	}
	
	private float _reduceAmount = 0f;
	void Update () 
	{
		
		if ((_explodeTime + _scaledDuration > Time.time) && _lightComponent.intensity > 0f)
		{
			_reduceAmount = intensity * (Time.deltaTime/_scaledDuration);
			_lightComponent.intensity -= _reduceAmount;
		}
		else
		{
			if (_lightComponent)
			{
				_lightComponent.enabled = false;
			}
		}
		
	}
	
	override public void Explode()
	{
		if (detailThreshold > detail) return;
		
		_lightComponent.color = color;
		_lightComponent.range = size * 50f;	
		_scaledDuration = (duration * timeScale);
		_lightComponent.enabled = true;
		_lightComponent.intensity = intensity;
		_explodeTime = Time.time;
	}
	
	public void Reset()
	{
		color = _baseColor;
		intensity = _baseIntensity;
	}
}
