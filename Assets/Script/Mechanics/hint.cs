using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint : MonoBehaviour
{
    public bool hinted = false;
    public Transform transform;
    private string text = "The path shall remain closed\nto those unknown.\n\nPress Enter to communicate.";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D (Collider2D collision){
        if (collision.CompareTag("Bolchie")){
            hinted = true;
        }
    }
    
    private void OnTriggerExit2D (Collider2D collision){
        if (collision.CompareTag("Bolchie")){
            hinted = false;
        }
    }

    private void OnGUI()
    {
        if (hinted){
            Vector3 position = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);
            position = new Vector3(position.x, position.y + 300, position.z);
            var textSize = GUI.skin.label.CalcSize(new GUIContent(text));
            GUI.Label(new Rect(position.x - textSize.x/2, Screen.height - position.y, textSize.x, textSize.y), text);
        }
    }
}
