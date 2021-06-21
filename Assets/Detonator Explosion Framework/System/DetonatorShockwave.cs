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
[AddComponentMenu("Detonator/Shockwave")]
public class DetonatorShockwave : DetonatorComponent
{
	private float _baseSize = 1f;
	private float _baseDuration = .25f;
	private Vector3 _baseVelocity = new Vector3(0f, 0f, 0f);
	private Color _baseColor = Color.white;

	private GameObject _shockwave;
	private DetonatorBurstEmitter _shockwaveEmitter;
	public Material shockwaveMaterial;
	
	public ParticleRenderMode renderMode;
		
	override public void Init()
	{
		//make sure there are materials at all
		FillMaterials(false);
		BuildShockwave();
	}
	
	//if materials are empty fill them with defaults
	public void FillMaterials(bool wipe)
	{
		if (!shockwaveMaterial || wipe)
		{
			shockwaveMaterial = MyDetonator().shockwaveMaterial;
		}
	}
	
	//Build these to look correct at the stock Detonator size of 10m... then let the size parameter
	//cascade through to the emitters and let them do the scaling work... keep these absolute.
    public void BuildShockwave()
    {
		_shockwave = new GameObject("Shockwave");
		_shockwaveEmitter = (DetonatorBurstEmitter)_shockwave.AddComponent("DetonatorBurstEmitter");
		_shockwave.transform.parent = this.transform;
		_shockwave.transform.localRotation = Quaternion.identity;
		_shockwave.transform.localPosition = localPosition;
		_shockwaveEmitter.material = shockwaveMaterial;
		_shockwaveEmitter.exponentialGrowth = false;
		_shockwaveEmitter.useWorldSpace = MyDetonator().useWorldSpace;
    }
	
	public void UpdateShockwave()
	{
		_shockwave.transform.localPosition = Vector3.Scale(localPosition,(new Vector3(size, size, size)));
		_shockwaveEmitter.color = color;
		_shockwaveEmitter.duration = duration;
		_shockwaveEmitter.durationVariation = duration * 0.1f;
		_shockwaveEmitter.count = 1;
		_shockwaveEmitter.detail = 1;
		_shockwaveEmitter.particleSize = 25f;
		_shockwaveEmitter.sizeVariation = 0f;
		_shockwaveEmitter.velocity = new Vector3(0f, 0f, 0f);
		_shockwaveEmitter.startRadius = 0f;
		_shockwaveEmitter.sizeGrow = 202f;
		_shockwaveEmitter.size = size;		
		_shockwaveEmitter.explodeDelayMin = explodeDelayMin;
		_shockwaveEmitter.explodeDelayMax = explodeDelayMax;
		_shockwaveEmitter.renderMode = renderMode;
	}

    public void Reset()
    {
		FillMaterials(true);
		on = true;
		size = _baseSize;
		duration = _baseDuration;
		explodeDelayMin = 0f;
		explodeDelayMax = 0f;
		color = _baseColor;
		velocity = _baseVelocity;
    }

    override public void Explode()
    {
		if (on)
		{
			UpdateShockwave();
			_shockwaveEmitter.Explode();
		}
    }

}
