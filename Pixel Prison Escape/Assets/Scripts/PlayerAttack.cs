using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("AttackTime")]
    [SerializeField] private float timeBetweenAttack;
    [SerializeField] private float startTimeBetweenAttack;

    [Header("AttackRange")]
    [SerializeField] private float attackRangeX;
    [SerializeField] private float attackRangeY;

    [Header("AttackAttributes")]
    [SerializeField] LayerMask whatIsEnemies;
    [SerializeField] private int damage;

     Animator anim;
     public Transform attackPos;
    void Start(){
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(timeBetweenAttack <= 0){
            if(Input.GetMouseButtonDown(0)){
                anim.SetBool("isAttacking", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeX), 0);
                for(int i = 0; i < enemiesToDamage.Length; i++){
                    //enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                 timeBetweenAttack = startTimeBetweenAttack;
            }
           
        }    
        else
        {
            timeBetweenAttack -= Time.deltaTime;
            anim.SetBool("isAttacking", false);
        }
    }
  void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
