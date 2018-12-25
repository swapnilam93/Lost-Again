using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class CameraChanger : MonoBehaviour {

	private AnalogGlitch analogGlitch;
	private DigitalGlitch digitalGlitch;
	public GameObject[] planes;
	public bool blackOut;
	public bool peek;

	private void Awake() {
		analogGlitch = this.gameObject.GetComponent<AnalogGlitch>();	
		digitalGlitch = this.gameObject.GetComponent<DigitalGlitch>();
		blackOut = false;
		peek = false;
	}

	public IEnumerator Shake (float duration, float magnitude) {
		Vector3 originalPos = transform.localPosition;
		float elapsed = 0.0f;
		while (elapsed < duration) {
			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range(-1f, 1f) * magnitude;

			transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
			elapsed += Time.deltaTime;
			yield return null;
		}

		transform.localPosition = originalPos;
	}

	public IEnumerator AnalogGlitch (float magnitude, float duration) {
		analogGlitch.scanLineJitter = 0.5f * magnitude;
		analogGlitch.verticalJump = 0.1f * magnitude;
		analogGlitch.horizontalShake = 0.1f * magnitude;
		analogGlitch.colorDrift = 0.5f * magnitude;
		yield return new WaitForSeconds(duration);
		analogGlitch.scanLineJitter = 0f;
		analogGlitch.verticalJump = 0f;
		analogGlitch.horizontalShake = 0f;
		analogGlitch.colorDrift = 0f;
	}

	public IEnumerator DigitalGlitch (float duration, float magnitude) {
		digitalGlitch.intensity = magnitude;
		yield return new WaitForSeconds(duration);
		digitalGlitch.intensity = 0.0f;
	}

	public void SwitchBlackOutOff() {
		if (planes[0] != null)
			planes[0].SetActive(false);
		blackOut = false;
	}

	public void SwitchBlackOutOn() {
		planes[0].SetActive(true);
		blackOut = true;
	}

	public void SwitchPeekOn() {
		planes[1].SetActive(true);
		peek = true;
	}

	public void SwitchPeekOff() {
		if (planes[1] != null)
			planes[1].SetActive(false);
		peek = false;
	}

	public IEnumerator Blink(float duration) {
		Debug.Log("blink");
		planes[2].SetActive(true);
		planes[3].SetActive(true);
		planes[2].GetComponent<Animator>().SetTrigger("Shut");
		planes[3].GetComponent<Animator>().SetTrigger("Shut");
		yield return new WaitForSeconds(duration/2);
		planes[2].GetComponent<Animator>().SetTrigger("Open");
		planes[3].GetComponent<Animator>().SetTrigger("Open");
		yield return new WaitForSeconds(duration/2);
		planes[2].SetActive(false);
		planes[3].SetActive(false);
	}
}
