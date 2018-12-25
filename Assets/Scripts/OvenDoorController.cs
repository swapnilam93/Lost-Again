using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenDoorController : MonoBehaviour {
	[SerializeField] public bool DoorClosedTrigger = false;
	[SerializeField] float RotateSpeed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(DoorClosedTrigger && gameObject.transform.rotation.z >=0){
			gameObject.transform.RotateAround(gameObject.transform.position, Vector3.right,RotateSpeed);
		}
		else if(!DoorClosedTrigger && gameObject.transform.rotation.z <0.28f ){
			gameObject.transform.RotateAround(gameObject.transform.position, Vector3.right,-RotateSpeed);
		}
	}
}
