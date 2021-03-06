using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint : MonoBehaviour
{
    public bool hinted = false;
    public Transform transform;
    public int fontSize = 20;
    private string text = "You again ? Congratulations, prancing child.\nBut there is no room for complacency here.\nThe path shall remain closed to those unnamed.\n\nPress Enter to communicate, I'm waiting for you.";

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
            var centeredStyle = GUI.skin.GetStyle("Label");
            centeredStyle.alignment = TextAnchor.UpperCenter;
            Vector3 position = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);
            position = new Vector3(position.x, position.y + 300, position.z);
            GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = fontSize;
            var textSize = GUI.skin.label.CalcSize(new GUIContent(text));
            GUI.Label(new Rect(position.x - textSize.x/2, Screen.height - position.y, textSize.x, textSize.y), text, centeredStyle);
        }
    }
}
