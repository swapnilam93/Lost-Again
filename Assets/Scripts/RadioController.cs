using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class RadioController : MonoBehaviour {

	AudioSource audioSource;

	public AudioClip ad;
	public AudioClip bgm;

	float adTime;
	float adTimeCounter;
	bool countTime;
	bool switchTriggered;

	public PlayableDirector[] playableDirectors;

	// Use this for initialization
	void Start () {
		audioSource = this.gameObject.GetComponent<AudioSource>();
		adTimeCounter = 0.0f;
		countTime = false;
		switchTriggered = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (countTime) {
			adTimeCounter += Time.deltaTime;
			if (adTimeCounter >= (adTime - 7f)) {
				if (!switchTriggered) {
					//switch channel
					switchTriggered = true;
					playableDirectors[1].Stop();
					playableDirectors[2].Play();
				}
			}
		}
	}

	private void OnTriggerStay(Collider other) {
		/*if (other.gameObject.name.Equals("RightHandAnchor") || other.gameObject.name.Equals("Right Hand")) {
			//Debug.Log("lala");
			if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) {
				audioSource.PlayOneShot(ad);
			}
		}*/
	}

	public void StartRadio() {
		Debug.Log("radio started");
		audioSource.loop = false;
		audioSource.PlayOneShot(ad);
		adTime = ad.length;
		countTime = true;
		StartCoroutine(ActivateTimelineAfterStartRadio());
	}

	public void SwitchChannel() {
		Debug.Log("radio channel switched");
		audioSource.loop = true;
		audioSource.PlayOneShot(bgm);
		//StartCoroutine(ActivateTimelineAfterSwitchChannel());
	}

	IEnumerator ActivateTimelineAfterStartRadio () {
		yield return new WaitForSeconds(2.0f);
		playableDirectors[0].Stop();
		playableDirectors[1].Play();
	}

	IEnumerator ActivateTimelineAfterSwitchChannel () {
		yield return new WaitForSeconds(3.0f);
		playableDirectors[2].Stop();
		playableDirectors[3].Play();
	}
}
