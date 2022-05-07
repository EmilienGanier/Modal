using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class letter : MonoBehaviour
{

public TextMeshPro text;
private enigme2 support;
public letter instance;
public bool activated = false;
private disappear checklist;

    // Start is called before the first frame update
    void Start()
    {
        support = GameObject.FindGameObjectWithTag("Enigme2").GetComponent<enigme2>();
        text.color = new Color(255, 0, 0, 255);
        RectTransform rt = GetComponent<RectTransform>();
        rt.position = new Vector3(-16.57f + (float)int.Parse(instance.name), rt.position.y, rt.position.z);
        if (int.Parse(instance.name) > 12) rt.position = new Vector3(-13.57f + (float)int.Parse(instance.name), rt.position.y, rt.position.z);

        checklist = GameObject.Find("Obstacle").GetComponent<disappear>();
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
                text.color = new Color(255, 0, 0, text.color[3]);
            }
            else{
                text.color = new Color(0, 255, 0, text.color[3]);
            }
            activated = !activated;
            checklist.activation[int.Parse(instance.name)] = activated;
            //text.color = new Color32(255 - text.color[0], 255 - text.color[1], 0, 255);
        }
    }
}
