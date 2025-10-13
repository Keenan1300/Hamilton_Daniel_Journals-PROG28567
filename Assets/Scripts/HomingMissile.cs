using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    //angularspeed
     private float angularspeedDeg = 90f;

    //Target Vector
    public Transform enemy;

    //detector
    public float Maxrange;

    //velocity
    private Vector3 velocity;

    //Once the missile has found its target
    bool foundtarget = false;

    //movement
    public float MaxSpeed = 3f;
    public float minspeed = 1f;
    public float Accelerationtime = 0.5f;
    public float DecelerationRate = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 pos = transform.position;
        velocity = Vector3.up + pos;
        transform.position += velocity * Time.deltaTime * 5;
    }

    // Update is called once per frame
    void Update()
    {

        //deceleration
        velocity -= velocity * Time.deltaTime * DecelerationRate;

        float accelerationRate = MaxSpeed / Accelerationtime;


        if (!foundtarget)
        {
            //find second vector
            Vector3 directionV = (enemy.position - transform.position).normalized;

            //first need to convert both vectors into floats using atan2!
            float upAngle = Mathf.Atan2(transform.position.y, transform.position.x);
            float directionangle = Mathf.Atan2(directionV.y, directionV.x);


            //now you can use delta angle to find shortest angle between these 2
            float deltaangle = Mathf.DeltaAngle(upAngle, directionangle);


            //calculate direction vector as a dot product representing -1.0 to 1.0
            float DotProd = Vector3.Dot(transform.up, directionV);


            //Sign makes the turret change direction that best suites the location of the enemy.
            //Basically go the other way if the turret is closer when moving in that direction
            float sign = Mathf.Sign(deltaangle);

            if (DotProd < 0.999f)
            {
                transform.Rotate(0, 0, angularspeedDeg * Time.deltaTime * sign);
            }
            else foundtarget = true;


            Vector3 pos = transform.position;
            Vector3 upness = transform.up;

        }



        if (foundtarget)
        {


            Vector3 pos = transform.position;
            Vector3 target = enemy.position;
            //find second vector
            Vector3 directionV = target - pos;

            float MissileExploadDist = directionV.magnitude;
            print(MissileExploadDist);


          

            if (MissileExploadDist < 0.1f)
            {
                Destroy(gameObject);
            }

            //Add velocity
            velocity += directionV * Time.deltaTime * accelerationRate * 10;

            //velocity wont exceed this value.
            velocity = Vector3.ClampMagnitude(velocity, MaxSpeed);

            transform.position += velocity * Time.deltaTime;

        }

    }
}
