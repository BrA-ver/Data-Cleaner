using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvents : MonoBehaviour
{
    [SerializeField] private PlayerAttack attack;
    [SerializeField] PlayerHealth playerHealth;

    private void OnEnable()
    {
        FinishAttack();
    }

    public void FinishAttack()
    {
        attack.FinishAttack();
    }

    public void SpawnBullet()
    {
        attack.SpawnBullet();
    }
}
