using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour


{
    private BolchiMove bolchieMove;
    public Transform body;
    float x;
    float y;
    float target = 180.0f;
    float speed = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        x = body.eulerAngles.x;
        y = body.eulerAngles.y;
        bolchieMove = GameObject.FindGameObjectWithTag("Bolchie").GetComponent<BolchiMove>();
        body.Rotate(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetButtonDown("EnterMirror") && bolchieMove.inMirror)
        {
            //if (Mathf.Abs(360.0f - body.rotation.z) > 1)
            //{
            //  float rotation = Mathf.MoveTowardsAngle(body.eulerAngles.z, target, speed * Time.deltaTime);
            //body.Rotate(x, y, rotation);
            //}
            //body.Rotate(x, y, Mathf.MoveTowardsAngle(body.eulerAngles.z, target, speed * Time.deltaTime));
            while (360.0f - body.rotation.z > 0.2f)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, target), speed * Time.deltaTime);
        }*/
    }
}