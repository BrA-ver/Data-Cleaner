using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Testing
{
    public class Attack : MonoBehaviour
    {
        public Enemy Attacker { get; private set; }

        private void Start()
        {
            Attacker = GetComponentInParent<Enemy>();
        }

        public void FinishAttack()
        {
            Debug.Log("Finish");
            Attacker.FinishAttack();
        }
    }
}