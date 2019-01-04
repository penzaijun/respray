using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeScale : MonoBehaviour
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
    public void ChangeObjScale()
    {
        if(GlobalVriable.currentObject.tag == "Bound")
            GlobalVriable.currentObject.transform.localScale = new Vector3((float)8.087 * slider.value * 2, (float)0.906 * slider.value * 2, slider.value * 2);
        else if (GlobalVriable.currentObject.tag == "Pick Up")
            GlobalVriable.currentObject.transform.localScale = new Vector3((float)1.5 * slider.value * 2, (float)1.5 * slider.value * 2, slider.value * 2);
        else if (GlobalVriable.currentObject.tag == "AbsorbBound")
            GlobalVriable.currentObject.transform.localScale = new Vector3((float)2.778603 * slider.value * 2, (float)2.778603 * slider.value * 2, (float)2.778603 * slider.value * 2);
        else if (GlobalVriable.currentObject.tag == "Shooter")
            GlobalVriable.currentObject.transform.localScale = new Vector3((float)1.687 * slider.value * 2, (float)1.687 * slider.value * 2, (float)1.687 * slider.value * 2);
        else if (GlobalVriable.currentObject.tag == "SpeedGate")
            GlobalVriable.currentObject.transform.localScale = new Vector3((float)1.924 * slider.value * 2, (float)1.924 * slider.value * 2, (float)1.924 * slider.value * 2);
        else if (GlobalVriable.currentObject.tag == "TransferGate")
            GlobalVriable.currentObject.transform.localScale = new Vector3((float)2 * slider.value * 2, (float)2 * slider.value * 2, (float)1.924 * slider.value * 2);
        else if (GlobalVriable.currentObject.tag == "Blackhole")
        {
            GlobalVriable.currentObject.transform.localScale = new Vector3((float)2 * slider.value * 2, (float)2 * slider.value * 2, (float)1.924 * slider.value * 2);
            Transform temp=GlobalVriable.currentObject.transform;
		    int childCount = temp.childCount;
		    for (int i = 0; i < childCount ; i++) {
			    temp.GetChild(i).gameObject.transform.localScale = new Vector3((float)2 * slider.value * 2, (float)2 * slider.value * 2, (float)1.924 * slider.value * 2);;
		    }
        }
            else
            GlobalVriable.currentObject.transform.localScale = new Vector3(slider.value * 2, slider.value * 2, slider.value * 2);
    }
}
