using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner : Chaser
{
    void Start()
    {
        //target = GameObject.FindWithTag("Player").transform;
        //myRigidbody = GetComponent<Rigidbody2D>();
        //sprite = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();     
    }

    void Update()
    {
        CheckDistance();
    }
    
}
