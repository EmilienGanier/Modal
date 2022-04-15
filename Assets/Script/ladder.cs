using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{

    public bool isInRange;
    private BolchiMove bolchiMove;
    float normms;
    // Start is called before the first frame update
    void Awake()
    {
        bolchiMove = GameObject.FindGameObjectWithTag("Bolchie").GetComponent<BolchiMove>();
        normms = bolchiMove.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange){
            bolchiMove.isClimbing = true;
            Debug.Log("bloup");
        }
        else bolchiMove.isClimbing = false;
        
        
    }


    private void OnTriggerEnter2D (Collider2D collision){
        if (collision.CompareTag("Ladder")){
            isInRange = true;
            bolchiMove.moveSpeed = normms/5.0f;
        }
    }

    private void OnTriggerExit2D (Collider2D collision){
        if (collision.CompareTag("Ladder")){
            isInRange = false;
            bolchiMove.moveSpeed = normms;
        }
    }
}
