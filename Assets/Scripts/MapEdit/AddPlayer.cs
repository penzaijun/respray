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
        }
    }
}
