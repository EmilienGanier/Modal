using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolchieMover : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeed;
    private bool grounded;
    private Vector2 direction;
    // Start is called before the first frame update
    void Awake()
    {
        body = transform.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ListenMove();
        Jump();
    }

    private void ListenMove()
    {
        int moving = 0;
        if(Input.GetButton("MoveRight"))
        {
            direction = new Vector2(1, 0);
            moving++;
        }
        if (Input.GetButton("MoveLeft"))
        {
            direction = new Vector2(-1, 0);
            moving++;
        }
        if (moving == 1) body.velocity = direction * moveSpeed;
    }

    private void Jump()
    {
        if (Input.GetButton("Jump") ) body.AddForce(new Vector2(0, 0.3f), ForceMode2D.Impulse);
    }
   

}
