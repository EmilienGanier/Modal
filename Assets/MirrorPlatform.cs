using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlatform : MonoBehaviour
{

    BolchiMove bolchie;

    private SpriteRenderer platformSprite;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .3f);
        GetComponent<BoxCollider2D>().enabled = false;
        gameObject.tag = "MirrorPlatform";
        gameObject.layer = LayerMask.NameToLayer("MirrorPlatform");
    }

    // Update is called once per frame
    void Update()
    {

        if (bolchie.inMirror)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .3f);
            GetComponent<BoxCollider2D>().enabled = false;
            gameObject.tag = "MirrorPlatform";
            gameObject.layer = LayerMask.NameToLayer("MirrorPlatform");
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            GetComponent<BoxCollider2D>().enabled = true;
            gameObject.tag = "Ground";
            gameObject.layer = LayerMask.NameToLayer("ground");
        }
    }
}
