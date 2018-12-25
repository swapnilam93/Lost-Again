using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnArmTrigger : MonoBehaviour {

	public BurnArmController burnArmController;

	// Use this for initialization
	void Start () {
		
	}
	
	private void OnEnable() {
		burnArmController.BurnTrigger = true;
	}
}
