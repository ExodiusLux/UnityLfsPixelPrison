using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
  

    private float dirX = 0f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private Transform wallCheck;
    

    private float wallRadius = 0.3f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;

    //idle = 0 , running = 1, falling = 2, jumping = 3
    private enum MovementState { idle, running, falling, jumping};
    // Start is called before the first frame update
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
       }
       else if (dirX < 0f){ //run backward
        state = MovementState.running;
        sprite.flipX = true;
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
    private bool IsTouchingWall(){
        return Physics2D.OverlapCircle(wallCheck.position, wallRadius, jumpableGround);
    }


    private void Jump(){

        if(IsGrounded()){
             if(Input.GetButtonDown("Jump")){
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        else if(IsTouchingWall()){
        
        }
    }
}
