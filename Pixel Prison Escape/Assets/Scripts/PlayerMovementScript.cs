using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovementScript : MonoBehaviour
{
    [Header("CharacterAttributes")]
    [SerializeField] private float playerHealth = 5f;
    [SerializeField] private float maxPlayerHealth = 5f;

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
                     private float wallDistance = .4f;
                     bool isWallSliding = false;
                     RaycastHit2D WallCheckHit;

    [Header("Sprite Components")]
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;
    private bool hasDied;

    //(Sprite animations enum) idle = 0 , running = 1, falling = 2, jumping = 3, wallSliding = 4
    private enum MovementState { idle, running, falling, jumping, wallSliding};

    void Start()
    {
        hasDied = false;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        playerHealth = maxPlayerHealth; //resetting player health on restart/death/etc
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
		if (dirX != 0f)
        {
            GetComponent<PlaySound>().Play(1);
        }
        if(gameObject.transform.position.y < -7)
        {
            hasDied = true;
        }
        if (hasDied == true)
        {
            StartCoroutine("Die");
        }
        Jump();
        UpdateAnimationUpdate();
    }
    IEnumerator Die()
    {
        SceneManager.LoadScene ("Level1");
        yield return null;
    }
    private void UpdateAnimationUpdate(){

       MovementState state;

       if(dirX > 0f){ //run forward
        state = MovementState.running;
        sprite.flipX = false;
        isFacingRight = true;
        GetComponent<PlaySound>().Play(1);
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
       if(isWallSliding){
        state = MovementState.wallSliding;
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
                GetComponent<PlaySound>().Play(0);
            }
            isWallSliding = false;
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
            isWallSliding = false;
        }
    }
    public void TakeDamage(float damage){
        playerHealth -= damage;
        if(playerHealth <= 0){
            SceneManager.LoadScene("Level1");
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "bullet"){
            playerHealth -= 1;
            if(playerHealth <= 0){
                SceneManager.LoadScene("Level1");
            }
        }
    }
}
