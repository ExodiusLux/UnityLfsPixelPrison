using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;
    private float timer;
    public float fireRange;
    private bool attackOne;
    public bool startFight = false;
    public int attack = 1;
    public string direction;
    public BossController boss;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        startFight = boss.startFight;
        attack = (int)boss.state;
        //distance to player
        //float distance = Vector2.Distance(transform.position, player.transform.position);

        //start auto attack

        if(startFight && attack != 0){// && attack == 2){//} && distance < fireRange){
            timer += Time.deltaTime;
            if(timer > .5){
                timer = 0;
                if(attack == 3){tripleShot();}
                else shoot();
            }
        }
    }

    private void shoot(){
        GameObject bull = Instantiate(bullet, bulletPos.position, Quaternion.identity) as GameObject;
        bull.GetComponent<BossBulletScript>().path = direction;
        bull.GetComponent<BossBulletScript>().bulletType = attack;
    }

    private void tripleShot(){
        int order = 2;
        GameObject bull1 = Instantiate(bullet, bulletPos.position, Quaternion.identity) as GameObject;
        bull1.GetComponent<BossBulletScript>().path = direction;
        bull1.GetComponent<BossBulletScript>().bulletType = attack;        
        bull1.GetComponent<BossBulletScript>().direct = order;
        order--;
        GameObject bull2 = Instantiate(bullet, bulletPos.position, Quaternion.identity) as GameObject;
        bull2.GetComponent<BossBulletScript>().path = direction;
        bull2.GetComponent<BossBulletScript>().bulletType = attack;
        bull2.GetComponent<BossBulletScript>().direct = order;
        order--;
        GameObject bull3 = Instantiate(bullet, bulletPos.position, Quaternion.identity) as GameObject;
        bull3.GetComponent<BossBulletScript>().path = direction;
        bull3.GetComponent<BossBulletScript>().bulletType = attack;        
        bull3.GetComponent<BossBulletScript>().direct = order;
    }
    
}
