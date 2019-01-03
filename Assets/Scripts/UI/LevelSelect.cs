using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour,
    IPointerClickHandler
{

    private int levelnum=0;
    public Text leveltext;
    private bool islocked=true;
    public GameObject levellock;
    public GameObject[] star= new GameObject[3];
    private int starnum=0;

    //public UnityEvent leftClick=new UnityEvent();

    // Use this for initialization
    void Start()
    {
        //GameObject.DontDestroyOnLoad(gameObject);
        //UI part initialization
        //paint stars & lock
        leveltext.text = levelnum.ToString();
        if (islocked)
            levellock.SetActive(true);
        else levellock.SetActive(false);
        if (starnum < 3)
            for (int i = 2; i >= starnum; i--)
                star[i].GetComponent<SpriteRenderer>().color = Color.black;

        //add listener
        //leftClick.AddListener(new UnityAction(LeftClick));
        Debug.Log("start");
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    //unlock level
    public void unlock()
    {
        islocked = false;
        levellock.SetActive(false);
    }

    public int GetStarNum()
    {
        return starnum;
    }
    //update starnum
    public void UpdateStar(int starnum_new)
    {
        //assert starnum_new <= 3
        if (starnum_new < starnum) return;
        starnum = starnum_new;
        for (int i = 2; i >= starnum; i--)
            star[i].SetActive(false);
            //star[i].GetComponent<SpriteRenderer>().color = Color.black;

    }

    public void SetLevelNum(int level)
    {
        levelnum = level;
        leveltext.text = levelnum.ToString();
    }
    /*
    private void OnMouseDown()
    {
        if (islocked)
        {
            Debug.Log("locked click");
            return;
        }
        Debug.Log("unlock click");
        //create new scene
        SceneManager.LoadScene("PlayingScene");
    }

    private void OnMouseOver()
    {
        Debug.Log("over");
    }
    */
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
        //if (eventData.button == PointerEventData.InputButton.Left)
        //   leftClick.Invoke();
        if (!islocked)
        {
            GameObject.Find("InterSceneData").GetComponent<InterSceneData>().setLevelNum(levelnum);
            SceneManager.LoadScene("PlayingScene");
        }
            
    }


    /*
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("up");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
    }
    */

    

   

}
