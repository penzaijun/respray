using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleControl : MonoBehaviour {

	public Text TitleText;
	public float H = 0;
	public float V = 0;
	private int timer = 0;
	private int dx = 1;
	// Use this for initialization
	void Start () {
		TitleText.color = new Color(255,0,255,1);
	}
	
	// Update is called once per frame
	void Update () {
		timer += dx;
		TitleText.color = Color.HSVToRGB(H/255f,timer/255f,V/255f);
		if (timer==255) dx=-1;
		if (timer==0) dx=1;
	}
}
