using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour {
    public float speed =5;
    public float mouseMov = 1;
    public float jumpSpeed = 4;
    public Camera cam;
    private float currCam = 0;
    private float velocity = 0;
    public bool isRunning=false;
    private CharacterController cont;
    public Animator ani;
    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        cont = GetComponent<CharacterController>();
        ani = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
        float rotX = Input.GetAxis("Mouse X") * mouseMov;
        float rotY = Input.GetAxis("Mouse Y") * mouseMov;
        transform.Rotate(0, rotX, 0);

        currCam -= rotY;
        float newRot = Mathf.Clamp(currCam, -50, 50);
        cam.transform.localRotation = Quaternion.Euler(newRot, 0, 0);


        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");
        velocity += Physics.gravity.y * Time.deltaTime;
        bool isWalking = (vert != 0 || hori != 0);
        if (Input.GetKey(KeyCode.LeftShift) && isWalking)
        {
            vert *= 2f;
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        if (Input.GetButtonDown("Jump") && cont.isGrounded)
        {
            velocity = jumpSpeed;
        }
        Vector3 move = new Vector3(hori*speed, velocity, vert*speed); 
        cont.Move(transform.rotation*move*Time.deltaTime);
        animate(isWalking);
	}

    void animate(bool walk)
    {
        if(isRunning)
        {
            ani.SetBool("Walking", false);
            ani.SetBool("Running", true);
        }
        else if(walk)
        {
            ani.SetBool("Running", false);
            ani.SetBool("Walking", true);
        }
        else
        {
            ani.SetBool("Walking", false);
            ani.SetBool("Running", false);
        }
    }
}
