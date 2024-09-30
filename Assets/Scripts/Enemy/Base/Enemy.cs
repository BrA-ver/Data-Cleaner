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

    public float attackCooldown = 2f;
    protected float attackCounter;
    protected bool canAttack;


    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        StateMachine = new EnemyStateMachine();
        Anim = GetComponentInChildren<Animator>();
        PlayerDetector = GetComponentInChildren<PlayerDetector>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        StateMachine.currentState?.Tick(Time.deltaTime);
        if (attackCounter > 0f)
        {
            attackCounter -= Time.deltaTime;
        }

        canAttack = attackCounter <= 0f;
    }

    public void SetDestination(Vector3 newDestination)
    {
        agent.SetDestination(newDestination);
    }

    public bool ReachedPoint()
    {
        return Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance;
    }

    public virtual void Attack()
    {
        if (!canAttack) { return; }
        attackCounter = attackCooldown;
        Anim.SetTrigger("attack");
    }

    public void LookAtTarget(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;
        dir.y = 0f;
        Quaternion rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }
}
