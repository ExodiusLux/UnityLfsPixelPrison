using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : Enemy
{
    Rigidbody2D myRigidbody;
    public Transform target;
    private SpriteRenderer sprite;
    private Animator anim;
    //public Transform home;
    public float chaseRadius;
    public float attackRadius;

    private enum MovementState{
        idle,
        walking
        //,shooting
    }

    MovementState state = MovementState.idle;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        myRigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        anim.SetInteger("state", (int)state);
    }

    void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius){
            Vector3 newPos = transform.position;
            newPos.x = Mathf.MoveTowards(transform.position.x, target.position.x, moveSpeed*Time.deltaTime);
            transform.position = newPos;
            state = MovementState.walking;
        }
        else state = MovementState.idle;
    }
}
