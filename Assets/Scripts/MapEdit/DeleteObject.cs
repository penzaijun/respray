using UnityEngine;
using System.Collections;

public class DeleteObject : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeleteObj()
    {
        //删除物体
        Destroy(GlobalVriable.currentObject);
    }
}
