using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferGate : MonoBehaviour {

    // 传送目标
    public TransferGate tgTarget;
    // 输出轴的角度
    public float outAngle;
    // 传送目标的位置
    private Vector3 v3Target;
    // 判断当前是否可以有效
    private bool isEff;
    // 传送目标的正弦余弦
    private Vector3 v3Out;

    // 旋转的组件，绕z轴旋转
    private Vector3 ax = new Vector3(0.0f, 0.0f, 1.0f);

    // Use this for initialization
    void Start () {
        // 获取目标的坐标
        v3Target = tgTarget.transform.position;
        // 获取目标的半径
        isEff = true;
        // 获取输出角度
        v3Out = new Vector3(Mathf.Sin(Mathf.Deg2Rad * outAngle), Mathf.Cos(Mathf.Deg2Rad * outAngle), 0);
    }
	
	// Update is called once per frame
    // 实时旋转
	void Update () {
        transform.Rotate(ax, 50 * Time.deltaTime, Space.Self);
    }

    // 碰撞进入
    private void OnTriggerEnter(Collider other)
    {
        // 在当前门有效时玩家才会进入
        if (other.CompareTag("Player") && isEff)
        {
            tgTarget.deff();
        }
    }

    // 传送
    private void OnTriggerStay(Collider other)
    {
        // 只有玩家完全进入才会触发
        if (other.CompareTag("Player") && isEff)
        {
            // 传送位置
            other.transform.position = v3Target;
            // 设置输出的方向
            other.attachedRigidbody.velocity = other.attachedRigidbody.velocity.magnitude * tgTarget.v3Out;
            // 测试全局变量是否传递
            // Debug.Log(GameObject.FindGameObjectWithTag("SceneNum").GetComponent<SceneNum>().getSN());
        }
    }

    // 离开
    private void OnTriggerExit(Collider other)
    {
        // 玩家离开时
        if (other.CompareTag("Player") && !isEff)
        {
            isEff = true;
        }
    }

    // 无效化
    void deff()
    {
        isEff = false;
    }

}
