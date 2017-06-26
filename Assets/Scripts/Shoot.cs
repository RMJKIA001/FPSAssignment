using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public int damage = 1;
    public float rate = 0.25f;
    public float range = 50f;
    public float hitF = 100f;
    private float nextFire;
    //public Transform gun;
    public Camera fps;
    private new AudioSource audio;
    public AudioClip shot;
    private Animator ani;
    
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
        audio.clip = shot;
        //fps = GetComponentInParent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + rate;
            ani.SetBool("Shoot", true);
            audio.Play();
            Vector3 rayOrig = fps.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(rayOrig, fps.transform.forward, out hit, range))
            {
                Shootable obj = hit.collider.GetComponent<Shootable>();
                if(obj !=null)
                {
                    obj.Damage(damage);
                }
                if(hit.rigidbody !=null)
                {
                    hit.rigidbody.AddForce(-hit.normal*hitF);
                }
            }
        }
        
	}
}
