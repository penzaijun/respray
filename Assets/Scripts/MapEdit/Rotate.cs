using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    public Slider slider;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //通过拖拽滑动条改变物体大小
    public void ChangeRotation()
    {        
        GlobalVriable.currentObject.transform.localEulerAngles = new Vector3(0, 0, 360 * slider.value);
    }
}