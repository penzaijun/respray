using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddTransferGate : MonoBehaviour
{
    public GameObject transferGatePrefab;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickTranferGate()
    {
        GameObject transferGate = GameObject.Instantiate(transferGatePrefab, Vector3.zero, Quaternion.identity);  
        MapEditList.transferGateList.Add(transferGate);
        transferGate.AddComponent<MouseDrag>();
        GlobalVriable.currentObject = transferGate;
        // Make the related objects visible
        GameObject obj1 = GameObject.Find("Canvas/Panel/TextAngle");
        GameObject obj2 = GameObject.Find("Canvas/Panel/InputFieldAngle");
        obj1.SetActive(true);
        obj2.SetActive(true);
        GameObject obj3 = GameObject.Find("Canvas/Panel/ButtonTarget");
        obj3.SetActive(true);
    }
}
