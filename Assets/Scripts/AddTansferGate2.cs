using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddTansferGate2 : MonoBehaviour
{
    public GameObject transferGate2Prefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickTransferGate2()
    {
        GameObject transferGateGroup = GameObject.Instantiate(transferGate2Prefab, Vector3.zero, Quaternion.identity);
        List<GameObject> transferGateList = new List<GameObject>();
        foreach(Transform child in transferGateGroup.transform)
        {
            GameObject transferGate = child.gameObject;
            transferGate.AddComponent<MouseDrag>();
            transferGateList.Add(transferGate);
        }
        MapEditList.listOfTransferGateList.Add(transferGateList);
        gameObject.SetActive(false);
        GameObject objButton1 = GameObject.Find("Canvas/Panel/ButtonTransferGate3");
        GameObject objButton2 = GameObject.Find("Canvas/Panel/ButtonTransferGate4");
        objButton1.SetActive(false);
        objButton2.SetActive(false);
    }
}
