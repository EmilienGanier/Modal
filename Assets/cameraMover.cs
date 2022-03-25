using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class cameraMover : MonoBehaviour
{
    public Transform body;
    public float yOffset;
    public float xOffset;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(body.position.x + xOffset, body.position.y + yOffset, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(body.position.x + xOffset, body.position.y + yOffset, transform.position.z);
    }
}
