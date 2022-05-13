using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bgMover : MonoBehaviour
{
    public Transform body;
    public float yOffset;
    public float xOffset;
    Vector3 delta;
    private float scale;
    public UnityEngine.Camera cam;
    private float zoom;
    public float baseZoom;

    public cameraMover cammove;
    private float ecart;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(body.position.x + xOffset, body.position.y + yOffset, transform.position.z);
        transform.localScale = new Vector3(0.5f*transform.localScale.x, 2*transform.localScale.y, 2*transform.localScale.z);


    }

    // Update is called once per frame
    void Update()
    {
        zoom = cam.orthographicSize;
        transform.localScale = new Vector3(baseZoom*zoom/4.0f, baseZoom*zoom/4.0f, baseZoom*zoom/4.0f);

        /*
        delta =body.position - transform.position;
        if (delta.x>2) {
            transform.position = new Vector3(body.position.x -2, transform.position.y + yOffset, transform.position.z);
        }
        if (delta.x<-2) {
            transform.position = new Vector3(body.position.x +2, transform.position.y + yOffset, transform.position.z);
        }
        if (delta.y>1) {
            transform.position = new Vector3(transform.position.x + xOffset, body.position.y - 1 + yOffset, transform.position.z);
        }
        if (delta.y<-1) {
            transform.position = new Vector3(transform.position.x + xOffset, body.position.y + 1 + yOffset, transform.position.z);
        }*/

        ecart = cammove.ecart;
        delta =body.position - transform.position;
        if (delta.x>ecart) {
            transform.position = new Vector3(body.position.x -ecart, transform.position.y + yOffset, transform.position.z);
        }
        if (delta.x<-ecart) {
            transform.position = new Vector3(body.position.x +ecart, transform.position.y + yOffset, transform.position.z);
        }
        if (delta.y>1) {
            transform.position = new Vector3(transform.position.x + xOffset, body.position.y - 1 + yOffset, transform.position.z);
        }
        if (delta.y<-1) {
            transform.position = new Vector3(transform.position.x + xOffset, body.position.y + 1 + yOffset, transform.position.z);
        }
    }
}
