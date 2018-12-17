using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbBound : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.attachedRigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }

}
