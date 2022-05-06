using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    public bool isAlive = true;
   
    public Vector3 checkpoint =  new Vector3(-2.5f, -0.5f, 0.0f);
    public Rigidbody2D body;
    public GameObject deathSprite;
    public float t = 0.0f;
    public bool dead = false;

    void Awake()
    {
        
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        deathSprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive || Input.GetButtonDown("Restart")) Death();
        if (dead && Time.time-t>3.0f){
            dead = false;
            deathSprite.SetActive(false);
        }
    }

    private void OnCollisionEnter2D (Collision2D collision){
        if (collision.collider.CompareTag("Ennemy")){
            isAlive = false;
        }
        if (collision.collider.CompareTag("Checkpoint")){
            
        }
    }


    void Death(){
        Debug.Log("Vous êtes mort !");
        deathSprite.SetActive(true);
        t = Time.time;
        isAlive = true;
        body.position = checkpoint;
        body.velocity = new Vector2(0.0f, 0.0f);
        dead = true;
    }


    /*
    IEnumerator DeathCoroutine()
    {
        Debug.Log("Vous êtes mort !");
        deathSprite.SetActive(true);
        yield return new WaitForSeconds(5);
        body.position = checkpoint;
        body.velocity = new Vector2(0.0f, 0.0f);
        isAlive = true;
        deathSprite.SetActive(false);
    }
    */



}
