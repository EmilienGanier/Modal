using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMirror : MonoBehaviour
{
    string message = "Press ENTER";
    float displayTime = 1;
    bool displayMessage = false;
    private BolchiMove bolchieMove;
    private bool stoneMirror;
    private bool bolchieMirror;

    // Start is called before the first frame update
    void Awake()
    {
        bolchieMove = GameObject.FindGameObjectWithTag("Bolchie").GetComponent<BolchiMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (displayMessage && stoneMirror)
        {
            displayTime -= Time.deltaTime;

        }
        if (displayTime <= 0)

        {

            displayMessage = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bolchie"))
        {
            bolchieMove.inMirror = true;
            bolchieMirror = true;


            displayMessage = true;
        }

        if (collision.CompareTag("Stone"))
        {
            bolchieMove.inMirror = true;
            stoneMirror = true;
            if (displayTime <= 0)

            {

                displayMessage = false;
            }
            else
            {

                displayMessage = true;
            }
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stone") || !bolchieMirror)
        {
            bolchieMove.inMirror = false;
            stoneMirror = false;
            displayTime = 1;
        }
        if (collision.CompareTag("Bolchie") || !stoneMirror)
        {
            bolchieMove.inMirror = false;
            bolchieMirror = false;
            displayMessage = false;
        }

    }

    private void OnGUI()
    {
        if (displayMessage)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 5, 250f, 250f), message);
        }
    }
}
