﻿using UnityEngine;
using System.Collections;

public class AddSpeedGate : MonoBehaviour
{
    public GameObject speedGatePrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickSpeedGate()
    {
        GameObject speedGate = GameObject.Instantiate(speedGatePrefab, Vector3.zero, Quaternion.identity);
        speedGate.AddComponent<MouseDrag>();
        MapEditList.speedGateList.Add(speedGate);
        GlobalVriable.currentObject = speedGate;

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
