using JetBrains.Annotations;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Vector3 velocity = new Vector3(2, 2, 0);

    public float maxSpeed = 12;
    public float accelerationTime = 2;
    public float decelerationTime = 2;
    
    [Header("Jump properties")]
    public float apexHeight = 5;
    public float apexTime = 3;

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
        accelSpeed = maxSpeed / accelerationTime;
        decelSpeed = maxSpeed / decelerationTime;

        jumpVel = 2 * apexHeight / apexTime;
        gravity = -2 * apexHeight / (Mathf.Pow(apexTime, 2f));
    }

    // Update is called once per frame
    void Update()
    {

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
        velocity.x += playerInput.x * accelSpeed * Time.deltaTime;

    }

    private void JumpInput(Vector2 playerInput)
    {
        //initiate Jumping
        if (IsGrounded() && playerInput.y == 1)
        {
            velocity.y = jumpVel;
        }
        //in air
        else if (!IsGrounded())
        {
            velocity.y += gravity * Time.deltaTime;
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
