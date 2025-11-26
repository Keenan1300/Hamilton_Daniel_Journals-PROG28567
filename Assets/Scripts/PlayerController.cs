using JetBrains.Annotations;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Vector3 velocity = new Vector3(2, 2, 0);

    public float maxSpeed = 5;
    public float accelerationTime = 2;
    public float decelerationTime = 2;
    
    [Header("Jump properties")]
    public float apexHeight = 5;
    public float apexTime = 3;
    public float termvelo = 4;
    public float CoyoteTime = 3;
    private float liveCoyoteTime;

    private float accelSpeed;
    private float decelSpeed;

    private float jumpVel;
    private float gravity;

    
    public LayerMask groundlayer;


    public enum FacingDirection
    {
        left, right
    }
    public FacingDirection currentdirection;

    // Start is called before the first frame update
    void Start()
    {
        liveCoyoteTime = CoyoteTime;
        accelSpeed = maxSpeed / accelerationTime /3f;
        decelSpeed = maxSpeed / decelerationTime /3f;

        jumpVel = 2 * apexHeight / apexTime;
        gravity = -2 * apexHeight / (Mathf.Pow(apexTime, 2f));
    }

    // Update is called once per frame
    void Update()
    {
        //debug 
        print(liveCoyoteTime);

        Vector2 playerInput = new()
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetButtonDown("Jump") ? 1 : 0
        };

        MovementUpdate(playerInput);

        transform.position += velocity * Time.deltaTime;
    }

    private void MovementUpdate(Vector2 playerInput)
    {

        JumpInput(playerInput);

        //horizontal movement

        if(velocity.x < maxSpeed ||  velocity.x > maxSpeed * -1)
        velocity.x += playerInput.x * accelSpeed * Time.deltaTime;

        //deceleration
        if (Input.GetAxisRaw("Horizontal") == 0 && velocity.x != 0)
        {
            velocity.x /= decelSpeed;
        }


    }

    private void JumpInput(Vector2 playerInput)
    {
        //initiate Jumping
        if (IsGrounded() && playerInput.y == 1)
        {
            velocity.y = jumpVel;
        }

        //Terminal velocity
        else if (!IsGrounded())
        {
            
            liveCoyoteTime -= 7 * Time.deltaTime;

            //Activate coyote jump
            if (liveCoyoteTime > 0 && playerInput.y == 1)
            {
                velocity.y = jumpVel;
                liveCoyoteTime = 0;
            }

            //term velocity
            if (velocity.y > termvelo * -1)
            { velocity.y += gravity * Time.deltaTime; }
            
        }
        else
        {
            liveCoyoteTime = CoyoteTime;
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
        else
        {
            return false;
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
            return FacingDirection.left;
        }



    }
}
