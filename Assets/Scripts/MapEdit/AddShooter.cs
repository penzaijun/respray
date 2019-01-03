using UnityEngine;
using System.Collections;

public class AddShooter : MonoBehaviour
{
    public GameObject shooterPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickShooter()
    {
        GameObject shooter = GameObject.Instantiate(shooterPrefab, Vector3.zero, Quaternion.identity);
        shooter.AddComponent<MouseDrag>();
        MapEditList.shooterList.Add(shooter);
        GlobalVriable.currentObject = shooter;

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
