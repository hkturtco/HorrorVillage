using UnityEngine;
using System.Collections;

public class CardBox : MonoBehaviour{
	public static bool stick;
	public static bool boxopen;
	public bool boxclose;
	public bool boxtrigger;

	void OnTriggerEnter(Collider other){
		boxtrigger = true;
	}
	void OnTriggerExit (Collider other){
		boxtrigger = false;
	}
		
    // Update is called once per frame
    void Update()
	{
		if (boxtrigger) {
			if (boxclose) {
				if (stick) {
					if (Input.GetKeyDown (KeyCode.O)) {
						boxopen = true;
						boxclose = false;
						Destroy (this.gameObject);
					}
				}
			} else {
				if (Input.GetKeyDown (KeyCode.O)) {
					boxclose = true;
					boxopen = false;
				}
			}

			if (boxtrigger) {
				if (boxopen) {
					Destroy (this.gameObject);
				}
			}
		}
	}

    // Show message on screen
    void OnGUI()
    {
        if (boxtrigger)
        {
			if (boxopen) {
			} else {
				if (stick) {
					GUI.Box (new Rect (0, 150, 300, 30), "Press O to crack the box");
				} else {
					GUI.Box (new Rect (0, 150, 300, 30), "Please find the sitck to crack the box");
				}
			}
        }
    }
}