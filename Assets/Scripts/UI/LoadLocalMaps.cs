using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;
public class LoadLocalMaps : MonoBehaviour {
	public GameObject myMaps;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadMaps(){
		Transform temp=myMaps.transform;
		int childCount = temp.childCount;
		for (int i = 0; i < childCount ; i++) {
			Destroy (temp.GetChild(0).gameObject);
		}
		GameObject mymap=GameObject.Find("myCreation");
		string dir = @".\Assets\Data";
		DirectoryInfo theFolder = new DirectoryInfo(dir);
		FileInfo[] fileInfo = theFolder.GetFiles();
		foreach(FileInfo file in fileInfo){
			string FirstName = file.Name.Substring(file.Name.LastIndexOf("\\") + 1, (file.Name.LastIndexOf(".") - file.Name.LastIndexOf("\\") - 1)); //文件名
			string LastName = file.Name.Substring(file.Name.LastIndexOf(".") + 1, (file.Name.Length - file.Name.LastIndexOf(".") - 1)); //扩展名
			if (file.Name.EndsWith("json")){
				GameObject myNewMission = Instantiate(Resources.Load("Prefabs/UIObject/MyMissionObject")) as GameObject;
				myNewMission.transform.SetParent(myMaps.transform);
				myNewMission.GetComponentsInChildren<Text>()[0].text=FirstName;
			}
			//myNewMission.transform.localScale=new Vector3(1,1,1);
		}
	}
}
