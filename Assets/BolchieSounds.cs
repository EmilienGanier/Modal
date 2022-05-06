using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolchieSounds : MonoBehaviour
{
    public AudioSource running;

    public Rigidbody2D body;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RunSound();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground") grounded = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground") grounded = false;
    }

    void RunSound()
    {
        if (Mathf.Abs(body.velocity.x) > 0.1f && !running.isPlaying && grounded) running.Play();
        if (Mathf.Abs(body.velocity.x) < 0.1f && running.isPlaying) running.Pause();
        if (!grounded && running.isPlaying) running.Pause();
    }
}
