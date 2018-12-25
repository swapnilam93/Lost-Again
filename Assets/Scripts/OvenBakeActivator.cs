using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OvenBakeActivator : MonoBehaviour {

	public PlayableDirector armFixTimeline;
	public PlayableDirector ovenBakeTimeline;
	public bool ovenBakePlayed;
	public BookOnFloorController bookOnFloorController;

	// Use this for initialization
	void Start () {
		ovenBakePlayed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (bookOnFloorController.FinishPickUp && !ovenBakePlayed) {
			armFixTimeline.Stop();
			ovenBakeTimeline.Play();
			ovenBakePlayed = true;
		}
	}
}
