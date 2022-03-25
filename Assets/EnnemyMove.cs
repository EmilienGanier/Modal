using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyMove : MonoBehaviour
{
    public Rigidbody2D body;
    public float moveSpeed;

    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Move(float speed)
    {
        direction = new Vector2(1, 0);
        body.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.otherCollider.tag == "Bolchie") touchBolchie();
        if (other.otherCollider.tag == "Wall") direction = -direction;
    }

    void touchBolchie()
    {
       if (/*Bolchie est en train de taper */1 == 1) isHitten();
    }

    void isHitten()
    {

        }

    void killsBolchie()
    {

    }
}
