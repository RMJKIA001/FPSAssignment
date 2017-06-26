using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCam : MonoBehaviour {

    public Transform lookAt;
    public Camera cam;
    public GameObject canvas;
    //private float distance = 5;
    
    private float speed = 12;
    //private float offset = 0;
    void Update()
    {
        if (gameObject.GetComponent<Camera>().enabled)
        {
            canvas.SetActive(false);
        }
        cam.transform.RotateAround(lookAt.position, Vector3.up, speed * Time.deltaTime);
        cam.transform.LookAt(lookAt.position);
    }
    

}
