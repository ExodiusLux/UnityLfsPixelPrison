using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerArea : MonoBehaviour
{
    public List<Collider2D> detectedColliders = new List<Collider2D>();
    Collider2D col;

    private void Awake() {
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player"){
           detectedColliders.Add(collision); 
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            detectedColliders.Remove(collision);
        }
    }
}
