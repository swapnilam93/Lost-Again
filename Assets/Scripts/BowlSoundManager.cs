using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlSoundManager : MonoBehaviour {
	public AudioClip[] audios;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<AudioSource>().mute = true;
		StartCoroutine(MuteStart());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision other) {
		Debug.Log(other.gameObject.name);
		if(other.gameObject.name.Equals("Environment")){
			gameObject.GetComponent<AudioSource>().clip = audios[1];
			gameObject.GetComponent<AudioSource>().Play();
		}
		
	}
	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.name.Equals("Right Hand")){
			gameObject.GetComponent<AudioSource>().clip = audios[0];
			gameObject.GetComponent<AudioSource>().Play();
		}
	}
	IEnumerator MuteStart(){
		yield return new WaitForSeconds(2f);
		gameObject.GetComponent<AudioSource>().mute = false;
	}
}
