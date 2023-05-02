using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Enemy
{
    

    Rigidbody2D myRigidbody;
    public triggerArea attackZone;

    private SpriteRenderer sprite;
    private Animator anim;
    private enum MovementState{
        walking,
        idle,
        punching
    }

    public bool _hasTarget = false;
    //detects if player is in detection zone
    public bool HasTarget{
        get { return _hasTarget;} 
        private set{
            _hasTarget = value;
        }
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    MovementState state = MovementState.walking;
    void Update()
    {
        //player in attack range
        HasTarget = attackZone.detectedColliders.Count > 0;

        if(HasTarget && state!=MovementState.punching){state = MovementState.punching;}
        else if(isFacingRight()&&state!=MovementState.punching){
            //walk right
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
            state = MovementState.walking;
        }
        else if (!isFacingRight()&&state!=MovementState.punching){
            //walk left
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
            state = MovementState.walking;
        }

        anim.SetInteger("state", (int)state);

    }


    //finds edge of ground
    //when ground colldider exits the enemy's detection collider, enemy is turned around
    private void OnTriggerExit2D(Collider2D collider) {
        //prevents player exiting the detection collider from flipping enemy
        if(collider.gameObject.tag != "Player" && collider.gameObject.tag != "Wall"){   
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D collider) {
        //prevents player exiting the detection collider from flipping enemy
        if(collider.gameObject.tag == "Wall"){   
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);
        }
    }*/
    private bool isFacingRight(){
        return transform.localScale.x > Mathf.Epsilon;
    }

    //detects the end of enemy punching animation
    public void AlertObservers(string message)
    {
        if (message.Equals("AttackAnimationEnded"))
        {
            state = MovementState.walking;
            // Do other things based on an attack ending.
        }
    }
}


