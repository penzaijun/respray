﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadTestScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Load(){
		SceneManager.LoadScene("PlayingScene");
	}

	public void GoBack(){
		SceneManager.LoadScene("Main");
	}
}
