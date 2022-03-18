using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolchiMove : MonoBehaviour
{

    public static BolchiMove instance;
    //public OnNewInputHandler OnNewInput;
    public Rigidbody2D body;
    public float moveSpeed;

    private Vector2 direction;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        if(body.transform.position[1]<-2.9f) grounded = true;
        else grounded = false;
    }


    private void Move(){
        int moving = 0;
        if (Input.GetButton("MoveRight")) {
            direction = new Vector2(1, 0);
            moving ++;
        }
        if (Input.GetButton("MoveLeft")) {
            direction = new Vector2(-1, 0);
            moving ++;
        }
        if (moving == 1) body.velocity = direction * moveSpeed;
    }

    private void Jump(){
        if (Input.GetButton("Jump")&&grounded) body.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
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
}
