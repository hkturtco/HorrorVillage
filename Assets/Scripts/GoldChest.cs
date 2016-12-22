using UnityEngine;
using System.Collections;

public class GoldChest : MonoBehaviour
{
    public bool boxtrigger;
    private AudioSource a_openChest;

    void Start()
    {
        this.transform.GetChild(1).gameObject.SetActive(false);
        AudioSource[] audios = GetComponents<AudioSource>();
        a_openChest = audios[0];
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
            boxtrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        boxtrigger = false;
    }
	
	void Update () {
	    if (boxtrigger && Input.GetKeyDown(KeyCode.E))
        {
            a_openChest.Play();
            GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
	}

    void OnGUI()
    {
        if (boxtrigger)
        {
            GUI.Box(new Rect(0, 150, 400, 30), "Press E to open the box.");
        }
    }
}
