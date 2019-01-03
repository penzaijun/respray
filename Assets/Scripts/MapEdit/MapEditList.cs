using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapEditList : MonoBehaviour
{

    // Initialize the map
    public static List<GameObject> flagList = new List<GameObject>();
    public static List<GameObject> starList = new List<GameObject>();
    public static List<List<GameObject>> listOfTransferGateList = new List<List<GameObject>>();
    public static List<GameObject> transferGateList = new List<GameObject>();
    public static List<GameObject> blackHoleList = new List<GameObject>();
    public static List<GameObject> shooterList = new List<GameObject>();
    public static List<GameObject> speedGateList = new List<GameObject>();
    public static List<GameObject> absorbBoundList = new List<GameObject>();
    public static List<GameObject> boundList = new List<GameObject>();
    public static List<GameObject> rotateGateList = new List<GameObject>();
    public static GameObject player;
}
