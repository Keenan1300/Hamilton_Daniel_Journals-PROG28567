using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    //initiate random spot
    public Vector3 RandomSpot;
    public Transform player;
    public Vector3 velocity;

    public bool Magnetic;

    // Start is called before the first frame update
    void Start()
    {
        //set random direction
        RandomSpot = new Vector3(Random.Range(-20,20),Random.Range(-10,10),0);
        Magnetic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Magnetic)
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
        else 
        {
            //If Magnetic = true;
            
            //Find player position
            Vector3 PlayerPos = player.position;


            //Find direction between player and asteroid
            Vector3 asteroid = transform.position;



            //Find direction between asteroid spot and player
            Vector3 DirectionMove = PlayerPos - asteroid;


            //Set enemy motion towards player
            velocity += moveSpeed * Time.deltaTime * DirectionMove;

            Vector3 direction = (velocity).normalized;
            transform.position += direction * Time.deltaTime;

        }
    }

    public void ReRollSpot() 
    {
        //set random direction
        RandomSpot = new Vector3(Random.Range(-20, 20), Random.Range(-10, 10), 0);
    }

    public void magnetize() 
    {
        print("MAGNETIZING!!");


        Magnetic = true;
   

    }
}
