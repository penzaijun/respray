﻿using UnityEngine;
using System.Collections;

public class AddStar : MonoBehaviour
{
    public GameObject starPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickStar()
    {
        GameObject star = GameObject.Instantiate(starPrefab, Vector3.zero, Quaternion.identity);
        star.AddComponent<RectMouseDrag>();
        MapEditList.starList.Add(star);
        GlobalVriable.currentObject = star;

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
