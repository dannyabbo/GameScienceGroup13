using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour {



    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public float rotationSpeed;

    float rotate;


    public float sightDistance;

    private Camera mainCamera;

    public AIGunController theGun;


    public bool playerSeen;
    public bool enemySeen;
    public bool playerHit;
    public bool isDead = false;


    public float HP;
    public float damageDone;

    private int stateCase;

    public void setCase(int c){
        stateCase = c;
    }



	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        HP = 25;
        damageDone = 0;
        rotate = rotationSpeed;
    }
    //d
    // Update is called once per frame
    void Update()
    {


        RaycastHit hit;
        Ray sight = new Ray(theGun.firePoint.position, theGun.firePoint.forward);
        Debug.DrawRay(theGun.firePoint.position, theGun.firePoint.forward * sightDistance, Color.red);

        //moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        // moveVelocity = moveInput * moveSpeed;

        // Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        //float rayLength;


        playerSeen = (Physics.Raycast(sight, out hit, sightDistance) && (hit.collider.gameObject.tag == "Player"));
        enemySeen = (Physics.Raycast(sight, out hit, sightDistance) && (hit.collider.gameObject.tag == "Enemy"));
        //playerHit = 

        switch(stateCase){
            case 0:
                //shoot
                rotationSpeed = 0;
                theGun.isFiring = false;
                break;
            case 1:
                //rotate left
                theGun.isFiring = false;
                rotationSpeed = -rotate;
                break;
            case 2:
                //rotate right
                theGun.isFiring = false;
                rotationSpeed = rotate;
                break;
            case 3:
                rotationSpeed = 0;
                theGun.isFiring = true;
                break;

        }


        if(HP <= 0){
            isDead = true;
            //Destroy(this.gameObject);
        }
            
               
      

    }
}
