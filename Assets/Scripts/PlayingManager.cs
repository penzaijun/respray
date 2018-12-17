using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class PlayingManager : MonoBehaviour {
	public List <GameObject> BlackHoles=new List <GameObject> ();
	public GameObject blackhole;
	public GameObject transferGate;
	public Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);

	// Use this for initialization
	void Start () {
		//load the scene json from file
		string FileName = "Assets/Data/1.json";
        StreamReader json = File.OpenText(FileName);
        string input = json.ReadToEnd();
        JsonData jd = JsonMapper.ToObject(input); 

		//load blackhole
		for(int i=0;i<jd["black_hole"].Count;i++)
		{
			GameObject hole = (GameObject)Resources.Load("Prefabs/units/BlackHole");
			float x=float.Parse(jd["black_hole"][i]["x"].ToString());
			float y=float.Parse(jd["black_hole"][i]["y"].ToString());
			float size=float.Parse(jd["black_hole"][i]["size"].ToString());
			float force=float.Parse(jd["black_hole"][i]["force"].ToString());
			Vector3 positions_black_hole = new Vector3(x,y,0f);
			GameObject instance = Instantiate(hole,positions_black_hole,Quaternion.identity);
			BlackHoles.Add(instance);
		}
		
		//load transfer gate
		List <Vector3> gate_poss = new List <Vector3> ();
		List <GameObject> gates=new List <GameObject> ();
		for(int i=0;i<jd["transfer_gate"].Count;i++){
			float x=float.Parse(jd["transfer_gate"][i]["x"].ToString());
			float y=float.Parse(jd["transfer_gate"][i]["y"].ToString());
			float size=float.Parse(jd["transfer_gate"][i]["size"].ToString());
			GameObject gate = (GameObject)Resources.Load("Prefabs/TransferGate");
			gate_poss.Add(new Vector3(x,y,0f));
			if(i%2==0){gate.name = "TransferGateA"+Convert.ToString(i/2);}
			else{gate.name = "TransferGateB"+Convert.ToString(i/2);}
			GameObject gate_object = Instantiate(gate,gate_poss[i],Quaternion.identity);
			gates.Add(gate_object);
		} 
		for(int i=0;i<jd["transfer_gate"].Count/2;i++){
			int Ai=2*i,Bi=2*i+1;
			GameObject gateA=gates[Ai];
			GameObject gateB=gates[Bi];
			gateA.GetComponent<TransferGate>().tgTarget = gateB.GetComponent<TransferGate>();
			gateA.GetComponent<TransferGate>().v3Target = gate_poss[Bi];
			gateB.GetComponent<TransferGate>().tgTarget = gateA.GetComponent<TransferGate>();
			gateB.GetComponent<TransferGate>().v3Target = gate_poss[Ai];
		}

		
		//load star
		for(int i=0;i<jd["star"].Count;i++){
			GameObject star = (GameObject)Resources.Load("Prefabs/units/F_star");
			float x=float.Parse(jd["star"][i]["x"].ToString());
			float y=float.Parse(jd["star"][i]["y"].ToString());
			float size=float.Parse(jd["star"][i]["size"].ToString());
			Vector3 pos=new Vector3(x,y,0f);
			Instantiate(star,pos,Quaternion.identity);
		} 

		//load player
		{
			GameObject player = (GameObject)Resources.Load("Prefabs/Player");
			float x=float.Parse(jd["player"]["x"].ToString());
			float y=float.Parse(jd["player"]["y"].ToString());
			float size=float.Parse(jd["player"]["size"].ToString());
			Vector3 pos=new Vector3(x,y,0f);
			player.tag = "Player";
			Instantiate(player,pos,Quaternion.identity);

		}

		//load end gate,must copy end gate
		for(int i=0;i<jd["end_gate"].Count;i++){
			GameObject end_gate = GameObject.FindWithTag("Flag");
			float x=float.Parse(jd["end_gate"][i]["x"].ToString());
			float y=float.Parse(jd["end_gate"][i]["y"].ToString());
			float size=float.Parse(jd["end_gate"][i]["size"].ToString());
			Vector3 pos=new Vector3(x,y,0f);
			Instantiate(end_gate,pos,Quaternion.identity);
		}

	}
	// Update is called once per frame
	void Update () {
		
	}
}
