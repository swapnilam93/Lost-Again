using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlourBagController : MonoBehaviour {

	// Use this for initialization
	public GameObject particles;
	private bool particleTrigger = true;

	void Start () {
		particles.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(gameObject.transform.rotation.x);
		if(Mathf.Abs(gameObject.transform.rotation.x) >= 0.5f ){
			startPour();

		}
		if(Mathf.Abs(gameObject.transform.rotation.x) < 0.5f && !particleTrigger ){
			particles.SetActive(false);
			particleTrigger = true;

		}
	}

	private void startPour(){
		particles.transform.position = gameObject.transform.GetChild(0).transform.position;
		particles.SetActive(true);
		particleTrigger = false;
	}
}
