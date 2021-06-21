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

/**
 *	WFX_ParticleMeshBillboard Script
 *	
 *	Rotate the vertices of a ParticleSystem's mesh so that it always face the current Camera (billboard effect)
 *	Duplicates the mesh internally to not alter the original selected Mesh
 *	Useless if the ParticleSystem Render Mode is not 'Mesh'!
 *	
 *	Mainly used for Mobile Optimization to reduce overdraw.
 *	
 *	(c) 2012, Jean Moreno
**/

[RequireComponent(typeof(ParticleSystemRenderer))]
public class WFX_ParticleMeshBillboard : MonoBehaviour
{
	Mesh mesh;
	Vector3[] vertices;
	Vector3[] rvertices;
	
	void Awake()
	{
		//Init Variables
		mesh = (Mesh)Instantiate(this.GetComponent<ParticleSystemRenderer>().mesh);
		this.GetComponent<ParticleSystemRenderer>().mesh = mesh;
		
		vertices = new Vector3[mesh.vertices.Length];
		for(int i = 0; i < vertices.Length; i++)
		{
			vertices[i] = mesh.vertices[i];
		}
		rvertices = new Vector3[vertices.Length];
	}
	
	void OnWillRenderObject ()
	{
		//Update Mesh
		if(mesh == null || Camera.current == null)
			return;
		
		Quaternion angle = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
		Quaternion rotation = Quaternion.Inverse(this.transform.rotation);
		
		for(int i = 0; i < rvertices.Length; i++)
		{
			rvertices[i] = angle * vertices[i];
			rvertices[i] = rotation * rvertices[i];
		}
		
		mesh.vertices = rvertices;
	}
}
