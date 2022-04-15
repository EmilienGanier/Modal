using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    bool isChest;
    bolchieHit bolchiehit;
    public SpriteRenderer spriteRenderer;
    public Sprite closed;
    public Sprite opened;

    // Start is called before the first frame update
    void Awake()
    {
        bolchiehit = GameObject.FindGameObjectWithTag("Bolchie").GetComponent<bolchieHit>();
        this.GetComponent<SpriteRenderer>().sprite = closed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChest && Input.GetButtonDown("EnterMirror"))
        {
            bolchiehit.hasBatte = true;
            this.GetComponent<SpriteRenderer>().sprite = opened;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bolchie"))
        {
            isChest = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bolchie"))
        {
            isChest = false;
        }

    }
}
