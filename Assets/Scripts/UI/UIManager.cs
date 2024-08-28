using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager insance;

    [SerializeField] Slider bulletSlider, healthSlider;
    [SerializeField] Image fadeScreen;

    Color fadeColor = Color.black;
    bool fade;
    bool clear;
    [SerializeField] float fadeTime = 2f;
    float fadeCounter;

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
        FadeToClear();
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            fadeScreen.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeScreen.color.a + (fadeTime * Time.deltaTime));
            if (fadeScreen.color.a >= 1)
            {
                fade = false;
            }
        }
        else if (clear)
        {
            fadeScreen.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, fadeScreen.color.a - (fadeTime * Time.deltaTime));
            if (fadeScreen.color.a <= 0f)
            {
                clear = false;
            }
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

    public void UpdateHealthSlider(float value)
    {
        healthSlider.value = value;
    }

    public void FadeToBlack()
    {
        fade = true;
        fadeCounter = fadeTime;
    }

    public void FadeToClear()
    {
        clear = true;
    }
}
