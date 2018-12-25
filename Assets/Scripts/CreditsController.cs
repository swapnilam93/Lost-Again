using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour {

	
	public Image[] creditImg;
	
	int screenNumber;

	// Use this for initialization
	void Start () {
		screenNumber = creditImg.Length;
		creditImg[0].CrossFadeAlpha(100.0f,3.0f,true);
		StartCoroutine(LerpCredits());
		
	}
	private void Update() {
		
	}

	IEnumerator LerpCredits() {
		for(int i = 0; i < screenNumber - 1; i++) {
			yield return new WaitForSeconds(5f);
			creditImg[i].CrossFadeAlpha(0.0f,2.0f,true);
			//StartCoroutine(disableCredit(i));
			yield return new WaitForSeconds(2f);
			creditImg[i+1].CrossFadeAlpha(100.0f,2.0f,true);
			Debug.Log(i);
			


			//meshRenderer.material = materials[i+1];
			//yield return new WaitForSeconds(1f);
		}
		yield return new WaitForSeconds(5f);
		
	}
	IEnumerator disableCredit(int j){
		yield return new WaitForSeconds(2f);
		creditImg[j].gameObject.SetActive(false);
	}
}
