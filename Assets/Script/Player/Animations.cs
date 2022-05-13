using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator animator;
    private bool grounded;
    public Rigidbody2D body;
    private bool goRight;
 
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        grounded = false;
        goRight = true;
    }

    void Update()
    {
        JumpAnim();
        RunAnim();
        AttackAnim();

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground" && other.GetContact(0).normal[1] > 0.001f) grounded = true;
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground") grounded = false;
    }

    void JumpAnim() 
    {
        animator.SetBool("Ground" , grounded);
    }
    void RunAnim()
    {
        if (goRight && body.velocity.x < -0.1f) ChangeDirection();
        else if (!goRight && body.velocity.x > 0.1f) ChangeDirection();
        float speed = Mathf.Abs(body.velocity.x);
        animator.SetFloat("Speed" , speed) ;
        
    }
    void ChangeDirection()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        goRight = !goRight;
    }

}
