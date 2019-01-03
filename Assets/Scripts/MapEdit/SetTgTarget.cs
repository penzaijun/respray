using UnityEngine;
using System.Collections;

public class SetTgTarget : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTarget()
    {
        GlobalVriable.transferGate = GlobalVriable.currentObject;
        GlobalVriable.isSetTarget = true;
    }
}
