using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleCam : MonoBehaviour {
    public Camera fps;
    public Camera tp;
    public Camera orb;
    //public Camera td;
	// Use this for initialization
	void Start () {
        fps.enabled = true;
        tp.enabled = false;
        orb.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (fps.enabled)
            {
                fps.enabled = false;
                tp.enabled = true;
            }
            else if(tp.enabled)
            {
                tp.enabled = false;
                orb.enabled = true;
            }
            else if(orb.enabled)
            {
                orb.enabled = false;
                fps.enabled = true;
            }
        }
	}
}
