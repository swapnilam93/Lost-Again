using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlackoutTrigger : MonoBehaviour {

	public CameraChanger cameraChanger;

	// Use this for initialization
	void Start () {
		
	}
	
	private void OnEnable() {
		cameraChanger.SwitchBlackOutOn();	
	}

	private void OnDisable() {
		cameraChanger.SwitchBlackOutOff();		
	}
}
