using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy" || col.gameObject.tag == "Wall")
        {


            if(col.gameObject.tag == "Enemy"){
                col.gameObject.GetComponent<FighterController>().HP -= damage;
            }
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<Fighter1Controller>().HP -= damage;
            }

            if(gameObject.transform.parent.gameObject.tag == "Enemy"){
                gameObject.transform.parent.gameObject.GetComponent<FighterController>().damageDone += damage;
            }
            Destroy(this.gameObject);

        }

    }
}
