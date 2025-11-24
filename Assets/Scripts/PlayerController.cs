using JetBrains.Annotations;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Vector3 velocity = new Vector3(2,2,0);
    private float gravity;
    private float Jumpvelocity;
    public float apexHeight = 5;
    public float apexTime = 3;
    public float jumpVel;
    public LayerMask groundlayer;

    public enum FacingDirection
    {
        left, right
    }
    public FacingDirection currentdirection;

    // Start is called before the first frame update
    void Start()
    {
        
        float Jumpvelocity = 2 * apexHeight / apexTime;
        float gravity = -2 * apexHeight / (Mathf.Pow(apexTime,2f));
    }

    // Update is called once per frame
    void Update()
    {
        //fall
        velocity.y = gravity * Time.deltaTime + jumpVel;
        
        Vector2 playerInput = new()
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetButtonDown("Jump") ? 1 : 0
        };

        MovementUpdate(playerInput);
        JumpInput(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {
       

        JumpInput(playerInput);

        //horizontal movement
        transform.position += playerInput.x * velocity * Time.deltaTime;
    }

    private void JumpInput(Vector2 playerInput)
    {
        //initiate Jumping
        if (IsGrounded() && playerInput.y == 1)
        {
            float position = 0.5f * gravity * Mathf.Pow(Time.deltaTime,2f) + Jumpvelocity * Time.deltaTime;
            velocity.y -= position;
        }
        //in air
        else if (!IsGrounded())
        {
            velocity.y = gravity * Time.deltaTime + jumpVel;
        }
        else
        {
            velocity.y = 0;
        }
    }

    //walking
    public bool IsWalking()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //grounded
    public bool IsGrounded()
    {
        Vector3 origin = transform.position + Vector3.down * 0.55f;

        if (Physics2D.OverlapBox(origin, new Vector2(1f, 0.2f), 0, groundlayer))
        { return true; }
        else { return false; 
        }
    }


    //turning
    public FacingDirection GetFacingDirection()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {  
                return FacingDirection.right;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            return FacingDirection.left;
        }
        else 
        {
            return FacingDirection.right;
        }


       
    }
}
