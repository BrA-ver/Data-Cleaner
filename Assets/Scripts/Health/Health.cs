using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float maxhealth = 10f;
    float currentHealth = 10f;
    public UnityEvent<float> onHealthChanged;
    public UnityEvent onDied = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
        if (GameEvents.instance)
        {
            GameEvents.instance.UpdateHealthBar(currentHealth, maxhealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        onHealthChanged?.Invoke(GetHealthRatio());
        if (currentHealth <= 0f)
        {
            Kill();
        }
    }

    public void Kill()
    {
        currentHealth = 0f;
        onHealthChanged?.Invoke(GetHealthRatio());
        gameObject.SetActive(false);
        onDied?.Invoke();
    }

    public void ResetHealth()
    {
        currentHealth = maxhealth;
        onHealthChanged?.Invoke(GetHealthRatio());
    }

    public void UpdateHealth()
    {
        if (!UIManager.insance) { return; }
        UIManager.insance.SetHealthSlider(currentHealth, maxhealth);
    }

    public float GetHealthRatio()
    {
        return currentHealth / maxhealth;
    }
}
