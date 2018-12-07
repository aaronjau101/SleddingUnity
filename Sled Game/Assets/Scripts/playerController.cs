using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    //Just a GitHub test

    Vector3 offset;
    public GameObject snowParticles;
    public Vector3 velocity;
    Rigidbody rb;
    bool start;

	// Use this for initialization
	void Start () {
        offset = Camera.main.transform.position - this.transform.position;
        rb = this.GetComponent<Rigidbody>();
        start = true;
        velocity = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        Camera.main.transform.position = this.transform.position + offset;
        if (!start)
        {
            velocity = rb.velocity;
            Quaternion angle = Quaternion.LookRotation(velocity, Vector3.up * 90f);
           
            this.transform.rotation = angle;
        }   
    }


    private void OnCollisionEnter(Collision collision)
    {
        start = false;
        
        Quaternion angle = Quaternion.LookRotation(velocity, Vector3.up * 90f);
        if (transform.rotation.eulerAngles.x - angle.x > 70)
        {
            Debug.Log("Crash");
            Instantiate(snowParticles, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }

}
