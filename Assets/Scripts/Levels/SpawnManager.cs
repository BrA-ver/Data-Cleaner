using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    private void Awake()
    {
        instance = this;
    }

    Vector3 checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        checkpoint = newCheckpoint;
    }

    public void RespawnPlayer()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        Player.instance.gameObject.SetActive(false);
        UIManager.insance.FadeToBlack();
        yield return new WaitForSeconds(2f);
        Player.instance.transform.position = checkpoint;
        UIManager.insance.FadeToClear();
        Player.instance.gameObject.SetActive(true);
        Player.instance.GetComponent<Health>().ResetHealth();
    }
}
