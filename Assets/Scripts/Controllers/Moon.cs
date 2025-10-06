using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public Transform Target;

    public float OrbitalSpeed = 0.5f;
    public float radius = 2f;
    private int currentIndexA = 0;
    private int currentIndexB = 0;

    public float LerpTransition = 0.01f;

    private int keyspots = 30;

    //List to track orbial position
    public List<float> OrbitSpots = new List<float>();


    // Start is called before the first frame update
    void Start()
    {
        //calculate Orbit spots
        for (int i = 0; i < keyspots + 1; i++)
        {
            float floatconvert = i;
            OrbitSpots.Add(floatconvert / keyspots * 360f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(radius, OrbitalSpeed, Target);
    }

    public void OrbitalMotion(float radius, float OrbitalSpeed, Transform Target)
    {
        Vector3 TargetPos = Target.position;
        Vector3 pos = transform.position;

        LerpTransition += 0.01f * OrbitalSpeed;

        if (LerpTransition >= 1)
        {
            LerpTransition = 0;
            currentIndexA = (currentIndexA + 1) % OrbitSpots.Count;
        }


     

        //move from A to B
        float MoveTargetA = OrbitSpots[currentIndexA] * Mathf.Deg2Rad;
        float Ay = Mathf.Sin(MoveTargetA);
        float Ax = Mathf.Cos(MoveTargetA);
        Vector3 PointASpot = new Vector3(Ax, Ay, 0) * radius;

        float MoveTargetB = OrbitSpots[currentIndexB + 1] * Mathf.Deg2Rad;
        float By = Mathf.Sin(MoveTargetA);
        float Bx = Mathf.Cos(MoveTargetA);
        Vector3 PointBSpot = new Vector3(Bx, By, 0) * radius;


        Vector3 transitionpoint = Vector3.Lerp(PointASpot + Target.position, PointBSpot + Target.position, LerpTransition);



        transform.position = transitionpoint;

      
    }

    
}
