using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelSwitcher : MonoBehaviour {

	public RadioController radioController;

	// Use this for initialization
	void Start () {
		radioController.SwitchChannel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
