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
    private bool wasAlreadyWaiting;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        isWaiting = false;
        wasAlreadyWaiting = false;
        mustGoBack = false;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        if (!goRight){
             speed = -speed;
             Vector3 theScale2 = transform.localScale;
             theScale2.x *= -1;
             transform.localScale = theScale2;
        }
        vSpeed = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //vSpeed.y = 0;
        ListenTrigger();
        ListenStop();
        body.velocity = vSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "WaitingPlace") isWaiting = true;
        if (other.collider.tag == "Goal") mustGoBack = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "WaitingPlace")
        {
            isWaiting = false;
            wasAlreadyWaiting = false;
        }
       // if (other.collider.tag == "Goal") mustGoBack = false;
    }

    void ListenTrigger()
    {
        //triggered = ????
        if (Input.GetButton("EnterMirror")) triggered = true;
        if (triggered)
        {
            Attack();
            triggered = false;
        }
    }

   
    void Attack()
    {
       vSpeed.x = speed;
        //animator.SetTrigger("Trigger");
    }

    void ListenStop()
    {
        if (isWaiting && !wasAlreadyWaiting) {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            vSpeed.x = 0;
            //animator.SetTrigger("MustWait");
            wasAlreadyWaiting = true;
            
        }
        else if (mustGoBack)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            vSpeed.x = -speed;
            //animator.SetTrigger("GoBack");
            mustGoBack = false;
        }
    }
}
