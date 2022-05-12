using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchHund : MonoBehaviour
{
    public bool triggerHund = false;
    private bool alreadyTriggered = false;
    public HundMove hundMove;

    void Awake()
    {
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
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Bolchie")
        {
            alreadyTriggered = false;
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
