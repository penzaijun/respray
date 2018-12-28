using UnityEngine;
using System.Collections;

public class ClickButtonTransferGate : MonoBehaviour
{

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
        // Make the buttons visible
        GameObject objButton1 = GameObject.Find("Canvas/Panel/ButtonTransferGate2");
        GameObject objButton2 = GameObject.Find("Canvas/Panel/ButtonTransferGate3");
        GameObject objButton3 = GameObject.Find("Canvas/Panel/ButtonTransferGate4");
        objButton1.SetActive(true);
        objButton2.SetActive(true);
        objButton3.SetActive(true);
    }
}
