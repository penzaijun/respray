using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGate : MonoBehaviour {

    // the output velocity is fixed
    public float vOut;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // After exit ths area, change the velocity
    private void OnTriggerExit(Collider other)
    {
        // Onlu effect for player
        if (other.CompareTag("Player"))
        {
            other.attachedRigidbody.velocity = other.attachedRigidbody.velocity.normalized * vOut;
        }
    }

}
