using UnityEngine;
using System.Collections;

public class Flickeringlight : MonoBehaviour {
	Light lightsource;

	// Use this for initialization
	void Start () {
		lightsource = GetComponent<Light>();
		StartCoroutine(Flashing());
	}

	IEnumerator Flashing()
	{
		while(true){
			yield return new WaitForSeconds(0.1f);
			lightsource.enabled =! lightsource.enabled;
			yield return new WaitForSeconds(0.1f);
			lightsource.enabled =! lightsource.enabled;
			yield return new WaitForSeconds(0.2f);
			lightsource.enabled =! lightsource.enabled;
			yield return new WaitForSeconds(0.5f);
			lightsource.enabled =! lightsource.enabled;
			yield return new WaitForSeconds(0.1f);
			lightsource.enabled =! lightsource.enabled;
			yield return new WaitForSeconds(0.1f);
			lightsource.enabled =! lightsource.enabled;
			yield return new WaitForSeconds(0.1f);
			lightsource.enabled =! lightsource.enabled;
		}
	}
}
