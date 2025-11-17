using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 velocity;
    public float gravity;
    public float jumpVel;
    public LayerMask groundlayer;

    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.
        Vector2 playerInput = new()
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetButtonDown("Jump") ? 1 : 0
        };

        MovementUpdate(playerInput);
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        JumpInput(playerInput);
        transform.position += playerInput.x * velocity * Time.deltaTime;
    }

    private void JumpInput(Vector2 playerInput)
    {
        if (IsGrounded() && playerInput.y == 1)
            velocity.y = jumpVel;
        else if (!IsGrounded())
            velocity.y += gravity * Time.deltaTime;
        else
            velocity.y = 0;

    }

    public bool IsWalking()
    {
        
        return false;
    }
    public bool IsGrounded()
    {
        Vector3 origin = transform.position + Vector3.down * 0.55f;

        return Physics2D.OverlapBox(origin,new Vector2 (1f,0.2f), 0, groundlayer);
    }

    public FacingDirection GetFacingDirection()
    {
        return FacingDirection.left;
    }
}
