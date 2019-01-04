using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Upload : MonoBehaviour {

    public GameObject server;
    public string Filename;

	// Use this for initialization
	void Start () {
        //server = GameObject.Find("DownloadFromServer");
        this.gameObject.GetComponent<Button>().onClick.AddListener(upload);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void upload(){

        //server.GetComponent<InteractWithServer>().Upload(Filename);
    }
}
