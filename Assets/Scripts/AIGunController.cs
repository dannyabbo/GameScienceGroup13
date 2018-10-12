using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIGunController : MonoBehaviour {


    public enum State { Initial, Watch, Shoot }
    State _state = State.Initial;

    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;



  


    public State CurrentState
    {
        get { return _state; }
    }

    public void SetState(State newState)
    {
        _state = newState;
        //PrintState();
    }

    void Watch()
    {
       

    }

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

   
    void Initial(){
        SetState(State.Shoot);
    }



    // Use this for initialization
    IEnumerator Start () {
        while (true)
        {
            switch (_state)
            {
                case State.Initial:
                    break;
                case State.Watch:
                    break;
                case State.Shoot:
                    Shoot();
                    break;
            }
            yield return null;
        }
    }
    /*
    // Update is called once per frame
    IEnumerator Update () {


	}
    */
}
