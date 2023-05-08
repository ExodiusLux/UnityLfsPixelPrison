using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPanel : MonoBehaviour
{
    public float health;
    private BoxCollider2D coll; 
    public BossController boss;
    private Animator anim;
    private enum PanelState{
        On ,Blink
    }
    PanelState state = PanelState.On;

    // Start is called before the first frame update
    void Start()
    {
        state = PanelState.On;
        coll = GetComponent<BoxCollider2D>();
        health = 5;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("state", (int)state);
    }
    
  
    public void TakeDamage(float damage){
        health -= damage;
         if(health <= 0){
            boss.health -= 1;
            Destroy(gameObject);
        }
    }
    public void AlertObservers(string message)
    {
        if (message.Equals("DamageDone"))
        {
            state = PanelState.On;
        }
    }
}
