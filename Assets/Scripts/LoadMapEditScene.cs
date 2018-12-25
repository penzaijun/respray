using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadMapEditScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Load()
    {
        // Load the MapEdit Scene
        SceneManager.LoadScene("MapEditScene");
    }
}
