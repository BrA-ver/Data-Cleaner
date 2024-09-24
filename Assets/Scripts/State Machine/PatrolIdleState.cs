using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolIdleState : EnemyState
{
    PatrolEnemy enemy;
    EnemyStateMachine stateMachine;
    string animBoolName;

    float waitCounter;
    public PatrolIdleState(PatrolEnemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public override void Enter()
    {
        Debug.Log("Enter Idle State");
        enemy.Anim.SetBool(animBoolName, true);
    }

    public override void Exit()
    {
        enemy.Anim.SetBool(animBoolName, false);
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Idle Tick");
        waitCounter += deltaTime;
        if (waitCounter >= enemy.waitTime)
        {
            waitCounter = 0f;
            stateMachine.SwitchState(enemy.MoveState);
        }
    }
}
