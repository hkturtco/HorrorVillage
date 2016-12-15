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
		if(trigger && CardBox.boxopen){
			if(Input.GetKeyDown(KeyCode.Q)){
				door.key = true;
				Destroy(this.gameObject);
			}
		}
	}

		void OnGUI(){
		if(trigger && CardBox.boxopen){
				GUI.Box(new Rect(0,200,200,25), "Press Q to pick the Key.");
		}
	}

}
