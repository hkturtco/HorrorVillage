using UnityEngine;
using System.Collections;

public class Ax : MonoBehaviour {
	private bool trigger;
    public static bool getAx;

    void Start()
    {
        gameObject.SetActive(false);
    }

	void OnTriggerEnter(Collider other){
		trigger = true;
	}

	void OnTriggerExit(Collider other){
		trigger = false;
	}

	void Update() {
        if (trigger) {
			if(Input.GetKeyDown(KeyCode.Q)){
				getAx = true;
				Destroy(this.gameObject);
			}
		}
	}

	void OnGUI() {
		if (trigger) {
			GUI.Box(new Rect(0,200,300,25), "Press Q to pick the Axe.");
		}
	}

}
