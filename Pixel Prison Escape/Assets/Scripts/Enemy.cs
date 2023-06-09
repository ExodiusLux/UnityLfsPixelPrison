using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int attackDamage;
    public float moveSpeed = 1f;
    public float walkSpeed = 1f;

    //private void Awake()
    //{
    //    health = maxHealth.initialValue;        
    //}
    public void TakeDamage(){
        health -= 1;
        if (health <= 0){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "PlayerHitbox"){
            TakeDamage();
        }
    }
}
