using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIGunController : MonoBehaviour {



    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;



    void Shoot(){
    
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }

    }

  

 

    // Use this for initialization
    public void Start () {

    }

    public void Update()
    {
        Shoot();
    }
    /*
    // Update is called once per frame
    IEnumerator Update () {


	}
    */
}
