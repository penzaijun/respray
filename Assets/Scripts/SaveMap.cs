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
        List<List<GameObject>> listOfTransferGateList = MapEditList.listOfTransferGateList;
        List<GameObject> blackHoleList = MapEditList.blackHoleList;
        GameObject player = MapEditList.player;
        //Debug.Log(player.transform.position.x+player.transform.position.y+player.transform.position.z);

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
        js += string_maker("size",1.0,false);
        js += "}";
        js += ",";

        //flag
        js += "\"Flag\":";
        js += "[";
        for(int i=0;i<flagList.Count;i++){
            js += "{";
            js += string_maker("x",flagList[i].transform.position.x,true);
            js += string_maker("y",flagList[i].transform.position.y,true);
            js += string_maker("size",1.0,false);
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
        for(int i=0;i<listOfTransferGateList.Count;i++){
            js += "{";
            js += string_maker("num",2,true);
            js += string_maker("color","white",true);
            js += string_maker("Ax",listOfTransferGateList[i][0].transform.position.x,true);
            js += string_maker("Ay",listOfTransferGateList[i][0].transform.position.y,true);
            js += string_maker("Bx",listOfTransferGateList[i][1].transform.position.x,true);
            js += string_maker("By",listOfTransferGateList[i][1].transform.position.y,true);
            js += string_maker("size",1.0,true);
            js += string_maker("angle",180,false);
            js += "}";
            //if end, no comma
            if(i!=listOfTransferGateList.Count-1){
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
            js += string_maker("size",1.0,true);
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
            js += string_maker("size",1.0,false);
            js += "}";
            //if end, no comma
            if(i!=starList.Count-1){
                js += ",";
            }
        }
        js += "]";
        //js += ",";

        //else things...

        js += "}";
        print(js);
        //JsonData jd=JsonMapper.ToObject(js);
        System.IO.File.WriteAllText(@".\Assets\Data\Mymap\" + "new"+id.ToString()+"_"+id.ToString() + ".json", js);
    }
}

