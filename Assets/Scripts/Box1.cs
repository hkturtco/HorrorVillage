using UnityEngine;
using System.Collections;

public class Box1 : MonoBehaviour {
    public static bool boxopen;
    public GameObject GameOver_Canvas;
    private bool boxtrigger;
    private AudioSource a_crackBox;

    void Start()
    {
        AudioSource[] audios = this.gameObject.GetComponents<AudioSource>();
        a_crackBox = audios[0];
        boxopen = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            boxtrigger = true;
        }
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
        if (boxopen || (distance.magnitude < 3 && torchcolor == Color.red && Ax.getAx))
        {
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                r.enabled = false;

        }
        else
        {
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                r.enabled = true;
        }
        if (boxtrigger && !boxopen && Ax.getAx && Input.GetKeyDown(KeyCode.E))
        {
            if (key.keynum != 0)
                StartCoroutine(displayGameOverCanvas());
            a_crackBox.Play();
            boxopen = true;
            Ax.getAx = false;
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
                    GUI.Box(new Rect(0, 150, 300, 30), "Press E to crack the box.");
                    GUI.Box(new Rect(0, 200, 400, 30), "Note that the ax will be destroyed after use.");
                }
                else
                {
                    GUI.Box(new Rect(0, 150, 400, 30), "You need something to crack the box.");
                }
            }
        }
    }

    IEnumerator displayGameOverCanvas()
    {
        yield return new WaitForSeconds(2);
        GameOver_Canvas.SetActive(true);
    }
}
