using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlRotationController : MonoBehaviour {

	public GameObject mLiquid;
	public GameObject mMesh;
	public GameObject egg1;
	public GameObject egg2;

	[SerializeField] private float SloshSpeed = 60f;
	[SerializeField] private float RotateSpeed = 15f;

	private int difference = 18;
	private Vector3 normalVec;
	public bool finish_pour = false;

	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!finish_pour){
			normalVec = mLiquid.transform.up;
			mMesh.transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime, Space.Self);
			Slosh();
		}
		
	
		
	}

	private void Slosh(){
		Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);
		Vector3 finalRotation = Quaternion.RotateTowards(mLiquid.transform.localRotation, inverseRotation, SloshSpeed * Time.deltaTime).eulerAngles;

		finalRotation.x = ClampRotationValue(finalRotation.x, difference);
		finalRotation.z = ClampRotationValue(finalRotation.z, difference);
		

		mLiquid.transform.localEulerAngles = finalRotation;
		//Debug.Log(finalRotation);
		egg1.transform.position += (mLiquid.transform.up - normalVec)* 0.05f;
		egg2.transform.position += (mLiquid.transform.up - normalVec)* 0.05f;
	}
	private void MoreSlosh(){

	}
	private float ClampRotationValue(float value, float difference){

		float returnValue = 0.0f;

		if(value > 180){
			returnValue = Mathf.Clamp(value, 360 - difference, 360);
		}
		else{
			returnValue = Mathf.Clamp(value, 0 , difference);
		}
		
		return returnValue;
	}

	IEnumerator delaySlosh(){
		yield return new WaitForEndOfFrame();
		Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);
		Vector3 finalRotation = Quaternion.RotateTowards(mLiquid.transform.localRotation, inverseRotation, SloshSpeed * Time.deltaTime).eulerAngles;

		finalRotation.x = ClampRotationValue(finalRotation.x, difference);
		finalRotation.z = ClampRotationValue(finalRotation.z, difference);

		mLiquid.transform.localEulerAngles = finalRotation;
	}
}
