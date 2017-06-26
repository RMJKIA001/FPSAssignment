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
    private Animator ani;
    public new AudioSource audio;
    public AudioClip[] walk;
    public AudioClip jump;
    public AudioClip land;
    public  AudioClip shot;

    public int damage = 1;
    public float rate = 0.25f;
    public float range = 50f;
    public float hitF = 100f;
    private float nextFire;

    // Use this for initialization
    void Start () {
        //Cursor.visible = false;
        cont = GetComponent<CharacterController>();
        ani = GetComponentInChildren<Animator>();
        audio = GetComponent<AudioSource>();
    }
    void shoot(bool walking)
    {
        
        if (walking)
        {
            
            audio.loop = false;
        }
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rate;
            audio.clip = shot;

            audio.Play();
            Vector3 rayOrig = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(rayOrig, cam.transform.forward, out hit, range))
            {
                Shootable obj = hit.collider.GetComponent<Shootable>();
                if (obj != null)
                {
                    obj.Damage(damage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitF);
                }
            }
        }
     
    }
    private void FixedUpdate()
    {
        ani.SetBool("Shoot", false);
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
        if(isWalking && audio.isPlaying == false && cont.isGrounded)
        {
            audio.clip = walk[0];
            audio.loop = true;
            audio.Play();
        }
        if(!isWalking)
        {
            audio.loop = false;
            //audio.Stop();
        }
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
            //ani.SetBool("Jump", true);
        }
        bool shooting = Input.GetButtonDown("Fire1");
        if (shooting)
        {
            ani.SetBool("Shoot", true);
            shoot(isWalking);
            
        }
        
                
        //ani.SetBool("Jump", false);
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
