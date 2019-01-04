using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using LitJson;
using System;

public class SaveMap : MonoBehaviour
{
    //just for save map
    private List<GameObject> flagList = MapEditList.flagList;
    private List<GameObject> starList = MapEditList.starList;
    private List<GameObject> transferGateList = MapEditList.transferGateList;
    private List<GameObject> blackHoleList = MapEditList.blackHoleList;
    private List<GameObject> shooterList = MapEditList.shooterList;
    private List<GameObject> speedGateList = MapEditList.speedGateList;
    private List<GameObject> absorbBoundList = MapEditList.absorbBoundList;
    private List<GameObject> boundList = MapEditList.boundList;
    private List<GameObject> rotateGateList = MapEditList.rotateGateList;
    private GameObject player = MapEditList.player;

    // Use this for initialization
    void Start()
    {
        //获取按钮游戏对象
        GameObject btnObj = GameObject.Find ("Canvas/ButtonSaveMap");
        //获取按钮脚本组件
        Button btn = (Button) btnObj.GetComponent<Button>();
        //只有需要进行自动测试才为true！不需要的时候请关掉
        bool test=false;
        if(test){
            //添加点击侦听  
            btn.onClick.AddListener (OnClick_Test_Save_Load_Map);
        }
        else{
            //添加点击侦听
            btn.onClick.AddListener (OnClick_Save_Map);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string string_maker(string head,string val,bool with_comma){
        //make the string like:  "head":"val",
        string ans = "\"" + head + "\":";
        ans += "\"" + val + "\"";
        if(with_comma){
            ans += ",";
        }
        return ans;
    }
    public string string_maker(string head,int val,bool with_comma){
        //make the string like:  "head":val,
        string ans = "\"" + head + "\":";
        ans += string.Format("{0}",val);
        if(with_comma){
            ans += ",";
        }
        return ans;
    }
    public string string_maker(string head,float val,bool with_comma){
        //make the string like:  "head":val,
        string ans = "\"" + head + "\":";
        ans += string.Format("{0}",val);
        if(with_comma){
            ans += ",";
        }
        return ans;
    }
    public string string_maker(string head,double val,bool with_comma){
        //make the string like:  "head":val,
        string ans = "\"" + head + "\":";
        ans += string.Format("{0}",val);
        if(with_comma){
            ans += ",";
        }
        return ans;
    }
    public float abs(float a){
		if(a<=0) return -a;
		else return a;
	}
	public bool sign(float a){
		if(a<=0) return false;
		else return true;
	}
    public string Get_Json_String(int id,bool need_refreash_list){
        if(need_refreash_list){
            flagList = MapEditList.flagList;
            starList = MapEditList.starList;
            transferGateList = MapEditList.transferGateList;
            blackHoleList = MapEditList.blackHoleList;
            shooterList = MapEditList.shooterList;
            speedGateList = MapEditList.speedGateList;
            absorbBoundList = MapEditList.absorbBoundList;
            boundList = MapEditList.boundList;
            rotateGateList = MapEditList.rotateGateList;
            player = MapEditList.player;
        }

        //check if destory
        List<GameObject> flagList_new = new List<GameObject>();
        List<GameObject> starList_new  = new List<GameObject>();
        List<GameObject> transferGateList_new  = new List<GameObject>();
        List<GameObject> blackHoleList_new  = new List<GameObject>();
        List<GameObject> shooterList_new  = new List<GameObject>();
        List<GameObject> speedGateList_new  = new List<GameObject>();
        List<GameObject> absorbBoundList_new  = new List<GameObject>();
        List<GameObject> boundList_new  = new List<GameObject>();
        List<GameObject> rotateGateList_new  = new List<GameObject>();

        for(int i=0;i<flagList.Count;i++){
            if(flagList[i]!=null){
                flagList_new.Add(flagList[i]);
            }
        }
        flagList = flagList_new;
        MapEditList.flagList = flagList;

        for(int i=0;i<starList.Count;i++){
            if(starList[i]!=null){
                starList_new.Add(starList[i]);
            }
        }
        starList = starList_new;
        MapEditList.starList = starList;

        for(int i=0;i<transferGateList.Count;i++){
            if(transferGateList[i]!=null){
                transferGateList_new.Add(transferGateList[i]);
            }
        }
        transferGateList = transferGateList_new;
        MapEditList.transferGateList = transferGateList;

        for(int i=0;i<blackHoleList.Count;i++){
            if(blackHoleList[i]!=null){
                blackHoleList_new.Add(blackHoleList[i]);
            }
        }
        blackHoleList = blackHoleList_new;
        MapEditList.blackHoleList = blackHoleList;

        for(int i=0;i<shooterList.Count;i++){
            if(shooterList[i]!=null){
                shooterList_new.Add(shooterList[i]);
            }
        }
        shooterList = shooterList_new;
        MapEditList.shooterList = shooterList;

        for(int i=0;i<speedGateList.Count;i++){
            if(speedGateList[i]!=null){
                speedGateList_new.Add(speedGateList[i]);
            }
        }
        speedGateList = speedGateList_new;
        MapEditList.speedGateList = speedGateList;

        for(int i=0;i<absorbBoundList.Count;i++){
            if(absorbBoundList[i]!=null){
                absorbBoundList_new.Add(absorbBoundList[i]);
            }
        }
        absorbBoundList = absorbBoundList_new;
        MapEditList.absorbBoundList = absorbBoundList;

        for(int i=0;i<boundList.Count;i++){
            if(boundList[i]!=null){
                boundList_new.Add(boundList[i]);
            }
        }
        boundList = boundList_new;
        MapEditList.boundList = boundList;

        for(int i=0;i<rotateGateList.Count;i++){
            if(rotateGateList[i]!=null){
                rotateGateList_new.Add(rotateGateList[i]);
            }
        }
        rotateGateList = rotateGateList_new;
        MapEditList.rotateGateList = rotateGateList;

        //save the json map data
        string js="";//json string
        js += "{";
        js += string_maker("map_name","test name",true);
        js += string_maker("map_id",id,true);

        //player
        js += "\"player\":";
        js += "{";
        js += string_maker("mass",10.0,true);
        js += string_maker("x",player.transform.position.x,true);
        js += string_maker("y",player.transform.position.y,true);
        js += string_maker("size",player.transform.localScale.x,false);
        js += "}";
        js += ",";

        //flag
        js += "\"Flag\":";
        js += "[";
        for(int i=0;i<flagList.Count;i++){
            js += "{";
            js += string_maker("x",flagList[i].transform.position.x,true);
            js += string_maker("y",flagList[i].transform.position.y,true);
            js += string_maker("angle",flagList[i].transform.localEulerAngles.z,true);
            js += string_maker("size",flagList[i].transform.localScale.x,false);
            js += "}";
            //if end, no comma
            if(i!=flagList.Count-1){
                js += ",";
            }
        }
        js += "]";
        js += ",";

        //TransferGate
        js += "\"TransferGate\":";
        js += "[";
        for(int i=0;i<transferGateList.Count;i+=2){
            if(transferGateList.Count%2==1 && i == transferGateList.Count-1)
                break;
            js += "{";
            js += string_maker("num",2,true);
            js += string_maker("color","white",true);
            js += string_maker("Ax",transferGateList[i].transform.position.x,true);
            js += string_maker("Ay",transferGateList[i].transform.position.y,true);
            js += string_maker("Bx",transferGateList[i].GetComponent<TransferGate>().tgTarget.transform.position.x,true);
            js += string_maker("By",transferGateList[i].GetComponent<TransferGate>().tgTarget.transform.position.y,true);
            js += string_maker("size",transferGateList[i].transform.localScale.x,true);
            js += string_maker("angle",transferGateList[i].transform.localEulerAngles.z,false);
            js += "}";
            //if end, no comma
            if(i!=transferGateList.Count/2-1){
                js += ",";
            }
        }
        js += "]";
        js += ",";

        //BlackHole
        js += "\"BlackHole\":";
        js += "[";
        for(int i=0;i<blackHoleList.Count;i++){
            js += "{";
            js += string_maker("x",blackHoleList[i].transform.position.x,true);
            js += string_maker("y",blackHoleList[i].transform.position.y,true);
            js += string_maker("size",blackHoleList[i].transform.localScale.x,true);
            float force = blackHoleList[i].GetComponent<ForceField>().magn;
            if(blackHoleList[i].GetComponent<ForceField>().isAttract)
                force = -force;
            js += string_maker("force",force,false);
            js += "}";
            //if end, no comma
            if(i!=blackHoleList.Count-1){
                js += ",";
            }
        }
        js += "]";
        js += ",";

        //star 
        js += "\"star\":";
        js += "[";
        for(int i=0;i<starList.Count;i++){
            js += "{";
            js += string_maker("x",starList[i].transform.position.x,true);
            js += string_maker("y",starList[i].transform.position.y,true);
            js += string_maker("angle",starList[i].transform.localEulerAngles.z,true);
            js += string_maker("size",starList[i].transform.localScale.x,false);
            js += "}";
            //if end, no comma
            if(i!=starList.Count-1){
                js += ",";
            }
        }
        js += "]";
        js += ",";

        //shooter
        js += "\"Shooter\":";
        js += "[";
        for(int i=0;i<shooterList.Count;i++){
            js += "{";
            js += string_maker("x",shooterList[i].transform.position.x,true);
            js += string_maker("y",shooterList[i].transform.position.y,true);
            js += string_maker("out_vel",shooterList[i].GetComponent<Shooter>().outVelocity,true);
            js += string_maker("angle",shooterList[i].GetComponent<Shooter>().angle,true);
            js += string_maker("size",shooterList[i].transform.localScale.x,false);
            js += "}";
            //if end, no comma
            if(i!=shooterList.Count-1){
                js += ",";
            }
        }
        js += "]";
        js += ",";

        //speedGate
        js += "\"SpeedGate\":";
        js += "[";
        for(int i=0;i<speedGateList.Count;i++){
            js += "{";
            js += string_maker("x",speedGateList[i].transform.position.x,true);
            js += string_maker("y",speedGateList[i].transform.position.y,true);
            js += string_maker("out_vel",speedGateList[i].GetComponent<SpeedGate>().vOut,true);
            js += string_maker("angle",speedGateList[i].transform.localEulerAngles.z,true);
            js += string_maker("size",speedGateList[i].transform.localScale.x,false);
            js += "}";
            //if end, no comma
            if(i!=speedGateList.Count-1){
                js += ",";
            }
        }
        js += "]";
        js += ",";

        //absorbBoundList
        js += "\"AbsorbBound\":";
        js += "[";
        for(int i=0;i<absorbBoundList.Count;i++){
            js += "{";
            js += string_maker("x",absorbBoundList[i].transform.position.x,true);
            js += string_maker("y",absorbBoundList[i].transform.position.y,true);
            js += string_maker("w",absorbBoundList[i].transform.localScale.x,true);
            js += string_maker("h",absorbBoundList[i].transform.localScale.y,true);
            js += string_maker("angle",absorbBoundList[i].transform.localEulerAngles.z,false);
            js += "}";
            //if end, no comma
            if(i!=absorbBoundList.Count-1){
                js += ",";
            }
        }
        js += "]";
        js += ",";

        //Bound
        js += "\"Bound\":";
        js += "[";
        for(int i=0;i<boundList.Count;i++){
            js += "{";
            js += string_maker("x",boundList[i].transform.position.x,true);
            js += string_maker("y",boundList[i].transform.position.y,true);
            js += string_maker("w",boundList[i].transform.localScale.x,true);
            js += string_maker("h",boundList[i].transform.localScale.y,true);
            js += string_maker("angle",boundList[i].transform.localEulerAngles.z,false);
            js += "}";
            //if end, no comma
            if(i!=boundList.Count-1){
                js += ",";
            }
        }
        js += "]";
        js += ",";

        //rotateGate
        js += "\"RotateGate\":";
        js += "[";
        for(int i=0;i<rotateGateList.Count;i++){
            js += "{";
            js += string_maker("x",rotateGateList[i].transform.position.x,true);
            js += string_maker("y",rotateGateList[i].transform.position.y,true);
            js += string_maker("an_vel",rotateGateList[i].GetComponent<RotateGate>().anVel,true);
            js += string_maker("angle",rotateGateList[i].GetComponent<RotateGate>().angle,true);
            js += string_maker("size",rotateGateList[i].transform.localScale.x,true);
            js += string_maker("relative_length",rotateGateList[i].GetComponent<RotateGate>().relativeLength,false);
            js += "}";
            //if end, no comma
            if(i!=rotateGateList.Count-1){
                js += ",";
            }
        }
        js += "]";
        js += "}";
        return js;
    }
    public void OnClick_Save_Map()
    {
        print("save map!");
        int id = (int)(UnityEngine.Random.Range(((float)0), ((float)1)) * 100000000);
        string js = Get_Json_String(id,true);
        print(js);
        System.IO.File.WriteAllText(@".\Assets\Data\" + id.ToString() + ".json", js);
        print("save as "+ id.ToString() + ".json");
    }

    //下面的函数都是进行测试的，对于功能没影响
    public float random(double lo,double hi){
        float x = (float)(UnityEngine.Random.Range(((float)lo), ((float)hi)));
        return x;
    }
    public float random(float lo,float hi){
        float x = (float)(UnityEngine.Random.Range(((float)lo), ((float)hi)));
        return x;
    }
    public float random(int lo,int hi){
        float x = (float)(UnityEngine.Random.Range(((float)lo), ((float)hi)));
        return x;
    }
    private int test_state=0;
    private static string json_test_str="";
    public void OnClick_Test_Save_Load_Map(){
        //点击save后，重复进行如下过程：新建随机元素，保存为json字符串，之后再加载出来
        if(test_state%5==0)
            Add_Random_Elem();
        if(test_state%5==1)
            json_test_str = Get_Json_String(0,false);
        if(test_state%5==2)
            Delete_All();
        if(test_state%5==3)
            Load_With_Json(json_test_str); 
        if(test_state%5==4)
            Delete_All();
        test_state++;
    }
    public void Add_Random_Elem(){
        //clean list
        blackHoleList=new List <GameObject> ();
        transferGateList=new List <GameObject> ();
        starList=new List <GameObject> ();
        flagList=new List <GameObject> ();
        boundList=new List <GameObject> ();
        absorbBoundList=new List <GameObject> ();
        rotateGateList=new List <GameObject> ();
        shooterList=new List <GameObject> ();
        speedGateList=new List <GameObject> ();
        player = new GameObject();

        //load blackhole
        for (int i = 0; i < 2; i++)
        {
            GameObject hole = (GameObject)Resources.Load("Prefabs/GameObject/BlackHole");
            float x = random(-8,8);
            float y = random(-4,4);
            float size = random(0.5,2);
            float force = 0.0f;
            Vector3 pos = new Vector3(x, y, 0f);
            GameObject instance = Instantiate(hole, pos, Quaternion.identity);
            instance.transform.localScale = new Vector3(size,size,1);
            instance.transform.position = pos;
            instance.GetComponent<ForceField>().magn = abs(force);
            instance.GetComponent<ForceField>().isAttract = !sign(force);
            blackHoleList.Add(instance);
        }

        //load star
        for (int i = 0; i < 3; i++)
        {
            GameObject hole = (GameObject)Resources.Load("Prefabs/GameObject/F_star");
            float x = random(-8,8);
            float y = random(-4,4);
            float size = random(0.5,2);
            float angle=random(0,360);
            Vector3 pos = new Vector3(x, y, 0f);
            GameObject instance = Instantiate(hole, pos, Quaternion.identity);
            instance.transform.localScale = new Vector3(size,size,1);
            instance.transform.position = pos;
            instance.transform.localEulerAngles = new Vector3(0.0f,0.0f,angle);
            starList.Add(instance);
        }

        //load player
        {
            GameObject player_obj = (GameObject)Resources.Load("Prefabs/Player");
            float x = random(-8,8);
            float y = random(-4,4);
            float size = random(0.5,2);
            float angle=random(0,360);
            Vector3 pos = new Vector3(x, y, 0f);
            GameObject instance = Instantiate(player_obj, pos, Quaternion.identity);
            instance.transform.localScale = new Vector3(size,size,1);
            instance.transform.position = pos;
            instance.transform.localEulerAngles = new Vector3(0.0f,0.0f,angle);
            player = instance;
        }

        //load flag
        for (int i = 0; i < 2; i++)
        {
            GameObject flag = (GameObject)Resources.Load("Prefabs/GameObject/Flag");
            float x = random(-8,8);
            float y = random(-4,4);
            float size = random(0.5,2);
            float angle=random(0,360);
            Vector3 pos = new Vector3(x, y, 0f);
            GameObject instance = Instantiate(flag, pos, Quaternion.identity);
            instance.transform.localScale = new Vector3(size,size,1);
            instance.transform.localEulerAngles = new Vector3(0.0f,0.0f,angle);
            instance.transform.position = pos;
            flagList.Add(instance);
        }

        //add TransferGate
        {
            float Ax =random(-8,8);
            float Ay = random(-4,4);
            Vector3 Apos = new Vector3(Ax, Ay, 0f);
            float Bx = random(-8,8);
            float By = random(-4,4);
            Vector3 Bpos = new Vector3(Bx, By, 0f);
            float size = random(0.5,2);
            //load prefab
            GameObject gate = (GameObject)Resources.Load("Prefabs/GameObject/TransferGate");
            GameObject gate_object_A = Instantiate(gate, Apos, Quaternion.identity);
            GameObject gate_object_B = Instantiate(gate, Bpos, Quaternion.identity);
            gate_object_A.transform.localScale = new Vector3(size,size,1);
            gate_object_B.transform.localScale = new Vector3(size,size,1);
            transferGateList.Add(gate_object_A);
            transferGateList.Add(gate_object_B);
            gate_object_A.GetComponent<TransferGate>().tgTarget = gate_object_B.GetComponent<TransferGate>();
            gate_object_A.GetComponent<TransferGate>().v3Target = Bpos;
            gate_object_B.GetComponent<TransferGate>().tgTarget = gate_object_A.GetComponent<TransferGate>();
            gate_object_B.GetComponent<TransferGate>().v3Target = Apos;
        }

        //add bound
        for (int i = 0; i < 2; i++)
        {
            GameObject bound = (GameObject)Resources.Load("Prefabs/GameObject/Bound");
            float x = random(-8,8);
            float y = random(-4,4);
            float w = random(1.0,8.0);
            float h = random(0.1,1);
            float angle = random(0,360);
            Vector3 pos = new Vector3(x, y, 0f);
            Vector3 shape = new Vector3(w, h, 1f);
            GameObject bound_object = Instantiate(bound, pos, Quaternion.identity);
            bound_object.transform.localScale = shape;
            bound_object.transform.localEulerAngles = new Vector3(0.0f,0.0f,angle);
            bound_object.GetComponent<BoxCollider>().isTrigger = false;
            boundList.Add(bound_object);
        }
        
    }
    public void Delete_All(){
        Destroy(player);
        for(int i=0;i<blackHoleList.Count;i++)
            Destroy(blackHoleList[i]);
        for(int i=0;i<flagList.Count;i++)
            Destroy(flagList[i]);
        for(int i=0;i<starList.Count;i++)
            Destroy(starList[i]);
        for(int i=0;i<transferGateList.Count;i++)
            Destroy(transferGateList[i]);
        for(int i=0;i<boundList.Count;i++)
            Destroy(boundList[i]);
    }
    public void Load_With_Json(string js){
        JsonData jd = JsonMapper.ToObject(js);
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
            instance.transform.localScale = new Vector3(size,size,1);
            blackHoleList.Add(instance);
        }
        //load star
        for (int i = 0; i < jd["star"].Count; i++)
        {
            GameObject star = (GameObject)Resources.Load("Prefabs/GameObject/F_star");
            float x = float.Parse(jd["star"][i]["x"].ToString());
            float y = float.Parse(jd["star"][i]["y"].ToString());
            float size = float.Parse(jd["star"][i]["size"].ToString());
            float angle = float.Parse(jd["star"][i]["angle"].ToString());
            Vector3 pos = new Vector3(x, y, 0f);
            GameObject star_obj = Instantiate(star, pos, Quaternion.identity);
            star_obj.transform.localEulerAngles = new Vector3(0.0f,0.0f,angle);
            star_obj.transform.localScale = new Vector3(size,size,1);
            starList.Add(star_obj);
        }
        //load player
        {
            GameObject player_obj = (GameObject)Resources.Load("Prefabs/Player");
            float x = float.Parse(jd["player"]["x"].ToString());
            float y = float.Parse(jd["player"]["y"].ToString());
            float size = float.Parse(jd["player"]["size"].ToString());
            Vector3 pos = new Vector3(x, y, 0f);
            player = Instantiate(player_obj,pos,Quaternion.identity);
            player.transform.position = pos;
            player.transform.localScale = new Vector3(size,size,1);
        }

        //load flag
        for (int i = 0; i < jd["Flag"].Count; i++)
        {
            //GameObject flag = GameObject.FindWithTag("Flag");
            GameObject flag = (GameObject)Resources.Load("Prefabs/GameObject/Flag");
            float x = float.Parse(jd["Flag"][i]["x"].ToString());
            float y = float.Parse(jd["Flag"][i]["y"].ToString());
            float size = float.Parse(jd["Flag"][i]["size"].ToString());
            float angle = float.Parse(jd["Flag"][i]["angle"].ToString());
            Vector3 pos = new Vector3(x, y, 0f);
            GameObject flag_object = Instantiate(flag,pos,Quaternion.identity);
            flag = GameObject.Find("Flag");
            flag_object.transform.localScale = new Vector3(size,size,1);
            flag_object.transform.position = pos;
            flag_object.transform.localEulerAngles = new Vector3(0.0f,0.0f,angle);
            flagList.Add(flag_object);
        }

        //transfer gate
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
                gate_object_A.transform.localScale = new Vector3(size,size,1);
                gate_object_B.transform.localScale = new Vector3(size,size,1);
                transferGateList.Add(gate_object_A);
                transferGateList.Add(gate_object_B);
                gate_object_A.GetComponent<TransferGate>().tgTarget = gate_object_B.GetComponent<TransferGate>();
                gate_object_A.GetComponent<TransferGate>().v3Target = Bpos;
                gate_object_B.GetComponent<TransferGate>().tgTarget = gate_object_A.GetComponent<TransferGate>();
                gate_object_B.GetComponent<TransferGate>().v3Target = Apos;
            }
        }
        //load bound
        for (int i = 0; i < jd["Bound"].Count; i++)
        {
            GameObject bound = (GameObject)Resources.Load("Prefabs/GameObject/Bound");
            float x = float.Parse(jd["Bound"][i]["x"].ToString());
            float y = float.Parse(jd["Bound"][i]["y"].ToString());
            float w = float.Parse(jd["Bound"][i]["w"].ToString());
            float h = float.Parse(jd["Bound"][i]["h"].ToString());
            float angle = float.Parse(jd["Bound"][i]["angle"].ToString());
            Vector3 pos = new Vector3(x, y, 0f);
            Vector3 shape = new Vector3(w, h, 1f);
            GameObject bound_object = Instantiate(bound, pos, Quaternion.identity);
            bound_object.transform.localScale = shape;
            bound_object.transform.localEulerAngles = new Vector3(0.0f,0.0f,angle);
            bound_object.GetComponent<BoxCollider>().isTrigger = false;
            boundList.Add(bound_object);
        }
        //load AbsorbBound
        try{
            for (int i = 0; i < jd["AbsorbBound"].Count; i++)
            {
                GameObject AbsorbBound = (GameObject)Resources.Load("Prefabs/GameObject/AbsorbBound");
                float x = float.Parse(jd["AbsorbBound"][i]["x"].ToString());
                float y = float.Parse(jd["AbsorbBound"][i]["y"].ToString());
                float w = float.Parse(jd["AbsorbBound"][i]["w"].ToString());
                float h = float.Parse(jd["AbsorbBound"][i]["h"].ToString());
                float angle = float.Parse(jd["AbsorbBound"][i]["angle"].ToString());
                Vector3 pos = new Vector3(x, y, 0f);
                Vector3 shape = new Vector3(w, h, 1f);
                GameObject AbsorbBound_object = Instantiate(AbsorbBound, pos, Quaternion.identity);
                AbsorbBound_object.transform.localScale = shape;
                AbsorbBound_object.transform.localEulerAngles = new Vector3(0.0f,0.0f,angle);
                absorbBoundList.Add(AbsorbBound_object);
            }
        }
        catch (Exception e) {}
        //load RotateGate
        try{
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
                rotate_gate_object.transform.localScale = new Vector3(size,size,1);
                rotate_gate_object.GetComponent<RotateGate>().anVel = an_vel;
                rotate_gate_object.GetComponent<RotateGate>().angle = angle;
                rotate_gate_object.GetComponent<RotateGate>().relativeLength = relative_length;
                rotateGateList.Add(rotate_gate_object);
            }
        }
        catch (Exception e) {}

        //load Shooter
        try{
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
                Shooter_object.transform.localScale = new Vector3(size,size,1);
                Shooter_object.GetComponent<Shooter>().outVelocity = out_vel;
                Shooter_object.GetComponent<Shooter>().angle = angle;
                shooterList.Add(Shooter_object);
            }
        }
        catch (Exception e) {}

        //load SpeedGate
        try{
            for (int i = 0; i < jd["SpeedGate"].Count; i++)
            {
                GameObject prefab = (GameObject)Resources.Load("Prefabs/GameObject/SpeedGate");
                float x = float.Parse(jd["SpeedGate"][i]["x"].ToString());
                float y = float.Parse(jd["SpeedGate"][i]["y"].ToString());
                float out_vel = float.Parse(jd["SpeedGate"][i]["out_vel"].ToString());
                float size = float.Parse(jd["SpeedGate"][i]["size"].ToString());
                float angle = float.Parse(jd["SpeedGate"][i]["angle"].ToString());
                Vector3 pos = new Vector3(x, y, 0f);
                GameObject SpeedGate_object = Instantiate(prefab, pos, Quaternion.identity);
                SpeedGate_object.transform.localScale = new Vector3(size,size,1);
                SpeedGate_object.GetComponent<SpeedGate>().vOut = out_vel;
                SpeedGate_object.transform.localEulerAngles = new Vector3(0.0f,0.0f,angle);
                speedGateList.Add(SpeedGate_object);
            }
        }
        catch (Exception e) {}
    }
}
