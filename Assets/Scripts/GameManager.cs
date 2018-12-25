using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject[] gameScenes;
	public int gameSceneNumber;

	AudioSource audioSource;

	void Awake() {
		audioSource = this.gameObject.GetComponent<AudioSource>();
		gameSceneNumber = 0;
	}

	// Use this for initialization
	void Start () {
		gameScenes[gameSceneNumber].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		//on event trigger increase gameSceneNumber
		for (int i = 0; i < gameScenes.Length; i++) {
			if (i == gameSceneNumber) {
				gameScenes[i].SetActive(true);
			} else {
				gameScenes[i].SetActive(false);
			}
		}
	}
}
