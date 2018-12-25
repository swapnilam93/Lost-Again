using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CandleController : MonoBehaviour {

	public PlayableDirector[] playableDirectors;
	public bool isBlown;
	public bool canBlow;
	public bool triggerBlow;
	public VoiceRecognizer voiceRecognizer;

	[SerializeField] bool candle_trigger = false;
	// Use this for initialization

	AudioSource audioSource;
	public AudioClip candleBlowOut;
	
	private void Awake() {
		audioSource = this.gameObject.GetComponent<AudioSource>();	
	} 

	void Start () {
		//gameObject.transform.GetChild(0).gameObject.SetActive(false);
		isBlown = false;
		canBlow = false;
		triggerBlow = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(candle_trigger){
			gameObject.transform.GetChild(0).gameObject.SetActive(true);

		}
		else{
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}
		
		if (canBlow && !isBlown && playableDirectors[0].state == PlayState.Playing) {
			if (Input.GetKeyDown(KeyCode.B) || voiceRecognizer.blowDetected || triggerBlow) {
				candle_trigger = false;
				audioSource.PlayOneShot(candleBlowOut);
				playableDirectors[0].Stop();
				playableDirectors[1].Play();
				isBlown = true;
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "BlowCandleTrigger") {
			triggerBlow = true;
		}
	}
}
