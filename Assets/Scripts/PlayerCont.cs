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
    private CharacterController cont;
    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        cont = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        float rotX = Input.GetAxis("Mouse X")*mouseMov;
        float rotY = Input.GetAxis("Mouse Y")*mouseMov;
        transform.Rotate(0,rotX,0);
        
        currCam -= rotY ;
        float newRot = Mathf.Clamp(currCam,-70,70);
        cam.transform.localRotation = Quaternion.Euler(newRot, 0, 0);
        //cam.transform.Rotate(-newRot,0,0);



        float vert = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");
        velocity += Physics.gravity.y * Time.deltaTime;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            vert += 2;
        }
        if (Input.GetButtonDown("Jump") && cont.isGrounded)
        {
            velocity = jumpSpeed;
        }
        Vector3 move = new Vector3(hori*speed, velocity, vert*speed);
         
        cont.Move(transform.rotation*move*Time.deltaTime);
	}
}
