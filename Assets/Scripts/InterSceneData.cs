using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InterSceneData : MonoBehaviour {

    public int LevelNum;
    public int[] starnum=new int[25];
    public int LastNotLockLevel=1;
    static bool created = false;

    private void Awake()
    {
        // 设置不可销毁
        if (!created)
        {
            GameObject.DontDestroyOnLoad(gameObject);
            for (int i = 0; i < 25; i++)
                starnum[i] = 0;
            created = true;
        }
        else
        {
            GameObject.Destroy(this);
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

}

