using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OpenMymap : MonoBehaviour {

    public string Filename;
    // Use this for initialization
	void Start () {
        Button bon = this.gameObject.GetComponent<Button>();
        bon.onClick.AddListener(open);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void open(){
        GameObject.Find("InterSceneData").GetComponent<InterSceneData>().setPath("./Assets/Data/"+Filename);
        SceneManager.LoadScene("PlayingScene");
    }
}
