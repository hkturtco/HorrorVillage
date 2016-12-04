using UnityEngine;
using System.Collections;

public class Ax : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Found an AX!");
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
