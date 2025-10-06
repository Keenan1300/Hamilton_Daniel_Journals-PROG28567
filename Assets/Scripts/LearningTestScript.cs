using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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

    //dotproduct
    public float RedAngleDeg = 60f;
    public float BlueAngleDeg = 30f;

    public Vector3 cirlecenter = Vector3.zero;

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //currentIndex = 0;

        //calculate vertices
       // for (int i = 0; i < numberofAngles + 1; i++)
       // {
           // float floatconvert = i;
            //angles.Add(floatconvert / numberofAngles * 360f);
       // }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 Playerpos = Player.position;

        //Draw force field

        //currentIndex = (currentIndex + 1) % angles.Count;



        // float PointA = angles[currentIndex] * Mathf.Deg2Rad;

        //float PointB = angles[currentIndex + 1] * Mathf.Deg2Rad;


        //Find vector for point A
        //find y
        //float Ay = Mathf.Sin(PointA);

        //find x 
        //float Ax = Mathf.Cos(PointA);



        //Find vector for point B
        //find y
        //float By = Mathf.Sin(PointB);

        //find x
        //float Bx = Mathf.Cos(PointB);


        //A spot used to be called Point
        //Vector3 PointASpot = new Vector3(Ax, Ay, 0) * radius;

        //B spot is experimental
        //Vector3 PointBSpot = new Vector3(Bx, By, 0) * radius;

        //Debug.DrawLine(Playerpos + PointASpot, Playerpos + PointBSpot, Color.green);
        //Debug.DrawLine(cirlecenter + PointASpot, cirlecenter + PointBSpot, Color.green);



        //dot product exercise
        Vector2 redVector = VectorFromAngle(RedAngleDeg);
        Vector2 blueVector = VectorFromAngle(BlueAngleDeg);

        Debug.DrawLine(Vector3.zero, redVector, Color.red);
        Debug.DrawLine(Vector3.zero, blueVector, Color.cyan);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dot = DotProduct(redVector, blueVector);

            if (Mathf.Abs(dot) < 0.001) dot = 0;
            Debug.Log($"<color=yellow><size=16>{dot}</size></color>");
        }
    }
    
    private float DotProduct(Vector3 a, Vector3 b)
    {
        return a.x * b.x + a.y * b.y;
    }
  

    private Vector2 VectorFromAngle(float angle)
    {
        float angleinRad = Mathf.Deg2Rad * angle;
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
}
