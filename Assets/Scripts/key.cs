using UnityEngine;
using System.Collections;

public class key : MonoBehaviour {
    public static bool getKey;
    public static int keynum;
    private bool trigger;
    private AudioSource a_getKey;
    private bool boxopen;

    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        a_getKey = audios[0];
        getKey = false;
        boxopen = false;
        keynum = (int)Random.Range(0, 3);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2 * keynum);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            trigger = true;
            
        }
	}

	void OnTriggerExit(Collider other){
		trigger = false;
	}

	void Update(){
        switch (keynum)
        {
            case 0:
                boxopen = Box1.boxopen;
                break;
            case 1:
                boxopen =Box2.boxopen;
                break;
            case 2:
                boxopen = Box3.boxopen;
                break;
        }
        if (trigger && boxopen && Input.GetKeyDown(KeyCode.P))
        {
            a_getKey.Play();
            getKey = true;
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                r.enabled = false;
        }
    }

	void OnGUI(){
        if(trigger && boxopen)
        {
		    GUI.Box(new Rect(0,200,300,25), "Press P to pick the Key.");
        }
	}

}
