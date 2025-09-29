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

    // Start is called before the first frame update
    void Start()
    {
        //set random direction
        RandomSpot = new Vector3(Random.Range(-20,20),Random.Range(-20,20),Random.Range(-20,20));
    }

    // Update is called once per frame
    void Update()
    {


        //velocity wont exceed this value.
        velocity = Vector3.ClampMagnitude(RandomSpot, maxFloatDistance);

        //Find direction between enemy and asteroid
        Vector3 enemypos = transform.position;
        Vector3 ChosenAsteroidPosition = ChosenAsteroid.position;
        Vector3 DirectionMove = ChosenAsteroidPosition - enemypos;

        //Calculate variables for velocity
        float accelerationRate = MaxSpeed / Accelerationtime * 2;

        //Set enemy motion towards asteroid
        velocity += accelerationRate * Time.deltaTime * DirectionMove;

        //set distance to check if enemy is nearby target asteroid
        float targetmagnitude = DirectionMove.magnitude;

        if (targetmagnitude < Maxrange)
        {
            reachedasteroid = true;
        }


   

        Vector3 direction = (velocity).normalized;
        transform.position += direction * Time.deltaTime;

    }


}
