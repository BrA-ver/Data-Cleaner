using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    public float pathUpdateDelay = 0.2f;
    float pathUpdateDeadline;

    public float attackDelay = 2f;
    float attackCounter;
    bool canShoot = true;

    EnemyShooter shooter;

    protected override void Start()
    {
        base.Start();
        shooter = GetComponentInChildren<EnemyShooter>();
    }

    protected override void Update()
    {
        base.Update();
        if (!canShoot)
        {
            attackCounter += Time.deltaTime;
            if (attackCounter >= attackDelay)
            {
                canShoot = true;
                attackCounter = 0f;
            }
        }
    }

    protected override void Movement()
    {
        base.Movement();
        UpdatePath();
    }

    protected override void Attack()
    {
        if (!canShoot) { return; }
        base.Attack();
        shooter.Attack();
        canShoot = false;
    }

    private void UpdatePath()
    {
        bool inRange = Vector3.Distance(transform.position, target.position) <= attackDistance;
        if (inRange)
        {
            moving = false;
            LookAtTarget();
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
