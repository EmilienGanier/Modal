using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMirror : MonoBehaviour
{
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bolchie"))
        {
            bolchieMove.inMirror = true;
            bolchieMirror = true;
        }

        if (collision.CompareTag("Stone"))
        {
            bolchieMove.inMirror = true;
            stoneMirror = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stone") || !bolchieMirror)
        {
            bolchieMove.inMirror = false;
            stoneMirror = false;
        }
        if (collision.CompareTag("Bolchie") || !stoneMirror)
        {
            bolchieMove.inMirror = false;
            bolchieMirror = false;
        }

    }
}
