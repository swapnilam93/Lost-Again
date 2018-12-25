using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CakeEatTrigger : MonoBehaviour {

	public PlayableDirector[] playableDirectors;

	bool warningPlayed;

	// Use this for initialization
	void Start () {
		warningPlayed= false;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.name.Equals("cake peice") && !warningPlayed) {
			playableDirectors[0].Stop();
			playableDirectors[1].Play();
			warningPlayed = true;
		}
	}
}
