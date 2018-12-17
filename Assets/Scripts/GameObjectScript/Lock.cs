using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {

    // the object that will be destroyed
    public GameObject game_object;
    // the unlock material
    public Material material;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(game_object);
            enabled = false;
            gameObject.GetComponent<Renderer>().material = material;
        }
        
    }

}
