using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGate : MonoBehaviour {

    // Bounds
    public Bound bound_1;
    public Bound bound_2;
    // interval
    public float interval;
    // relative length of corridor
    public float relativeLength;
    // is fixed angle
    public bool isFixed;
    // angular velocity
    public float anVel;
    // the value of angle
    public float angle;
    // rotate axis
    private Vector3 ax = new Vector3(0.0f, 0.0f, 1.0f);

	// Use this for initialization
	void Start () {

        // change the relatvie scale of two bounds
        transform.localScale = new Vector3(relativeLength, 1.0f, 1.0f);

        // rotate it
        transform.RotateAround(transform.position, ax, angle);

    }
	
	// Update is called once per frame
	void Update () {
        if (!isFixed)
        {
            transform.RotateAround(transform.position, ax, 50 * Time.deltaTime * anVel);
        }
    }
}
