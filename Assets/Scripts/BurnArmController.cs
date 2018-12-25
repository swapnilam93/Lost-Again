using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnArmController : MonoBehaviour {
	[SerializeField] public bool BurnTrigger = false;
	[SerializeField] public float BurnSpeed = 0.005f;

	public GameObject Sparks;

	private float burn_amount = 0f;
	private bool StartBurn = false;
	private Material BurnMat;
	private Material originalMat;
	// Use this for initialization
	void Start () {
		var a = gameObject.GetComponent<Renderer>().materials;
		originalMat = a[0];
		BurnMat = a[1];

		
	}
	
	// Update is called once per frame
	void Update () {
		if(BurnTrigger){
			SwitchArmMat();
			
		}
		if(StartBurn && burn_amount <= 0.5f){
			BurnMat.SetFloat("_DissolveAmount", burn_amount+=BurnSpeed);
			Sparks.SetActive(true);



		}
		
	}
	private void SwitchArmMat(){
		
		originalMat.SetFloat("_Cutoff", 0.435f);
		BurnMat.SetFloat("_DissolveAmount", burn_amount);
		StartBurn = true;
		//switch_mat = false;

	}
	public void StopSparks(){
		Sparks.SetActive(false);
	}
}
