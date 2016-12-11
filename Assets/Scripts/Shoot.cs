using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public GameObject bullet;
	public float delayTime = 8f;
	
	private float counter = 0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if(Input.GetKey(KeyCode.Mouse0) && counter > delayTime){
				Instantiate(bullet, transform.position, transform.rotation);
				counter=0;
		}
		counter += Time.deltaTime;
	}
}
