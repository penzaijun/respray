using UnityEngine;
using System.Collections;

public class AddStar : MonoBehaviour
{
    public GameObject starPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickStar()
    {
        GameObject star = GameObject.Instantiate(starPrefab, Vector3.zero, Quaternion.identity);
        star.AddComponent<RectMouseDrag>();
        MapEditList.starList.Add(star);
    }
}
