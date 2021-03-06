﻿using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	public bool open;
	public bool close;
    private AudioSource a_doorlocked;
    private AudioSource a_doorunlock;
    private AudioSource a_dooropen;
	private bool trigger;

	void OnTriggerEnter(Collider other){
        if (other.gameObject.name == "FPSController")
        {
            trigger = true;
            if (this.transform.FindChild("Ax"))
            {
                this.transform.FindChild("Ax").gameObject.SetActive(true);
            }
            if (close && !key.getKey && a_doorlocked)
            {
                a_doorlocked.Play();
            }
        }
	}
	void OnTriggerExit (Collider other){
		trigger = false;
	}

    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        a_doorlocked = audios[0];
        a_doorunlock = audios[1];
        a_dooropen = audios[2];
        close = true;
        open = false;
    }

    void Update()
    {
        if (trigger && close && key.getKey && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("open door");
            a_doorunlock.Play();
            a_dooropen.Play();
            open = true;
            close = false;
        }
        if (trigger && open && Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("close door");
            StartCoroutine(playDoorCloseAudio());
            open = false;
            close = true;
        }
        if (open)
        {
            var ro = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 70.0f, 0.0f), Time.deltaTime * 20);
            transform.rotation = ro;
        } else if (close)
        {
            var ro = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 20);
            transform.rotation = ro;
        }
    }

	void OnGUI(){
		if (trigger) {
			if (open) {
				GUI.Box(new Rect(0,200,300,30), "Press P to close the door.");
			} else {
				if (key.getKey)
                {
					GUI.Box(new Rect(0,200,300,30), "Press E to open the door.");
				} else
                {
                    GUI.Box(new Rect(0,200,300,30), "You need a key to open the door.");
                    GUI.Box(new Rect(0,230,450,30), "You have just triggered the machine that hiding the Ax in the room.");
				}
				
			}
		}
	}

    IEnumerator playDoorCloseAudio()
    {
        a_dooropen.Play();
        yield return new WaitForSeconds(3.8f);
        a_doorunlock.Play();
    }
}
