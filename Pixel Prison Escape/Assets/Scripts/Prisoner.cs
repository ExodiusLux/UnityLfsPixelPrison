using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner : Chaser
{
    public triggerArea attackZone; 

    public bool _hasTarget = false;
    //detects if player is in detection zone
    public bool HasTarget{
        get { return _hasTarget;} 
        private set{
            _hasTarget = value;
        }
    }
    new void Update(){
        HasTarget = attackZone.detectedColliders.Count > 0;   
        if(HasTarget && state!=MovementState.punching){
            state = MovementState.punching; anim.SetInteger("state", (int)state);
            GetComponent<PlaySound>().Play(1);
        }
        else if(state!=MovementState.punching){
            CheckDistance();
            UpdateAnimationUpdate();
            anim.SetInteger("state", (int)state);
        }
    }
    
    public void AlertObservers(string message)
    {
        if (message.Equals("AttackAnimationEnded"))
        {
            state = MovementState.idle;
            //Debug.Log("done punch");
            // Do other things based on an attack ending.
        }
    }
}
