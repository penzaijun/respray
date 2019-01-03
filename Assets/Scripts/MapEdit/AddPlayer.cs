using UnityEngine;
using System.Collections;

public class AddPlayer : MonoBehaviour
{
    public GameObject playerPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickPlayer()
    {
        if (MapEditList.player == null)
        {
            GameObject player = GameObject.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            player.AddComponent<MouseDrag>();
            MapEditList.player = player;
            GlobalVriable.currentObject = player;

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
}
