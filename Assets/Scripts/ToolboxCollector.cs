using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ToolboxCollector : MonoBehaviour {

	public bool collectToolbox;
	public bool timelinePlayed;
	public PlayableDirector armBrokeTimeline;
	public PlayableDirector armFixTimeline;
	public GameObject guidanceParticle;

	public GameObject guestBox;
	public GameObject momBox;

	// Use this for initialization
	void Start () {
		timelinePlayed = false;
	}

	private void OnEnable() {
		collectToolbox = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other) {
		//Debug.Log("trigger on " + other.gameObject.name);
		if (collectToolbox) {
			if (other.gameObject.name.Equals("toolbox")) {
				Debug.Log("toolbox placed");
				Behaviour halo = (Behaviour) this.gameObject.GetComponent("Halo");
				halo.enabled = false;
				guidanceParticle.SetActive(false);
				//guestBox.SetActive(false);
				momBox.SetActive(true);
				collectToolbox = false;
				if (!timelinePlayed) {
					//stop last timeline
					//start next timeline
					armBrokeTimeline.Stop();
					armFixTimeline.Play();
					timelinePlayed = true;
				}
			}
			if (other.gameObject.name.Equals("Right Hand")) {
				Debug.Log("do nothing");
			}	
		}
	}
}
