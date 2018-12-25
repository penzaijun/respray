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
    }
}
