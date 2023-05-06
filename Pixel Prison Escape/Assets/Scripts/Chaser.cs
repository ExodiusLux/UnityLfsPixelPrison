using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    private SpriteRenderer sprite;
    public Animator anim;
    //public Transform home;
    public float chaseRadius;
    public float attackRadius;
    Vector3 direction;
    private bool facingRight;
    [SerializeField] private LayerMask jumpableGround;   
    private BoxCollider2D coll; 

    public enum MovementState{
        idle,
        walking,
        running,
        shooting,
        punching
    }

    public MovementState state = MovementState.idle;
    public void Start()
    {
        facingRight = true;
        target = GameObject.FindWithTag("Player").transform;
        myRigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();        
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        CheckDistance();
        UpdateAnimationUpdate();
        anim.SetInteger("state", (int)state);
    }

    public void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius && IsGrounded()){
            direction = target.transform.position - transform.position;
            myRigidbody.velocity = new Vector2(direction.x, transform.position.y).normalized * moveSpeed;
        }
    }
    public void UpdateAnimationUpdate(){
        if(myRigidbody.velocity.x > 0f){ //run forward
            state = MovementState.running;
            //sprite.flipX = false;
            if(!facingRight){flip();}
            facingRight = true;
        }
        else if (myRigidbody.velocity.x < 0f){ //run backward
            state = MovementState.running;
            //sprite.flipX = true;
            
            if(facingRight){flip();}
            facingRight = false;
        }
        else{ //idle
            state = MovementState.idle;
        }
    }

    private void flip(){
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }    
}
