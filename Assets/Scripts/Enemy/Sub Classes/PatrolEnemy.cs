using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : Enemy
{
    public PatrolIdleState IdleState { get; private set; }
    public PatrolMoveState MoveState { get; private set; }
    public PatrolChaseState ChaseState { get; private set; }
    public PatrolAttackState AttackState { get; private set; }

    [SerializeField] Transform patrolRoute;
    List<Transform> points = new List<Transform>();
    public int currentPoint;

    [SerializeField] public float waitTime { get; private set; } = .5f;

    protected override void Awake()
    {
        base.Awake();
        GetPatrolRoute();

        IdleState = new PatrolIdleState(this, StateMachine, "idle");
        MoveState = new PatrolMoveState(this, StateMachine, "move");
        ChaseState = new PatrolChaseState(this, StateMachine, "move");
        AttackState = new PatrolAttackState(this, StateMachine, "idle");
    }

    private void Start()
    {
        StateMachine.SwitchState(IdleState);
    }

    void GetPatrolRoute()
    {
        patrolRoute.parent = null;
        foreach (Transform point in patrolRoute)
        {
            points.Add(point);
        }
        //Debug.Log("Points " + points.Count);
    }

    public void IncrementPoint()
    {
        currentPoint++;
        if (currentPoint >= points.Count)
        {
            currentPoint = 0;
        }
        
    }

    public void Route()
    {
        agent.SetDestination(points[currentPoint].position);
    }
}
