using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
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
        if (inRange == false)
        {
            stateMachine.SwitchState(new EnemyChaseState(enemy, stateMachine, "move"));
            return;
        }
        else
        {
            enemy.LookAtTarget();
        }
    }
}
