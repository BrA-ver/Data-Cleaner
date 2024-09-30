using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIdleState : RangeEnemyState
{
    public RangeIdleState(RangeEnemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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

    public override void Tick(float deltaTime)
    {
        base.Tick(deltaTime);
        if (enemy.PlayerDetector.detected)
        {
            stateMachine.SwitchState(enemy.AttackState);
        }
    }
}
