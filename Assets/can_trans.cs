using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class can_trans : MonoBehaviour {

	public Image im;
	
	// Use this for initialization
	void Start () {
         im.GetComponent<CanvasRenderer>().SetAlpha(0.7f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
