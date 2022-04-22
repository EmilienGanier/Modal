using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BolchiMove : MonoBehaviour
{

    public static BolchiMove instance;
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

    public float verticalmovement;


    // PRIMARY
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(0, 0);
        isClimbing = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        verticalmovement = Input.GetAxis("Vertical") * climbSpeed * Time.fixedDeltaTime;
    
        if (isClimbing) Debug.Log("isClimbing");

        Move(verticalmovement);
        Jump();
        //grounded = false;
    }

    private void Update()
    {
        CheckInput();
    }

    void OnCollisionEnter2D(Collision2D other) {
        //if (other.collider.tag == "Ground" && other.GetContact(0).normal == new Vector2(0.0f, 1.0f)) grounded = true;
        if (other.collider.tag == "Ground" && other.GetContact(0).normal[1] > 0.0f) grounded = true;
    }

    void OnCollisionExit2D(Collision2D other) {

        if (other.collider.tag == "Ground") grounded = false;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        //if (collision.CompareTag("Mirror")) inMirror = true;
        //if (collision.CompareTag("Start"))
        //{
          //  SceneManager.LoadScene("Level 1");
            //Debug.Log("uegyflaiu");
        //}
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
      //  if (collision.tag == "Mirror") inMirror = false;
    //}


    // OTHER

    private void CheckInput() {


        if (Input.GetButtonDown("EnterMirror") && inMirror)
        {
            mirror = !mirror;

        }

    }
    private void Move(float _verticalmovement) {
  
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

        if(isClimbing){
            Vector3 targetVelocity = new Vector2(body.velocity.x, _verticalmovement);
            body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, .05f);
        }

        // Pour debug quand bolchie "glisse"

        if (Input.GetButtonDown("Debug")) body.position = new Vector2(body.position.x, body.position.y + 0.1f);
    }


    private void Jump() {
        if (Input.GetButton("Jump") && grounded) {
            //body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            body.AddForce(new Vector2(0, jumpForce));
        }
    }
}



























