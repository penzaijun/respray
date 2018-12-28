using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterSceneData : MonoBehaviour {

    public int LevelNum;
    public int[] starnum=new int[25];
    public int LastNotLockLevel=1;
    public GameObject temp;
    static bool created = false;

    private void Awake()
    {
        // 设置不可销毁
        temp=GameObject.Find("Main Camera");
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
    }


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // 设置scene的序号
    public void setLevel(int l)
    {
        LevelNum = l;
    }



    // 获取scene的序号
    public int getLevel()
    {
        return LevelNum;
    }

    public void SetStarNum(int newstarnum,int level)
    {
        Debug.Log(level.ToString());
        Debug.Log(newstarnum.ToString());
        try
        {
            if (starnum[level-1] < newstarnum)
                starnum[level-1] = newstarnum;
            if (level == LastNotLockLevel)
            {
                LastNotLockLevel++;
                Debug.Log("plus");
                Debug.Log(LastNotLockLevel.ToString());
            }
                

        }
        catch(System.IndexOutOfRangeException e)
        {
            print("level num out of range");
        }
    }
    private IEnumerator myWait(){
        while(SceneManager.GetActiveScene().name!="Main"){
            yield return null;
        }
    }
    public IEnumerator PlayingSceneToMain(){
        SceneManager.LoadScene("Main");
        yield return StartCoroutine(myWait());
        GameObject root = GameObject.Find("Main Camera");
        temp=root;
        temp=GameObject.Find("Flag");
        if (root==null) Debug.Log("camera not found");
        GameObject Welcome = root.GetComponent<MainSceneManager>().GetWelcome();
        GameObject Choose = root.GetComponent<MainSceneManager>().Choose;
        Debug.Log("delete");
        Welcome.SetActive(false);
        Choose.SetActive(true);

    }

}

