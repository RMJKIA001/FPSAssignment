using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCam : MonoBehaviour {
    public Transform lookAt;
    public GameObject canvas;
    //Vector3 height;
	// Use this for initialization
	void Start () {
      //  height = new Vector3 (0f,2.6f, 0.255f);
    }

    // Update is called once per frame
    void Update () {
        if(gameObject.GetComponent<Camera>().enabled)
        {
            canvas.SetActive(true);
        }
        //transform.position = lookAt.position  + height;	
	}
}
