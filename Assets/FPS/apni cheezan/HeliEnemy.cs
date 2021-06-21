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

public class HeliEnemy : MonoBehaviour {

    public Transform target;
    public Transform fakeTarget;

    public GameObject Bullets; // Bullet prefeb
    public GameObject Rocket; // Rocket prefeb


    public float LifeTimeBullet = 5;
    public int Spread = 0;
    private float guntimefire = 0;
    public float gunFireRate = 0.2f;

    private float rockettimefire = 0;
    public float rocketFireRate = 0.2f;


    public float flySpeed;

    public float minDistance;

    bool isPaused;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

        if (isPaused) return;

        //transform.LookAt(targetPos);
        LookAtTarget();

        Chase();

    }

    void OnPauseGame()
    {
        isPaused = true;
    }

    void OnResumeGame()
    {
        isPaused = false;
    }

    void LookAtTarget()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3f);
    }

    void Chase()
    {
        Vector3 targetPos, faketargetPos;

        targetPos = target.position;
        faketargetPos = fakeTarget.position;

        float step = flySpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, faketargetPos) <= minDistance)
        {
            //fire
            Attack();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, faketargetPos, step);

            Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3f);
        }
    }

    void Attack()
    {

        if (guntimefire + gunFireRate < Time.time)
        {
            Debug.Log("Machine gun Firing");

            Vector3 point = target.position;
            GameObject bullet = (GameObject)Instantiate(Bullets, transform.position, transform.rotation);
            bullet.transform.forward = transform.forward + (new Vector3(Random.Range(-Spread, Spread), Random.Range(-Spread, Spread), Random.Range(-Spread, Spread)) * 0.001f);
            Destroy(bullet, LifeTimeBullet);

            guntimefire = Time.time;   
        }


        if (rockettimefire + rocketFireRate < Time.time)
        {
            Debug.Log("Machine gun Firing");

            GameObject rocket = (GameObject)Instantiate(Rocket, transform.position, transform.rotation);
            rocket.transform.forward = transform.forward + (new Vector3(Random.Range(-Spread, Spread), Random.Range(-Spread, Spread), Random.Range(-Spread, Spread)) * 0.001f);
            Destroy(rocket, LifeTimeBullet);

            rockettimefire = Time.time;
        }


    }

}
