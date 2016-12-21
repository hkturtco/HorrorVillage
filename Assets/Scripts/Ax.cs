using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Ax : MonoBehaviour {
	private bool trigger;
    public static bool getAx;
    private AudioSource a_getAx;

    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        a_getAx = audios[0];
        gameObject.SetActive(false);
        getAx = true;
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            trigger = true;
        }
	}

	void OnTriggerExit(Collider other){
		trigger = false;
	}

	void Update() {
        if (trigger && !getAx && Input.GetKeyDown(KeyCode.P))
        {
            a_getAx.Play();
            getAx = true;
            GetComponent<Renderer>().enabled = false;
        }
    }

	void OnGUI() {
		if (trigger) {
			GUI.Box(new Rect(0,200,300,25), "Press P to pick the Ax.");
		}
	}
}
