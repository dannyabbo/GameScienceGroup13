using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter1Controller : MonoBehaviour {
    
    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController theGun;

    public int HP = 25;
    public bool isDead = false;

    // Use this for initialization
    void Start () {
		myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
	}
	//d
	// Update is called once per frame
	void Update () {
		moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }


        if (HP <= 0)
        {
            isDead = true;
            Destroy(this.gameObject);
        }

    }
    
    void FixedUpdate () {
        myRigidbody.velocity = moveVelocity;
    }
}
