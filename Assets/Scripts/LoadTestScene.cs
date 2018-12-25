using System.Collections;
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

        // 测试用，将sceneNUm设置为1
        // GameObject.FindGameObjectWithTag("SceneNum").GetComponent<SceneNum>().setSN(1);

        SceneManager.LoadScene("PlayingScene");
        // 不知道这里有什么变化
        // SceneManager.LoadSceneAsync("PlayingScene");
    }

    public void GoBack(){
		SceneManager.LoadScene("Main");
	}
}
