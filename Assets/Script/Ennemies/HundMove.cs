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
    //public hasRespawn = false;

    public bool triggered;
    private bool alreadyTriggered = false;
    private bool mustGoBack;
    private bool isWaiting;
    private bool wasAlreadyWaiting;
    public Animator animator;
   

    void Awake()
    {
        //launchHund = GameObject.FindGameObjectWithTag("Goal").GetComponent<LaunchHund>();
        Death = GameObject.FindGameObjectWithTag("Bolchie").GetComponent<death>();
        respawn_point = body.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        isWaiting = false;
        wasAlreadyWaiting = false;
        mustGoBack = false;
        /*Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;*/
        if (!goRight){
             speed = -speed;
        }
        vSpeed = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //vSpeed.y = 0;
        ListenBolchie();
        ListenTrigger();
        ListenStop();
        body.velocity = vSpeed;  
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.collider.tag == "WaitingPlace") isWaiting = true;
        //if (other.collider.tag == "Goal") mustGoBack = true;
        //if (other==goal) mustGoBack = true;
    }
    /*void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "WaitingPlace")
        {
            isWaiting = false;
            wasAlreadyWaiting = false;
        }
       // if (other.collider.tag == "Goal") mustGoBack = false;
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal")
        {
            mustGoBack = true;
            //Debug.Log("fait-il demi-tour ??");
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
            //if (Input.GetButton("EnterMirror")) triggered = true;
            if (triggered && !alreadyTriggered)
            {
                Attack();
                alreadyTriggered = true;
                triggered = false;
                //Debug.Log("triggered =" + triggered);
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
            Debug.Log("yess");
            //hasRespawn = true;
        }
        
    }


    void Attack()
    {
        //animator.SetTrigger("Triggered");
        animator.SetBool("Wait", false);
        animator.SetBool("Trigger", true);
        //Debug.Log("Trigger");
        vSpeed.x = speed;
    }

    void ListenStop()
    {
        if (isWaiting && !wasAlreadyWaiting) {
            //animator.SetTrigger("MustWait");
            animator.SetBool("Wait", true);
            //Debug.Log("Wait");
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            vSpeed.x = 0;
            wasAlreadyWaiting = true;
            alreadyTriggered = false;
        }
 
        else if (mustGoBack)
        {
            //animator.SetTrigger("MustGoback");
            animator.SetBool("Trigger", false);
            //Debug.Log("GoBack");
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            vSpeed.x = -0.7f*speed;
            mustGoBack = false;
            
        }
    }
}
