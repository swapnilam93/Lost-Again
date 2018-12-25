using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenDoorAnimationEnabler : MonoBehaviour {

	public OvenDoorController ovenDoorController;

	// Use this for initialization
	void Start () {
		//Debug.Log("start");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnEnable() {
		//Debug.Log("false");
		if (ovenDoorController.DoorClosedTrigger)
			ovenDoorController.DoorClosedTrigger = false;
		else
			ovenDoorController.DoorClosedTrigger = true;
	}

	private void OnDisable() {
		//Debug.Log("true");
		//ovenDoorController.DoorClosedTrigger = true;
	}
}
