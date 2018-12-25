using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlayAfterEggDrop : MonoBehaviour {

	public MixerController mixerController;

	// Use this for initialization
	void Start () {
		mixerController.playEggDrop = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
