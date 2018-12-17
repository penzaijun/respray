using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : MonoBehaviour {

    public GameObject player;
    public GameObject transferGate;

    private Vector3 vel;
    private float mag = 200;
    private float ang;
    
    // Use this for initialization
    void Start()
    {

        Vector3 pos = new Vector3(0f, 0f, 0f);
        Instantiate(transferGate, pos, Quaternion.identity);

        player.transform.position = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        ang = Random.Range(0, 2 * Mathf.PI);
        vel = new Vector3(Mathf.Cos(ang), Mathf.Sin(ang), 0.0f) * mag;
    }
    // Update is called once per frame
    void Update()
    {
        player.GetComponent<Rigidbody>().velocity = vel;

        if (player.transform.position.magnitude > 20)
        {
            player.transform.position = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
            ang = Random.Range(0, 2 * Mathf.PI);
            vel = new Vector3(Mathf.Cos(ang), Mathf.Sin(ang), 0.0f) * mag;
        }
    }
}
