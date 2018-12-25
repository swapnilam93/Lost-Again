using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSparkStopper : MonoBehaviour {

	public BurnArmController burnArmController;

	// Use this for initialization
	void Start () {
		burnArmController.StopSparks();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
