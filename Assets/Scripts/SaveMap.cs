using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using LitJson;

public class SaveMap : MonoBehaviour
{
   
    // Use this for initialization
    void Start()
    {
        //获取按钮游戏对象
        GameObject btnObj = GameObject.Find ("Canvas/ButtonSaveMap");
        //获取按钮脚本组件
        Button btn = (Button) btnObj.GetComponent<Button>();
        //添加点击侦听
        btn.onClick.AddListener (OnClick_Save_Map);
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

    public void OnClick_Save_Map()
    {
        List<GameObject> flagList = MapEditList.flagList;
        List<GameObject> starList = MapEditList.starList;
        //List<List<GameObject>> listOfTransferGateList = MapEditList.listOfTransferGateList;
        List<GameObject> transferGateList = MapEditList.transferGateList;
        List<GameObject> blackHoleList = MapEditList.blackHoleList;
        List<GameObject> shooterList = MapEditList.shooterList;
        List<GameObject> speedGateList = MapEditList.speedGateList;
        List<GameObject> absorbBoundList = MapEditList.absorbBoundList;
        List<GameObject> boundList = MapEditList.boundList;
        List<GameObject> rotateGateList = MapEditList.rotateGateList;
        GameObject player = MapEditList.player;
        
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
        //Random rd = new Random();
        int id = (int)(Random.Range(((float)0), ((float)1)) * 100000000);
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
            js += string_maker("force",10.0,false);
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
        print(js);
        //JsonData jd=JsonMapper.ToObject(js);
        System.IO.File.WriteAllText(@".\Assets\Data\" + id.ToString() + ".json", js);
        print("save as "+ id.ToString() + ".json");
    }
}




