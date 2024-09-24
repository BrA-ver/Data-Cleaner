using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAttackState : EnemyState
{
    PatrolEnemy enemy;
    EnemyStateMachine stateMachine;
    string animBoolName;

    float attackCooldown = 2f;
    float attackCounter;

    public PatrolAttackState(PatrolEnemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public override void Enter()
    {
        Debug.Log("Enter Attack State");
        attackCounter = attackCooldown;
        enemy.Anim.SetBool(animBoolName, true);
        
    }

    public override void Exit()
    {
        enemy.Anim.SetBool(animBoolName, false);
    }

    public override void Tick(float deltaTime)
    {
        attackCounter += deltaTime;
        if (attackCounter >= attackCooldown)
        {
            enemy.Anim.SetTrigger("attack");
            attackCounter = 0f;
        }

        bool inRange = Vector3.Distance(enemy.transform.position, enemy.PlayerDetector.GetPlayerPosition()) <= enemy.agent.stoppingDistance;

        if (!inRange)
        {
            stateMachine.SwitchState(enemy.ChaseState);
        }

        if (!enemy.PlayerDetector.IsPlayerDetected())
        {
            stateMachine.SwitchState(enemy.IdleState);
        }
    }
}
