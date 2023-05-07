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
        if(health <= 0){
            boss.health -= 1;
            Destroy(gameObject);
        }
        anim.SetInteger("state", (int)state);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && state != PanelState.Blink){   
            health--;
            state = PanelState.Blink;
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
