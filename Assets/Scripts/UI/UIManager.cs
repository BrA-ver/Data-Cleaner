using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager insance;
    FadeScreen fadeScreen;

    [SerializeField] Slider bulletSlider, healthSlider;


    PlayerHealth playerHealth;

    private void Awake()
    {
        if (insance)
        {
            Destroy(gameObject);
        }
        else
        {
            insance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fadeScreen = GetComponentInChildren<FadeScreen>();
        fadeScreen?.FadeToClear();

        playerHealth = FindAnyObjectByType<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.onHealthChanged.AddListener(UpdateHealthSlider);
        }
    }


    public void SetBulletSlider(int value, int max)
    {
        bulletSlider.maxValue = max;
        bulletSlider.value = value;
    }

    public void UpdateBulletSlider(int value)
    {
        bulletSlider.value = value;
    }

    public void SetHealthSlider(float value, float max)
    {
        healthSlider.maxValue = max;
        healthSlider.value = value;
    }

    private void UpdateHealthSlider(float value)
    {
        healthSlider.value = value;
        Debug.Log("Health " + value);
    }

    
}
