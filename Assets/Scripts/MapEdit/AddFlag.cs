using UnityEngine;
using System.Collections;
using UnityEditor;

public class AddFlag : MonoBehaviour
{
    public GameObject flagPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickFlag()
    {
        GameObject flag = GameObject.Instantiate(flagPrefab, Vector3.zero, Quaternion.identity);
        flag.AddComponent<MouseDrag>();
        MapEditList.flagList.Add(flag);
    }
}
