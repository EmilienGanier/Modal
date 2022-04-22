using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    public bool isAlive = true;
   
    public Vector3 checkpoint =  new Vector3(-2.5f, -0.5f, 0.0f);
    public Rigidbody2D body;

    void Awake()
    {
        
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive || Input.GetButtonDown("Restart")) Death();
    }

    private void OnCollisionEnter2D (Collision2D collision){
        if (collision.collider.CompareTag("Ennemy")){
            isAlive = false;
        }
    }


    void Death(){
        Debug.Log("Vous êtes mort !");
        body.position = checkpoint;
        body.velocity = new Vector2(0.0f, 0.0f);
        //isAlive = true;
    }
}
