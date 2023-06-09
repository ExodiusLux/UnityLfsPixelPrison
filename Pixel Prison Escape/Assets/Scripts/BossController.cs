using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject exitDoor;
    public Transform exitPosition;
    public enum AttackState {Rest, AutoFire, Line, Tripple};
    public AttackState state = AttackState.Rest;
    public bool startFight;
    private float pattern;
    public float health;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
        Debug.Log("enter");
        if(health > 0){
            startFight = true;
            state = AttackState.Tripple;
        }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){

        startFight = false;
        Debug.Log("exit");
        state = AttackState.Rest;
        }
    }
    public void TakeDamage(float damage){
        health -= damage;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
    void Update(){
        if(health > 0){
            pattern += Time.deltaTime;
            if(pattern > 10){
                state = AttackState.AutoFire;
            }
            if(pattern > 15){
                state = AttackState.Rest;
            }
            if(pattern > 20){
                state = AttackState.AutoFire;
            }
            if(pattern > 30){
                state = AttackState.Rest;
            }
            if(pattern > 40){ 
                pattern = 0;
                state = AttackState.Tripple;
            }

        }
        else {
            state = AttackState.Rest;
            GameObject ex = Instantiate(exitDoor, exitPosition.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);}  
    }        
}
