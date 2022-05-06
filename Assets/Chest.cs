using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    bool isChest;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isChest)
        {
            this.gameObject.transform.Translate(2.57f, 2.73f, 0.2f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bolchie"))
        {
            isChest = true;
            SceneManager.LoadScene("Final Scene and Replay");
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
