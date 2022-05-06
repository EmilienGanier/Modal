using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class letter : MonoBehaviour
{

public TextMeshPro text;
private enigme2 support;
public letter instance;

    // Start is called before the first frame update
    void Start()
    {
        support = GameObject.FindGameObjectWithTag("Enigme2").GetComponent<enigme2>();
        text.color = new Color32(255, 0, 0, 255);
        RectTransform rt = GetComponent<RectTransform>();
        rt.position = new Vector3(-16.92f + int.Parse(instance.name), rt.position.y, rt.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("EnterMirror") && support.inRange){
            AllumerLeFeu();
        }
    }

    void AllumerLeFeu(){
        if (support.letter == int.Parse(instance.name)){
            if (text.color[0] == 0){
                text.color = new Color32(255, 0, 0, 255);
                Debug.Log("all");
            }
            else{
                text.color = new Color32(0, 255, 0, 255);
            }
            //text.color = new Color32(255 - text.color[0], 255 - text.color[1], 0, 255);
        }
    }
}
