using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Enemy Attacker { get; private set; }

    private void Start()
    {
        Attacker = GetComponentInParent<Enemy>();
    }

    public void FinishAttack()
    {
        Attacker.FinishAttack();
    }
}
