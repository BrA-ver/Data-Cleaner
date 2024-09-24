using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolChaseState : EnemyState
{
    PatrolEnemy enemy;
    EnemyStateMachine stateMachine;
    string animBoolName;

    float waitTime = 0.2f;
    float waitCounter;

    public PatrolChaseState(PatrolEnemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public override void Enter()
    {
        Debug.Log("Enter Chase State");
        enemy.Anim.SetBool(animBoolName, true);
        enemy.SetDestination(enemy.PlayerDetector.GetPlayerPosition());
    }

    public override void Exit()
    {
        enemy.Anim.SetBool(animBoolName, false);
    }

    public override void Tick(float deltaTime)
    {
        if (enemy.PlayerDetector.IsPlayerDetected())
        {
            UpdatePath(deltaTime);
            if (enemy.ReachedPoint())
            {
                stateMachine.SwitchState(enemy.AttackState);
            }
        }
        else if (enemy.ReachedPoint())
        {
            stateMachine.SwitchState(enemy.IdleState);
        }
    }

    void UpdatePath(float deltaTime)
    {
        waitCounter += deltaTime;
        if (waitCounter >= waitTime)
        {
            waitCounter = 0f;
            enemy.SetDestination(enemy.PlayerDetector.GetPlayerPosition());
        }
    }
}
