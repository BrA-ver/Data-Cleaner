using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelEnd : MonoBehaviour
{
    public string nextLevel;


    private void OnTriggerEnter(Collider other)
    {
        SwitchLevel();
    }

    void SwitchLevel()
    {
        if (nextLevel == string.Empty) { return; }
        StartCoroutine(Switch());
    }

    IEnumerator Switch()
    {
        // Immidiatly change the scene if we don't have a UI manager and break out of the coroutine
        if (!UIManager.insance)
        {
            SceneManager.LoadScene(nextLevel);
            yield break;
        }
        
        // If we do have a UI manager fade the screen to black and switch to the next level
        UIManager.insance.FadeToBlack();
        yield return new WaitForSeconds(UIManager.insance.fadeTime);
        SceneManager.LoadScene(nextLevel);
    }
}
