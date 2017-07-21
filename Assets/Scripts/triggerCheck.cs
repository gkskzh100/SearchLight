using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCheck : MonoBehaviour {

	public Transform rightTopParticle;
	public Transform leftTopParticle;
	public Transform rightBottomParticle;
	public Transform leftBottomParticle;

	// Use this for initialization
	void Start () {
		rightTopParticle.GetComponent<ParticleSystem>().enableEmission = false;
		leftTopParticle.GetComponent<ParticleSystem>().enableEmission = false;
		rightBottomParticle.GetComponent<ParticleSystem>().enableEmission = false;
		leftBottomParticle.GetComponent<ParticleSystem>().enableEmission = false;
	}
	void OnTriggerEnter(Collider other){
		if(!other.CompareTag("spectrumCube"))
		other.SendMessage("DestroyNote");
		if(other.CompareTag("Note")) {
			if(other.transform.name == "RightTopNote(Clone)") {
				rightTopParticle.GetComponent<ParticleSystem>().enableEmission = true;
				StartCoroutine(stopParticle("RightTopNote"));
			}
			if(other.transform.name == "LeftTopNote(Clone)") {
				leftTopParticle.GetComponent<ParticleSystem>().enableEmission = true;
				StartCoroutine(stopParticle("LeftTopNote"));
			}
			if(other.transform.name == "LeftBottomNote(Clone)") {
				leftBottomParticle.GetComponent<ParticleSystem>().enableEmission = true;
				StartCoroutine(stopParticle("LeftBottomNote"));
			}
			if(other.transform.name == "RightBottomNote(Clone)") {
				rightBottomParticle.GetComponent<ParticleSystem>().enableEmission = true;
				StartCoroutine(stopParticle("RightBottomNote"));
			}
		}
	}

	IEnumerator stopParticle(string name) {
		yield return new WaitForSeconds(.4f);
		if(name == "RightTopNote") {
			rightTopParticle.GetComponent<ParticleSystem>().enableEmission = false;
		}
		if(name == "LeftTopNote") {
			leftTopParticle.GetComponent<ParticleSystem>().enableEmission = false;
		}
		if(name == "LeftBottomNote") {
			leftBottomParticle.GetComponent<ParticleSystem>().enableEmission = false;
		}
		if(name == "RightBottomNote") {
			rightBottomParticle.GetComponent<ParticleSystem>().enableEmission = false;
		}
	}
}
