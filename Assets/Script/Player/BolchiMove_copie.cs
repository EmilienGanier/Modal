using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BolchiMove_copie : MonoBehaviour
{
    public static BolchiMove_copie instance;
    //public OnNewInputHandler OnNewInput;
    public Rigidbody2D body;
    public float moveSpeed;
    public float jumpForce;
    public float climbSpeed;

    private Vector2 direction;
    public bool grounded;
    public bool isClimbing;

    public bool mirror;
    public bool inMirror;
    private Vector3 velocity = Vector3.zero;

    private float verticalmovement;


    // PRIMARY
    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
        direction = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        verticalmovement = Input.GetAxis("Vertical") * climbSpeed * Time.deltaTime;

        Move(verticalmovement);
        Jump();
        //grounded = false;

    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Ground") grounded = true;
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.collider.tag == "Ground") grounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mirror") inMirror = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Mirror") inMirror = false;
    }


    // OTHER
    private void Move(float _verticalmovement) {
        if (!isClimbing){
            if (Input.GetButtonDown("EnterMirror") && inMirror)
            {
                mirror = !mirror;
            }
            int moving = 0;
            if (Input.GetButton("MoveRight") && !mirror) {
                direction.x = Math.Max(direction.x, 1);
                moving++;
            }
            if (Input.GetButton("MoveLeft") && !mirror) {
                direction.x = Math.Min(direction.x, -1);
                moving++;
            }
            if (Input.GetButton("MoveRight") && mirror) {
                direction.x = Math.Min(direction.x, -1);
                moving++;
            }
            if (Input.GetButton("MoveLeft") &&mirror) {
                direction.x = Math.Max(direction.x, 1);
                moving++;
            }
            Vector3 movement = direction * moveSpeed;
            if (moving == 1) body.velocity = new Vector3(movement.x, body.velocity.y, 0.0f);
        }
        else{
            Vector3 targetVelocity = new Vector2(body.velocity.x, _verticalmovement);
            body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, .05f);
        }
    }


    private void Jump() {
        if (Input.GetButton("Jump") && grounded) body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}

