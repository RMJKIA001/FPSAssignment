using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour {
    public Transform lookAt;
    public Camera cam;
    public float x = 3;
    public float y = -20;
    private float distance = 5;
    private float currX = 0;
    

    void Update()
    {
        //currY += Input.GetAxis("Mouse Y");
        
        currX += Input.GetAxis("Mouse X");
        distance -= Input.GetAxis("Mouse ScrollWheel");
        distance = Mathf.Clamp(distance, 1, 10);
        
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0,0, -distance);
        //float t = -(distance * 4);
        Quaternion rot = Quaternion.Euler(0, currX, 0);
        Vector3 moveUp = new Vector3(0, distance / 3, 0);
        cam.transform.position = lookAt.position + rot*dir + moveUp;

        cam.transform.LookAt(lookAt.position);


         //Debug.Log(distance);
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
