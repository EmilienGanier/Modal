using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn_titleScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 respawn = new Vector3(-4.93f, 2.63f, 0f);
    public bool isAlive = true;
    public Rigidbody2D body;

    public AudioSource fall;

    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        listenDeath();
        if (!isAlive || Input.GetButtonDown("Restart")) Death();
    }
     void listenDeath()
    {
        if (body.position.y < -3.0f && !fall.isPlaying) fall.Play();
        if (body.position.y < -50.0f) isAlive = false;
    }
    void Death()
    {
        fall.Pause();
        body.position = respawn;
        body.velocity = new Vector2(0.0f, 0.0f);
        isAlive = true;
    }
}
