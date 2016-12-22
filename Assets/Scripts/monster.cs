using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class monster : MonoBehaviour {

	public Transform target;
	public Transform myTransform; 
	public GameObject Die_Canvas;
	public GameObject Win_Canvas;
	//public static int hittime = 10;
	bool playedroar = false;
	bool started = false;
	bool dead = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		var animator = gameObject.GetComponent<Animator>();
		var roar = gameObject.GetComponent<AudioSource>();
		var animatorstateinfo = animator.GetCurrentAnimatorStateInfo(0);
		if ((target.transform.position.z < -30) && (!started)) {
			if (!playedroar) roar.mute = false;
			animator.SetTrigger("SeePlayer");
			playedroar = true;
			started = true;
		}
		if ((started) && (!dead)){
			Vector3 targetPostition = new Vector3( target.position.x, this.transform.position.y, target.position.z ) ;
 			this.transform.LookAt( targetPostition ) ;
		}
		if (animatorstateinfo.IsName("chase") || animatorstateinfo.IsName("attack")){
			if (playedroar) roar.mute = true;
			transform.Translate(Vector3.forward*6*Time.deltaTime);
		}
		else{
			transform.Translate(Vector3.forward*0*Time.deltaTime);
		}
		if (animatorstateinfo.IsName("die")){
			dead = true;
		}
		if (dead){
			StartCoroutine(Win());
		}
		// Debug.Log(dead);
	}

	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.name == "FPSController"){

			var animator = gameObject.GetComponent<Animator>();
			animator.SetTrigger("InMeleeRange");

			StartCoroutine(Die());			
		}
        
    }

    IEnumerator Die() {
        yield return new WaitForSeconds(2);
		Die_Canvas.gameObject.SetActive (true);
		Time.timeScale = 0;
		 if ( Input.GetKeyDown(KeyCode.R)) {
 
 Application.LoadLevel(0);
 
   }
    }

    IEnumerator Win() {
        yield return new WaitForSeconds(2);
		Win_Canvas.gameObject.SetActive (true);
		Time.timeScale = 0;
    }
}
