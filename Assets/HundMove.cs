using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HundMove : MonoBehaviour
{
    public Rigidbody2D body;
    public bool goRight;
    public float speed;
    private Vector2 vSpeed;

    public bool triggered;
    private bool mustGoBack;
    private bool isWaiting;
    
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        isWaiting = false;
        mustGoBack = false;
        if (!goRight){
             speed = -speed;
             Vector3 theScale = transform.localScale;
             theScale.x *= -1;
             transform.localScale = theScale;
        }
        vSpeed = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
       // ListenTrigger();
       // ListenStop();
        test();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "WaitPlace") isWaiting = true;
        if (other.collider.tag == "Goal") mustGoBack = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
       // if (other.collider.tag == "WaitPlace") isWaiting = false;
       // if (other.collider.tag == "Goal") mustGoBack = false;
    }

    void test()
    {

    }

    /*void ListenTrigger()
    {
        //triggered = ????
        if (Input.GetButton("return")) triggered = true;
        if (triggered)
        {
            Attack();
            triggered = false;
        }
    }

   
    void Attack()
    {
       vSpeed.x = speed;
       body.velocity = vSpeed;
       animator.SetTrigger("Trigger");
    }

    void ListenStop()
    {
        if (isWaiting) {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            vSpeed.x = 0;
            body.velocity = vSpeed;
            animator.SetTrigger("MustWait");
            isWaiting = false;
        }
        else if (mustGoBack)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            vSpeed.x = -speed;
            body.velocity = vSpeed;
            animator.SetTrigger("GoBack");
            mustGoBack = false;
        }
    }*/
}
