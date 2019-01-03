using UnityEngine;
using System.Collections;

public class AddBlackHole : MonoBehaviour
{
    public GameObject blackHolePrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickBlackHole()
    {
        GameObject blackHole = GameObject.Instantiate(blackHolePrefab, Vector3.zero, Quaternion.identity);
        blackHole.AddComponent<MouseDrag>();
        MapEditList.blackHoleList.Add(blackHole);
        GlobalVriable.currentObject = blackHole;

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
