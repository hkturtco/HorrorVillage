using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class can_trans : MonoBehaviour {

	public Image im;
	
	// Use this for initialization
	void Start () {
         im.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		 if ( Input.GetKeyDown(KeyCode.R)) {
 
 Application.LoadLevel(Application.loadedLevel);
 
   }
	
	}
}
