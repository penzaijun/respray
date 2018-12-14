using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraRendering : MonoBehaviour
{
	public Material m_Mat = null;
	private GameObject blackhole;
	//public List <GameObject> BlackHoles=new List <GameObject> ();
	[Range(0.01f, 0.2f)] public float m_DarkRange = 0.1f;
	[Range(-2.5f, -1f)] public float m_Distortion = -2f;
	[Range(0.05f, 0.3f)] public float m_Form = 0.2f;
	
	void Start ()
	{
		blackhole=gameObject;
		//this.BlackHoles=GetComponent<PlayingManager>().BlackHoles;
	}
	void OnRenderImage (RenderTexture sourceTexture, RenderTexture destTexture)
	{
		// var positions=new Vector4[10];
		// for (int i=0;i<l;i++){
		// 	Vector3 screenPos=Camera.main.WorldToScreenPoint(BlackHoles[i].transform.position);
		// 	float x=screenPos.x/Screen.width;
		// 	float y=screenPos.y/Screen.height;
		// 	positions[i]=new Vector4(x,y,0f,0f);
		// }
			m_Mat.SetVector("_Center",new Vector4(0,0,0,0));
			//m_Mat.SetVector ("_Center", new Vector4 (x, y, 0f, 0f));
			m_Mat.SetFloat ("_DarkRange", m_DarkRange);
			m_Mat.SetFloat ("_Distortion", m_Distortion);
			m_Mat.SetFloat ("_Form", m_Form);
			Graphics.Blit (sourceTexture, destTexture, m_Mat);
	}
	void Update ()
	{
	}
}