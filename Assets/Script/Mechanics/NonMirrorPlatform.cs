using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonMirrorPlatform : MonoBehaviour
{
    private BolchiMove bolchieMove;

    private SpriteRenderer platformSprite;

    BoxCollider2D platformCollider;

    // Start is called before the first frame update
    void Awake()
    {
        bolchieMove = GameObject.FindGameObjectWithTag("Bolchie").GetComponent<BolchiMove>();
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        this.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.tag = "Ground";
        gameObject.layer = LayerMask.NameToLayer("ground");
    }

    // Update is called once per frame
    void Update()
    {
        if (bolchieMove.mirror)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
            this.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.tag = "MirrorPlatform";
            gameObject.layer = LayerMask.NameToLayer("MirrorPlatform");
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            this.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.tag = "Ground";
            gameObject.layer = LayerMask.NameToLayer("ground");
        }
    }
}
