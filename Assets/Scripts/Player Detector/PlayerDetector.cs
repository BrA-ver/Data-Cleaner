using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public LayerMask layer;
    public bool playerInRange;
    public bool detected;
    Transform player;
    SphereCollider sphereCollider;

    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (playerInRange)
        {
            transform.LookAt(player.position);
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, sphereCollider.radius, layer))
            {
                Debug.DrawRay(ray.origin, transform.forward * hit.distance, Color.yellow);

                if (hit.collider.CompareTag("Player"))
                {
                    //Debug.Log(Vector3.Distance(transform.position, player.position));
                    detected = true;
                    return;
                }
            }

            detected = false;
        }
    }

    public Vector3 GetPlayerPosition()
    {
        return player.position;
    }

    public bool IsPlayerDetected()
    {
        return detected;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        
        if (other.transform.GetComponent<Player>())
        {
            player = other.transform.GetComponent<Player>().transform;
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.GetComponent<Player>())
        {
            playerInRange = false;
            detected = false;
        }
    }
}
