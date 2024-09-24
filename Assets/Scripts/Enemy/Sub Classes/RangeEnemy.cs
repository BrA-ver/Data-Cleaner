using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Testing
{
    public class RangeEnemy : Enemy
    {
        public float pathUpdateDelay = 0.2f;
        float pathUpdateDeadline;
        bool canShoot = true;

        EnemyShooter shooter;

        protected override void Start()
        {
            base.Start();
            shooter = GetComponentInChildren<EnemyShooter>();
        }

        protected override void Update()
        {
            base.Update();

        }

        public override void Movement()
        {
            base.Movement();
            UpdatePath();
        }

        public override void Attack()
        {
            if (attacking || attackCounter < attackCooldown) { return; }
            attacking = true;
            attackCounter = 0f;
            
            shooter.Attack();
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
    }
}