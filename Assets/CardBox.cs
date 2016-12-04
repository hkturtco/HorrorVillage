using UnityEngine;
using System.Collections;

public class CardBox : MonoBehaviour
{
    public bool trigger = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2))
        {
            Debug.Log("Hit something!");
            trigger = true;
        }
    }

    // Show message on screen
    void OnGUI()
    {
        if (trigger)
        {
            GUI.Box(new Rect(0, 200, 200, 25), "Check out the bed.");
        }
    }
}