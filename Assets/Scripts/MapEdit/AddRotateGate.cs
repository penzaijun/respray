using UnityEngine;
using System.Collections;

public class AddRotateGate : MonoBehaviour
{
    public GameObject rotateGatePrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickRotateGate()
    {
        GameObject rotateGate = GameObject.Instantiate(rotateGatePrefab, Vector3.zero, Quaternion.identity);
        rotateGate.AddComponent<MouseDrag>();
        MapEditList.rotateGateList.Add(rotateGate);
        GlobalVriable.currentObject = rotateGate;

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
