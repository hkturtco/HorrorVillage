using UnityEngine;
using System.Collections;

public class audio_gethit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		AudioSource audio = gameObject.GetComponent<AudioSource>();
		if (audio.isPlaying == false) gameObject.SetActive(false);
	}
}
