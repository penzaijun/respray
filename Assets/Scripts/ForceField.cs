using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{

    // 核心区不可进入（暂未实现）
    public double coreRadius;

    // 判断吸引力或斥力
    public bool isAttract=false;
    // 强度
    public float magn;
    // 运算时参数
    private float coe;

    // Use this for initialization
    void Start()
    {
        // 判断当前是引力还是斥力
        if (isAttract)
            coe = -magn;
        else
            coe = magn;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
    }

   

    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            Vector3 pos = other.transform.position - this.transform.position;
            if(pos.magnitude>0)
                other.attachedRigidbody.AddForce(pos.normalized * coe / pos.magnitude);
        }
    }

  

}