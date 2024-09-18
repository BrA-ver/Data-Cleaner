using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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
        base.PhysicsTick();
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Attack State");
        base.Tick(deltaTime);
        enemy.LookAtTarget();
        enemy.Attack();
        bool inRange = Vector3.Distance(enemy.transform.position, enemy.target.position) <= enemy.attackDistance;
        if (inRange == false)
        {
            stateMachine.SwitchState(new EnemyChaseState(enemy, stateMachine, "move"));
            return;
        }
    }

}
