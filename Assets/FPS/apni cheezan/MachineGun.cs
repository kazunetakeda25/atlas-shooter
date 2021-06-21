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

public class MachineGun : MonoBehaviour
{


    public float LifeTimeBullet = 5;
    public Camera NormalCamera;// FPS camera
    public GameObject Bullets; // Bullet prefeb
    public GameObject Shell; // Shell prefeb
    public GameObject Muzzle; // Shell prefeb
    public Transform[] ShellsSpawn; // shell spawing position
    public Transform[] MuzzelsSpawn; // shell spawing position
    public int Spread = 0;
    public float FireRate = 0.2f;
    public AudioClip SoundGunFire;
    public RotateNali[] rotateNali;
    public GameObject[] guns;
    private int naliIndex = 0;

    private float timefire = 0;
    public Texture2D CrosshairImg;


    bool isPaused;
	// Use this for initialization
	void Start () {
	//	UIcontroller.SelectedRegion = 1;
        naliIndex = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnGUI()
    {
			
		if (PlayerHelthScript.pausemenuVisible){
        if (isPaused) return;
        GUI.color = new Color(1, 1, 1, 0.8f);
			//if (UIcontroller.SelectedRegion == 1){
		GUI.DrawTexture(new Rect((Screen.width * 0.5f) - (CrosshairImg.width * 0.5f), (Screen.height * 0.5f) - (CrosshairImg.height * 0.5f), CrosshairImg.width, CrosshairImg.height), CrosshairImg);
			//}
//			else{
//				GUI.DrawTexture(new Rect((Screen.width * 0.5f) - (CrosshairImg.width * 0.5f)-150f, (Screen.height * 0.5f) - (CrosshairImg.height * 0.5f)+30f, CrosshairImg.width, CrosshairImg.height), CrosshairImg);
//			}
				GUI.color = Color.white;
		}
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
//            Debug.Log("Machine gun Firing");

            if (SoundGunFire && audio != null)
            {
                audio.PlayOneShot(SoundGunFire);
            }

            rotateNali[naliIndex].speed = 2000;

            Vector3 point = NormalCamera.camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            GameObject bullet = (GameObject)Instantiate(Bullets, point, NormalCamera.gameObject.transform.rotation);
			//bullet.transform.forward = NormalCamera.transform.forward + (new Vector3(Random.Range(-Spread, Spread), Random.Range(-Spread, Spread), Random.Range(-Spread, Spread)) * 0.001f);//0.001
            Destroy(bullet, LifeTimeBullet);
			Debug.Log(""+(new Vector3(Random.Range(-Spread, Spread), Random.Range(-Spread, Spread), Random.Range(-Spread, Spread)) * 0.001f));


            timefire = Time.time;


            //GameObject shell = (GameObject)Instantiate(Shell, ShellSpawn.position, ShellSpawn.rotation);
            //shell.rigidbody.AddForce(ShellSpawn.transform.right * 2);
            //shell.rigidbody.AddTorque(Random.rotation.eulerAngles * 10);
            //GameObject.Destroy(shell, 5);


            GameObject shell = (GameObject)Instantiate(Shell, ShellsSpawn[naliIndex].position, ShellsSpawn[naliIndex].rotation);
            shell.rigidbody.AddForce(ShellsSpawn[naliIndex].transform.right * 2);
            shell.rigidbody.AddTorque(Random.rotation.eulerAngles * 10);
            shell.transform.parent = guns[naliIndex].transform;
            GameObject.Destroy(shell, 5);

//            GameObject muzzle = (GameObject)Instantiate(Muzzle, MuzzelsSpawn[naliIndex].position, MuzzelsSpawn[naliIndex].rotation);
     //       muzzle.transform.parent = guns[naliIndex].transform;
    //        GameObject.Destroy(muzzle, FireRate);


            naliIndex = (naliIndex + 1) % rotateNali.Length;
        }

    }

}
