using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlinkTrigger : MonoBehaviour {

	public CameraChanger cameraChanger;
	bool blinked;

	// Use this for initialization
	void Start () {
		blinked = false;
	}
	
	private void OnEnable() {
		if (!blinked) {
			StartCoroutine(cameraChanger.Blink(4f));
			blinked = true;
		}
	}

	private void OnDisable() {
		blinked = false;
	}
}
