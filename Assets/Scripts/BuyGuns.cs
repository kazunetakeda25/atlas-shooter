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

public class BuyGuns : MonoBehaviour {
	private int earnedCoins;
	public GameObject unlockMissile;
	public GameObject unlockGarnade;

	// Use this for initialization
	void Start () {
	//	PlayerPrefs.SetInt("missile",0);
	//	PlayerPrefs.SetInt("garnade",0);
		if (PlayerPrefs.GetInt ("missile") == 1) {
			unlockMissile.SetActive(false);
		
		}
		if (PlayerPrefs.GetInt ("garnade") == 1) {
			unlockGarnade.SetActive(false);
			
		}
		//PlayerPrefs.SetInt ("garnade", 0);
	
	}

	void buyBazooka(){
		earnedCoins = PlayerPrefs.GetInt ("highScoreCoin");
		if (PlayerPrefs.GetInt ("missile") == 0 &&  earnedCoins>=500) {
			PlayerPrefs.SetInt("missile",1);
			earnedCoins-=500;
			PlayerPrefs.SetInt("highScoreCoin",earnedCoins);
			unlockMissile.SetActive(false);
			GameObject.Find("Labelcoin").GetComponent<UILabel>().text=""+earnedCoins;	
		}
	}

	void buyGarnade(){
		earnedCoins = PlayerPrefs.GetInt ("highScoreCoin");
		if (PlayerPrefs.GetInt ("garnade") == 0 &&  earnedCoins>=1000) {
			PlayerPrefs.SetInt("garnade",1);
			earnedCoins-=1000;
			PlayerPrefs.SetInt("highScoreCoin",earnedCoins);
			unlockGarnade.SetActive(false);
			GameObject.Find("Labelcoin").GetComponent<UILabel>().text=""+earnedCoins;
		}
	}



	// Update is called once per frame
	void Update () {
	
	}
}
