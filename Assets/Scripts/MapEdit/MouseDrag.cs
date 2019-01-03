using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MouseDrag : MonoBehaviour
{
    //用于实现可以拖动物体移动 
    //先写一个方法将屏幕坐标转换成世界坐标

    Vector3 MyScreenPointToWorldPoint(Vector3 ScreenPoint, Transform target)
    {
        //1 得到物体在主相机的xx方向
        Vector3 dir = (target.position - Camera.main.transform.position);
        //2 计算投影 (计算单位向量上的法向量)
        Vector3 norVec = Vector3.Project(dir, Camera.main.transform.forward);
        //返回世界空间
        return Camera.main.ViewportToWorldPoint
            (
               new Vector3(
                   ScreenPoint.x / Screen.width,
                   ScreenPoint.y / Screen.height,
                   norVec.magnitude
               )
            );
    }

    private Vector3 startPos;     // 拖拽起始位置
    private Vector3 endPos;       // 拖拽结束位置
    private Vector3 offset;       // 鼠标偏移量

    private void OnMouseDown()
    {
        //记录起始位置
        //因为我们的物体cube所处的是世界空间 鼠标是屏幕空间
        //需要将鼠标的屏幕空间转换成世界空间
        startPos = MyScreenPointToWorldPoint(Input.mousePosition, transform);
        //修改当前操作对象
        GlobalVriable.currentObject = gameObject;
        if(GlobalVriable.currentObject.tag != "TransferGate")
        {
            GameObject obj1 = GameObject.Find("Canvas/Panel/TextAngle");
            GameObject obj2 = GameObject.Find("Canvas/Panel/InputFieldAngle");
            obj1.SetActive(false);
            obj2.SetActive(false);
            GameObject obj3 = GameObject.Find("Canvas/Panel/ButtonTarget");
            obj3.SetActive(false);
            GlobalVriable.isSetTarget = false;
            GlobalVriable.transferGate = null;
        }
        else
        {
            GameObject obj1 = GameObject.Find("Canvas/Panel/TextAngle");
            GameObject obj2 = GameObject.Find("Canvas/Panel/InputFieldAngle");
            obj1.SetActive(true);
            obj2.SetActive(true);
            GameObject obj3 = GameObject.Find("Canvas/Panel/ButtonTarget");
            obj3.SetActive(true);
            if(GlobalVriable.isSetTarget == true)
            {
                GlobalVriable.transferGate.GetComponent<TransferGate>().tgTarget = GlobalVriable.currentObject.GetComponent<TransferGate>();
                GlobalVriable.isSetTarget = false;
                GlobalVriable.currentObject = GlobalVriable.transferGate;
                GlobalVriable.transferGate = null;
            }
        }
    }

    private void OnMouseDrag()
    {
        endPos = MyScreenPointToWorldPoint(Input.mousePosition, transform);
        //计算偏移量
        offset = (endPos - startPos);
        //让cube移动
        transform.position += offset;
        //这一次拖拽的终点变成了下一次拖拽的起点  
        startPos = endPos;
    }
    
} 