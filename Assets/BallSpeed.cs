using UnityEngine;

public class BallSpeed : MonoBehaviour
{
    Rigidbody RB;
    public float Propel = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BallBurst()
    {
        RB.AddForce(new Vector3(Input.GetAxisRaw("Horizontal"), 0,0) * Propel);
    }
}
