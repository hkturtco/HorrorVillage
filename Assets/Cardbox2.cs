using UnityEngine;
using System.Collections;

public class Cardbox2 : MonoBehaviour {
    public static bool boxopen;
    public bool boxclose;
    private bool boxtrigger;

    void OnTriggerEnter(Collider other)
    {
        boxtrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        boxtrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        var heading = Camera.main.transform.position - this.transform.position;
        var distance = heading + Camera.main.transform.forward;
        var torchcolor = GameObject.Find("Spotlight").GetComponent<Light>().color;
        if (distance.magnitude < 3 && torchcolor == Color.red && Ax.getAx)
        {
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                r.enabled = false;

        }
        else
        {
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                r.enabled = true;
        }
        if (boxtrigger)
        {
            if (boxclose)
            {
                if (Ax.getAx)
                {
                    if (Input.GetKeyDown(KeyCode.O))
                    {
                        boxopen = true;
                        boxclose = false;
                        Destroy(this.gameObject);
                        Ax.getAx = false;
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.O))
                {
                    boxclose = true;
                    boxopen = false;
                }
            }

            if (boxtrigger)
            {
                if (boxopen)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }

    // Show message on screen
    void OnGUI()
    {
        if (boxtrigger)
        {
            if (!boxopen)
            {
                if (Ax.getAx)
                {
                    GUI.skin.label.alignment = TextAnchor.UpperLeft;
                    GUI.Box(new Rect(0, 150, 300, 20), "Press O to crack the box.");
                    GUI.Box(new Rect(0, 200, 400, 20), "Note that the ax will be destroyed after use.");
                }
                else
                {
                    GUI.Box(new Rect(0, 150, 400, 30), "You need something to crack the box.");
                }
            }
        }
    }
}
