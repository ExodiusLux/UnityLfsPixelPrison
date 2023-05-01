using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    Rigidbody2D myRigidbody;

    private SpriteRenderer sprite;
    private Animator anim;
    private enum MovementState{
        idle,
        walking
        //,shooting
    }

    MovementState state = MovementState.idle;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
