using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MixerController : MonoBehaviour {

	public string IngredientTag;
	public IngredientManager ingredientManager;
	public PlayableDirector[] playableDirectors;
	private bool[] directorPlayed;




	
	public int count;

	private Animator animator;
	private AudioSource audioSource;
	public AudioClip[] audioClips;
	
	public CameraChanger cameraChanger;

	public bool playEggDrop;
	public bool playFlourDrop;

	public GameObject mixerInstructor;
	public Material bButton;

	//Mixer Parameter
	private enum mixerState {
		idle,
		Rising,
		Low,
		Mixing
	}
	private mixerState state;
	private bool mixerReady = true;
	private bool ingredientReady = false;
	[SerializeField] private Vector3 mixerRiseSpeed = new Vector3(0f, 0.005f, 0f);
	[SerializeField] private float mixerRotateSpeed = 0.1f;



	//Recipe Parameters
	public GameObject recipe;
	private bool flour = false;
	private bool egg = false;
	private bool sugar = false;
	private bool mixed = false;


	private void Awake() {
		animator = this.gameObject.GetComponent<Animator>();
		audioSource = this.gameObject.GetComponent<AudioSource>();
		directorPlayed = new bool[playableDirectors.Length];
		for (int i = 0; i < playableDirectors.Length; i++) {
			directorPlayed[i] = false;
		}
		directorPlayed[0] = true;
		playEggDrop = false;
		playFlourDrop = false;
	}

	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {

		/*if(Input.GetKeyDown(KeyCode.F) || OVRInput.GetDown(OVRInput.Button.One)){
			if(mixerReady ==true && ingredientReady == false){
				state = mixerState.Rising;
			}
			else if (mixerReady == false){
				state = mixerState.Low;
			}
			else if (ingredientReady == true){
				state = mixerState.Mixing;
				audioSource.PlayOneShot(audioClips[4]);
				if (!directorPlayed[5]) {
					StartCoroutine(cameraChanger.DigitalGlitch(0.5f, 0.3f));
				}
				StartCoroutine(StopMixerRotation());
			}
			
			
		}
		if(Input.GetKeyDown(KeyCode.V) || OVRInput.GetDown(OVRInput.Button.Two)){
			state = mixerState.Rising;
			if (!directorPlayed[5]) {
				playableDirectors[3].Stop();
				//playableDirectors[4].Stop();
				playableDirectors[5].Play();
				directorPlayed[5] = true;
			}
		}*/
		MixerMovement();

		if (!directorPlayed[1] && playFlourDrop & flour) {
			playableDirectors[0].Stop();
			playableDirectors[1].Play();
			directorPlayed[1] = true;
		}

		if (!directorPlayed[3] && playEggDrop && egg) {
			Debug.Log(playEggDrop + " lalalalaalalalala");
			StartCoroutine(MomToMixer());
		}
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag(IngredientTag)) {
			other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			if(other.gameObject.name.Equals("FlourBag")) {
				flour = true;
				SetRecipeMat();
				
				
				//StartCoroutine(cameraChanger.DigitalGlitch(0.2f, 0.3f));
				ingredientManager.keepHalo = false;
				Behaviour mixerHalo = (Behaviour)this.gameObject.GetComponent("Halo");
				mixerHalo.enabled = false;
				animator.SetBool("Glow", false);
				audioSource.PlayOneShot(audioClips[0]);

				/* other.gameObject.GetComponent<Animator>().SetTrigger("Tilt");
				other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
				if (!directorPlayed[0]) {
					directorPlayed[0] = true;
					playableDirectors[0].Play();
				} */
			} 
			else if(other.gameObject.name.Equals("Sugar")){
				audioSource.PlayOneShot(audioClips[1]);
				if(!sugar)
					audioSource.PlayOneShot(audioClips[2]);
				sugar = true;
				SetRecipeMat();
			}
			else if(other.gameObject.name.Equals("Egg")){
				audioSource.PlayOneShot(audioClips[3]);
				egg = true;
				SetRecipeMat();
				other.gameObject.GetComponent<BowlRotationController>().finish_pour = true;
				Destroy(other.gameObject.transform.GetChild(0).gameObject,0.2f);
				
			}
			
			
			else {
				//GameObject.Destroy(other.gameObject);
			} 
			count++;
			//animate adding ingredient to mixer
			
			//StartCoroutine(cameraChanger.Shake(.15f, .05f));
			Debug.Log(count);
		}
	}

	private void OnTriggerExit(Collider other) {
		
		 if (other.gameObject.CompareTag(IngredientTag)) {
			 other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			/*if(other.gameObject.name.Equals("FlourBag")) {
				other.gameObject.GetComponent<Animator>().SetTrigger("Even");
				StartCoroutine(MakeEven(other));
			}*/
		} 
	}

	/* IEnumerator MakeEven(Collider other) {
		yield return new WaitForSeconds(0.5f);
		other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
	} */

	private void OnTriggerStay(Collider other) {
		//enable mixer operations only when guest hand stays in it
		if (other.gameObject.name.Equals("Right Hand")) {
			if(Input.GetKeyDown(KeyCode.F) || OVRInput.GetDown(OVRInput.Button.One)){
				Debug.Log(mixerReady + " "+  ingredientReady);
				if(mixerReady ==true && ingredientReady == true){
					//ADD MIXER BUTTON ANIMATION
					gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("PushButton");
					state = mixerState.Mixing;
				//if (ingredientReady == true && state == mixerState.Mixing){
					if (!audioSource.isPlaying) {
						mixed = true;
						state = mixerState.Mixing;
						audioSource.PlayOneShot(audioClips[4]);
						if (!directorPlayed[5]) {
							StartCoroutine(cameraChanger.DigitalGlitch(0.5f, 0.3f));
						}
						StartCoroutine(StopMixerRotation());
					}
				}
				
				
			}
			if(Input.GetKeyDown(KeyCode.V) || OVRInput.GetDown(OVRInput.Button.Two)){
				Debug.Log("Pressed V");
				if (!directorPlayed[5] && playableDirectors[3].state == PlayState.Playing && !audioSource.isPlaying && mixed) {
					gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("PushButton");
					state = mixerState.Rising;
					playableDirectors[3].Stop();
					//playableDirectors[4].Stop();
					playableDirectors[5].Play();
					directorPlayed[5] = true;
					mixerInstructor.SetActive(false);
				}
			}
		}
	}
	


	private void SetRecipeMat(){
		if(flour && !sugar && !egg){
			recipe.GetComponent<RecipeController>().SetRecipeMat(1);
		}
		else if(!flour && sugar && !egg){
			recipe.GetComponent<RecipeController>().SetRecipeMat(2);
		}
		else if(!flour && !sugar && egg){
			recipe.GetComponent<RecipeController>().SetRecipeMat(3);
		}
		else if(flour && sugar && !egg){
			recipe.GetComponent<RecipeController>().SetRecipeMat(4);
		}
		else if(flour && !sugar && egg){
			recipe.GetComponent<RecipeController>().SetRecipeMat(5);
		}
		else if(!flour && sugar && egg){
			recipe.GetComponent<RecipeController>().SetRecipeMat(6);
		}
		else if(flour && sugar && egg){
			recipe.GetComponent<RecipeController>().SetRecipeMat(7);
			ingredientReady = true;
		}
	

		
	}
	private void MixerMovement(){
		switch(state){
			case mixerState.idle:
				//idle
				break;
			case mixerState.Rising:
				gameObject.transform.GetChild(3).transform.localPosition += mixerRiseSpeed;
				
				Vector3 target = gameObject.transform.GetChild(3).transform.localPosition;
				if(0.38 - target.y < 0.01 && 0.45 - target.y >=0){
					Debug.Log("Rise:" + (0.45 - target.y).ToString());
					//state = mixerState.idle;
					state = mixerState.idle;
					//mixerReady = false;
				}
				break;
			case mixerState.Low:
				gameObject.transform.GetChild(3).transform.localPosition -= mixerRiseSpeed;
				Debug.Log(gameObject.transform.GetChild(3).name);
				Vector3 temp = gameObject.transform.GetChild(3).transform.localPosition;
				if(temp.y - 0.21< 0.01 && temp.y - 0.21 >=0){
					
					//state = mixerState.idle;
					state = mixerState.Mixing;
					
					mixerReady = true;
					ingredientReady =true;
				}
				break;
			case mixerState.Mixing:
				gameObject.transform.GetChild(3).transform.RotateAround(gameObject.transform.GetChild(3).transform.position, gameObject.transform.GetChild(3).transform.up, mixerRotateSpeed);
				break;
		}

	}
	
	IEnumerator MomToMixer () {
		yield return new WaitForSeconds(2.0f);
		playableDirectors[2].Stop();
		playableDirectors[3].Play();
		directorPlayed[2] = true;
		directorPlayed[3] = true;
	}

	IEnumerator StopMixerRotation() {
		yield return new WaitForSeconds(audioClips[4].length);
		if (mixerInstructor != null)
			mixerInstructor.GetComponent<MeshRenderer>().material = bButton;
		state = mixerState.idle;
	}


	
}
