using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperLvl1 : MonoBehaviour
{

    private Transform bolchiPos;

    // Start is called before the first frame update
    void Awake()
    {
        bolchiPos = GameObject.FindGameObjectWithTag("Bolchie").GetComponent<Transform>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Place(bolchiPos.position.x, bolchiPos.position.y);
    }

    // 6.5 et -0.9
    void Place(float xjoueur, float yjoueur){
        if (yjoueur<3.0f && yjoueur>-2.5f && xjoueur>-4.5f && xjoueur<13.5f){
            transform.position = new Vector3(transform.position.x, 7.4f * Mathf.Abs(transform.position.x-xjoueur)/9.0f - 0.9f, transform.position.z);
        }
    }
}
