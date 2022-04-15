using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_StartToLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider>().tag == "Bolchie")
        //if(other.Get.tag == "Bolchie")
        {
            SceneManager.LoadScene("Level 1");
            Debug.Log("uegyflaiu");
        }
    }
}
