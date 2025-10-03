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
        for (int i = 0; i < numberofAngles; i++)
        {
            angles.Add(Random.value * 360f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedtime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || elapsedtime > lineDuration)
        {
            currentIndex = (currentIndex + 1) % angles.Count; 
        }

        float PointA = angles[currentIndex] * Mathf.Deg2Rad;

        float PointB = angles[currentIndex] * Mathf.Deg2Rad;

        //Find vector for point A
        float Ay = Mathf.Sin(PointA);
        float Ax = Mathf.Cos(PointA);

        //Find vector for point B
        float By = Mathf.Sin(PointB);
        float Bx = Mathf.Cos(PointB);

        //A spot used to be called Point
        Vector3 PointASpot = new Vector3(Ax, Ay, 0) * radius;

        //B spot is experimental
        Vector3 PointBSpot = new Vector3(Bx, By, 0) * radius;
        
        //Debug.DrawLine(cirlecenter, cirlecenter + Point, Color.green);
        Debug.DrawLine(cirlecenter + PointASpot, cirlecenter + PointBSpot, Color.green);


    }




}
