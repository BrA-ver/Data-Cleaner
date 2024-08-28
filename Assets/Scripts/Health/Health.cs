using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxhealth = 10f;
    float currentHealth = 10f;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.insance.SetHealthSlider(currentHealth, maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstaKill()
    {
        currentHealth = 0f;
        UIManager.insance.UpdateHealthSlider(currentHealth);
        SpawnManager.instance.RespawnPlayer();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UIManager.insance.UpdateHealthSlider(currentHealth);
        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            UIManager.insance.UpdateHealthSlider(currentHealth);
            SpawnManager.instance.RespawnPlayer();
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxhealth;
        UIManager.insance.UpdateHealthSlider(currentHealth);
    }
}
