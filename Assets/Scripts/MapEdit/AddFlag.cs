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
        GlobalVriable.currentObject = flag;

        GameObject obj1 = GameObject.Find("Canvas/Panel/TextAngle");
        GameObject obj2 = GameObject.Find("Canvas/Panel/InputFieldAngle");
        obj1.SetActive(false);
        obj2.SetActive(false);
        GameObject obj3 = GameObject.Find("Canvas/Panel/ButtonTarget");
        obj3.SetActive(false);
        GlobalVriable.isSetTarget = false;
        GlobalVriable.transferGate = null;
    }
}
