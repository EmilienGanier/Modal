using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchHund : MonoBehaviour
{
    public bool triggerHund = false;
    //private HundMove hundMove;

    void Awake()
    {
        //hundMove = GameObject.FindGameObjectWithTag("Hund").GetComponent<HundMove>();
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
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Bolchie") triggerHund = true;
    }
    void ListenHund()
    {
        /*if (HundMove.triggered)
        {
            triggerHund = false;
        }*/
    }
}
