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

public class RPGLauncher : MonoBehaviour {

    public float LifeTimeBullet = 5;
    public Camera NormalCamera;// FPS camera
    public GameObject Bullets; // Bullet prefeb
    public GameObject Shell; // Shell prefeb
    public Transform ShellSpawn; // shell spawing position
    public int Spread = 0;
    public float FireRate = 0.2f;
    public AudioClip SoundGunFire;
    public GameObject rocket;

    private float timefire = 0;
    public Texture2D CrosshairImg;


    bool isPaused;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetMouseButtonDown (0)) {
//			Fire();		
//		}
	}

    void OnGUI()
    {
        if (isPaused) return;
        GUI.color = new Color(1, 1, 1, 0.8f);
        GUI.DrawTexture(new Rect((Screen.width * 0.5f) - (CrosshairImg.width * 0.5f), (Screen.height * 0.5f) - (CrosshairImg.height * 0.5f), CrosshairImg.width, CrosshairImg.height), CrosshairImg);
        GUI.color = Color.white;
    }

    void OnPauseGame()
    {
        isPaused = true;
    }

    void OnResumeGame()
    {
        isPaused = false;
    }


    public void Fire()
    {
        if (timefire + FireRate < Time.time)
        {
            Debug.Log("RPG Firing");

            if (SoundGunFire && audio != null)
            {
                audio.PlayOneShot(SoundGunFire);
            }
            rocket.SetActive(false);
            Invoke("SetRocketActive", FireRate - 0.3f);

            Vector3 point = NormalCamera.camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
			GameObject bullet = (GameObject)Instantiate(Bullets, rocket.transform.position, NormalCamera.gameObject.transform.rotation);
            bullet.transform.forward = NormalCamera.transform.forward *100f;
            
			Destroy(bullet, LifeTimeBullet);

            timefire = Time.time;

//            GameObject shell = (GameObject)Instantiate(Shell, rocket.transform.position, rocket.transform.rotation);
//            shell.rigidbody.AddForce(Vector3.forward * 100);
//            shell.rigidbody.AddTorque(Random.rotation.eulerAngles * 7);
//            GameObject.Destroy(shell, 5);
        }

    }

    void SetRocketActive()
    {
        rocket.SetActive(true);
    }

}
