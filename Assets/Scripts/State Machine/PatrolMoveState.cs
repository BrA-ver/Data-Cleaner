using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMoveState : EnemyState
{
    PatrolEnemy enemy;
    EnemyStateMachine stateMachine;
    string animBoolName;

    public PatrolMoveState(PatrolEnemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public override void Enter()
    {
        Debug.Log("Enter Move State");
        enemy.Anim.SetBool(animBoolName, true);
        enemy.Route();
    }

    public override void Exit()
    {
        enemy.Anim.SetBool(animBoolName, false);
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Move Tick");
        if (enemy.ReachedPoint())
        {
            enemy.IncrementPoint();
            stateMachine.SwitchState(enemy.IdleState);
        }
    }
}
