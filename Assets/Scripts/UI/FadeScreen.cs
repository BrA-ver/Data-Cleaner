using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] Image fadeScreen;
    Color fadeColor = Color.black;

    bool fade, clear;
    [SerializeField] public float fadeTime = 2f;

    PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        fadeScreen = GetComponent<Image>();
        player = FindAnyObjectByType<PlayerHealth>();
        if (player)
        {
            player.onDied.AddListener(FadeToBlack);
        }

        if (SpawnManager.instance)
        {
            SpawnManager.instance.onPlayerRespawn.AddListener(FadeToClear);
        }
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

    public void FadeToBlack()
    {
        fade = true;
    }

    public void FadeToClear()
    {
        clear = true;
    }
}
