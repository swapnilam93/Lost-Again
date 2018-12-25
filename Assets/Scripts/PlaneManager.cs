using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour {

	public string IngredientTag;
	public IngredientManager ingredientManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.I)) {
			ingredientManager.RegenerateAllIngredients();
		}
	}

	/*private void OnCollisionEnter(Collision other) {
		Debug.Log("collision " + other.gameObject.name);
		if (other.gameObject.CompareTag(IngredientTag)) {
			if(other.gameObject.name.Equals("FlourBag")) {
				ingredientManager.keepHalo = false;
				GameObject.Destroy(other.gameObject);
				ingredientManager.GenerateIngredient(other.gameObject.name);
			}
			//GameObject.Destroy(other.gameObject);
			if(other.gameObject.name.Equals("Sugar")) {
				GameObject.Destroy(GameObject.Find("SugarBottleWithParticle"));
				ingredientManager.GenerateIngredient("SugarBottleWithParticle");
			}
			if (other.gameObject.name.Equals("Egg")) {
				GameObject.Destroy(other.gameObject);
				ingredientManager.GenerateIngredient(other.gameObject.name);
			}
		}
	}*/
	
}
