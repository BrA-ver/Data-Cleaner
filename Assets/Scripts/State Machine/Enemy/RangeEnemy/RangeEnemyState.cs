using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyState : EnemyState
{
    public RangeEnemy enemy;
    public EnemyStateMachine stateMachine;
    public string animBoolName;

    public RangeEnemyState(RangeEnemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public override void Enter()
    {
        enemy.Anim.SetBool(animBoolName, true);
    }

    public override void Exit()
    {
        enemy.Anim.SetBool(animBoolName, false);
    }

    public override void Tick(float deltaTime)
    {
        
    }
}
