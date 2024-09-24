using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public UnityEvent <Vector3> onSetSpawn;
    public UnityEvent<float> onPlayerDisable;
    public UnityEvent onPlayerRespawn = new UnityEvent();

    PlayerHealth playerHealth;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        playerHealth = FindAnyObjectByType<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.onDied.AddListener(RespawnPlayer);
        }
    }

    Vector3 checkpoint;

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
        yield return new WaitForSeconds(2f);
        Player.instance.transform.position = checkpoint;
        
        Player.instance.gameObject.SetActive(true);
        Player.instance.GetComponent<Health>().ResetHealth();
        onPlayerRespawn?.Invoke();
    }
}
