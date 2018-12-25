using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionActivator : MonoBehaviour {

	public IngredientManager ingredientManager;

	// Use this for initialization
	void Start () {
		//ingredientManager.SwitchHalo(true);
		ingredientManager.SwitchGuidanceParticle(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
