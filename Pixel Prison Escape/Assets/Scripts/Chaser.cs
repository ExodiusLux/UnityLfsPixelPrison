using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public SpriteRenderer sprite;
    private Animator anim;
    //public Transform home;
    public float chaseRadius;
    public float attackRadius;
    Vector3 direction;

    public enum MovementState{
        idle,
        walking,
        running
    }

    public MovementState state = MovementState.idle;
    public void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        myRigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    public void Update()
    {
        CheckDistance();
        UpdateAnimationUpdate();
        anim.SetInteger("state", (int)state);
    }

    public void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius){
            direction = target.transform.position - transform.position;
            myRigidbody.velocity = new Vector2(direction.x, transform.position.y).normalized * moveSpeed;
        }
    }
    public void UpdateAnimationUpdate(){
        if(myRigidbody.velocity.x > 0f){ //run forward
            state = MovementState.running;
            sprite.flipX = false;
            //Debug.Log("x > 0");
        }
        else if (myRigidbody.velocity.x < 0f){ //run backward
            state = MovementState.running;
            sprite.flipX = true;
        }
        else{ //idle
            state = MovementState.idle;
            //Debug.Log("x = 0");
        }
    }
}
