using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour {
    public Transform lookAt;
    public Camera cam;
    public GameObject canvas;
    private float distance = 7;
    private float currX = 0;
    private float currY = 0;
    private bool other;
    
    void Update()
    {
        if (gameObject.GetComponent<Camera>().enabled)
        {
            canvas.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            if(other)
            {
                other = false;
            }
            else
            {
                other = true;
            }

        }
        if(other)
        {
            currY += Input.GetAxis("Mouse Y");
            currY = Mathf.Clamp(currY, 0, 80);
        }
        currX += Input.GetAxis("Mouse X");
        distance -= Input.GetAxis("Mouse ScrollWheel");
        distance = Mathf.Clamp(distance, 3, 13);
        
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0,0, -distance);
        Quaternion rot = Quaternion.Euler(currY, currX, 0);
        Vector3 moveUp = new Vector3(0,1.8f, 0);

        cam.transform.position = lookAt.position + rot*dir +moveUp;
        cam.transform.forward = dir;
        cam.transform.LookAt(lookAt.position);
        
    }
	
}

/*
 Vector3 direction = (lookAt.position - cam.transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(direction);
        lookrotation.x = transform.rotation.x;
        lookrotation.z = transform.rotation.z;

        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 100);
        transform.position = Vector3.Slerp(transform.position, lookAt.position, Time.deltaTime * 1);
     */
//camTransform.rotation = lookAt.rotation;
