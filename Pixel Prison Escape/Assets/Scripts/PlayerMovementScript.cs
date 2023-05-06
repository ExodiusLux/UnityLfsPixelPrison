using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Movement Components")]
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private LayerMask jumpableGround;
                     bool isFacingRight = true;
                     private float dirX = 0f;

    [Header("Wall Jump Components")]
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallJumpTime;
    [SerializeField] private float wallSlideSpeed;
    [SerializeField] private float jumpTime;
                     private float wallDistance = .2f;
                     bool isWallSliding = false;
                     RaycastHit2D WallCheckHit;
                     private float wallPushForce = 5f;

    [Header("Sprite Components")]
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;

    //(Sprite animations enum) idle = 0 , running = 1, falling = 2, jumping = 3
    private enum MovementState { idle, running, falling, jumping};

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

    
        Jump();
        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate(){

       MovementState state;

       if(dirX > 0f){ //run forward
        state = MovementState.running;
        sprite.flipX = false;
        isFacingRight = true;
       }
       else if (dirX < 0f){ //run backward
        state = MovementState.running;
        sprite.flipX = true;
        isFacingRight = false;
       }
       else{ //idle
        state = MovementState.idle;
       }

       if(rb.velocity.y > .1f){ //jump up
        state = MovementState.jumping;
       }
       else if(rb.velocity.y < -.1f){ //falling down
        state = MovementState.falling;
        
       }
       anim.SetInteger("state", (int)state);

       

    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


    private void Jump(){

        if(IsGrounded()){
             if(Input.GetButtonDown("Jump")){
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        if(isFacingRight){
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0 ), wallDistance, jumpableGround);
            Debug.DrawRay(transform.position, new Vector2(wallDistance, 0), Color.blue);
        }
        else{
             WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0 ), wallDistance, jumpableGround);
             Debug.DrawRay(transform.position, new Vector2(-wallDistance, 0), Color.blue);
        }


        if(WallCheckHit && !IsGrounded() && dirX != 0){
            isWallSliding = true;
            jumpTime = Time.time + wallJumpTime;
        }
        else if(jumpTime < Time.time){
            isWallSliding = false;
        }

        if(isWallSliding){
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }

        if(isWallSliding && Input.GetButtonDown("Jump")){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
