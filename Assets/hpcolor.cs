using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hpcolor : MonoBehaviour {
	public Image im;
	// Use this for initialization
	void Start () {
		im.GetComponent<CanvasRenderer> ().SetColor (Color.green);
	}
	
	// Update is called once per frame
	void Update () {
		if (monster.hittime == 5) {
			im.GetComponent<CanvasRenderer> ().SetColor (Color.yellow);
		}if (monster.hittime == 4) {
			im.GetComponent<CanvasRenderer> ().SetColor (Color.yellow);
		}if (monster.hittime == 3) {
			im.GetComponent<CanvasRenderer> ().SetColor (Color.yellow);
		}if (monster.hittime == 2) {
			im.GetComponent<CanvasRenderer> ().SetColor (Color.yellow);
		}if (monster.hittime == 1) {
			im.GetComponent<CanvasRenderer> ().SetColor (Color.yellow);
		}if (monster.hittime == 0) {
			im.GetComponent<CanvasRenderer> ().SetColor (Color.yellow);
		}
	}
}
