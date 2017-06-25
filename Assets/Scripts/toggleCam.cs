using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleCam : MonoBehaviour {
    public Camera fps;
    public Camera tp;
    //public Camera td;
	// Use this for initialization
	void Start () {
        //fps.enabled = true;
        //tp.enabled = false;
        fps.gameObject.SetActive(true);
        tp.gameObject.SetActive(false);
        tp.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.C))
        {
            //Debug.Log("Third Person " + tp.enabled + "\nFirst Person " + fps.enabled);
            if (fps.enabled)
            {
                fps.gameObject.SetActive(false);
                fps.enabled = false;
                tp.gameObject.SetActive(true);
                tp.enabled = true;
            }
            else if(tp.enabled)
            {
                tp.gameObject.SetActive(false);
                tp.enabled = false;
                fps.gameObject.SetActive(true);
                fps.enabled = true;
            }
        }
	}
}
