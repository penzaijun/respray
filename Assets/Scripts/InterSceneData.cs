using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using System.IO;


public class InterSceneData : MonoBehaviour
{

    private int LevelNum = 25;
    public int[] starnum;
    public int LastNotLockLevel = 1;
    public GameObject temp;
    static bool created = false;
    private AsyncOperation _p;
    private const string userdataPath = "Assets/Data/LevelData/userdata.json";
    private string levelmapPath;
    private void Awake()
    {
        //force code to keep only one instance exist
        if (!created)
        {
            GameObject.DontDestroyOnLoad(gameObject);
            for (int i = 0; i < 25; i++)
                starnum[i] = 0;
            created = true;
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
        if (!File.Exists(userdataPath))
        {
            Debug.Log("FIRST OPEN: creating userdata");
            File.CreateText(userdataPath);
        }
        else
        {

            StreamReader json = File.OpenText(userdataPath);
            string input = json.ReadToEnd();
            JsonData jsonData = JsonMapper.ToObject(input);

            //JsonData jsonData = JsonMapper.ToObject(File.ReadAllText(userdataPath));
            string s = @"{'name':'盘子脸','数字':['123', '456']}";
            JsonData data = LitJson.JsonMapper.ToObject(s);
            Debug.Log(s);
            Debug.Log(data["name"].ToJson());
            Debug.Log(input);
            Debug.Log(jsonData["LevelNum"].ToString());
            LevelNum = int.Parse(jsonData["LevelNum"].ToString());
            LastNotLockLevel = int.Parse(jsonData["LastNotLockLevel"].ToString());
            for (int i = 0; i < LevelNum; i++)
                starnum[i] = int.Parse(jsonData["starnum"][i].ToString());

        }
        //reading userdata
        try
        {
            
        }
        catch (IOException e)
        {
            System.Console.Write("ERROE in reading userdata json");
        }
        finally
        {
           
        }
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 设置scene的序号
    public void setLevelNum(int l)
    {
        LevelNum = l;
        levelmapPath = "Assets/Data/LevelData/" + l.ToString() + ".json";
    }

    public string getPath()
    {
        return levelmapPath;
    }

    public void setPath(string path)
    {
        levelmapPath = path;
    }

    // 获取scene的序号
    public int getLevelNum()
    {
        return LevelNum;
    }

    public void SetStarNum(int newstarnum, int level)
    {
        Debug.Log(level.ToString());
        Debug.Log(newstarnum.ToString());
        try
        {
            if (starnum[level - 1] < newstarnum)
                starnum[level - 1] = newstarnum;
            if (level == LastNotLockLevel)
            {
                LastNotLockLevel++;
                Debug.Log("plus");
                Debug.Log(LastNotLockLevel.ToString());
            }


        }
        catch (System.IndexOutOfRangeException e)
        {
            print("level num out of range");
        }
    }
    private IEnumerator EndofLoading()
    {
        while (SceneManager.GetActiveScene().name != "Main")
        {
            yield return null;
        }
        GameObject root = GameObject.Find("Main Camera");
        temp = root;
        temp = GameObject.Find("Flag");
        if (root == null) Debug.Log("camera not found");
        GameObject Welcome = root.GetComponent<MainSceneManager>().GetWelcome();
        GameObject Choose = root.GetComponent<MainSceneManager>().Choose;
        Debug.Log("delete");
        Welcome.SetActive(false);
        Choose.SetActive(true);
    }
    public void PlayingSceneToMain()
    {
        _p = SceneManager.LoadSceneAsync("Main");
        StartCoroutine(EndofLoading());
    }

    private void OnApplicationQuit()
    {
        JsonData userdata = new JsonData();
        userdata["Levelnum"] = 25;
        userdata["LastNotLockLevel"] = LastNotLockLevel;
        userdata["starnum"] = new JsonData();
        for (int i = 0; i < LevelNum; i++)
            userdata["starnum"].Add(starnum[i]);

        //save user data

        StreamWriter sw = new StreamWriter(userdataPath);
        string json = userdata.ToJson();
        Debug.Log(json);
        sw.Write(json);
        sw.Close();
        sw.Dispose();
    }
}

