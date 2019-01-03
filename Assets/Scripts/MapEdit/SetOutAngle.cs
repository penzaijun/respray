using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SetOutAngle : MonoBehaviour
{
    public InputField inputField;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndEdit()
    {
        GlobalVriable.currentObject.transform.GetComponent<TransferGate>().outAngle = Convert.ToSingle(inputField.text);
        inputField.text = "";
    }
}
