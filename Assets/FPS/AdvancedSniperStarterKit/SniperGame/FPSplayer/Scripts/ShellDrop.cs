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
[RequireComponent(typeof(AudioSource))]

public class ShellDrop : MonoBehaviour {
	private AudioSource audiosource;
	public GameObject ParticleHit;
	public AudioClip[] Sounds;
	
	void Start () {
		if(audio != null && Sounds!=null && Sounds.Length>0){
			audiosource = audio;
		}
	}

	void Update(){
		if(audiosource != null && Sounds!=null && Sounds.Length>0){
			audiosource.pitch = Time.timeScale;
			if(audiosource.pitch<0.5f){
				audiosource.pitch = 0.5f;
			}
		}
	}
	void OnCollisionEnter(Collision collision) {
		if(audiosource != null && Sounds!=null && Sounds.Length>0){
			audiosource.PlayOneShot(Sounds[Random.Range(0,Sounds.Length)]);
		}
		if(ParticleHit){
			GameObject particle = (GameObject)GameObject.Instantiate(ParticleHit,this.transform.position,this.transform.rotation);
			GameObject.Destroy(particle,3);
		}
	}
}
