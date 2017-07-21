using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveNote : MonoBehaviour {
	
	public float xMove = 1.6f;
	public float yMove = -1f;
	public int speed = 1;

	// Update is called once per frame
	void Update () {
		float x = xMove * speed * Time.deltaTime;
		float y = yMove * speed * Time.deltaTime;
		this.transform.Translate(new Vector3(x,y,0));
	}
	public void DestroyNote() {
		Destroy(this.gameObject,0f);
	}
}
