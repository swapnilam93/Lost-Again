using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour {

	public GameObject[] ingredients;

	public Transform[] ingredientTransforms;

	public GameObject instructingFlour;
	public GameObject mixer;
	public GameObject guidanceParticle;

	public bool keepHalo;
	public bool keepGuidanceParticle;
	//private Behaviour halo;

	// Use this for initialization
	void Start () {
		//for (int i = 1; i < ingredients.Length; i++) {
		//	GenerateIngredient(ingredients[i], ingredientTransforms[i]);
		///}
		keepHalo = false;
		keepGuidanceParticle = false;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (keepHalo) {
			AnimateHalo();
		}*/
		if (keepGuidanceParticle) {
			AnimateGuidanceParticle();
		}

	}

	public GameObject GenerateIngredient (string ingredientName) {
		Debug.Log(ingredientName);
		for (int i = 0; i < ingredients.Length; i++) {
			if (ingredientName.Equals(ingredients[i].name)) {
				return GenerateIngredient(ingredients[i], ingredientTransforms[i]);
			}
		}
		return null;
	}

	private GameObject GenerateIngredient (GameObject ingredient, Transform transform) {
		//GameObject ingre = GameObject.Find(ingredient.name);
		//if (ingre == null) {
			GameObject ing =  Instantiate(ingredient, transform.position, transform.rotation);
			ing.name = ingredient.name;
			return ing;
		///return null;
	}

	public void SwitchHalo(bool keep) {
		keepHalo = keep;
	}

	void AnimateHalo () {
		Behaviour halo = (Behaviour)instructingFlour.GetComponent("Halo");
		halo.enabled = true;
		instructingFlour.GetComponent<Animator>().SetBool("Glow", true);
		OVRGrabbable oVRGrabbable = instructingFlour.GetComponent<OVRGrabbable>();
		if (oVRGrabbable.isGrabbed) {
			halo.enabled = false;
			instructingFlour.GetComponent<Animator>().SetBool("Glow", false);
			Behaviour mixerHalo = (Behaviour)mixer.GetComponent("Halo");
			mixerHalo.enabled = true;
			mixerHalo.GetComponent<Animator>().SetBool("Glow", true);
		}
	}

	public void RegenerateAllIngredients() {
		for (int i = 0; i < ingredients.Length; i++) {
			GameObject.Destroy(GameObject.Find(ingredients[i].name));
			GenerateIngredient(ingredients[i], ingredientTransforms[i]);
		}
	}

	public void SwitchGuidanceParticle(bool keep) {
		keepGuidanceParticle = keep;
	}

	void AnimateGuidanceParticle () {
		guidanceParticle.SetActive(true);
		OVRGrabbable oVRGrabbable = instructingFlour.GetComponent<OVRGrabbable>();
		if (oVRGrabbable.isGrabbed) {
			guidanceParticle.SetActive(false);
			Behaviour mixerHalo = (Behaviour)mixer.GetComponent("Halo");
			mixerHalo.enabled = true;
			mixerHalo.GetComponent<Animator>().SetBool("Glow", true);
		}
	}
}
