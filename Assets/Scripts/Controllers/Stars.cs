using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    private float drawingTime;
    private int starnumberB =1;
    private int starnumberA = 0;

    //initialize vectors
    public Vector3 PointA;
    public Vector3 PointB;

   

// Update is called once per frame
    void Update()
    {
        DrawConstellation(starTransforms);
    }

    public void DrawConstellation(List<Transform> starTransforms)
    {
        //make it so drawing time matches half the rate of real time
        drawingTime += Time.deltaTime * 0.9f;

        Transform starB = starTransforms[starnumberB];
        Transform starA = starTransforms[starnumberA];

        Vector3 PointB = starB.position;
        Vector3 PointA = starA.position;

        // lerp between Point A and B lol
        Vector3 SpaceBetweenPoints = Vector3.Lerp(PointA, PointB, drawingTime);

        if (drawingTime >= 1)
        {
            //loop b
            if (starnumberB == 9)
            {

                starnumberB = 0;
                starnumberA = 9;
                drawingTime = 0;

            }
           
            else if (starnumberB < 9)
            {

                //change b position
                starnumberB += 1;

                //change A position
                starnumberA += 1;

                drawingTime = 0;
            
            }
            //make sure A is never a problem for looping
            if (starnumberA == 10)
            {
                starnumberB = 1;
                starnumberA = 0;
                drawingTime = 0;
            }
        }
        //draw
        Debug.DrawLine(PointA, SpaceBetweenPoints);
       
    }
}
