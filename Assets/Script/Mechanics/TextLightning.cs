using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLightning : MonoBehaviour
{
    private TextMeshPro text;
    public float dist;
    private BolchiMove bolchiMove;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        bolchiMove = GameObject.FindGameObjectWithTag("Bolchie").GetComponent<BolchiMove>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(bolchiMove.body.position, transform.position);
        if (dist < 5.3f && dist > 3.0f){
            text.color = new Color(text.color[0], text.color[1], text.color[2], (5.3f-dist)/2.3f);
        }
        if (dist > 5.3f){
            text.color = new Color(text.color[0], text.color[1], text.color[2], 0);
        }
        if (dist < 3.0f){
            text.color = new Color(text.color[0], text.color[1], text.color[2], 1);
        }
    }
}
