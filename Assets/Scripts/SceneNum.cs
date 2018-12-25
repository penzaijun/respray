using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNum : MonoBehaviour {

    private int sceneNum;

	// Use this for initialization
	void Start () {
        // 设置不可销毁
        GameObject.DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // 设置scene的序号
    public void setSN(int no)
    {
        sceneNum = no;
    }

    // 获取scene的序号
    public int getSN()
    {
        return sceneNum;
    }
}
