using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarCanController : MonoBehaviour {

	// Use this for initialization
	public GameObject particles;
	private bool particleTrigger = true;

	void Start () {
		particles.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Mathf.Abs(gameObject.transform.GetChild(0).transform.rotation.z) >= 0.5f ){
			startPour();

		}
		if(Mathf.Abs(gameObject.transform.GetChild(0).transform.rotation.z) < 0.5f && !particleTrigger ){
			particles.SetActive(false);
			particleTrigger = true;

		}
	}

	private void startPour(){
		particles.transform.position = gameObject.transform.GetChild(0).transform.GetChild(0).transform.position;
		particles.SetActive(true);
		particleTrigger = false;
	}
}
