using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyEnnemyMove : MonoBehaviour
{
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    public Sprite goLeft;
    public Sprite goRight;
    public float moveSpeed;
    public int gr;

    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(1, 0);
        this.GetComponent<SpriteRenderer>().sprite = goRight;
        gr = 1;
        moveSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
           body.velocity = moveSpeed*direction;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Bolchie") touchBolchie();
        if (other.collider.tag == "Wall")
        {
            moveSpeed = -moveSpeed;
            
            changeSprite();
            gr = -gr;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

    }

    void changeSprite()
    {
        if (gr==1) this.GetComponent<SpriteRenderer>().sprite = goLeft;
        if (gr==-1) this.GetComponent<SpriteRenderer>().sprite = goRight;
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
