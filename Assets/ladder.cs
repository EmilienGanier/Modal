using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{

    private bool isInRange;
    private BolchiMove bolchiMove;
    // Start is called before the first frame update
    void Awake()
    {
        bolchiMove = GameObject.FindGameObjectWithTag("Bolchie").GetComponent<BolchiMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange){
            bolchiMove.isClimbing = true;
        }
        else bolchiMove.isClimbing = false;
        
    }


    private void OnTriggerEnter2D (Collider2D collision){
        if (collision.CompareTag("Bolchie")){
            isInRange = true;
        }
    }

    private void OnTriggerExit2D (Collider2D collision){
        if (collision.CompareTag("Bolchie")){
            isInRange = false;
        }
    }
}
