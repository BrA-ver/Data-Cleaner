using UnityEngine.AI;
using UnityEngine;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    // Agent allows enemy to move 
    protected NavMeshAgent agent;

    // Enemies will use the same animation tree so I animate them in the base class
    public Animator anim;
    protected bool moving = false;

    [SerializeField] public float attackDistance;
    protected bool attacking = false;
    [SerializeField] public Transform target;

    public float attackCooldown = 1.5f;
    protected float attackCounter;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        agent.stoppingDistance = attackDistance;
    }

    protected virtual void Start() { }

    protected virtual void Update()
    {
        if (attackCounter <= attackCooldown)
        {
            attackCounter += Time.deltaTime;
        }
    }

    // Allowing the enemies to move in different ways 
    public virtual void Movement(){}

    // Call the enemy's attack animation
    public virtual void Attack()
    {
        if (attacking || attackCounter < attackCooldown) { return; }
        attacking = true;
        attackCounter = 0f;
        anim.SetTrigger("attack");
    }

    public void FinishAttack()
    {
        attacking = false;
        //anim.SetBool("attack", false);
    }

    public virtual void LookAtTarget()
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

    public bool InTargetRange()
    {
        bool inRange = Vector3.Distance(transform.position, target.position) <= attackDistance;
        return inRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

}
