using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn_hund : MonoBehaviour
{
    public Vector3 respawn_point;
    public Rigidbody2D body;
    private death Death;

    void Awake()
    {
        Death = GameObject.FindGameObjectWithTag("Bolchie").GetComponent<death>();
    }
    // Start is called before the first frame update
    void Start()
    {
        respawn_point = body.position;
    }

    // Update is called once per frame
    void Update()
    {
        ListenBolchie();
    }

    void ListenBolchie()
    {
        if (!Death.isAlive) body.position = respawn_point;
        //body.velocity = new Vector2(0f, 0f);
    }
}
