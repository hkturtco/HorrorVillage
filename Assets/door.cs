using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	public static bool key;
	public bool open;
	public bool close;
	public bool trigger;

	void OnTriggerEnter(Collider other){
		trigger = true;
	}
	void OnTriggerExit (Collider other){
		trigger = false;
	}

	void Update()
	{		
		if(trigger){
			if(close){
				if(key){
					if(Input.GetKeyDown(KeyCode.Q)){
						open = true;
						close = false;
					}
				}
			} else {
					if(Input.GetKeyDown(KeyCode.Q)){
						close = true;
						open = false;
					}
			}
		}

		if(trigger){
			if(open){
				var ro = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 70.0f, 0.0f), Time.deltaTime*200);
				transform.rotation = ro;
			} else {
				var ro = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime*200);
				transform.rotation = ro;
			}
		}
	}
	void OnGUI(){
		if(trigger){
			if(open){
				GUI.Box(new Rect(0,200,300,25), "Press Q to close the door");
			} else {
				if(key){
					GUI.Box(new Rect(0,200,300,25), "Press Q to open the door");
					} else {
					GUI.Box(new Rect(0,200,300,25), "You are required to find the key");
					}
				
			}
		}
	}
}
