using UnityEngine;
using UnityEngine.Audio;

public class Turret : MonoBehaviour
{
    public float angularspeedDeg = 40f;
    public Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //find second vector
        Vector3 directionV = (target.position - transform.position).normalized;

        //first need to convert both vectors into floats using atan2!
        float upAngle = Mathf.Atan2(transform.position.y, transform.position.x);
        float directionangle = Mathf.Atan2(directionV.y, directionV.x);


        //now you can use delta angle to find shortest angle between these 2
        float deltaangle = Mathf.DeltaAngle(upAngle, directionangle);
        Debug.Log($"<color=cyan><size=16>{deltaangle}</size></color>");


        //calculate direction vector as a dot product representing -1.0 to 1.0
        float DotProd = Vector3.Dot(transform.up, directionV);


        //Sign makes the turret change direction that best suites the location of the enemy.
        //Basically go the other way if the turret is closer when moving in that direction
        float sign = Mathf.Sign(deltaangle);

        if (DotProd < 0.999f) transform.Rotate(0, 0, angularspeedDeg * Time.deltaTime * sign); 


        Vector3 pos = transform.position;
        Vector3 upness = transform.up;


 


        Debug.DrawLine(pos, pos + transform.up, Color.cyan);
        Debug.DrawLine(pos, pos + directionV, Color.red);
        Debug.Log($"<color=yellow><size=16>{DotProd}</size></color>");


        if (Mathf.Abs(DotProd) > 0.001)
        {
           
            Debug.Log("Infront!");
        }
        else if (DotProd < 0)
        {

            Debug.Log("behind!");
        }





    }
}
