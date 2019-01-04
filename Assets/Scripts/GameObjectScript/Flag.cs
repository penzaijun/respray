using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour {
    public GameObject WinUI;
    
    
    void Awake() {
    }
	// Use this for initialization
	void Start () {
         
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        // 只有撞向玩家才会触发
        if (collider.CompareTag("Player"))
        {
            WinUI.SetActive(true);
            GameObject InterSceneData = GameObject.Find("InterSceneData");
            InterSceneData.GetComponent<InterSceneData>().SetStarNum(collider.gameObject.GetComponent<PlayerController>().getF(),InterSceneData.GetComponent<InterSceneData>().getLevelNum());
            collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationZ;
        }
    }

}
