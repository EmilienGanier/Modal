using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HundMove : MonoBehaviour
{
    public Rigidbody2D body;
    public bool goRight;
    public float speed;
    private Vector2 vSpeed;
    public Vector3 respawn_point;

    private death Death;
    public LaunchHund launchHund;

    public bool triggered = false;
    private bool alreadyTriggered = false;
    private bool mustGoBack = false;
    private bool isWaiting = false;
    private bool wasAlreadyWaiting = false;

    public Animator animator;
   

    void Awake()
    {
        Death = GameObject.FindGameObjectWithTag("Bolchie").GetComponent<death>();
    }
    // Start is called before the first frame update
    void Start()
    { 
        if (!goRight){
             speed = -speed;
        }
        vSpeed = new Vector2(0, 0);
        respawn_point = body.position;
    }

    // Update is called once per frame
    void Update()
    {
        ListenBolchie();
        ListenTrigger();
        ListenStop();
        body.velocity = vSpeed;  
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal")
        {
            mustGoBack = true;
        }
        if (other.tag == "WaitingPlace") isWaiting = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "WaitingPlace")
        {
            isWaiting = false;
            wasAlreadyWaiting = false;
        }
    }

    void ListenTrigger()
    {
        if (launchHund.triggerHund)
        {
            triggered = true;
            if (triggered && !alreadyTriggered)
            {
                Attack();
                alreadyTriggered = true;
                triggered = false;
            }
        }
    }

    void ListenBolchie()
    {
        if (Death.dead)
        {
            body.position = respawn_point;
            vSpeed = new Vector2(0f, 0f);

            animator.SetBool("Trigger", false);
            animator.SetBool("Wait", true);

            triggered = false;
            alreadyTriggered = false;
            isWaiting = true;
            wasAlreadyWaiting = true;
            mustGoBack = false;
        }
        
    }


    void Attack()
    {
        animator.SetBool("Wait", false);
        animator.SetBool("Trigger", true);
        vSpeed.x = speed;
    }

    void ListenStop()
    {
        if (isWaiting && !wasAlreadyWaiting) {
            animator.SetBool("Wait", true);
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            vSpeed.x = 0;
            wasAlreadyWaiting = true;
            alreadyTriggered = false;
        }
 
        else if (mustGoBack)
        {
            animator.SetBool("Trigger", false);
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            vSpeed.x = -0.7f*speed;
            mustGoBack = false;
        }
    }
}
