using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public enum AttackState {Rest, AutoFire, Line, Tripple};
    public AttackState state = AttackState.Rest;
    public bool startFight;
    private float pattern;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        startFight = true;
        state = AttackState.Tripple;
    }

    void Update(){
        pattern += Time.deltaTime;
        if(pattern > 10){
            state = AttackState.AutoFire;
        }
        if(pattern > 15){
            state = AttackState.Rest;
            pattern = 0;
        }
    }        
}
