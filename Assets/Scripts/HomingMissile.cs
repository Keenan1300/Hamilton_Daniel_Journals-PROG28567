using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    //angularspeed
     private float angularspeedDeg = 120f;

    //Target Vector
    public Transform enemy;

    //detector
    public float Maxrange;

    //velocity
    private Vector3 velocity;

    //Once the missile has found its target
    bool foundtarget = false;

    //movement
    private float MaxSpeed = 7f;
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


        //missile will explode after 5 seconds
        Destroy(gameObject,5);

        //constantly update where major positions are
        Vector3 pos = transform.position;
        Vector3 target = enemy.position;

        //find second vector
        Vector3 directionV = target - pos;

        //find the magnitude between missile and target so that missile would explode if close enough to target
        //prevents akward moments where player shoots ontop of enemy and missile doesnt immediatley explode
        float MissileExploadDist = directionV.magnitude;
        print(MissileExploadDist);


        if (MissileExploadDist < 0.8f)
        {
            Destroy(gameObject);
        }

            //Speed control for acceleration
            float accelerationRate = MaxSpeed / Accelerationtime;



            //find second vector
            Vector3 directionVnormed = (enemy.position - transform.position).normalized;

            //first need to convert both vectors into floats using atan2!
            float upAngle = Mathf.Atan2(transform.position.y, transform.position.x);
            float directionangle = Mathf.Atan2(directionVnormed.y, directionVnormed.x);


            //now you can use delta angle to find shortest angle between these 2
            float deltaangle = Mathf.DeltaAngle(upAngle, directionangle);


            //calculate direction vector as a dot product representing -1.0 to 1.0
            float DotProd = Vector3.Dot(transform.up, directionVnormed);


            //Missile rotates clockwise, or counter clock wise depending on whatever method is quicker to aligning to target
            float sign = Mathf.Sign(deltaangle);


         

        if (!foundtarget)
            {

            //if missile is not facing enemy, rotate towards them to do so
            if (DotProd < 0.999f)
            {

                transform.Rotate(0, 0, angularspeedDeg * Time.deltaTime * sign);

            }


            if (DotProd > 0.999f)
             {

                foundtarget = true;

             }




           

             //Add velocity
             velocity += directionV * Time.deltaTime * accelerationRate * 10;
             velocity = Vector3.ClampMagnitude(velocity, MaxSpeed);
             transform.position += transform.up * MaxSpeed * Time.deltaTime;
    
            }



        if (foundtarget)
        {



            //Add velocity
            velocity += directionVnormed * Time.deltaTime * accelerationRate * 10;

            //velocity wont exceed this value.
            velocity = Vector3.ClampMagnitude(velocity, MaxSpeed);

            transform.position += velocity * Time.deltaTime;

        }

    }
}
