using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolchieHit : MonoBehaviour
{
    public static bolchieHit instance;
    public Rigidbody2D body;
    public bool hasBatte;
    public bool isHitting;
    public bool attacking;
  
    // Start is called before the first frame update
    void Start()
    {
        isHitting = false;   
    }

    // Update is called once per frame
    void Update()
    {
        ListenHit();
    }

    void ListenHit()
    {
        if (Input.GetButton("Hit"))
        {
            if (hasBatte) HitWithBatte();
            else HitWithoutBatte();
        }
    }

    void HitWithoutBatte()
    {

    }

    void HitWithBatte()
    {
        isHitting = true;
    }
}
