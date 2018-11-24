using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarControl : MonoBehaviour {

	public GameObject star;
	private GameObject[] stars;
	private Transform holder;
	public RectTransform TransformRange;
	// Use this for initialization
	void Start () {
		float w = TransformRange.sizeDelta.x/100;
		float h = TransformRange.sizeDelta.y/100; 
		Debug.Log("w="+w+"      h="+h);
		for (int i=1;i<=10;i++){
			GameObject instance =Instantiate(star, 
				new Vector3(Random.Range(-w,w),Random.Range(-h,h),0f),
				Quaternion.identity);
			instance.transform.SetParent(TransformRange);
			instance.transform.localScale=Vector3.one*1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
