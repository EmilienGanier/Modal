using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enigme2 : MonoBehaviour
{
    public int letter;
    public bool inRange = false;
    private BolchiMove bolchiMove;

    // Start is called before the first frame update
    void Awake()
    {
        bolchiMove = GameObject.FindGameObjectWithTag("Bolchie").GetComponent<BolchiMove>();
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange){
            if (bolchiMove.transform.position.x < -4.0f){
                letter = (int)Math.Truncate(bolchiMove.transform.position.x + 17.0f);
            }
            if (bolchiMove.transform.position.x > -1.0f){
                letter = (int)Math.Truncate(bolchiMove.transform.position.x + 14.0f);
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D collision){
        Debug.Log("OTEnter");
        if (collision.CompareTag("Bolchie")){
            inRange = true;
        }
    }

    private void OnTriggerExit2D (Collider2D collision){
        Debug.Log("OTExit");
        if (collision.CompareTag("Bolchie")){
            inRange = false;
        }
    }
}
