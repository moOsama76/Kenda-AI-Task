using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexibleDots : MonoBehaviour
{
    static bool isSomePointPicked = false;
    bool isDotDraggable = false;
    Vector2 mousePos;
    public Vector3 prevPos;

    void Start(){
        prevPos = gameObject.transform.position; 
    }
    void Update(){
        if (Input.GetMouseButton(0)){
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(!isSomePointPicked && Vector2.Distance(mousePos, transform.position)  < 1f){
                isSomePointPicked = true;
                isDotDraggable = true;
            }
        } else if (Input.GetMouseButtonUp(0)){
            isSomePointPicked = false;
            isDotDraggable = false;
            prevPos = gameObject.transform.position;
        }
        if(isDotDraggable){
            gameObject.transform.position = mousePos;
        }

        
    }
}
