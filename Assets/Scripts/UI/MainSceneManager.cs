using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour {

    public int levelnum=25;
    public GameObject Choose;
    public GameObject Content;
    public GameObject Welcome;
    private GameObject InterSceneData;
    
    public GameObject GetWelcome(){
        return this.Welcome;
    }
	// Use this for initialization
	void Start () {
        InterSceneData = GameObject.Find("InterSceneData");
        int LastNotLockLevel = InterSceneData.GetComponent<InterSceneData>().LastNotLockLevel;
        for (int i=0;i<levelnum;i++)
        {
            GameObject level= Instantiate(Resources.Load("Prefabs/UIObject/GameLevelUIObject")) as GameObject;
            level.transform.SetParent(Content.transform);
            level.transform.localScale = new Vector3(1, 1, 1);
            LevelSelect l = level.GetComponent<LevelSelect>();
            if ((i + 1) <= LastNotLockLevel) l.unlock();
            l.SetLevelNum(i + 1);
            l.UpdateStar(InterSceneData.GetComponent<InterSceneData>().starnum[i]);
        }
        //Choose.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
