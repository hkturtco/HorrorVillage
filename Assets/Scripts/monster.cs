using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class monster : MonoBehaviour {

	public Transform target;
	public Transform myTransform; 
	public GameObject Die_Canvas;
	public GameObject Win_Canvas;
	public GameObject audio_roar;
	public GameObject audio_die;
	public GameObject audio_attack;
	bool playedroar = false;
	bool started = false;
	bool dead = false;

	void Start () {
	}
	
	void Update () {
		var animator = gameObject.GetComponent<Animator>();
		var animatorstateinfo = animator.GetCurrentAnimatorStateInfo(0);
		if ((target.transform.position.z < -30) && (!started)) {
			if (!playedroar) audio_roar.gameObject.SetActive(true);
			animator.SetTrigger("SeePlayer");
			playedroar = true;
			started = true;
		}
		if ((started) && (!dead)){
			Vector3 targetPostition = new Vector3( target.position.x, this.transform.position.y, target.position.z ) ;
 			this.transform.LookAt( targetPostition ) ;
		}
		if (animatorstateinfo.IsName("chase") || animatorstateinfo.IsName("attack")){
			transform.Translate(Vector3.forward*6*Time.deltaTime);
		}
		else{
			transform.Translate(Vector3.forward*0*Time.deltaTime);
		}
		if (animatorstateinfo.IsName("die")){
			dead = true;
			audio_die.gameObject.SetActive(true);
		}
		if (dead){
			StartCoroutine(Win());
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "FPSController"){
			var animator = gameObject.GetComponent<Animator>();
			animator.SetTrigger("InMeleeRange");
			audio_attack.gameObject.SetActive(true);	
			StartCoroutine(Die());			
		}
    }

    IEnumerator Die() {
        yield return new WaitForSeconds(2);
		Die_Canvas.gameObject.SetActive (true);
		Time.timeScale = 0;
    }

    IEnumerator Win() {
        yield return new WaitForSeconds(2);
		Win_Canvas.gameObject.SetActive (true);
		Time.timeScale = 0;
    }
}
