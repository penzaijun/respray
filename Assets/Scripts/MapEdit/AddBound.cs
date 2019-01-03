using UnityEngine;
using System.Collections;

public class AddBound : MonoBehaviour
{
    public GameObject boundPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickBound()
    {
        GameObject bound = GameObject.Instantiate(boundPrefab, Vector3.zero, Quaternion.identity);
        bound.AddComponent<MouseDrag>();
        MapEditList.boundList.Add(bound);
        GlobalVriable.currentObject = bound;

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
