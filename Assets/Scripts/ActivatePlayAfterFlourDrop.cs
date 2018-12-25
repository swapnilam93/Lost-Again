using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlayAfterFlourDrop : MonoBehaviour {

	public MixerController mixerController;

	// Use this for initialization
	void Start () {
		mixerController.playFlourDrop = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
