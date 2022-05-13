using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchMusic : MonoBehaviour

{
    public AudioSource music;
    private bool hasAlreadyStarted = false;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!hasAlreadyStarted && time > 7.0f)
        {
            music.Play();
            hasAlreadyStarted = true;
        }
    }
}
