using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelEnd : MonoBehaviour
{
    public string nextLevel;
    public UnityEvent onLevelComplete = new UnityEvent();


    private void OnTriggerEnter(Collider other)
    {
        AudioManager.Instance.PlaySFX("Win");
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

        onLevelComplete?.Invoke();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextLevel);
    }
}
