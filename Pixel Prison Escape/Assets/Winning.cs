using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll){
        SceneManager.LoadScene("WinScreen");
    }
}
