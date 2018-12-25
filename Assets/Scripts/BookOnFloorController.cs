using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOnFloorController : MonoBehaviour {

	public GameObject newspaper;
	public AudioClip SingleBookFall;
	[SerializeField] public bool FinishPickUp  = false;
	private int bookonfloorCount = 0;
	private bool CanPlay = true;
	// Use this for initialization
	void Start () {
		newspaper.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other) {
		if(CanPlay){
			gameObject.GetComponent<AudioSource>().Play();
			CanPlay = false;
		}
		
		bookonfloorCount++;
		newspaper.SetActive(true);
		Debug.Log("Enter: " +other.gameObject.name + bookonfloorCount);
	}

	private void OnTriggerExit(Collider other) {
		bookonfloorCount--;
		Debug.Log("PickUp :" + other.gameObject.name + bookonfloorCount);
		if(bookonfloorCount == 0){
			FinishPickUp = true;
		}
	}


}
