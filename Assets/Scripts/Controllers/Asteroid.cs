using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    //initiate random spot
    public Vector3 RandomSpot;

    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        //set random direction
        RandomSpot = new Vector3(Random.Range(-20,20),Random.Range(-10,10),0);
    }

    // Update is called once per frame
    void Update()
    {
        //Random location is picked, clamp its distance
        Vector3 RandomSpotFix = Vector3.ClampMagnitude(RandomSpot, maxFloatDistance);


        //Find direction between enemy and asteroid
        Vector3 asteroid = transform.position;
       
        //Find direction between asteroid spot and randomspot
        Vector3 DirectionMove = RandomSpotFix - asteroid;


        //Set enemy motion towards asteroid
        velocity += moveSpeed * Time.deltaTime * DirectionMove;

        //set distance to check if enemy is nearby target asteroid
        float targetmagnitude = DirectionMove.magnitude;

        if (targetmagnitude < arrivalDistance)
        {
            ReRollSpot();
        }

        Vector3 direction = (velocity).normalized;
        transform.position += direction * Time.deltaTime;

    }

    public void ReRollSpot() 
    {
        //set random direction
        RandomSpot = new Vector3(Random.Range(-20, 20), Random.Range(-10, 10), 0);
    }
}
