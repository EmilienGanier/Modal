using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HundMove : MonoBehaviour
{
    public Rigidbody2D body;
    public bool goRight;
    public bool triggered;
    public speed;
    private bool mustGoBack;
    private bool 
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        if (!goRight) speed = -speed;
    }

    // Update is called once per frame
    void Update()
    {
        ListenTrigger();
        ListenStop();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground") grounded = true;
    }


    void ListenTrigger()
    {
        if (triggered)
        {
            Attack();
            animator.SetTrigger("Trigger");
            triggered = false;
        }
    }

   
    void Attack()
    {
        body.velocity.x = speed;
    }

    void ListenStop()
    {

    }
}
