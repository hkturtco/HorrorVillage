using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hp : MonoBehaviour {
	public static Text txt;
	// Use this for initialization
	void Start () {
		txt = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		txt = GetComponent<Text> ();
		if (monster.hittime == 10) {
			txt.text = "100%";
		}if (monster.hittime == 9) {
			txt.text = "90%";
		}if (monster.hittime == 8) {
			txt.text = "80%";
		}if (monster.hittime == 7) {
			txt.text = "70%";
		}if (monster.hittime == 6) {
			txt.text = "60%";
		}if (monster.hittime == 5) {
			txt.text = "50%";
		}if (monster.hittime == 4) {
			txt.text = "40%";
		}if (monster.hittime == 3) {
			txt.text = "30%";
		}if (monster.hittime == 2) {
			txt.text = "20%";
		}if (monster.hittime == 1) {
			txt.text = "10%";
		}if (monster.hittime == 0) {
			txt.text = "0%";
		}
	
	}
}
