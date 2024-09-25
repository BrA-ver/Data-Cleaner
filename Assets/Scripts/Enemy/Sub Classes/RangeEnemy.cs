using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    public EnemyShooter Shooter { get; private set; }

    public float pathUpdateDelay = 0.2f;
    float pathUpdateDeadline;
    bool canShoot = true;

    public float attackDistance = 5f;

    public RangeIdleState IdleState { get; private set; }
    public RangeAttackState AttackState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Shooter = GetComponentInChildren<EnemyShooter>();

        IdleState = new RangeIdleState(this, StateMachine, "idle");
        AttackState = new RangeAttackState(this, StateMachine, "move");
    }

    private void Start()
    {
        StateMachine.SwitchState(IdleState);
        agent.stoppingDistance = attackDistance;
    }

    protected override void Update()
    {
        base.Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

    public override void Attack()
    {
        base.Attack();
        if (canAttack)
        {
            Shooter.Attack();
        }
    }

}