using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    public int levelnum=0;
    public Text leveltext;
    public bool islocked=true;
    public GameObject levellock;
    public GameObject[] star= new GameObject[3];
    public int starnum=0;


    // Use this for initialization
    void Start()
    {
        //UI part initialization
        //paint stars & lock
        leveltext.text = levelnum.ToString();
        if (islocked)
            levellock.SetActive(true);
        else levellock.SetActive(false);
        if (starnum < 3)
            for (int i = 2; i >= starnum; i--)
                star[i].GetComponent<SpriteRenderer>().color = Color.black;
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

    //update starnum
    public void update_star(int starnum_new)
    {
        //assert starnum_new <= 3
        if (starnum_new < starnum) return;
        starnum = starnum_new;
        for (int i = 2; i >= starnum; i--)
            star[i].GetComponent<SpriteRenderer>().color = Color.black;
    }

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

}
