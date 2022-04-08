using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator animator;
    private bool grounded;
    public Rigidbody2D body;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        grounded = false;
        
        // Hooks.
        //transform.parent.GetComponent<MarkThrower>().OnThrow += LaunchThrow;
    }

    void Update()
    {
        JumpAnim();
        RunAnim();
        AttackAnim();

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground") grounded = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground") grounded = false;
    }

    void JumpAnim() //ouii ça marche !
    {
        animator.SetBool("Ground" , grounded);
    }
    void RunAnim()
    {
        if (body.velocity.x < 0) animator.SetBool("Right", false);
        else if (body.velocity.x > 0) animator.SetBool("Right", true);
        float speed = Mathf.Abs(body.velocity.x);
        animator.SetFloat("Speed" , speed) ;
        
    }

    void AttackAnim()
    {
        animator.SetBool("Attack" , bolchieHit.instance.attacking);
    }
    /*void DeadAnim()
    {
        animator.SetBool("Dead" = )
    }*/

    // HOOKS
    //private void LaunchThrow()
    //{
     //   animator.Play("1-Throw");
   // }

}
