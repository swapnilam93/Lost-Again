using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBoxController : MonoBehaviour {

	bool toolboxCollected = false;
	public MeshRenderer[] meshRenderers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter (Collider other) {
		if (other.gameObject.name.Equals("toolbox collector")) {
			foreach (MeshRenderer mr in meshRenderers) {
				mr.enabled = false;
			}
			toolboxCollected = true;
		}
	}

	private void OnTriggerExit (Collider other) {
		if (other.gameObject.name.Equals("Right Hand") && toolboxCollected) {
			this.gameObject.SetActive(false);
		}
	}

}
