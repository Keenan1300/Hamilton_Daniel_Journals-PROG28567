using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    private float drawingTime;
    private int starnumberB;
    private int starnumberA;

    //initialize vectors
    public Vector3 PointA;
    public Vector3 PointB;

    void Start()
    {
         starnumberB = 1;
         starnumberA = 0;
    }

// Update is called once per frame
    void Update()
    {
        DrawConstellation(starTransforms);
    }

    public void DrawConstellation(List<Transform> starTransforms)
    {
        //make it so drawing time matches half the rate of real time
        drawingTime += Time.deltaTime * 0.6f;

        Transform starB = starTransforms[starnumberB];
        Transform starA = starTransforms[starnumberA];

        Vector3 PointB = starB.position;
        Vector3 PointA = starA.position;

        // lerp between Point A and B lol
        Vector3 SpaceBetweenPoints = Vector3.Lerp(PointA, PointB, drawingTime);

        if (drawingTime >= 1)
        {
            if (starnumberB > 10)
            {
                starnumberB = 1;
                starnumberA = 0;
            }
            else 
            {

                //change b position
                starnumberB += 1;

                //change A position
                starnumberA += 1;

                drawingTime = 0;
            }

         
        }

        //draw
        Debug.DrawLine(PointA, SpaceBetweenPoints);
       
    }
}
