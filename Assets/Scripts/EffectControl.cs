using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EffectControl : MonoBehaviour {

    private ParticleSystem.ShapeModule shape;

    // Use this for initialization
    void Start () {
        GetComponent<ParticleSystem>().Stop();
        shape = GetComponent<ParticleSystem>().shape;
  
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    public void update(Vector2 v2)
    {
        double angle = Math.Atan2(v2.y, v2.x) * 180 / Math.PI;
        //double angle =Vector2.Angle(v1, v2);
        //double i = v2.y;
        Vector3 v3 = new Vector3(0,0,(float)(angle+90));
        shape.rotation = v3;
        GetComponent<ParticleSystem>().Play();
    }
}
