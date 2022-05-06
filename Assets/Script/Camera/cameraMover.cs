using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class cameraMover : MonoBehaviour
{
    public Transform body;
    public float yOffset;
    public float xOffset;
    Vector3 delta;




    public UnityEngine.Camera cam;
    public float speed =8;

    private bool toBeZoomed = false;
    private float zoom = 6.0f;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(body.position.x + xOffset, body.position.y + yOffset, transform.position.z);
        cam.orthographicSize = 8;

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(cam.orthographicSize-zoom)>0.2f){
            float newSize = Mathf.MoveTowards(cam.orthographicSize, cam.orthographicSize - 0.02f*Math.Sign(cam.orthographicSize-zoom), speed * Time.deltaTime);
            cam.orthographicSize = newSize;
        }
        if (body.position.x>-7.5f && body.position.x <2.5f){
            zoom = 6;
        }
        else zoom = 4;


        //scrolling camera
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
        }
    }

    void Zoom(float scale1, float scale2){
        float newSize = Mathf.MoveTowards(cam.orthographicSize, scale2, speed * Time.deltaTime);
        cam.orthographicSize = newSize;
    }
}
