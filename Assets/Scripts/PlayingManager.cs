using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class PlayingManager : MonoBehaviour {
	public List <GameObject> BlackHoles=new List <GameObject> ();
	public List <GameObject> TransferGates=new List <GameObject> ();
	public List <GameObject> Stars=new List <GameObject> ();
	public List <GameObject> Flags=new List <GameObject> ();
	public List <GameObject> Bounds=new List <GameObject> ();
	public List <GameObject> AbsorbBounds=new List <GameObject> ();
	public List <GameObject> ControlGates=new List <GameObject> ();
	public List <GameObject> RotateGates=new List <GameObject> ();
	public List <GameObject> Shooters=new List <GameObject> ();
	public List <GameObject> SpeedGates=new List <GameObject> ();
	public GameObject Player = null;
    public int level;
    

	public float abs(float a){
		if(a<=0) return -a;
		else return a;
	}
	public bool sign(float a){
		if(a<=0) return false;
		else return true;
	}


	// Use this for initialization
	void Start () {
        GameObject InterSceneData = GameObject.Find("InterSceneData");
        Loadmap(InterSceneData.GetComponent<InterSceneData>().getPath());
	}
	// Update is called once per frame
	void Update () {
		
	}

    void Loadmap(string path)
    {
    //load the scene json from file
    
    StreamReader json = File.OpenText(path);
    string input = json.ReadToEnd();
    JsonData jd = JsonMapper.ToObject(input);

    //load blackhole
    for (int i = 0; i < jd["BlackHole"].Count; i++)
    {
        GameObject hole = (GameObject)Resources.Load("Prefabs/GameObject/BlackHole");
        float x = float.Parse(jd["BlackHole"][i]["x"].ToString());
        float y = float.Parse(jd["BlackHole"][i]["y"].ToString());
        float size = float.Parse(jd["BlackHole"][i]["size"].ToString());
        float force = float.Parse(jd["BlackHole"][i]["force"].ToString());
        Vector3 positions_black_hole = new Vector3(x, y, 0f);
        GameObject instance = Instantiate(hole, positions_black_hole, Quaternion.identity);
        instance.GetComponent<ForceField>().magn = abs(force);
        instance.GetComponent<ForceField>().isAttract = !sign(force);
        instance.transform.localScale *= size;
        BlackHoles.Add(instance);
    }

    //load transfer gate group
    for (int i = 0; i < jd["TransferGate"].Count; i++)
    {
        int gate_num = int.Parse(jd["TransferGate"][i]["num"].ToString());
        if (gate_num == 2)
        {//double gate
            float Ax = float.Parse(jd["TransferGate"][i]["Ax"].ToString());
            float Ay = float.Parse(jd["TransferGate"][i]["Ay"].ToString());
            Vector3 Apos = new Vector3(Ax, Ay, 0f);
            float Bx = float.Parse(jd["TransferGate"][i]["Bx"].ToString());
            float By = float.Parse(jd["TransferGate"][i]["By"].ToString());
            Vector3 Bpos = new Vector3(Bx, By, 0f);
            float size = float.Parse(jd["TransferGate"][i]["size"].ToString());
            //load prefab
            GameObject gate = (GameObject)Resources.Load("Prefabs/GameObject/TransferGate");
            GameObject gate_object_A = Instantiate(gate, Apos, Quaternion.identity);
            GameObject gate_object_B = Instantiate(gate, Bpos, Quaternion.identity);
            gate_object_A.transform.localScale *= size;
            gate_object_B.transform.localScale *= size;
            TransferGates.Add(gate_object_A);
            TransferGates.Add(gate_object_B);
            gate_object_A.GetComponent<TransferGate>().tgTarget = gate_object_B.GetComponent<TransferGate>();
            gate_object_A.GetComponent<TransferGate>().v3Target = Bpos;
            gate_object_B.GetComponent<TransferGate>().tgTarget = gate_object_A.GetComponent<TransferGate>();
            gate_object_B.GetComponent<TransferGate>().v3Target = Apos;
        }
        else if (gate_num == 3)
        {//trible gate
            float Ax = float.Parse(jd["TransferGate"][i]["Ax"].ToString());
            float Ay = float.Parse(jd["TransferGate"][i]["Ay"].ToString());
            Vector3 Apos = new Vector3(Ax, Ay, 0f);
            float Bx = float.Parse(jd["TransferGate"][i]["Bx"].ToString());
            float By = float.Parse(jd["TransferGate"][i]["By"].ToString());
            Vector3 Bpos = new Vector3(Bx, By, 0f);
            float Cx = float.Parse(jd["TransferGate"][i]["Cx"].ToString());
            float Cy = float.Parse(jd["TransferGate"][i]["Cy"].ToString());
            Vector3 Cpos = new Vector3(Cx, Cy, 0f);
            float size = float.Parse(jd["TransferGate"][i]["size"].ToString());
            //load prefab
            GameObject gate = (GameObject)Resources.Load("Prefabs/GameObject/TransferGate");
            GameObject gate_object_A = Instantiate(gate, Apos, Quaternion.identity);
            GameObject gate_object_B = Instantiate(gate, Bpos, Quaternion.identity);
            GameObject gate_object_C = Instantiate(gate, Cpos, Quaternion.identity);
            gate_object_A.transform.localScale *= size;
            gate_object_B.transform.localScale *= size;
            gate_object_C.transform.localScale *= size;
            TransferGates.Add(gate_object_A);
            TransferGates.Add(gate_object_B);
            TransferGates.Add(gate_object_C);
            gate_object_A.GetComponent<TransferGate>().tgTarget = gate_object_B.GetComponent<TransferGate>();
            gate_object_A.GetComponent<TransferGate>().v3Target = Bpos;
            gate_object_B.GetComponent<TransferGate>().tgTarget = gate_object_C.GetComponent<TransferGate>();
            gate_object_B.GetComponent<TransferGate>().v3Target = Cpos;
            gate_object_C.GetComponent<TransferGate>().tgTarget = gate_object_A.GetComponent<TransferGate>();
            gate_object_C.GetComponent<TransferGate>().v3Target = Apos;
        }
        else if (gate_num == 4)
        {//4 gate
            float Ax = float.Parse(jd["TransferGate"][i]["Ax"].ToString());
            float Ay = float.Parse(jd["TransferGate"][i]["Ay"].ToString());
            Vector3 Apos = new Vector3(Ax, Ay, 0f);
            float Bx = float.Parse(jd["TransferGate"][i]["Bx"].ToString());
            float By = float.Parse(jd["TransferGate"][i]["By"].ToString());
            Vector3 Bpos = new Vector3(Bx, By, 0f);
            float Cx = float.Parse(jd["TransferGate"][i]["Cx"].ToString());
            float Cy = float.Parse(jd["TransferGate"][i]["Cy"].ToString());
            Vector3 Cpos = new Vector3(Cx, Cy, 0f);
            float Dx = float.Parse(jd["TransferGate"][i]["Dx"].ToString());
            float Dy = float.Parse(jd["TransferGate"][i]["Dy"].ToString());
            Vector3 Dpos = new Vector3(Dx, Dy, 0f);
            float size = float.Parse(jd["TransferGate"][i]["size"].ToString());
            //load prefab
            GameObject gate = (GameObject)Resources.Load("Prefabs/GameObject/TransferGate");
            GameObject gate_object_A = Instantiate(gate, Apos, Quaternion.identity);
            GameObject gate_object_B = Instantiate(gate, Bpos, Quaternion.identity);
            GameObject gate_object_C = Instantiate(gate, Cpos, Quaternion.identity);
            GameObject gate_object_D = Instantiate(gate, Dpos, Quaternion.identity);
            gate_object_A.transform.localScale *= size;
            gate_object_B.transform.localScale *= size;
            gate_object_C.transform.localScale *= size;
            gate_object_D.transform.localScale *= size;
            TransferGates.Add(gate_object_A);
            TransferGates.Add(gate_object_B);
            TransferGates.Add(gate_object_C);
            TransferGates.Add(gate_object_D);
            gate_object_A.GetComponent<TransferGate>().tgTarget = gate_object_B.GetComponent<TransferGate>();
            gate_object_A.GetComponent<TransferGate>().v3Target = Bpos;
            gate_object_B.GetComponent<TransferGate>().tgTarget = gate_object_C.GetComponent<TransferGate>();
            gate_object_B.GetComponent<TransferGate>().v3Target = Cpos;
            gate_object_C.GetComponent<TransferGate>().tgTarget = gate_object_D.GetComponent<TransferGate>();
            gate_object_C.GetComponent<TransferGate>().v3Target = Dpos;
            gate_object_D.GetComponent<TransferGate>().tgTarget = gate_object_A.GetComponent<TransferGate>();
            gate_object_D.GetComponent<TransferGate>().v3Target = Apos;
        }
    }

    //load star
    for (int i = 0; i < jd["star"].Count; i++)
    {
        GameObject star = (GameObject)Resources.Load("Prefabs/GameObject/F_star");
        float x = float.Parse(jd["star"][i]["x"].ToString());
        float y = float.Parse(jd["star"][i]["y"].ToString());
        float size = float.Parse(jd["star"][i]["size"].ToString());
        Vector3 pos = new Vector3(x, y, 0f);
        GameObject star_obj = Instantiate(star, pos, Quaternion.identity);
        star_obj.transform.localScale *= size;
        Stars.Add(star_obj);
    }

    //load player
    {
        GameObject player = (GameObject)Resources.Load("Prefabs/Player");
        float x = float.Parse(jd["player"]["x"].ToString());
        float y = float.Parse(jd["player"]["y"].ToString());
        float size = float.Parse(jd["player"]["size"].ToString());
        Vector3 pos = new Vector3(x, y, 0f);
        //Player = Instantiate(player,pos,Quaternion.identity);
        Player = GameObject.Find("Player");
        Player.GetComponent<SphereCollider>().isTrigger = false;
        Player.tag = "Player";
        Player.transform.position = pos;
        Player.transform.localScale *= size;
    }

    //load end gate,must copy end gate
    for (int i = 0; i < jd["Flag"].Count; i++)
    {
        //GameObject flag = GameObject.FindWithTag("Flag");
        GameObject flag = (GameObject)Resources.Load("Prefabs/GameObject/Flag");
        float x = float.Parse(jd["Flag"][i]["x"].ToString());
        float y = float.Parse(jd["Flag"][i]["y"].ToString());
        float size = float.Parse(jd["Flag"][i]["size"].ToString());
        Vector3 pos = new Vector3(x, y, 0f);
        //GameObject flag_object = Instantiate(flag,pos,Quaternion.identity);
        flag = GameObject.Find("Flag");
        //flag_object.transform.localScale *= size;
        //Flags.Add(flag_object);
        flag.transform.position = pos;
    }

    //load Bound
    for (int i = 0; i < jd["Bound"].Count; i++)
    {
        GameObject bound = (GameObject)Resources.Load("Prefabs/GameObject/Bound");
        float x = float.Parse(jd["Bound"][i]["x"].ToString());
        float y = float.Parse(jd["Bound"][i]["y"].ToString());
        float w = float.Parse(jd["Bound"][i]["w"].ToString());
        float h = float.Parse(jd["Bound"][i]["h"].ToString());
        Vector3 pos = new Vector3(x, y, 0f);
        Vector3 shape = new Vector3(w, h, 1f);
        GameObject bound_object = Instantiate(bound, pos, Quaternion.identity);
        bound_object.transform.localScale = shape;
        bound_object.GetComponent<BoxCollider>().isTrigger = false;
        Bounds.Add(bound_object);
    }

    //load AbsorbBound
    for (int i = 0; i < jd["AbsorbBound"].Count; i++)
    {
        GameObject AbsorbBound = (GameObject)Resources.Load("Prefabs/GameObject/AbsorbBound");
        float x = float.Parse(jd["AbsorbBound"][i]["x"].ToString());
        float y = float.Parse(jd["AbsorbBound"][i]["y"].ToString());
        float w = float.Parse(jd["AbsorbBound"][i]["w"].ToString());
        float h = float.Parse(jd["AbsorbBound"][i]["h"].ToString());
        Vector3 pos = new Vector3(x, y, 0f);
        Vector3 shape = new Vector3(w, h, 1f);
        GameObject AbsorbBound_object = Instantiate(AbsorbBound, pos, Quaternion.identity);
        AbsorbBound_object.transform.localScale = shape;
        AbsorbBounds.Add(AbsorbBound_object);
    }

    //load ControlGate
    for (int i = 0; i < jd["ControlGate"].Count; i++)
    {
        GameObject prefab = (GameObject)Resources.Load("Prefabs/GameObject/ControlGate");
        float x = float.Parse(jd["ControlGate"][i]["x"].ToString());
        float y = float.Parse(jd["ControlGate"][i]["y"].ToString());
        float permit_vel = float.Parse(jd["ControlGate"][i]["permit_vel"].ToString());
        float elastic_ratio = float.Parse(jd["ControlGate"][i]["elastic_ratio"].ToString());
        float size = float.Parse(jd["ControlGate"][i]["size"].ToString());
        Vector3 pos = new Vector3(x, y, 0f);
        GameObject control_object = Instantiate(prefab, pos, Quaternion.identity);
        control_object.transform.localScale *= size;
        control_object.GetComponent<ControlGate>().permit_vel = permit_vel;
        control_object.GetComponent<ControlGate>().elastic_ratio = elastic_ratio;
        ControlGates.Add(control_object);
    }

    //load RotateGate
    for (int i = 0; i < jd["RotateGate"].Count; i++)
    {
        GameObject RotateGate = (GameObject)Resources.Load("Prefabs/GameObject/RotateGate");
        float x = float.Parse(jd["RotateGate"][i]["x"].ToString());
        float y = float.Parse(jd["RotateGate"][i]["y"].ToString());
        float an_vel = float.Parse(jd["RotateGate"][i]["an_vel"].ToString());
        float angle = float.Parse(jd["RotateGate"][i]["angle"].ToString());
        float relative_length = float.Parse(jd["RotateGate"][i]["relative_length"].ToString());
        float size = float.Parse(jd["RotateGate"][i]["size"].ToString());
        Vector3 pos = new Vector3(x, y, 0f);
        GameObject rotate_gate_object = Instantiate(RotateGate, pos, Quaternion.identity);
        rotate_gate_object.transform.localScale *= size;
        rotate_gate_object.GetComponent<RotateGate>().anVel = an_vel;
        rotate_gate_object.GetComponent<RotateGate>().angle = angle;
        rotate_gate_object.GetComponent<RotateGate>().relativeLength = relative_length;
        RotateGates.Add(rotate_gate_object);
    }

    //load Shooter
    for (int i = 0; i < jd["Shooter"].Count; i++)
    {
        GameObject prefab = (GameObject)Resources.Load("Prefabs/GameObject/Shooter");
        float x = float.Parse(jd["Shooter"][i]["x"].ToString());
        float y = float.Parse(jd["Shooter"][i]["y"].ToString());
        float out_vel = float.Parse(jd["Shooter"][i]["out_vel"].ToString());
        float angle = float.Parse(jd["Shooter"][i]["angle"].ToString());
        float size = float.Parse(jd["Shooter"][i]["size"].ToString());
        Vector3 pos = new Vector3(x, y, 0f);
        GameObject Shooter_object = Instantiate(prefab, pos, Quaternion.identity);
        Shooter_object.transform.localScale *= size;
        Shooter_object.GetComponent<Shooter>().outVelocity = out_vel;
        Shooter_object.GetComponent<Shooter>().angle = angle;
        Shooters.Add(Shooter_object);
    }

    //load SpeedGate
    for (int i = 0; i < jd["SpeedGate"].Count; i++)
    {
        GameObject prefab = (GameObject)Resources.Load("Prefabs/GameObject/SpeedGate");
        float x = float.Parse(jd["SpeedGate"][i]["x"].ToString());
        float y = float.Parse(jd["SpeedGate"][i]["y"].ToString());
        float out_vel = float.Parse(jd["SpeedGate"][i]["out_vel"].ToString());
        float size = float.Parse(jd["SpeedGate"][i]["size"].ToString());
        Vector3 pos = new Vector3(x, y, 0f);
        GameObject SpeedGate_object = Instantiate(prefab, pos, Quaternion.identity);
        SpeedGate_object.transform.localScale *= size;
        SpeedGate_object.GetComponent<SpeedGate>().vOut = out_vel;
        SpeedGates.Add(SpeedGate_object);
    }
    }
}
