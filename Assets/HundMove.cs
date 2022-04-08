using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HundMove : MonoBehaviour
{
    public Rigidbody2D body;
    public bool goRight;
    public bool triggered;
    public float speed;
    private bool mustGoBack;
    private bool isWaiting;
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        isWaiting = true;
        mustGoBack = false;
        if (!goRight){
             speed = -speed;
             Vector3 theScale = transform.localScale;
             theScale.x *= -1;
             transform.localScale = theScale;
             }
        }

    // Update is called once per frame
    void Update()
    {
        ListenTrigger();
        ListenStop();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "WaitPlace") isWaiting = true;
        if (ither.collider.tag == "Goal") mustGoBack = true;
    }
    void OncollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "WaitPlace") isWaiting = false;
        if (ither.collider.tag == "Goal") mustGoBack = false;
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
