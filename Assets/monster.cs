using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class monster : MonoBehaviour {

	public Transform target;
	public Transform myTransform; 
	public GameObject Die_Canvas;
	public static int hittime = 10;
	bool playedroar = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		var animator = gameObject.GetComponent<Animator>();
		var roar = gameObject.GetComponent<AudioSource>();
		if (target.transform.position.z < -30) {
			if (!playedroar) roar.mute = false;
			playedroar = true;
			animator.SetTrigger("SeePlayer");
			transform.LookAt(target);
		}
		var animatorstateinfo = animator.GetCurrentAnimatorStateInfo(0);

		if (animatorstateinfo.IsName("chase") || animatorstateinfo.IsName("attack")){
			if (playedroar) roar.mute = true;
			transform.Translate(Vector3.forward*6*Time.deltaTime);
		}
		else{
			transform.Translate(Vector3.forward*0*Time.deltaTime);
		}
	}

	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.name == "FPSController"){

			var animator = gameObject.GetComponent<Animator>();
			animator.SetTrigger("InMeleeRange");

			StartCoroutine(Wait());			
		}
		if ((collision.gameObject.name == "Bullet") || (collision.gameObject.name == "Bullet(Clone)")){

			var animator = gameObject.GetComponent<Animator>();
			animator.SetTrigger("GetHit");
			Debug.Log("gethit");
			StartCoroutine(Wait());			
		}
        
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(5);
		hittime = hittime - 1;
		if (hittime == 0) {
			Die_Canvas.gameObject.SetActive (true);
		}
    }

}
