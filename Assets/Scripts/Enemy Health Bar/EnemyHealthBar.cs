using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    Slider healthSlider;
    Health enemyHealth;
    Camera cam;

    private void Awake()
    {
        healthSlider = GetComponentInChildren<Slider>();
        enemyHealth = GetComponentInParent<Health>();
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth?.onHealthChanged.AddListener(UpdateSlider);
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.transform.position);
    }

    public void UpdateSlider(float newVal)
    {
        healthSlider.value = newVal;
    }
}
