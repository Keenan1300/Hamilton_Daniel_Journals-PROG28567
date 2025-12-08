using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Vector3 velocity = new Vector3(2, 2, 0);

    public float maxSpeed = 10;
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


    //Movement mechanic
    public float movement;
    private float rollingcoold = 30;
    private bool isrolling;

    private float jumpVel;
    private float gravity;



    public LayerMask groundlayer;


    public enum FacingDirection
    {
        left, right, current
    }
    public FacingDirection currentdirection;

    // Start is called before the first frame update
    void Start()
    {
        isrolling = false;
        liveCoyoteTime = CoyoteTime;
        accelSpeed = maxSpeed / accelerationTime;
        decelSpeed = maxSpeed / decelerationTime;

        jumpVel = 2 * apexHeight / apexTime;
        gravity = -2 * apexHeight / (Mathf.Pow(apexTime, 2f));
    }

    // Update is called once per frame
    void Update()
    {
        //roll cool down
        if (rollingcoold > 0) rollingcoold -= 0.5f;
        print(rollingcoold);

        //Check constantly if character is running into a wall
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            movement = Input.GetAxisRaw("Horizontal");
        }

        //Detection Boundary
        Vector3 Check = transform.position + new Vector3(movement, 0, 0);


        //Horizontal Mechanic
        if (Input.GetKeyUp(KeyCode.R) && !isrolling)
        {
            if (rollingcoold < 1)
            {
                rollInput(Check);
            }
        }

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

        if (velocity.x < maxSpeed || velocity.x > maxSpeed * -1)
            velocity.x += playerInput.x * accelSpeed * Time.deltaTime;

        //deceleration
        if (Input.GetAxisRaw("Horizontal") == 0 && velocity.x != 0)
        {
            velocity.x /= decelSpeed;
        }


    }


    //Horizontal Mechanic - Roll
    private void rollInput(Vector3 Check)
    {
        if (IsGrounded())
        {

            for (int i = 2; i > 1; i--)
            {
                if (!infrontofwall(Check))
                {
                    isrolling = true;
                    Rolling();
                    print("activated");
                    velocity *= 3f;
                    
                }
                else
                {
                    velocity = Vector3.zero;
                }
            }
            rollingcoold = 200f;
            isrolling = false;
        }


    }

    //Vertical Mechanic - Wall Jump



    //Physics Mechanic - Ball Bounce


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

    public bool infrontofwall(Vector3 Check)
    {

        if (Physics2D.OverlapBox(Check, new Vector2(1f, 0.2f), 0, groundlayer))
        {
            print("wall touching");
            return true;
        }
        else
        {
            return false;
        }
    }


    public bool Rolling()
    {
        return true;
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
            return FacingDirection.current;
        }
        


    }

 
}
