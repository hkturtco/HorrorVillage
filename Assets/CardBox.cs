﻿using UnityEngine;
using System.Collections;

public class CardBox : MonoBehaviour{
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
        var heading = Camera.main.transform.position - this.transform.position;
        var distance = heading + Camera.main.transform.forward;
        var torchcolor = GameObject.Find("Spotlight").GetComponent<Light>().color;
        if (distance.magnitude < 3 && torchcolor == Color.green && Ax.getAx)
        {
            GetComponent<Renderer>().enabled = false;

        } else
        {
            GetComponent<Renderer>().enabled = true;
        }
        if (boxtrigger) {
			if (boxclose) {
				if (Ax.getAx) {
					if (Input.GetKeyDown (KeyCode.O)) {
						boxopen = true;
						boxclose = false;
						Destroy (this.gameObject);
                        Ax.getAx = false;
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
			if (!boxopen) {
				if (Ax.getAx) {
					GUI.Box (new Rect (0, 150, 300, 30), "Press O to crack the box");
				} else {
					GUI.Box (new Rect (0, 150, 400, 30), "You need something to crack the box.");
				}
			}
        }
    }
}