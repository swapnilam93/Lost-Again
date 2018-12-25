using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestHandController : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)) {
			animator.SetBool("Grab", true);
		}
		else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger)) {
			animator.SetBool("Grab", false);
		}
	}
}
