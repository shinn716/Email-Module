using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	public GameObject KeyUI;
	public Camera cam;
	public SendEvent _send;
	public bool RaycastMode = true;
	public bool MouseMode = false;
	Vector3 pos;

	[SerializeField]
	float step=.1f;
	bool workOnce1 = false;
	bool workOnce2 = false;
	public bool showKeyUI = false;


	void Start(){
		pos = transform.position;
	}

	void Update () {

		if(Input.GetKeyDown("`")){
			showKeyUI = !showKeyUI;
		}

		if (showKeyUI && !workOnce1) {
			workOnce1 = true;
			workOnce2 = false;
			KeyUI.SetActive (true);
		} else if (!showKeyUI && !workOnce2) {
			workOnce1 = false;
			workOnce2 = true;
			_send.KeyUIEnd ();
		}

		if(RaycastMode){
			
			if(Input.GetKey(KeyCode.W) ){
				pos.y += step;
				transform.position = pos;
			}
			if(Input.GetKey(KeyCode.S) ){
				pos.y -= step;
				transform.position = pos;
			}
			if(Input.GetKey(KeyCode.A) ){
				pos.x -= step;
				transform.position = pos;
			}
			if(Input.GetKey(KeyCode.D) ){
				pos.x += step;
				transform.position = pos;
			}

		}

		if(MouseMode){

			transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
		}


	}
}
