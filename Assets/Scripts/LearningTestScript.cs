using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class LearningTestScript : MonoBehaviour
{
    public float radius = 1.0f;
    public int numberofAngles = 6;
    public List<float> angles = new List<float>();

    //time
    public float lineDuration = 10.0f;
    private float elapsedtime = 0.0f;

    private int currentIndex = 0;
    private bool isRunning = false;

    public Vector3 cirlecenter = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = 0;

        //calculate vertices
        for (int i = 0; i < numberofAngles + 1; i++)
        {
            float floatconvert = i;
            angles.Add(floatconvert / numberofAngles * 360f);
        }
    }

    // Update is called once per frame
    void Update()
    {
     

              //Draw force field
        
             currentIndex = (currentIndex + 1) % angles.Count; 
            


             float PointA = angles[currentIndex] * Mathf.Deg2Rad;

             float PointB = angles[currentIndex + 1] * Mathf.Deg2Rad;
            

            //Find vector for point A
            //find y
            float Ay = Mathf.Sin(PointA);

            //find x 
            float Ax = Mathf.Cos(PointA);



            //Find vector for point B
            //find y
            float By = Mathf.Sin(PointB);

            //find x
            float Bx = Mathf.Cos(PointB);


            //A spot used to be called Point
            Vector3 PointASpot = new Vector3(Ax, Ay, 0) * radius;

            //B spot is experimental
            Vector3 PointBSpot = new Vector3(Bx, By, 0) * radius;
        
            Debug.DrawLine(cirlecenter + PointASpot, cirlecenter + PointBSpot, Color.green);
            //Debug.DrawLine(cirlecenter + PointASpot, cirlecenter + PointBSpot, Color.green);


    }




}
