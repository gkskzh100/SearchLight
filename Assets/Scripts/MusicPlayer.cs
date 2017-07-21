using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public Slider musicLength;
	private bool stop = false;
	private WWW tmpWWW;
	private AudioSource music;
	private string path = null;
	private float playValue = 0;

	// Use this for initialization
	void Start () {
		music = GetComponent<AudioSource>();
	}

	public void move(float newTime) {
		music.time = newTime;
	}

	
	// Update is called once per frame
	void Update () {
		if(!stop && path != null) {
			musicLength.value += Time.deltaTime;
		}
	}
	

	public void pathReceive(string receive) {
		path = receive;
		StartCoroutine(musicSearch());
	}

	IEnumerator musicSearch() {
		tmpWWW = new WWW("file://" + path);
		do {
			yield return null;
		} while (!tmpWWW.isDone);
		if(tmpWWW.error != null) {
			Debug.LogError("tmpWWW.error="+tmpWWW.error);
			yield break;
		}
		Debug.Log(tmpWWW.GetAudioClip().length);
		music.clip = tmpWWW.GetAudioClip();

		musicLength.maxValue = music.clip.length;
		musicLength.value = 0;
		music.Play();
	}

	public void StartAudio() {
		if(stop) {
			musicLength.value = playValue;
			music.Play();
			stop = false;
		}
	}

	public void StopAudio() {
		playValue = musicLength.value;
		music.Pause();
		stop = true;
		Debug.Log(music.time);
	}
}
