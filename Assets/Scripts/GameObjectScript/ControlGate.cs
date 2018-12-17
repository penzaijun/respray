using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Some problems exist here, since we cannot get the collision from collider, so the angle is not easily determined

public class ControlGate : MonoBehaviour {

    // enter velocity
    public float permit_vel;
    // elastic ratio
    public float elastic_ratio = 1;
    // the position of core
    private Vector3 posCore;

    // Use this for initialization
    void Start () {
        posCore = transform.position;
        if (elastic_ratio < 0 || elastic_ratio > 1)
            elastic_ratio = 1;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    // enter the area
    private void OnTriggerEnter(Collider other)
    {
        // only effective for player
        if (other.CompareTag("Player"))
        {
            Vector3 vel = other.attachedRigidbody.velocity;
            if (vel.magnitude < permit_vel)
            {
                Vector3 ndir = - (other.transform.position - posCore).normalized;
                Vector3 nel = (vel.x * ndir.x + vel.y * ndir.y + vel.z * ndir.z) * ndir;
                // there must be some delay, the coefficients can be changed
                other.attachedRigidbody.velocity = vel - 2 * nel;
            }
        }
    }

}
