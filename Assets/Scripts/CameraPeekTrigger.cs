using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPeekTrigger : MonoBehaviour {

	public CameraChanger cameraChanger;
	public GameObject ambientLights;

	public CandleController candleController;

	// Use this for initialization
	void Start () {
		
	}
	
	private void OnEnable() {
		candleController.canBlow = true;
		StartCoroutine(Peek());	
		ambientLights.SetActive(false);
	}

	private void OnDisable() {
		cameraChanger.SwitchPeekOff();
		if (ambientLights != null)
			ambientLights.SetActive(true);
	}

	IEnumerator Peek() {
		yield return new WaitForSeconds(0.25f);
		cameraChanger.SwitchPeekOn();
	}
}
