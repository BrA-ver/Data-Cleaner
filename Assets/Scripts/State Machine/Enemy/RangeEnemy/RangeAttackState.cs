using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackState : RangeEnemyState
{
    float waitTime = 0.2f;
    float waitCounter;

    public RangeAttackState(RangeEnemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetDestination(enemy.PlayerDetector.GetPlayerPosition());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Tick(float deltaTime)
    {
        base.Tick(deltaTime);

        if (enemy.PlayerDetector.IsPlayerDetected())
        {
            bool inRange = Vector3.Distance(enemy.transform.position, enemy.PlayerDetector.GetPlayerPosition()) <= enemy.agent.stoppingDistance;
            if (inRange)
            {
                enemy.LookAtTarget(Player.instance.transform.position);
                enemy.Attack();
                enemy.Anim.SetBool("idle", true);
                enemy.Anim.SetBool("move", false);
            }
            else
            {
                UpdatePath(deltaTime);
                enemy.Anim.SetBool("idle", false);
                enemy.Anim.SetBool("move", true);
            }
        }
        else if (!enemy.PlayerDetector.IsPlayerDetected())
        {
            if (enemy.ReachedPoint())
            {
                enemy.Anim.SetBool("idle", false);
                enemy.Anim.SetBool("move", false);
                stateMachine.SwitchState(enemy.IdleState);
            }
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
