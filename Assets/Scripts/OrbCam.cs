using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCam : MonoBehaviour {

    public Transform lookAt;
    public Camera cam;
    public GameObject canvas;
    private float distance = 0;
    
    private float speed = 12;
    //private float offset = 0;
    void Update()
    {
        if (gameObject.GetComponent<Camera>().enabled)
        {
            canvas.SetActive(false);
        }

        if(Input.GetAxis("Mouse ScrollWheel")!=0)
        {
            distance = Input.GetAxis("Mouse ScrollWheel");
            //distance = Mathf.Clamp(distance, 3, 13);
            cam.transform.Translate(new Vector3(0, 0, distance));
        }


        cam.transform.RotateAround(lookAt.position, Vector3.up, speed * Time.deltaTime);
        cam.transform.LookAt(lookAt.position);
    }
    

}
