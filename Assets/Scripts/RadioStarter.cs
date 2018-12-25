using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioStarter : MonoBehaviour {

	public RadioController radioController;

	// Use this for initialization
	void Start () {
		//radioController.StartRadio();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnEnable() {
		radioController.StartRadio();
	}
}
