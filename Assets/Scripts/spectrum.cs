using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class spectrum : MonoBehaviour {

	public GameObject prefeb;
	public int objectNum = 44;
	public float radius = 0.2f; //간격
	private GameObject[] cubes;
	private float x;
	private float y;
	private float max=0.08f;
	public Transform spectrums;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < objectNum; i++) {
			if(i<=10) {
				float angle_x = -i * radius;
				float angle_y = -i * radius;
				x = angle_x;
				y = angle_y;
				Vector2 pos = new Vector2 (angle_x-0.5f, angle_y+3.2f);
				Instantiate(prefeb,pos,Quaternion.Euler(0,0,225)).transform.SetParent(spectrums);
			}
			if(i>10 && i<=21) {
				float angle_x = x + radius;
				float angle_y = y - radius;
				Vector2 pos = new Vector2 (angle_x-0.7f, angle_y+2.4f);
				x = angle_x;
				y = angle_y;
				Instantiate(prefeb,pos,Quaternion.Euler(0,0,-45)).transform.SetParent(spectrums);
			}
			if(i>21 && i<=32) {
				float angle_x = x + radius; 
				float angle_y = y + radius;
				Vector2 pos = new Vector2 (angle_x+0.1f, angle_y+2.2f);
				x = angle_x;
				y = angle_y;
				Instantiate(prefeb,pos,Quaternion.Euler(0,0,45)).transform.SetParent(spectrums);
			}
			if(i>32 && i<=44) {
				float angle_x = x - radius; 
				float angle_y = y + radius;
				Vector2 pos = new Vector2 (angle_x+0.3f, angle_y+3f);
				x = angle_x;
				y = angle_y;
				Instantiate(prefeb,pos,Quaternion.Euler(0,0,135)).transform.SetParent(spectrums);
			}
		}
		cubes = GameObject.FindGameObjectsWithTag("spectrumCube");
		
	}
	
	// Update is called once per frame
	void Update () {
		float[] spect = AudioListener.GetSpectrumData (1024, 0, FFTWindow.Hamming);
		for(int i=0;i<objectNum;i++) {
			try {
				Vector3 previousScale = cubes[i].transform.localScale;
				if(spect[i]>=max) {
					spect[i] = max;
				}
				previousScale.y = spect[i] + 0.02f;
				cubes[i].transform.localScale = previousScale;
			} catch (IndexOutOfRangeException e) {

			}
		}
	}
}
