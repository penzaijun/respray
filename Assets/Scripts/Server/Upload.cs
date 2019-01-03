using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upload : MonoBehaviour {

    //public GameObject mymap;
    public GameObject server;
    public string Filename;
    public int i;
	// Use this for initialization
	void Start () {
        //mymap = GameObject.Find("Mylocalmap");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void upload(){
        //string Filename = mymap.GetComponent<Mymap>().Filename;
        server.GetComponent<InteractWithServer>().Upload(Filename);
    }
}
