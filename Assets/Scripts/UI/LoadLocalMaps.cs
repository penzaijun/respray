using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;
public class LoadLocalMaps : MonoBehaviour {
	public GameObject myMaps;
	public GameObject downloadMaps;
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
			Destroy (temp.GetChild(i).gameObject);
		}
		GameObject mymap=GameObject.Find("myCreation");
		string dir = @".\Assets\Data";
		DirectoryInfo theFolder = new DirectoryInfo(dir);
		FileInfo[] fileInfo = theFolder.GetFiles();
		foreach(FileInfo file in fileInfo){
			string FirstName = file.Name.Substring(file.Name.LastIndexOf("\\") + 1, (file.Name.LastIndexOf(".") - file.Name.LastIndexOf("\\") - 1)); //文件名
			string MapName = file.Name.Substring(file.Name.LastIndexOf("\\") + 1, (file.Name.LastIndexOf("_") - file.Name.LastIndexOf("\\") - 1)); //地图名
            string LastName = file.Name.Substring(file.Name.LastIndexOf(".") + 1, (file.Name.Length - file.Name.LastIndexOf(".") - 1)); //扩展名
			if (file.Name.EndsWith("json")){
				GameObject myNewMission = Instantiate(Resources.Load("Prefabs/UIObject/MyLocalmap")) as GameObject;
				myNewMission.transform.SetParent(myMaps.transform);
                myNewMission.transform.localScale = new Vector3(1.69f, 1, 1);
                myNewMission.GetComponentsInChildren<Text>()[0].text = MapName;
            }
			//
		}

        temp = downloadMaps.transform;
        childCount = temp.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(temp.GetChild(i).gameObject);
        }
        GameObject downloadmap = GameObject.Find("Download");
        dir = @".\Assets\Data\Download_";
        theFolder = new DirectoryInfo(dir);
        fileInfo = theFolder.GetFiles();
        foreach (FileInfo file in fileInfo)
        {
            string FirstName = file.Name.Substring(file.Name.LastIndexOf("\\") + 1, (file.Name.LastIndexOf(".") - file.Name.LastIndexOf("\\") - 1)); //文件名
            string MapName = file.Name.Substring(file.Name.LastIndexOf("\\") + 1, (file.Name.LastIndexOf("_") - file.Name.LastIndexOf("\\") - 1)); //地图名
            string LastName = file.Name.Substring(file.Name.LastIndexOf(".") + 1, (file.Name.Length - file.Name.LastIndexOf(".") - 1)); //扩展名
            if (file.Name.EndsWith("json"))
            {
                GameObject myNewMission = Instantiate(Resources.Load("Prefabs/UIObject/Download")) as GameObject;
                myNewMission.transform.SetParent(downloadMaps.transform);
                myNewMission.transform.localScale = new Vector3(1.69f, 1, 1);
                myNewMission.GetComponentsInChildren<Text>()[0].text = MapName;
            }
            //
        }
    }
    public void compare()
    {

    }
}
