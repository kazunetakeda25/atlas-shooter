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

public class GunContainer : MonoBehaviour {

    //public MachineGun machineGun;//temporary
    public GameObject[] guns;
    public int gunIndex = 0;
	public GameObject [] gun1parts;
    
    bool isHidden = false;

	public bool MachineGunBool=true;

	public GameObject cam;
	public bool Zoom=false;
	public GameObject gunButton;
	public GameObject bazokaButton;
	public GameObject rocketLauncher;
	public GameObject garnadeLauncher;
	private int missileStatus=0;// which type gun unlock
	private int garnadeStatus=0;//garnade active or not
	// Use this for initialization
    void Start()
    {
	
//		PlayerPrefs.SetInt ("missile", 0);
//		PlayerPrefs.SetInt ("garnade", 0);

		//for bazooka and pistol only
		if (PlayerPrefs.GetInt ("missile")==1) {
			missileStatus=1;
		}
		//false both
		if(garnadeStatus==0 && missileStatus==0) {
			
			bazokaButton.SetActive(false);
		}

//        for (int i = 0; i < guns.Length; i++)
//        {
//           // guns[i].SetActive(true);
//        }
        guns[gunIndex].SetActive(true);
        Debug.Log("gun is unHidden: " + guns[gunIndex].name);

		//for bazooka and pistol only bomber
		if (PlayerPrefs.GetInt ("garnade")==1) {
			garnadeStatus=1;

			//for only one time      only chnage button
			if(missileStatus==0){
			bazokaButton.transform.GetChild(0).GetComponent<UISprite>().spriteName="gernate";
			}


				} 

	}


//Bazoka on


	void OnGunnerChange(){


		//Both guns active here                     Done ok
		if (garnadeStatus == 1 && missileStatus == 1) {
						if (gunIndex == 0) {//bomber on       MachineGunBool
								//MachineGunBool=false;
								//guns[0].SetActive(false);
								gunIndex = 1;// chnage the gun
								guns [1].SetActive (true);
								for (int i=0; i<4; i++) {
										gun1parts [i].GetComponent<MeshRenderer> ().enabled = false;

								}
								garnadeLauncher.SetActive (true);
								//gunButton.SetActive (true);
								bazokaButton.SetActive (false);

						} else if (gunIndex == 1) {//gumnnerOn
								//MachineGunBool=true;
								//guns[0].SetActive(true);
								gunIndex = 2;
								garnadeLauncher.SetActive (false);
								gunButton.SetActive (true);
								guns [1].SetActive (false);
								//gunButton.SetActive (false);
								guns [2].SetActive (true);

						
						} else if (gunIndex == 2) {
								gunIndex = 0;
								guns [1].SetActive (false);
								for (int i=0; i<4; i++) {
										gun1parts [i].GetComponent<MeshRenderer> ().enabled = true;
								}
								guns [2].SetActive (false);
								garnadeLauncher.SetActive (false);
								gunButton.SetActive (false);
								bazokaButton.SetActive (true);
				
						}
				}//////'//////////////////unlock all guns here





		//only missile unlock            Done ok
		else   if (missileStatus == 1) {
				
		
						if (gunIndex == 0) {//gumnnerOn
								//MachineGunBool=true;
								//guns[0].SetActive(true);
								gunIndex = 1;// chnage the gun
								guns [1].SetActive (true);
								for (int i=0; i<4; i++) {
										gun1parts [i].GetComponent<MeshRenderer> ().enabled = false;
					
								}
								garnadeLauncher.SetActive (true);
								//gunButton.SetActive (true);
								bazokaButton.SetActive (false);
				                garnadeLauncher.transform.GetChild(0).GetComponent<UISprite>().spriteName="gun-change";
				
				
						} else if (gunIndex == 1) {
								gunIndex = 0;
								guns [1].SetActive (false);
								for (int i=0; i<4; i++) {
										gun1parts [i].GetComponent<MeshRenderer> ().enabled = true;
								}
								guns [2].SetActive (false);
								garnadeLauncher.SetActive (false);
								gunButton.SetActive (false);
								bazokaButton.SetActive (true);
				
						}////////////////to unlock bazooka and pistol only


		
				}


		//only missile unlock
		else	if (garnadeStatus == 1) {

			if (gunIndex == 0) {//gumnnerOn
				gunIndex = 2;
				gunButton.SetActive (false);
				guns [0].SetActive (false);
				gunButton.SetActive (false);
				guns [2].SetActive (true);
				bazokaButton.transform.GetChild(0).GetComponent<UISprite>().spriteName="gun-change";
				}
				
				
			 else if (gunIndex == 2) {
				gunIndex = 0;
				guns [2].SetActive (false);
				for (int i=0; i<4; i++) {
					gun1parts [i].GetComponent<MeshRenderer> ().enabled = true;
					bazokaButton.transform.GetChild(0).GetComponent<UISprite>().spriteName="gernate";
				}
				guns [0].SetActive (true);
				garnadeLauncher.SetActive (false);
				gunButton.SetActive (false);
			//	rocketLauncher.transform.GetChild(0).GetComponent<UISprite>().spriteName="gernate";
				
			}////////////////to unlock bazooka and pistol only
			
			
			
		}
	}

	public void Zoomm(){
		if(Zoom==false){
			Zoom=true;
			cam.GetComponent<Camera>().fieldOfView=30;
			   }
			   else{
			Zoom=false;
			cam.GetComponent<Camera>().fieldOfView=60;
			}

	}

	// Update is called once per frame
    void Update()
    {

		if (Input.GetMouseButtonDown (0)) {
			//OnGunnerChange();	
			//Zoomm();

		}
        if (isHidden) return;
	
	}

	//Fire button is common for all
    public void Fire()
    {
        if (isHidden) return;
		//if (gunIndex == 0)
		{

			if(gunIndex==0){ // Boolean for machine gun       MachineGunBool
			MachineGun machineGun = guns[gunIndex].GetComponent<MachineGun>();
			machineGun.Fire();
			}
			else if(gunIndex==1){
			
				rocketLauncher.GetComponent<RPGLauncher>().Fire();
			}

			else if(gunIndex==2){
				
				//guns [2].GetComponent<RPGLauncher>().Fire();
				guns [2].GetComponent<BombController>().BombTrough();
			}
		}
//		Debug.Log ("gunIndex:" + gunIndex);
//		else if (gunIndex == 1)
//		{
//			RPGLauncher rpgLauncher = guns[gunIndex].GetComponent<RPGLauncher>();
//			rpgLauncher.Fire();
//		}
//        switch (gunIndex)
//        {
//            case 0:
//                {
//                    MachineGun machineGun = guns[gunIndex].GetComponent<MachineGun>();
//                    machineGun.Fire();
//                    break;
//                }
//            case 1:
//                {
//                    RPGLauncher rpgLauncher = guns[gunIndex].GetComponent<RPGLauncher>();
//                    rpgLauncher.Fire();
//                    break;
//                }
//            default:
//                {
//                    break;
//                }
//        }

    }

//    public void SwitchGun()
//    {
//        if (isHidden) return;
//        gunIndex++;
//        if (gunIndex >= guns.Length)
//        {
//            gunIndex = 0;
//        }
//
//        for (int i = 0; i < guns.Length; i++)
//        {
//            guns[i].SetActive(false);
//        }
//
//        guns[gunIndex].SetActive(true);
//
//    }

    public void HideGun(bool hide)
    {
        isHidden = hide;
        guns[gunIndex].SetActive(false);//means if hide true then setactive false :)

    }

}
