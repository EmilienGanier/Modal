using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchHund : MonoBehaviour
{
    public bool triggerHund = false;
    private bool alreadyTriggered = false;
    private HundMove hundMove;

    void Awake()
    {
        hundMove = GameObject.FindGameObjectWithTag("Hund").GetComponent<HundMove>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ListenHund();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bolchie" && !alreadyTriggered)
        {
            triggerHund = true;
            alreadyTriggered = true;
            Debug.Log("OK");
        }

        /*if (other.tag == "Bolchie" && alreadyTriggered)
        {
            triggerHund = false;
        }*/
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Bolchie")
        {
            alreadyTriggered = false;
            Debug.Log("On est sorti");
        }
    }
    void ListenHund()
    {
        if (hundMove.triggered)
        {
            triggerHund = false;
        }
    }
}
