using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Awake()
    {
        //process first open case
        if(!PlayerPrefs.HasKey("firstopen"))
        {
            PlayerPrefs.SetInt("firstopen", 1);
            PlayerPrefs.SetInt("music", 50);        // music strenth:[0,100]
        }
        //normal case
        else
        {
            
        }
    }
}
