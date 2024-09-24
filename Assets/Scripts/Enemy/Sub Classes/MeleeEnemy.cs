using UnityEngine.AI;
using UnityEngine;

namespace Testing
{
    public class MeleeEnemy : Enemy
    {
        public float pathUpdateDelay = 0.2f;
        float pathUpdateDeadline;

        public override void Movement()
        {
            base.Movement();
            UpdatePath();
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