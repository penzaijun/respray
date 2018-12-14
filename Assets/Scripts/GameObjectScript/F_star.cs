using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_star : MonoBehaviour {

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
            collider.GetComponent<PlayerController>().incF();
            // 测试
            //Debug.Log(collider.GetComponent<PlayerController>().getF());
            Destroy(this.gameObject);
        }
    }


}
