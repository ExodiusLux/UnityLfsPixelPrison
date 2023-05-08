using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int attackDamage;
    public float moveSpeed = 1f;
    public float walkSpeed = 1f;

    private void Awake()
    {
        health = maxHealth.initialValue;        
    }
    public void TakeDamage(float damage){
        health -= damage;
        if (health <= 0){
            Destroy(gameObject);
        }
    }
}
