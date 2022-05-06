using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{

    public bool isInRange;
    private BolchiMove bolchiMove;
    float normms;
    string text = "Press up to climb";


    // Start is called before the first frame update
    void Awake()
    {
        bolchiMove = GameObject.FindGameObjectWithTag("Bolchie").GetComponent<BolchiMove>();
        normms = bolchiMove.moveSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if (isInRange){
            bolchiMove.isClimbing = true;
            Debug.Log("bolchiMove.isClimbing = true;");
        }
        else bolchiMove.isClimbing = false;
        //Debug.Log("bolchiMove.isClimbing = false;");
        */
        
        
    }


    private void OnTriggerEnter2D (Collider2D collision){
        if (collision.CompareTag("Ladder")){
            //isInRange = true;
            bolchiMove.isClimbing = true;
            if (!Input.GetButton("MoveRight") && !Input.GetButton("MoveLeft")) bolchiMove.moveSpeed = normms/5.0f;
            Debug.Log("True");
        }
    }

    private void OnTriggerExit2D (Collider2D collision){
        if (collision.CompareTag("Ladder")){
            //isInRange = false;
            bolchiMove.isClimbing = false;
            bolchiMove.moveSpeed = normms;
            Debug.Log("False");
        }
    }
    
    private void OnGUI()
    {
        if (bolchiMove.isClimbing){
            Vector3 position = Camera.main.WorldToScreenPoint(bolchiMove.transform.position);
            position = new Vector3(position.x, position.y + 100, position.z);
            var textSize = GUI.skin.label.CalcSize(new GUIContent(text));
            GUI.Label(new Rect(position.x - textSize.x/2, Screen.height - position.y, textSize.x, textSize.y), text);
        }
    }
}
