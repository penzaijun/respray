using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    public int levelnum=0;
    public Text leveltext;

	// Use this for initialization
	void Start () {
        leveltext.text = levelnum.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
