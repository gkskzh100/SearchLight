using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	public Transform[] points;
	public GameObject RedNote; //(6.2, 6.9, -0.2) //point[1]
	public GameObject YellowNote; //(7.2, -6.6, -0.2) //point[2]
	public GameObject BlueNote; //(-6.2, 6.9, -0.2) //point[3]
	public GameObject GreenNote;//(-7.2, -6.6, -0.2) //point[4]
	public Transform RightTopPannel;
	public Transform LeftTopPannel;
	public Transform LeftBottomPannel;
	public Transform RightBottomPannel;
	public GameObject SpawnObj;

	// Use this for initialization
	void Start () {
		points = SpawnObj.GetComponentsInChildren<Transform>();
	}
	
	public void RedCreate() {
		Instantiate(RedNote,points[1].position,Quaternion.Euler(0,0,-45)).transform.SetParent(RightTopPannel);
	}
	public void BlueCreate() {
		Instantiate(BlueNote,points[3].position,Quaternion.Euler(0,0,-45)).transform.SetParent(LeftTopPannel);
	}
	public void GreenCreate() {
		Instantiate(GreenNote,points[4].position,Quaternion.Euler(0,0,-45)).transform.SetParent(LeftBottomPannel);
	}
	public void YellowCreate() {
		Instantiate(YellowNote,points[2].position,Quaternion.Euler(0,0,-45)).transform.SetParent(RightBottomPannel);
	}
}
