using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer [] dots;
    [SerializeField] LineRenderer LinePrefab;

    // This creats new object with new LineRenderer component
    void CreateLine(SpriteRenderer start, SpriteRenderer end){
        LineRenderer newLine = Instantiate(LinePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        newLine.SetPosition( 0, start.transform.position);
        newLine.SetPosition( 1, end.transform.position);
    }

    void LetterK(){
        // Left side
        CreateLine(dots[0], dots[1]);
        CreateLine(dots[1], dots[2]);
        CreateLine(dots[2], dots[3]);
        CreateLine(dots[3], dots[4]);
        CreateLine(dots[4], dots[5]);

        // Right upper side
        CreateLine(dots[6], dots[7]);
        CreateLine(dots[7], dots[8]);
        CreateLine(dots[8], dots[9]);

        // Right lower side
        CreateLine(dots[9], dots[10]);
        CreateLine(dots[10], dots[11]);
        CreateLine(dots[11], dots[12]);
        CreateLine(dots[11], dots[13]);

        // Cross connections
        CreateLine(dots[1], dots[11]);
        CreateLine(dots[2], dots[9]);
        CreateLine(dots[3], dots[6]);
        CreateLine(dots[4], dots[6]);
        CreateLine(dots[5], dots[8]);
        CreateLine(dots[8], dots[11]);
        CreateLine(dots[9], dots[11]);

    }

    void Start()
    {
        LetterK();
    }

    void Update(){
        // check if dots chaged position
        foreach(SpriteRenderer dot in dots){
            if (dot.GetComponent<FlexibleDots>().prevPos != dot.transform.position){
                Debug.Log(dot.name + "\n" + dot.GetComponent<FlexibleDots>().prevPos + "\n" + dot.transform.position);
                // Kill and redraw lines
                GameObject [] lines = GameObject.FindGameObjectsWithTag("line");
                foreach(GameObject line in lines){
                    Destroy(line);
                }
                LetterK();
                break;
            }
        }
    }

}
