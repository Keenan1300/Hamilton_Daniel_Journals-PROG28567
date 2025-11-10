using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class PhysicsTestTorque : MonoBehaviour
{
    public float angle;
    public Rigidbody2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            torqueexperimentation(angle);
        }
    }

    //function takes found angle, and uses it to calculate angular torque b
    void torqueexperimentation(float angle)
    {
        body = GetComponent<Rigidbody2D>();
        float Torque = (angle * Mathf.Deg2Rad)* body.inertia;
        body.AddTorque(Torque);
    }

}
