using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : State
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;
    protected string animBoolName;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public override void Enter()
    {
        enemy.anim.SetBool(animBoolName, true);
    }

    public override void Exit()
    {
        enemy.anim.SetBool(animBoolName, false);
    }

    public override void PhysicsTick()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        
    }
}
