using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHandler : MonoBehaviour
{
    public static TargetHandler instance;

    [SerializeField]
    List<Enemy> targets = new List<Enemy>();

    public bool EnemyDetected { get; private set; }
    public bool HasTarget { get; private set; }

    public Vector3 DirectionToClosest { get; private set; }
    public float ClosestDistance { get; private set; }

    Collider thisCollider;

    private void Awake()
    {
        instance = this;
        thisCollider = GetComponent<Collider>();
    }



    private void Update()
    {
        //// If there is at least one target in the targets array then there is an enemy detected
        //EnemyDetected = targets.Count > 0;

        //if (EnemyDetected)
        //{
        //    Enemy closestTarget = null;  // Create a local target to store the closest target
        //    ClosestDistance = Mathf.Infinity; // make the closest distance be an absurdly large number so that every other distance is always smaller
        //    HasTarget = false;

        //    // Go through the targets array and find the closest one
        //    foreach (Enemy target in targets)
        //    {
        //        if (!target.transform.gameObject.activeSelf)
        //        {
        //            return;
        //        }
        //        // Create a local float to store the current distance
        //        float currentDistance = Vector3.Distance(transform.position, target.transform.position);

        //        // If the current distance is less than the closest distance last recorded then change the closest distance to be the 
        //        // current distance
        //        // We also need the closest target so make it be this loop itteration's target
        //        if (currentDistance < ClosestDistance)
        //        {
        //            closestTarget = target;
        //            ClosestDistance = currentDistance;
        //        }
        //    }

        //    if (closestTarget)
        //    {
        //        HasTarget = true;
        //        DirectionToClosest = closestTarget.transform.position - transform.position;
        //        DirectionToClosest.Normalize();
        //    }
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("c");
        if (other.CompareTag("Enemy"))
        {
            targets.Add(other.GetComponentInParent<Enemy>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targets.Remove(other.GetComponentInParent<Enemy>());
            Debug.Log("Target Left");
        }
    }

    public void ResetList()
    {
        // Remove everything in the targets list
        targets.Clear();

        // Turn the collider off and on again
        // this will trigger the OntriggerEntered event will will check to see if there are any targets and add them to the list
        // This way we are not keeping track of destroyed objects
        thisCollider.enabled = false;
        thisCollider.enabled = true;
    }



}
