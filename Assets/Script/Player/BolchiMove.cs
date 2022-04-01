using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BolchiMove : MonoBehaviour
{

    public static BolchiMove instance;
    //public OnNewInputHandler OnNewInput;
    public Rigidbody2D body;
    public float moveSpeed;
    public float jumpForce;

    private Vector2 direction;
    private bool grounded;

    private bool mirror;


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
        Move();
        Jump();
        //grounded = false;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Ground") grounded = true;
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.collider.tag == "Ground") grounded = false;
        if (other.collider.tag == "Mirror" && Input.GetButton("EnterMirror")) mirror = true;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Mirror" && Input.GetButton("EnterMirror") && !mirror) mirror = true;
        if (other.collider.tag == "Mirror" && Input.GetButton("EnterMirror") && mirror) mirror = false;
    }


    // OTHER
    private void Move() {
        int moving = 0;
        if (!mirror) {
            if (Input.GetButton("MoveRight")) {
                direction.x = Math.Max(direction.x, 1);
                moving++;
            }
            if (Input.GetButton("MoveLeft")) {
                direction.x = Math.Min(direction.x, -1);
                moving++;
            }
            Vector3 movement = direction * moveSpeed;
            if (moving == 1) body.velocity = new Vector3(movement.x, body.velocity.y, 0.0f);
        }
        else {
            if (Input.GetButton("MoveRight"))
            {
                direction.x = Math.Max(direction.x, -1);
                moving++;
            }
            if (Input.GetButton("MoveLeft"))
            {
                direction.x = Math.Min(direction.x, 1);
                moving++;
            }
            Vector3 movement = direction * moveSpeed;
            if (moving == 1) body.velocity = new Vector3(movement.x, body.velocity.y, 0.0f);
        }
    }


    private void Jump() {
        if (Input.GetButton("Jump") && grounded) body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}

























/*

    private void ListenMove() {
        if (Input.GetButton("MoveLeft"))
            OnNewInput(Vocabulary.input_type.MoveLeft); // Move left.
        if (Input.GetButton("MoveRight"))
            Send(Vocabulary.input_type.MoveRight); // Move right.
        if (!Input.GetButton("MoveRight") && !Input.GetButton("MoveLeft")
            || Input.GetButton("MoveRight") && Input.GetButton("MoveLeft")) // Stop.
            Send(Vocabulary.input_type.MoveStop);
    }

    private void MoveRequest(Vocabulary.input_type type) {
        if (ignore) return;
        switch (type) { // Set direction according to input type.
            case Vocabulary.input_type.MoveLeft : direction = Vector2.left; break;
            case Vocabulary.input_type.MoveRight : direction = Vector2.right; break;
            case Vocabulary.input_type.MoveStop : direction = Vector2.zero; break;
        }
        Move(speed);
    }

    private void Move(float intensity) {
        if (direction == Vector2.zero) body.velocity = Vector2.zero;
        body.velocity = direction * intensity;
        curve_debug_velocity.AddKey(
            new Keyframe(Time.time, body.velocity.x));
    }*/

