using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingManager : MonoBehaviour {
	private List <Vector3> positions = new List <Vector3> ();
	public List <GameObject> BlackHoles=new List <GameObject> ();
	public GameObject blackhole;
	public GameObject transferGate;
	public int number=1;
	// Use this for initialization
	void Start () {
		for (int i=0;i<number;i++){
			positions.Add(new Vector3(Random.Range(-4,4),Random.Range(-4,4),0f));
		}
		for (int i=0;i<number;i++){
			GameObject instance = Instantiate(blackhole,positions[i],Quaternion.identity);
			BlackHoles.Add(instance);
		}
		Vector3 pos=new Vector3(Random.Range(-4,4),Random.Range(-4,4),0f);
		Instantiate(transferGate,pos,Quaternion.identity);
	
	}
	// Update is called once per frame
	void Update () {
		
	}
}
