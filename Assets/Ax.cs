using UnityEngine;
using System.Collections;

public class Ax : MonoBehaviour {
	public bool trigger;

	void OnTriggerEnter(Collider other){
		trigger = true;
	}

	void OnTriggerExit(Collider other){
		trigger = false;
	}

	void Update(){
		if(trigger){
			if(Input.GetKeyDown(KeyCode.Q)){
				CardBox.stick = true;
				Destroy(this.gameObject);
			}
		}
	}

	void OnGUI(){
		if(trigger){
			GUI.Box(new Rect(0,200,200,25), "Press Q to pick the Axe.");
		}
	}

}
