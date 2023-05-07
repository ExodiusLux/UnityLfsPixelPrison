using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D myRb;
    public float bulletSpeed;
    private float timer;
    public float timeOut = 2;

    void Start()
    {
        //find player position
        myRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        //move towards player
        Vector3 direction = player.transform.position - transform.position;
        myRb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;

        //bullet rotation based on player position
        float rot = Mathf.Atan2(-direction.y, -direction.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot+180);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeOut){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //if(other.gameObject.CompareTag("Player")){
            //TODO remove player health
            Destroy(gameObject);
       // }
    }
}
