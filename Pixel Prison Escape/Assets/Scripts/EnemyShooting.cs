using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;
    private float timer;
    public float fireRange;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distance = Vector2.Distance(transform.position, player.transform.position);

        //spawn if player is within range
        if(distance < fireRange){
            timer += Time.deltaTime;
            //shooting rate
            if(timer > 2){
                timer = 0;
                shoot();
            }
        }
    }

    void shoot(){
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
