using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {
	public GameObject Pause_Canvas;
	bool paused;
	// Use this for initialization
	void Start () {
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.BackQuote)){
			Time.timeScale = 1-Time.timeScale;
			if (!paused){
				Pause_Canvas.gameObject.SetActive (true);
				paused = true;
			}
			else{
				Pause_Canvas.gameObject.SetActive (false);
				paused = false;
			}
		}
	}
}
