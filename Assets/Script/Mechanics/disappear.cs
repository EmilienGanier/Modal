using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour
{
    public bool[] activation = new bool[26];
    public bool[] solution = new bool[] {false, true, false, false, false, false, false, false, false, false, true, true, false, false, true, false, false, false, true, false, false, false, false, false, true, false};
    public GameObject obstacle;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 26; i++){
            activation[i] = GameObject.Find(i.ToString()).GetComponent<letter>().activated;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Compare()){
            Debug.Log("cest fini");
            obstacle.SetActive(false);
        }
    }

    bool Compare(){
        bool result = true;
        for (int i = 0; i < 26; i++){
            result = result && activation[i] == solution[i];
        }
        return result;
    }
}
