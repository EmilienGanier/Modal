using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTest : MonoBehaviour
{
    public Rigidbody2D body;
    public float moveSpeed;
    public float puissanceJambes;

    private Vector3 velocity = Vector3.zero;
    float horizontalMovement;
    public bool enSaut = false;
    public bool grounded;

    public Transform groundL;
    public Transform groundR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapArea(groundL.position, groundR.position, 0); //cree une boit de collision

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump")&&grounded) enSaut = true;
        Movingeasily(horizontalMovement);

    }




    void Movingeasily(float hm){ //takes horizontalmovement
        Vector3 targetVelo = new Vector3(hm, body.velocity.y, 0);
        body.velocity = Vector3.SmoothDamp(body.velocity, targetVelo, ref velocity, 0.05f);

        if (enSaut){
            body.AddForce(new Vector2(0, puissanceJambes));
            enSaut = false;
            grounded = false;
        }
    }
}   
