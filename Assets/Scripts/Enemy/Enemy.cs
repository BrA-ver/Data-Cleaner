using UnityEngine.AI;
using UnityEngine;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected Animator anim;
    protected bool moving = false;

    [SerializeField] protected float attackDistance;
    protected bool attacking = false;
    [SerializeField] protected Transform target;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        agent.stoppingDistance = attackDistance;
    }

    protected virtual void Update()
    {
        Movement();
        UpdateAnim();
    }

    protected virtual void Movement()
    {

    }

    protected virtual void Attack()
    {
        if (attacking) { return; }
        attacking = true;
        anim.SetTrigger("attack");
    }

    public void FinishAttack()
    {
        attacking = false;
    }

    protected virtual void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    protected virtual void UpdateAnim()
    {
        anim.SetBool("moving", moving);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

}
