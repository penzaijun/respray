using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    // output velocity
    public float outVelocity;
    // output angle
    public float angle;
    // output vector
    private Vector3 ang;

    // rotate
    private Vector3 ax = new Vector3(0.0f, 0.0f, -1.0f);

    // Use this for initialization
    void Start () {
        ang = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle), 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(ax, 50 * Time.deltaTime, Space.Self);
    }

    // Enter
    private void OnTriggerEnter(Collider other)
    {
        // effective only when player enters
        if (other.CompareTag("Player"))
        {
            other.attachedRigidbody.velocity /= 2;
        }
    }

    // Stay
    private void OnTriggerStay(Collider other)
    {
        // effective only for player
        if (other.CompareTag("Player"))
        {
            other.attachedRigidbody.velocity = outVelocity * ang;
        }
    }

    // Exit
    private void OnTriggerExit(Collider other)
    {
        // effective only for player
        if (other.CompareTag("Player"))
        {
            
        }
    }

}
