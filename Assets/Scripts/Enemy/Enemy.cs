using UnityEngine.AI;
using UnityEngine;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    private float attackDistance;

    [SerializeField] Transform target;
    public float pathUpdateDelay = 0.2f;
    float pathUpdateDeadline;

    Animator anim;
    bool attacking;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        attackDistance = agent.stoppingDistance;
    }

    private void Update()
    {
        print("Stopped: " + agent.isStopped);
        if (target != null)
        {
            bool inRange = Vector3.Distance(transform.position, target.position) <= attackDistance;

            if (inRange)
            {
                anim.SetBool("isIdle", true);
                LookAtTarget();
                Attack();
            }
            else
            {
                UpdatePath();
                anim.SetBool("isIdle", false);
            }
        }

        
    }

    private void Attack()
    {
        if (attacking) { return; }
        attacking = true;
        anim.SetTrigger("attack");
    }

    private void UpdatePath()
    {
        if (Time.time >= pathUpdateDeadline)
        {
            Debug.Log("Updating Path");
            pathUpdateDeadline = Time.time + pathUpdateDelay;
            agent.SetDestination(target.position);
        }
    }

    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    public void FinishAttack()
    {
        attacking = false;
    }
}
