using UnityEngine;
using System.Collections;

public class key : MonoBehaviour {
	public bool trigger;

	void OnTriggerEnter(Collider other){
		trigger = true;
	}

	void OnTriggerExit(Collider other){
		trigger = false;
	}

	void Update(){
		if(trigger){
			if(Input.GetKeyDown(KeyCode.E)){
				door.key = true;
				Destroy(this.gameObject);
			}
		}
	}

}
