using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent { get; private set; }
    public Animator Anim { get; protected set; }
    public EnemyStateMachine StateMachine { get; private set; }
    public PlayerDetector PlayerDetector { get; private set; }


    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        StateMachine = new EnemyStateMachine();
        Anim = GetComponentInChildren<Animator>();
        PlayerDetector = GetComponentInChildren<PlayerDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.currentState?.Tick(Time.deltaTime);
    }

    public void SetDestination(Vector3 newDestination)
    {
        agent.SetDestination(newDestination);
    }

    public bool ReachedPoint()
    {
        return Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance;
    }
}
