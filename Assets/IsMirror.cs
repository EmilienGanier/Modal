using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMirror : MonoBehaviour
{
    private BolchiMove bolchieMove;

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
        if (collision.CompareTag("Stone") || collision.CompareTag("Bolchie")) bolchieMove.inMirror = true;

    }
}
