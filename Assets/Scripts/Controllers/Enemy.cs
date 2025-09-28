using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    //playet location
    public Transform playertransform;

    //Asteroid Detection
    public List<Transform> asteroidTransforms;
    public int RandomAsteroid;


    //detector for asteroids
    public float Maxrange = 0.3f;

    //detector for player
    public float PlayerMaxrange = 50f;

    //velocity
    private Vector3 velocity;


    //movment variables
    public float MaxSpeed = 30f;
    public float Accelerationtime = 0.5f;


    //Set status booleans
    public bool aggro;
    public bool reachedasteroid;

    private void start() 
    {
        aggro = false;
        reachedasteroid = false;

        RandomAsteroid = Random.Range(0, 9);
    }
    private void Update()
    {

       

        //Check if enemy is aggro'd
        if (!aggro)
        {
            if (!reachedasteroid)
            {
                {
                    Asteroidmovement(RandomAsteroid);
                    DetectPlayer(playertransform);
                }
            }
            else
            {
                //If asteroid is reached, then move to another one at random
                RandomAsteroid = Random.Range(0, 9);
                reachedasteroid = false;
            }
          
        }
        else
        {
            HuntPlayer(playertransform);
        }


    }

    //movement method
    public void Asteroidmovement(int RandomAsteroid)
    {
       Transform ChosenAsteroid = asteroidTransforms[RandomAsteroid];
       
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


        //velocity wont exceed this value.
        velocity = Vector3.ClampMagnitude(velocity, MaxSpeed);

        Vector3 direction = (velocity).normalized;
        transform.position += direction * Time.deltaTime;

    }

    //Check if player is nearby
    public void DetectPlayer(Transform playertransform)
    {
        //locations for key game objects
        Vector3 playerlocation = playertransform.position;
        Vector3 enemypos = transform.position;

        //find direction between player and enemy
        Vector3 DirectionMove = enemypos - playerlocation;

        //set distance to check if enemy is nearby target asteroid
        float targetmagnitude = DirectionMove.magnitude;



        if (targetmagnitude < PlayerMaxrange)
        {
            aggro = true;
        }
    }


    //player is found, hunt them down
    public void HuntPlayer(Transform playertransform)
    {
        //locations for key game objects
        Vector3 playerlocation = playertransform.position;
        Vector3 enemypos = transform.position;

        //find direction between player and enemy
        Vector3 DirectionMove = playerlocation - enemypos;

        //Calculate variables for velocity
        float accelerationRate = MaxSpeed / Accelerationtime * 2;


        //Set enemy motion towards asteroid
        velocity += accelerationRate * Time.deltaTime * DirectionMove;


        //set distance to check if enemy is nearby target asteroid
        float targetmagnitude = DirectionMove.magnitude;



        //velocity wont exceed this value.
        velocity = Vector3.ClampMagnitude(velocity, MaxSpeed);

        Vector3 direction = (velocity).normalized;
        transform.position += direction * Time.deltaTime;


        //if the player escapes the sight of the enemy, then enemy stops chasing
        if (targetmagnitude > PlayerMaxrange)
        {
            //aggro = false;
        }

    }
}
