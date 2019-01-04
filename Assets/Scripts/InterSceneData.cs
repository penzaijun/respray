using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using System.IO;


public class InterSceneData : MonoBehaviour
{
    public int TotalLevelNum;
    private int LevelNum = 1;
    public int[] starnum;
    public int LastNotLockLevel = 1;
    public GameObject temp;
    static bool created = false;
    private AsyncOperation _p;
    private const string userdataPath = "Assets/Data/LevelData/userdata.json";
    private string levelmapPath;
    private string prestatus;
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
            JsonData jsonData = JsonMapper.ToObject(File.ReadAllText(userdataPath));
            TotalLevelNum = int.Parse(jsonData["LevelNum"].ToString());
            LastNotLockLevel = int.Parse(jsonData["LastNotLockLevel"].ToString());
            for (int i = 0; i < TotalLevelNum; i++)
              starnum[i] = int.Parse(jsonData["starnum"][i].ToString());
        }
        //reading userdata
        try
        {
            
        }
        catch (IOException e)
        {
            Debug.Log(e.Message);
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
        prestatus = "LevelSelect";
    }

    public string getPath()
    {
        return levelmapPath;
    }

    public void setPath(string path)
    {
        levelmapPath = path;
        prestatus = "Mymap";
    }

    // 获取scene的序号
    public int getLevelNum()
    {
        return LevelNum;
    }

    public void SetStarNum(int newstarnum, int level)
    {
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
            print(e.Message);
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
        GameObject Welcome = root.GetComponent<MainSceneManager>().Welcome;
        GameObject Choose = root.GetComponent<MainSceneManager>().Choose;
        GameObject Mymap = root.GetComponent<MainSceneManager>().Mymap;
        switch (prestatus)
        {
            case "LevelSelect":
                Welcome.SetActive(false);
                Mymap.SetActive(false);
                Choose.SetActive(true);
                break;
            case "Mymap":
                Welcome.SetActive(false);
                Mymap.SetActive(true);
                Choose.SetActive(false);
                Mymap.GetComponent<LoadLocalMaps>().LoadMaps();
                break;
        }
        
       
    }
    public void PlayingSceneToMain()
    {
        SceneManager.LoadSceneAsync("Main");
        StartCoroutine(EndofLoading());
    }

    public void SaveUserData()
    {
        //create json
        JsonData userdata = new JsonData();
        userdata["LevelNum"] = TotalLevelNum;
        userdata["LastNotLockLevel"] = LastNotLockLevel;
        userdata["starnum"] = new JsonData();
        for (int i = 0; i < TotalLevelNum; i++)
            userdata["starnum"].Add(starnum[i]);

        //save user data

        StreamWriter sw = new StreamWriter(userdataPath);
        string json = userdata.ToJson();
        Debug.Log(json);
        sw.Write(json);
        sw.Close();
        sw.Dispose();
    }

    private void OnApplicationQuit()
    {
        SaveUserData();
    }
}

