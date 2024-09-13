using UnityEngine.AI;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float pathUpdateDelay = 0.2f;
    float pathUpdateDeadline;

    protected override void Movement()
    {
        base.Movement();
        UpdatePath();
    }

    private void UpdatePath()
    {
        bool inRange = Vector3.Distance(transform.position, target.position) <= attackDistance;
        if (inRange) 
        {
            moving = false;
            Attack();
            return; 
        }
        if (Time.time >= pathUpdateDeadline)
        {
            moving = true;
            Debug.Log("Updating Path");
            pathUpdateDeadline = Time.time + pathUpdateDelay;
            agent.SetDestination(target.position);
        }
    }
}
