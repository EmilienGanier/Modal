using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolchieMover : MonoBehaviour
{
    public Rigidbody2D body;
    private Vector2 direction;
    void Awake()
    {
        body = transform.GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetSpeed();
        GetJump();
    }

    private void GetSpeed()
    {
        if (Input.GetButton("MoveRight")) Move(2);
        else if (Input.GetButton("MoveLeft")) Move(-2);
        //else Move(0);
    }

    private void GetJump()
    {
        if (Input.GetButton("Jump")) Jump();
    }

    private void Jump()
    {
        body.AddForce(new Vector2(0, 2), ForceMode2D.Impulse);
    }

    private void Move(float speed)
    {   
        direction = new Vector2(1, 0);
        body.velocity = speed*direction;
        
    }
}
