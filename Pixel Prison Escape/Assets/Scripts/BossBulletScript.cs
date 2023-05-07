using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D myRb;
    public float bulletSpeed;
    private float timer;
    public float timeOut = 2;
    private int shotType = 0;
    public string path;
    public int direct;

    public int bulletType;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();

        if(bulletType == 1){

        //find player position
        player = GameObject.FindGameObjectWithTag("Player");

        //move towards player
        Vector3 direction = player.transform.position - transform.position;
        myRb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;

        //bullet rotation based on player position
        float rot = Mathf.Atan2(-direction.y, -direction.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot+180);
        }
        else if(bulletType == 2){
            if(path == "Right"){
                myRb.velocity = new Vector2(bulletSpeed, 0);
            }
            else if(path == "Left"){
                myRb.velocity = new Vector2(-bulletSpeed, 0);
            }
            else if(path == "Up"){
                myRb.velocity = new Vector2(0, bulletSpeed);
            }
            else if(path == "Down"){
                myRb.velocity = new Vector2(0, -bulletSpeed);
            }
        }
        else if(bulletType == 3){
            if(direct == 0){
                if(path == "Left"){
                    myRb.velocity = new Vector2(-2, -2).normalized * bulletSpeed;
                }
                else if(path == "Right"){
                    myRb.velocity = new Vector2(2, 2).normalized * bulletSpeed;
                }
                else if(path == "Up"){
                    myRb.velocity = new Vector2(-2, 2).normalized * bulletSpeed;
                }
                else if(path == "Down"){
                    myRb.velocity = new Vector2(2, -2).normalized * bulletSpeed;
                }
            }
            if(direct == 1){
                if(path == "Left"){
                    myRb.velocity = new Vector2(-2, 0).normalized * bulletSpeed;
                }
                else if(path == "Right"){
                    myRb.velocity = new Vector2(2, 0).normalized * bulletSpeed;
                }
                else if(path == "Up"){
                    myRb.velocity = new Vector2(0, 2).normalized * bulletSpeed;
                }
                else if(path == "Down"){
                    myRb.velocity = new Vector2(0, -2).normalized * bulletSpeed;
                }
            }
            else if (direct == 2){
                if(path == "Left"){
                    myRb.velocity = new Vector2(-2, 2).normalized * bulletSpeed;
                }
                else if(path == "Right"){
                    myRb.velocity = new Vector2(2, -2).normalized * bulletSpeed;
                }
                else if(path == "Up"){
                    myRb.velocity = new Vector2(2, 2).normalized * bulletSpeed;
                }
                else if(path == "Down"){
                    myRb.velocity = new Vector2(-2, -2).normalized * bulletSpeed;
                }
            }
        }
    }

    void Update()
    {

        timer += Time.deltaTime;
        if(timer > timeOut){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
            //TODO remove player health
            Destroy(gameObject);
        
    }
}
