using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendEvent : MonoBehaviour {


	public Material keyNormal;
	public Material keySelect;
	public Material keyPressed;

	public Renderer Send;
	bool once = false;

	public SendProcessed mail;
	public Text _input;

	[Header("KeyUI")]
	public GameObject All;
	public KeyboardIn[] keyUI;


	void Update () {


		RaycastHit hit;
		Ray ray = new Ray (transform.position, transform.forward);

		if( Physics.Raycast(ray, out hit)){

			if (hit.collider.tag == "send") {


				if (Input.GetMouseButton (0) || Input.GetKeyDown(KeyCode.L) ) {
					
					Send.material = keyPressed;

					if(!once){
						once = true;
						StartCoroutine (back(7));
						mail.sendEmail (_input.text, "");

						KeyUIEnd ();

					}



				} else {
					Send.material = keySelect;
				}
			} 


		}else {
			
			Send.material = keyNormal;

		}

	}

	public void KeyUIEnd(){
		for (int i = 0; i < keyUI.Length; i++)
			keyUI [i].Send ();
		StartCoroutine (KeyBack (.6f));
	}


	IEnumerator back(float delay){
		yield return new WaitForSeconds (delay);
		once = false;
	}

	IEnumerator KeyBack(float delay){
		yield return new WaitForSeconds (delay);	
		All.SetActive (false);
	}


}
