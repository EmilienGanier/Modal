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
            if (bolchiMove.transform.position.x < -3.95f){
                letter = (int)Math.Truncate(bolchiMove.transform.position.x + 16.95f);
            }
            if (bolchiMove.transform.position.x > -0.95f){
                letter = (int)Math.Truncate(bolchiMove.transform.position.x + 19.95f);
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
