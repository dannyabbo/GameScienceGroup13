using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour {
    
    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public float rotationSpeed;

    public float sightDistance;

    private Camera mainCamera;

    public AIGunController theGun;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
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


        if (Physics.Raycast(sight, out hit, sightDistance))
        {

            if (hit.collider.gameObject.tag == "Player")
            {
                rotationSpeed = 0;
                theGun.SetState(AIGunController.State.Shoot);
            }
        }

    }
}
