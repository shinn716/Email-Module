using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardIn : MonoBehaviour {


	public iTween.EaseType InEase; 
	public iTween.EaseType OutEase; 
	public float orgaxisy;
	public float tarrot;
	public float time=0;

	void OnEnable () {

		gameObject.transform.localEulerAngles = new Vector3 (0, orgaxisy, 0);

		time = Random.Range (.5f, 2);
		iTween.RotateTo (gameObject, iTween.Hash("y", tarrot, "time", time, "easetype", InEase) );

	}

	public void Send(){
		iTween.RotateTo (gameObject, iTween.Hash("y", orgaxisy, "time", .5f, "easetype", OutEase) );
	}



}
