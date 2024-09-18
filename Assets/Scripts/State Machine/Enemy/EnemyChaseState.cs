using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Switch");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PhysicsTick()
    {
        throw new System.NotImplementedException();
    }

    public override void Tick(float deltaTime)
    {
        bool inRange = Vector3.Distance(enemy.transform.position, enemy.target.position) <= enemy.attackDistance;
        if (inRange)
        {
            stateMachine.SwitchState(new EnemyAttackState(enemy, stateMachine, "idle"));
            return;
        }
        enemy.Movement();
        Debug.Log("Chasing");
    }
}
