using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfectionTracker : MonoBehaviour
{
    Enemy[] enemiesArray;
    float enemyMax;
    Slider contamSlider;

    [SerializeField] TextMeshProUGUI contamText;

    private void Awake()
    {
        contamSlider = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        enemiesArray = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemiesArray)
        {
            enemyMax++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Enemy[] currentEnemies = FindObjectsOfType<Enemy>();
        float currentNum = 0;
        foreach (Enemy enemy in currentEnemies)
        {
            currentNum++;
        }

        contamSlider.value = (currentNum / enemyMax);
        Debug.Log(currentNum);

        if (currentNum <= 0)
        {
            contamText.text = "Contamination Clear";
        }
        else
        {
            contamText.text = "Contamination Level " + Mathf.Floor((currentNum / enemyMax) * 100f) + "%";
        }
    }
}
