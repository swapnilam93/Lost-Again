using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSceneController : MonoBehaviour {

	public CameraChanger cameraChanger;
	//public AudioClip audioClip;

	// Use this for initialization
	void Start () {
		StartCoroutine(cameraGlitch());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator cameraGlitch() {
		//OVRHapticsClip hapticsClip = new OVRHapticsClip(audioClip);
		//OVRHaptics.RightChannel.Preempt(hapticsClip);
		StartCoroutine(cameraChanger.AnalogGlitch(0.1f, 3f));
		StartCoroutine(cameraChanger.DigitalGlitch(3f, .2f));
		yield return new WaitForSeconds(3f);
		//StartCoroutine(cameraChanger.DigitalGlitch(7f, 0f));
		yield return new WaitForSeconds(3f);
		StartCoroutine(cameraChanger.AnalogGlitch(.5f, 2f));
		StartCoroutine(cameraChanger.DigitalGlitch(2f, .3f));
		yield return new WaitForSeconds(2f);
		StartCoroutine(cameraChanger.AnalogGlitch(1f, 2f));
		StartCoroutine(cameraChanger.DigitalGlitch(2f, .5f));
		yield return new WaitForSeconds(2f);
		StartCoroutine(cameraChanger.AnalogGlitch(2f, 1f));
		StartCoroutine(cameraChanger.DigitalGlitch(1f, .7f));
	}
	

}
