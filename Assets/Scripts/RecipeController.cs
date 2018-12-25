using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeController : MonoBehaviour {

	public Material[] MatList = new Material[8];




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetRecipeMat(int r){
		
		gameObject.GetComponent<Renderer>().material = MatList[r];			
	}
}
