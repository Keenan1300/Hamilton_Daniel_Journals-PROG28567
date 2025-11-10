using UnityEngine;

public class PhysicsGetIgnore : MonoBehaviour
{
    public Collider2D SelfCollider;
    public Collider2D IgnoredthisCollision;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelfCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            print("Accessing collider");
            print(Physics2D.GetIgnoreCollision(SelfCollider, IgnoredthisCollision));

        }
        if (Input.GetMouseButtonDown(1))
        {
            print("phase");
            Physics2D.IgnoreCollision(IgnoredthisCollision.GetComponent<Collider2D>(), SelfCollider, true);

        }
       

    }

  
}
