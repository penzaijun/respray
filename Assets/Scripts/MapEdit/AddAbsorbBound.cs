using UnityEngine;
using System.Collections;

public class AddAbsorbBound : MonoBehaviour
{
    public GameObject absorbBoundPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickAbsorbBound()
    {
        GameObject absorbBound = GameObject.Instantiate(absorbBoundPrefab, Vector3.zero, Quaternion.identity);
        absorbBound.AddComponent<MouseDrag>();
        MapEditList.absorbBoundList.Add(absorbBound);
        GlobalVriable.currentObject = absorbBound;

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
