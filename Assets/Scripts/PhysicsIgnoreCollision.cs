using UnityEngine;

public class PhysicsIgnoreCollision : MonoBehaviour
{
    public Collider2D SelfCollider;
    public Collider2D IgnoredthisCollision;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelfCollider = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(IgnoredthisCollision.GetComponent<Collider2D>(), SelfCollider, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
