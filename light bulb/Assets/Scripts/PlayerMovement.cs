using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;
    public float horizontalValue;
    
    public float currentSpeed;

    bool jumpPressed;
    bool onGround;
    bool isJumping;

    public float maxSpeed = 7.5f;
    public float accel = 1f;
    public float decel = 0.5f;

    public LayerMask mask;
    public float jumpStrength = 20f;
    public float jumpGravity = 4.5f;
    public float fallGravity = 6f;
    public float hopGravity = 16f;

    public float jumpBufferSeconds = 0.1f;
    public float bufferLeftSeconds = 0f;

    public float yVelocityThreshold = .1f;
    
    public float groundedSkin = 0.2f;
    Vector2 playerSize;
    Vector2 boxSize;

    public Vector2 initialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerSize = GetComponent<BoxCollider2D>().size;
        boxSize = new Vector2(playerSize.x - 0.05f, groundedSkin);

        rb.gravityScale = 1f;

        currentSpeed = 0;

        initialPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");

        currentSpeed = rb.velocity.x;
        animator.SetFloat("Speed", Mathf.Abs(currentSpeed));

        if(checkGrounded() && (Input.GetButtonDown("Jump") || bufferLeftSeconds > 0))
        {
            isJumping = true;
            jumpPressed = true;
        }
        else if(Input.GetButtonDown("Jump"))
        {
            bufferLeftSeconds = jumpBufferSeconds;
        }
        else if(!Input.GetButton("Jump"))
        {
            jumpPressed = false;
        }

        if(bufferLeftSeconds > 0)
        {
            bufferLeftSeconds = Mathf.Max(0f, bufferLeftSeconds - Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        jump();
        move();
    }

    void move()
    {
        float speed = currentSpeed;
        
        if(horizontalValue == 0)
        {
            speed *= decel;
        }
        else if(speed * horizontalValue < 0)
        {
            speed += horizontalValue * (accel + decel);
        }
        else if(speed * horizontalValue >= 0)
        {
            speed += horizontalValue * accel;
        }

        if(Mathf.Abs(speed) < 0.1f)
        {
            speed = 0f;
        }
        else
        {
            speed = Mathf.Clamp(speed, -1 * maxSpeed, maxSpeed);
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void jump()
    {
        if(isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            
            //Initial jump: add impulse force upwards
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            isJumping = false;
            bufferLeftSeconds = 0f;
        }
        
        if(Mathf.Abs(rb.velocity.y) <= yVelocityThreshold)
        {
            rb.gravityScale = jumpGravity;
        }
        else if(rb.velocity.y < 0)
        {
            rb.gravityScale = fallGravity;
        }
        else if(rb.velocity.y > 0)
        {   
            if(jumpPressed)
            {
                rb.gravityScale = jumpGravity;
            }
            else
            {
                rb.gravityScale = hopGravity;
            }
            
        }
    }

    bool checkGrounded()
    {
        Vector2 boxCenter = (Vector2)transform.position + Vector2.down * (playerSize.y + boxSize.y) * 0.5f;
        onGround = (Physics2D.OverlapBox(boxCenter, boxSize, 0.05f, mask) != null);

        return onGround;
    }
    
}
