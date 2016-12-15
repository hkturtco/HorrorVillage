using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class monster : MonoBehaviour {

	public Transform target;
	public Transform myTransform; 
	public GameObject Canvas;
	bool chasing = false;
	public static int hittime = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target.transform.position.z < -30) {
			chasing = true;
			var animator = gameObject.GetComponent<Animator>();
			animator.SetTrigger("SeePlayer");
		}
		if (chasing){
			transform.LookAt(target);
			transform.Translate(Vector3.forward*6*Time.deltaTime);
		}
		else{
			transform.Translate(Vector3.forward*0*Time.deltaTime);
		}

	}

	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.name == "FPSController"){

			chasing = false;
			var animator = gameObject.GetComponent<Animator>();
			animator.SetTrigger("InMeleeRange");

			StartCoroutine(Wait());			
		}
        
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(5);
		hittime = hittime - 1;
		if (hittime == 0) {
			Canvas.gameObject.SetActive (true);
		}
    }
}
