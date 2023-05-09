using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(healthAmount <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void TakeDamagePlayer(float damage){
        Debug.Log("Taking Damage");
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
    public void HealPlayer(float healingAmount){
        Debug.Log("Healing Damage");
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0 , 100);
        healthBar.fillAmount = healthAmount / 100f;
    }
}
