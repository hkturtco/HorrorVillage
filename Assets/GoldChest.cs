using UnityEngine;
using System.Collections;

public class GoldChest : MonoBehaviour
{
    public bool boxtrigger;
    void OnTriggerEnter(Collider other)
    {
        boxtrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        boxtrigger = false;
    }

    // Use this for initialization
    void Start () {
        this.transform.GetChild(1).gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	    if (boxtrigger && Input.GetKeyDown(KeyCode.O))
        {
            GetComponent<Renderer>().enabled = false;
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
	}

    void OnGUI()
    {
        if (boxtrigger)
        {
            GUI.Box(new Rect(0, 150, 400, 30), "Press O to open the box.");
        }
    }
}
