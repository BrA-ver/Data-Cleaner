using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCheckpoint()
    {
        // Set the player's respawn position
        SpawnManager.instance.SetCheckpoint(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        SetCheckpoint();
    }
}